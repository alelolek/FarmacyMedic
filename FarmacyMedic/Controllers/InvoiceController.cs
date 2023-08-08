using AutoMapper;
using FarmacyMedic.Migrations;
using FarmacyMedic.Models;
using FarmacyMedic.Models.DAO.Entities;
using FarmacyMedic.Models.DTO;
using FarmacyMedic.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;

namespace FarmacyMedic.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly FarmacyDbContext _context;
        private readonly IMapper mapper;

        public InvoiceController(FarmacyDbContext context,IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var invoice = await _context.Invoices.ToListAsync();
                var invoiceDto = mapper.Map<List<InvoiceDto>>(invoice);
                return View(invoiceDto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || _context.Invoices == null)
            {
                return NotFound();
            }

            var invoice = _context.Invoices
                      .Include(i => i.Order)
                          .ThenInclude(o => o.ProductDetail)
                              .ThenInclude(pd => pd.Product)
                      .Include(i => i.Order)
                          .ThenInclude(o => o.Client)
                      .FirstOrDefault(f => f.Id == id);

            //var invoiceDto = mapper.Map<InvoiceDto>(invoice);
            //if(invoiceDto == null)
            //{
            //    return NotFound();
            //}
            return View(invoice);
        }


        public async Task<IActionResult> Create()
        {
            var orders = await _context.Orders.Include(o => o.Client).ToListAsync();
            var ordersSelectList = orders.Select(o => new SelectListItem { Value = o.Id.ToString(), Text = $"{o.Client.Name} - Order ID: {o.Id}" }).ToList();
            ViewBag.Orders = ordersSelectList;

            ViewBag.OrderDetails = orders.FirstOrDefault()?.ProductDetail;

            return View();
        }

        public async Task<IActionResult> GetOrderDetails(int orderId)
        {
            var order = await _context.Orders
               .Include(o => o.ProductDetail)
                   .ThenInclude(pd => pd.Product) 
               .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                return NotFound();
            }

            return PartialView("_OrderDetailsPartial", order);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InvoiceCreacionDto invoiceCreacionDto)
        {
            if (!ModelState.IsValid)
            {
                var orders = await _context.Orders.Include(o => o.Client).ToListAsync();
                var ordersSelectList = orders.Select(o => new SelectListItem { Value = o.Id.ToString(), Text = $"{o.Client.Name} - Order ID: {o.Id}" }).ToList();
                ViewBag.Orders = ordersSelectList;

                ViewBag.OrderDetails = orders.FirstOrDefault()?.ProductDetail;

                return View(invoiceCreacionDto);
            }

            var invoice = mapper.Map<Invoice>(invoiceCreacionDto);
            _context.Add(invoice);
            await _context.SaveChangesAsync();

           
            return RedirectToAction("Index");
        }


		public IActionResult ImprimirVenta(int id)
		{
			var modelo = _context.Invoices
	                 .Include(i => i.Order)
		                 .ThenInclude(o => o.ProductDetail)
			                 .ThenInclude(pd => pd.Product)
	                 .Include(i => i.Order)
		                 .ThenInclude(o => o.Client)
	                 .FirstOrDefault(f => f.Id == id);

			return new ViewAsPdf("ImprimirVenta", modelo)
            {
                FileName = $"Venta {modelo.Id}.pdf",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
				PageSize = Rotativa.AspNetCore.Options.Size.A4
			};
		}

		

		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Invoices == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            var invoiceDto = mapper.Map<InvoiceDto>(invoice);

            return View(invoiceDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(InvoiceCreacionDto invoiceCreacionDto, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var invoice = mapper.Map<Product>(invoiceCreacionDto);
                    invoice.Id = id;
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }

            return View(invoiceCreacionDto);
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Invoices == null)
            {
                return NotFound();
            }

            var invoices = await _context.Invoices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoices == null)
            {
                return NotFound();
            }

            return View(invoices);
        }
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Invoices == null)
            {
                return Problem("Entity set 'AgendaContext.Clientes'  is null.");
            }
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);

            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
