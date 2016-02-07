﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IYCDashboard.Models.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IYCEntities : DbContext
    {
        public IYCEntities()
            : base("name=IYCEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BloodRequest> BloodRequests { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<DirectoryCategory> DirectoryCategories { get; set; }
        public virtual DbSet<ItemPicture> ItemPictures { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UserFaviourateBloodRequest> UserFaviourateBloodRequests { get; set; }
        public virtual DbSet<UserFaviourateItem> UserFaviourateItems { get; set; }
        public virtual DbSet<UserPreference> UserPreferences { get; set; }
        public virtual DbSet<UserRegistration> UserRegistrations { get; set; }
        public virtual DbSet<AdminLogin> AdminLogins { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<UserDevice> UserDevices { get; set; }
        public virtual DbSet<Directory> Directories { get; set; }
    }
}
