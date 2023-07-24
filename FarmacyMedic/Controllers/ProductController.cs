using AutoMapper;
using FarmacyMedic.Models;
using FarmacyMedic.Models.DAO.Entities;
using FarmacyMedic.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarmacyMedic.Controllers
{
	public class ProductController : Controller
	{
		private readonly FarmacyDbContext _context;
		private readonly IMapper mapper;

		public ProductController(FarmacyDbContext context,IMapper mapper)
        {
			_context = context;
			this.mapper = mapper;
		}
        public async Task<IActionResult> Index()
		{
			try
			{
				var products = await _context.Products.ToListAsync();
				var productDtos = mapper.Map<List<ProductDto>>(products);
				
				return View(productDtos);
			}
			catch (Exception)
			{

				throw;
			}
		}
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Products == null)
			{
				return NotFound();
			}
			var product = await _context.Products
				.FirstOrDefaultAsync(m => m.Id == id);
			var productDtos = mapper.Map<ProductDto>(product);
			if (productDtos == null)
			{
				return NotFound();
			}
			return View(productDtos);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(ProductCreationDto productCreationDto)
		{
			
			if (ModelState.IsValid)
			{
				var product = mapper.Map<Product>(productCreationDto);
				if (product == null)
				{
					return NotFound();
				}
				_context.Add(product);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			return View(productCreationDto);
		}

		public async Task<IActionResult> Edit(int? id)
		{
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var productDto = mapper.Map<ProductDto>(product);

            return View(productDto);
        }

		[HttpPost]
		public async Task<IActionResult> Edit(ProductCreationDto productCreationDto,int id)
		{
            if (ModelState.IsValid)
            {
                try
                {
                    var product = mapper.Map<Product>(productCreationDto);
					product.Id = id;
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }

            return View(productCreationDto);
        }


		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Products == null)
			{
				return NotFound();
			}

			var product = await _context.Products
				.FirstOrDefaultAsync(m => m.Id == id);
			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Products == null)
			{
				return Problem("Entity set 'AgendaContext.Clientes'  is null.");
			}
			var producto = await _context.Products.FindAsync(id);
			if (producto != null)
			{
				_context.Products.Remove(producto);

			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

	}
}
