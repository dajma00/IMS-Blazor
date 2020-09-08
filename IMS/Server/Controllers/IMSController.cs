using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IMS.Server.DataAccess.IMS.Server.DataAccess;
using IMS.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace IMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IMSController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public IMSController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        [HttpGet]
        //following two methods can be used: First one is from sample created by MS
        //that has the WeatherForecastController

        //public IEnumerable<TitlesTable> Get()
        //{
        //    var data = _dataContext.tblTitles.ToList();
        //    return data;
        //}

        //This is the second method, shown in the tutorial (see notes.txt for tutorial link)
        public async Task<IActionResult> Get()
        {
            
                var titles = await _dataContext.tblTitles.ToListAsync();
                return Ok(titles);
            
        }

        [HttpGet("vehicles/{quoteid}")]
        
        public async Task<IActionResult> GetVehicles(int quoteid)
        {

            var vehicles = await _dataContext.tblVehicles.ToListAsync();
            if (vehicles == null)
            {
                var v = new Vehicle();
                vehicles[0] = v; //add a null vehicle for json result only.
            }
            return Ok(vehicles);

        }

        //given a quote id, return the quote
        [HttpGet("quote/{quoteid}")]
        public async Task<IActionResult> GetQuote(string quoteid)
        {
            int QuoteID = int.Parse(quoteid);
            var quote = await _dataContext.tblQuotes //TO DO: apply quote filter here
                                .Where(x => x.ID == QuoteID)
                                .SingleOrDefaultAsync();
                               
            if (quote == null)
                quote = new Quote();
            return Ok(quote);
        }

        [HttpGet("quotes")]
        public async Task<IActionResult> GetQuotes()
        {
            var quotes = await _dataContext.tblQuotes.ToListAsync();
            return Ok(quotes);
        }
        
        [HttpPost("PostSaveChanges")]
        public async Task<IActionResult> PostSaveChanges(Quote quote)
        {
            Quote q = _dataContext.tblQuotes.FirstOrDefault(e => e.ID == quote.ID);
            if (q != null)
            {
                //found quote, just update it with new data
                q.TitleCode = quote.TitleCode;
                q.ClientName = quote.ClientName;
                _dataContext.tblQuotes.Update(q);
            }
            else
            { //add
                _dataContext.tblQuotes.Add(quote); //new quote
            }
            await _dataContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("PostAddVehicle")]
        public async Task<IActionResult> PostAddVehicle(Vehicle v)
        {

            //add
            
                _dataContext.tblVehicles.Add(v); //new quote
            
            await _dataContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("PostDeleteVehicle")]
        public async Task<IActionResult> PostDeleteVehicle(Vehicle v)
        {

            //add
            _dataContext.tblVehicles.Remove(v); //new quote

            await _dataContext.SaveChangesAsync();

            return Ok();
        }

    }
}
