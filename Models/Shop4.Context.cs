﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EcommersShop.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ShopDbEntities4 : DbContext
    {
        public ShopDbEntities4()
            : base("name=ShopDbEntities4")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<DetailsProduct> DetailsProducts { get; set; }
        public virtual DbSet<LatestProduct> LatestProducts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<TopProduct> TopProducts { get; set; }
    }
}
