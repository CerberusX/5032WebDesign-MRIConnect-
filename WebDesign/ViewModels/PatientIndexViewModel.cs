using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDesign.Models;

namespace WebDesign.ViewModels
{
    public class PatientIndexViewModel
    {
        public IEnumerable<Patient> Patients { get; set; }
        public string UserName { get; set; }
    }

}