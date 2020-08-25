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


        [HttpGet("quote")]
        public async Task<IActionResult> GetQuote()
        {
            var quote = await _dataContext.tblQuotes.FirstOrDefaultAsync(); //TO DO: apply quote filter here 
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
                _dataContext.tblQuotes.Update(q);
            }
            else
            { //add
                _dataContext.tblQuotes.Add(quote); //new quote
            }
            await _dataContext.SaveChangesAsync();

            return Ok();
        }
        
    }
}
