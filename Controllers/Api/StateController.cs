using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CovidNet.Data;
using CovidNet.Models;
using CovidNet.Models.SyncfusionViewModels;
using Microsoft.AspNetCore.Authorization;

namespace CovidNet.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/state")]
    public class StateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StateController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/state
        [HttpGet]
        public async Task<IActionResult> Getstate()
        {
            List<State> Items = await _context.State.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }



        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<State> payload)
        {
            State state = payload.value;
            _context.State.Add(state);
            _context.SaveChanges();
            return Ok(state);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<State> payload)
        {
            State state = payload.value;
            _context.State.Update(state);
            _context.SaveChanges();
            return Ok(state);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<State> payload)
        {
            State state = _context.State
                .Where(x => x.StateId == (int)payload.key)
                .FirstOrDefault();
            _context.State.Remove(state);
            _context.SaveChanges();
            return Ok(state);

        }
    }
}