using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;
using api.Data;
using Microsoft.AspNetCore.Http;

namespace api.Controllers
{

    [ApiController]
    [Route("clients")]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Client>>> Get([FromServices] DataContext context)
        {
            var clients = await context.Clients.Include(p => p.Cars).ToListAsync();            
            return clients;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Client>> Post([FromServices] DataContext context, [FromBody] Client model)
        {
            context.Clients.Add(model);
            await context.SaveChangesAsync();
            return model;
        }

        [HttpDelete]
        [Route("")]
        public async Task<ActionResult<Client>> Delete([FromServices] DataContext context, [FromBody] Client model)
        {
            Client client = context.Clients.Single(c => c.ClientId == model.ClientId);

            var cars = context.Cars.Where(c => c.ClientId == model.ClientId);
            
            foreach(Car car in cars)
            {
                context.Cars.Remove(car);
            }
            
            context.Clients.Remove(client);
            await context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "Removido com sucesso.");
        }
    }
}
