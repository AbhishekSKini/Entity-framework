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
    [Route("countries")]
    public class CountriesController : ControllerBase
    {
        private readonly DotNetMVCDbContext _dbContext;
        private readonly DbSet<Country> tableReference;
        public CountriesController(DotNetMVCDbContext dbContext)
        {
            _dbContext = dbContext;
            tableReference = _dbContext.Set<Country>();
        }

        [HttpPost]
        public IActionResult Save(Country entity)
        {
            entity.CreatedDate = DateTime.Now;
            tableReference.Add(entity);
            _dbContext.SaveChanges();
            return this.Ok(entity);

        }
        [HttpGet]
        public IActionResult Get()
        {
            var countries = tableReference.Take(100).ToList();
            ///tableReference.Where(x=>x.CountryCode=="IND");
            return this.Ok(countries);
        }
    }
}
