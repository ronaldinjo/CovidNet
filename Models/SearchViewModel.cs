using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidNet.Models.ViewModel
{
    public class SearchViewModel
    {
        public List<Patient> Patients { get; set; }
        public SelectList States { get; set; }
        public string PatientState { get; set; }
        public string SearchString { get; set; }
    }
}
