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
    
    public partial class tblPersonnelFunction
    {
        public decimal PersonnelFunctionID { get; set; }
        public int PersonnelID { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int CarpetID { get; set; }
        public double Meters { get; set; }
        public double Count { get; set; }
        public double WorkDay { get; set; }
        public string Description { get; set; }
        public short Active { get; set; }
        public string RegisterDate { get; set; }
    
        public virtual tblCarpet tblCarpet { get; set; }
        public virtual tblPersonnel tblPersonnel { get; set; }
    }
}
