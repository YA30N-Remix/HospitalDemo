//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hospital.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCustomerBuyList
    {
        public decimal CustomerBuyListID { get; set; }
        public int CustomerBuyID { get; set; }
        public int CarpetID { get; set; }
        public int Count { get; set; }
        public double Shur { get; set; }
        public double Darkesh { get; set; }
        public double Gayegh { get; set; }
        public double Shiraze { get; set; }
        public double Charm { get; set; }
        public double Hasiri { get; set; }
        public double Geytani { get; set; }
        public double Pardakht { get; set; }
        public decimal ShurPrice { get; set; }
        public decimal DarkeshPrice { get; set; }
        public decimal GayeghPrice { get; set; }
        public decimal ShirazePrice { get; set; }
        public decimal CharmPrice { get; set; }
        public decimal HasiriPrice { get; set; }
        public decimal GeytaniPrice { get; set; }
        public decimal PardakhtPrice { get; set; }
        public decimal SumPrice { get; set; }
        public decimal Discount { get; set; }
        public short FactorStatus { get; set; }
        public string FactorDate { get; set; }
        public string Description { get; set; }
        public string RegisterDate { get; set; }
    
        public virtual tblCustomerBuy tblCustomerBuy { get; set; }
    }
}
