﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebDesign.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EntityModelContainer : DbContext
    {
        public EntityModelContainer()
            : base("name=EntityModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Patient> PatientSet { get; set; }
        public virtual DbSet<Doctor> DoctorSet { get; set; }
        public virtual DbSet<Appointment> AppointmentSet { get; set; }
        public virtual DbSet<Rate> RateSet { get; set; }
    }
}