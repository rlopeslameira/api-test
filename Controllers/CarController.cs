using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;
using api.Data;

namespace api.Controllers
{

    [ApiController]
    [Route("cars")]
    public class CarController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Car>>> Get([FromServices] DataContext context)
        {
            var cars = await context.Cars.ToListAsync();
            return cars;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<List<Car>>> Post([FromServices] DataContext context, [FromBody] List<Car> model)
        {
            foreach(Car car in model)
            {
                context.Cars.Add(car);
                await context.SaveChangesAsync();
            }
            
            return model;
        }
    }
}
