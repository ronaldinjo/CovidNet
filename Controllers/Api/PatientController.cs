using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CovidNet.Data;
using CovidNet.Models;
using CovidNet.Services;
using CovidNet.Models.SyncfusionViewModels;
using Microsoft.AspNetCore.Authorization;

namespace CovidNet.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Patient")]
    public partial class PatientController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INumberSequence _numberSequence;

        public PatientController(ApplicationDbContext context,
                        INumberSequence numberSequence)
        {
            _context = context;
            _numberSequence = numberSequence;
        }

        // GET: api/patient
        [HttpGet]
        public async Task<IActionResult> GetPatient()
        {
            List<Patient> Items = await _context.Patient.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

      
        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<Patient> payload)
        {
            Patient patient = payload.value;
            patient.PatientName = _numberSequence.GetNumberSequence("patient");
            _context.Patient.Add(patient);
            _context.SaveChanges();
            return Ok(patient);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<Patient> payload)
        {
            Patient patient = payload.value;
            _context.Patient.Update(patient);
            _context.SaveChanges();
            return Ok(patient);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<Patient> payload)
        {
            Patient patient = _context.Patient
                .Where(x => x.PatientId == (int)payload.key)
                .FirstOrDefault();
            _context.Patient.Remove(patient);
            _context.SaveChanges();
            return Ok(patient);

        }
    }
}