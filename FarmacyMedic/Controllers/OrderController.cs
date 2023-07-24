using AutoMapper;
using FarmacyMedic.Models;
using FarmacyMedic.Models.DAO.Entities;
using FarmacyMedic.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FarmacyMedic.Controllers
{
    public class OrderController : Controller
    {
        private readonly FarmacyDbContext context;
        private readonly IMapper mapper;

        public OrderController(FarmacyDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var orders = await context.Orders.ToListAsync();
                var orderDto = mapper.Map<List<OrderDto>>(orders);
                return View(orderDto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || context.Orders == null)
            {
                return NotFound();
            }
            var orders = await context.Clients.FirstOrDefaultAsync(m => m.Id == id);
            var orderDto = mapper.Map<OrderDto>(orders);
            if (orderDto == null)
            {
                return NotFound();
            }
            return View(orderDto);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreationDto orderCreationDto)
        {
            if (ModelState.IsValid)
            {
                var order = mapper.Map<Order>(orderCreationDto);
                if (order == null)
                {
                    return NotFound();
                }
                
                context.Add(order);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderCreationDto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || context.Orders == null)
            {
                return NotFound();
            }

            var order = await context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            var orderDto = mapper.Map<OrderDto>(order);

            return View(orderDto);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(OrderCreationDto orderCreationDto, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var order = mapper.Map<Order>(orderCreationDto);
                    order.Id = id;
                    context.Update(order);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(orderCreationDto);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || context.Orders == null)
            {
                return NotFound();
            }
            var order = await context.Orders.FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        public async Task<IActionResult> Deleteconfirmed(int id)
        {
            if (context.Orders == null)
            {
                return Problem("");
            }
            var order = await context.Orders.FindAsync(id);
            if (order != null)
            {
                context.Orders.Remove(order);
            }
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
