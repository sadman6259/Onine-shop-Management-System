//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class LatestProduct
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string ProductCode { get; set; }
        public System.DateTime AddedDate { get; set; }
        public Nullable<int> AvailableQuantity { get; set; }
        public Nullable<double> ProductReview { get; set; }
    }
}