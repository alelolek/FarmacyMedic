using AutoMapper;
using FarmacyMedic.Models;
using FarmacyMedic.Models.DAO.Entities;
using FarmacyMedic.Models.DTO;
using FarmacyMedic.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            var invoice = await _context.Invoices
                .FirstOrDefaultAsync(i=>i.Id == id);
            var invoiceDto = mapper.Map<InvoiceDto>(invoice);
            if(invoiceDto == null)
            {
                return NotFound();
            }
            return View(invoiceDto);
        }

        public async Task<IActionResult> Create()
        {
            var orders = await _context.Orders
                .Include(o => o.OrderProduct)
                .ThenInclude(op => op.Product)
                .Include(o => o.Client)
                .ToListAsync();

            ViewBag.Orders = new SelectList(orders, "Id", "Id");

            var currentOrder = orders.FirstOrDefault();

            decimal totalAmount = currentOrder?.OrderProduct.Sum(op => op.Product.Price ) ?? 0;
            //decimal totalAmount = currentOrder?.OrderProduct.Sum(op => op.Product.Price * op.Quantity) ?? 0;


            var invoiceCreacionDto = new InvoiceCreacionDto
            {
                OrderId = currentOrder?.Id ?? 0,
                Date = DateTime.Now,
                TotalAmount = totalAmount,
                State = InvoiceState.Done
            };

            return View(invoiceCreacionDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InvoiceCreacionDto invoiceCreacionDto)
        {
			if (ModelState.IsValid)
			{
				var invoice = mapper.Map<Invoice>(invoiceCreacionDto);
                _context.Add(invoice);
                await _context.SaveChangesAsync();
            }

			var orders = await _context.Orders
				.Include(o => o.OrderProduct) 
				.ThenInclude(op => op.Product) 
                .ToListAsync();

			ViewBag.Orders = new SelectList(orders, "Id", "DateCreation");
			return View(invoiceCreacionDto);
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
