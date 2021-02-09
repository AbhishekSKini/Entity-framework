using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotnetMVC.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetMVC.Controllers
{
    [ApiController]
    [Route("state")]
    public class GenderController : ControllerBase
    {
        private readonly DotNetMVCDbContext _dbContext;
        private readonly DbSet<state> tableReference;
        public GenderController(DotNetMVCDbContext dbContext)
        {
            _dbContext = dbContext;
            tableReference = _dbContext.Set<state>();
        }

        [HttpPost]
        public IActionResult Save(state entity)
        {
            entity.CreatedDate = DateTime.Now;
            tableReference.Add(entity);
            _dbContext.SaveChanges();
            return this.Ok(entity);

        }
        [HttpGet]
        public IActionResult Get()
        {
            var states = tableReference.Take(100).ToList();
            ///tableReference.Where(x=>x.CountryCode=="IND");
            return this.Ok(states);
        }
    }
}
