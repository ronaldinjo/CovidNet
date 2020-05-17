using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidNet.Data;
using CovidNet.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CovidNet.Controllers
{
    [Authorize(Roles = Pages.MainMenu.Dashboard.RoleName)]
    public class DashboardController : Controller
    {
        
     
            private readonly ApplicationDbContext _context;
            
           public DashboardController(ApplicationDbContext context)
            {
                _context = context;
            }
           
            public async Task<IActionResult> Index(string state, string searchString)
            {
                IQueryable<string> stateQuery = from m in _context.Patient
                                                orderby m.Status
                                                select m.Status;


                var patients = from m in _context.Patient select m;
                if (!string.IsNullOrEmpty(searchString))
                {
                    patients = patients.Where(s => s.PatientName.Contains(searchString));
                }

                if (!string.IsNullOrEmpty(state))
                {
                    patients = patients.Where(x => x.Status == state);
                }

                var searchVM = new SearchViewModel
                {
                    States = new SelectList(await stateQuery.Distinct().ToListAsync()),
                    Patients = await patients.ToListAsync()
                };

                return View(searchVM);

            }

            #region Dashboard Statistics
            [AllowAnonymous]
            public ActionResult TotalPatients()
            {
                var patients = _context.Patient.ToList();
                return Json(patients.Count());
            }
          



            public ActionResult TotalUsers()
            {
                var users = _context.Users.ToList();
                return Json(users.Count());
            }

            //Today's patients
            [AllowAnonymous]
            public ActionResult TodaysPatients()
            {
                DateTime today = DateTime.Now.Date;
                var patients = _context.Patient.Where(p => p.DateRegistered >= today).ToList();
                return Json(patients.Count());
            }
            //Todays appointments
       
         

            #endregion


            [AllowAnonymous]
            public ActionResult About()
            {
                ViewBag.Message = "Your application description page.";

                return View();
            }
            [AllowAnonymous]
            public ActionResult Contact()
            {
                ViewBag.Message = "Your contact page.";

                return View();
            }
        }
    }
