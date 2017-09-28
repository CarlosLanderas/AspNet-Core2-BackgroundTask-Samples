﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreIHostedService.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using AspNetCoreIHostedService.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreIHostedService.Controllers
{
    [Route("api/weather")]
    public class WeatherController: Controller
    {
        private readonly WeatherDbContext _weatherDbContext;

        public WeatherController(WeatherDbContext weatherDbContext)
        {
            _weatherDbContext = weatherDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var weatherData = await _weatherDbContext.WeatherData.
                OrderByDescending(w => w.Id).ToListAsync();
            return Ok(weatherData);
        }
    }
}
