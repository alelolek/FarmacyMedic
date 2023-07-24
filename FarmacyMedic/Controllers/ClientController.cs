using AutoMapper;
using FarmacyMedic.Models;
using FarmacyMedic.Models.DAO.Entities;
using FarmacyMedic.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarmacyMedic.Controllers
{
    public class ClientController : Controller
    {
        private readonly FarmacyDbContext context;
        private readonly IMapper mapper;

        public ClientController(FarmacyDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var clients = await context.Clients.ToListAsync();
                var clienteDto = mapper.Map<List<ClientDto>>(clients);
                return View(clienteDto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || context.Clients == null)
            {
                return NotFound();
            }
            var clients = await context.Clients.FirstOrDefaultAsync(m=>m.Id==id);
            var clientDto = mapper.Map<ClientDto>(clients);
            if(clientDto == null)
            {
                return NotFound();
            }
            return View(clientDto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientCreationDto clientCreationDto)
        {
            if(ModelState.IsValid)
            {
                var client = mapper.Map<Client>(clientCreationDto);
                if(client == null)
                {
                    return NotFound();
                }
                context.Add(client);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientCreationDto);
        }

        public async Task<IActionResult> Edit(int? id) 
        {
            if (id == null || context.Clients == null)
            {
                return NotFound();
            }

            var client = await context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            var clientDto = mapper.Map<ClientDto>(client);

            return View(clientDto);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ClientCreationDto clientCreationDto,int id)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var client = mapper.Map<Client>(clientCreationDto);
                    client.Id = id;
                    context.Update(client);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(clientCreationDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if(id == null || context.Clients ==null)
            {
                return NotFound();
            }
            var client = await context.Clients.FirstOrDefaultAsync(m=>m.Id==id);
            if( client == null )
            {
                return NotFound();
            }
            return View(client);
        }

        public async Task<IActionResult> Deleteconfirmed(int id)
        {
            if(context.Clients == null)
            {
                return Problem("");
            }
            var client = await context.Clients.FindAsync(id);
            if( client != null )
            {
                context.Clients.Remove(client);
            }
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
