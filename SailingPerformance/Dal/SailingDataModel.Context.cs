﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dal
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SailingDbContext : DbContext
    {
        public SailingDbContext()
            : base("name=SailingDbContext")
        {
          //  Database.Connection.ConnectionString= "data source=H-PEREVERZIEVA2;initial catalog=SailingManagerDB;Integrated Security=True;Connect Timeout=35;Encrypt=False;TrustServerCertificate=False";
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Boat> Boats { get; set; }
        public virtual DbSet<GPSData> GPSDatas { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
