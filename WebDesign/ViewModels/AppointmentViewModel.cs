using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDesign.Models;

namespace WebDesign.ViewModels
{
    public class AppointmentViewModel
    {
        public Appointment Appointment { get; set; }
        public string Email { get; set; }
        public string UploadFilepath { get; set; }
    }

}