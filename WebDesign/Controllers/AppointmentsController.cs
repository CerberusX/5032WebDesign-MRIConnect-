using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebDesign.Models;
using WebDesign.ViewModels;

namespace WebDesign.Controllers
{
    public class AppointmentsController : Controller
    {
        private EntityModelContainer db = new EntityModelContainer();

        // GET: Appointments
        public ActionResult Index()
        {
            var appointmentSet = db.AppointmentSet.Include(a => a.Patient).Include(a => a.Doctor);
            return View(appointmentSet.ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.AppointmentSet.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            // 初始化ViewModel
            var viewModel = new AppointmentViewModel();

            // 初始化Appointment并设置默认值
            viewModel.Appointment = new Appointment
            {
                DateTime = DateTime.Now,
                Time = DateTime.Now.ToString() // 这里直接设置为DateTime类型，而不是转化为字符串
            };

            // 其它的代码，例如为下拉列表填充数据等...
            ViewBag.PatientId = new SelectList(db.PatientSet, "Id", "FirstName");
            ViewBag.DoctorId = new SelectList(db.DoctorSet, "Id", "FirstName");

            // 将viewModel传递给视图
            return View(viewModel);
        }


        // POST: Appointments/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppointmentViewModel viewModel, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {
                string filePath = viewModel.UploadFilepath;
                viewModel.Appointment.Rate = new Rate();
                viewModel.Appointment.Rate.RateStar = 5;
                int doctorId = viewModel.Appointment.DoctorId;
                string doctoruserid = db.DoctorSet.Where(s => s.Id == doctorId).FirstOrDefault().UserID;
                viewModel.Appointment.Rate.DoctorID = db.DoctorSet.Where(s => s.UserID == doctoruserid).FirstOrDefault().UserID;
                db.AppointmentSet.Add(viewModel.Appointment);
                db.SaveChanges();
                var path = "";

                // Save the uploaded file
                //if (file != null)
                //{
                    
                    //path = Path.Combine(Server.MapPath("~/uploads"), filePath);
                    //file.SaveAs(path);
                    // Send confirmation email
                    var mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("HuangYHMonash@outlook.com");
                    mailMessage.To.Add(new MailAddress(viewModel.Email));
                    mailMessage.Subject = "Appointment Confirmation";
                    mailMessage.Body = "Your appointment has been confirmed for " + viewModel.Appointment.DateTime;
                //var attachment = new Attachment(path);
                //mailMessage.Attachments.Add(attachment);
                    mailMessage.IsBodyHtml = false;
                    var smtp = new SmtpClient();
                    smtp.Host = "smtp.office365.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new System.Net.NetworkCredential
                    ("HuangYHMonash@outlook.com", "hyh990723");
                    smtp.Send(mailMessage);

                //}

                return RedirectToAction("Index");
            }

            ViewBag.PatientId = new SelectList(db.PatientSet, "Id", "FirstName", viewModel.Appointment.PatientId);
            ViewBag.DoctorId = new SelectList(db.DoctorSet, "Id", "FirstName", viewModel.Appointment.DoctorId);
            return View(viewModel);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.AppointmentSet.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientId = new SelectList(db.PatientSet, "Id", "FirstName", appointment.PatientId);
            ViewBag.DoctorId = new SelectList(db.DoctorSet, "Id", "FirstName", appointment.DoctorId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateTime,Time,PatientId,DoctorId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientId = new SelectList(db.PatientSet, "Id", "FirstName", appointment.PatientId);
            ViewBag.DoctorId = new SelectList(db.DoctorSet, "Id", "FirstName", appointment.DoctorId);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.AppointmentSet.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // 基于AppointmentId找到相关的Rate
            Rate rate = db.RateSet.FirstOrDefault(r => r.Appointment.Id == id);

            if (rate != null)
            {
                // 删除Rate
                db.RateSet.Remove(rate);
            }

            // 然后删除Appointment
            Appointment appointment = db.AppointmentSet.Find(id);
            db.AppointmentSet.Remove(appointment);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
