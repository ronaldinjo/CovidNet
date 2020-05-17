using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CovidNet.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
   
        public string PatientName { get; set; }
        public bool isCorona { get; set; }   
        public string Status { get; set; }
        public State State { get; set; }
        public DateTimeOffset DateRegistered { get; set; }

        public int StateId { get; set; }
    }
}
