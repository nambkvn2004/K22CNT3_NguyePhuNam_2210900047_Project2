//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace K22CNT3_NguyenPhuNam_Project2_2210900047.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CT_HOA_DON
    {
        public int MaHD { get; set; }
        public int MaSPCT { get; set; }
        public int So_luong_ban { get; set; }
        public double Gia_ban { get; set; }
        public Nullable<int> Tra_lai { get; set; }
    
        public virtual HOA_DON HOA_DON { get; set; }
        public virtual SAN_PHAM_CT SAN_PHAM_CT { get; set; }
    }
}
