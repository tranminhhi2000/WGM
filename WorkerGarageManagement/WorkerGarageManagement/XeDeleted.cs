//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorkerGarageManagement
{
    using System;
    using System.Collections.Generic;
    
    public partial class XeDeleted
    {
        public string Name { get; set; }
        public string License_Plates { get; set; }
        public int Manufacture { get; set; }
        public System.DateTime Time_Parking { get; set; }
    
        public virtual HangXe HangXe { get; set; }
    }
}