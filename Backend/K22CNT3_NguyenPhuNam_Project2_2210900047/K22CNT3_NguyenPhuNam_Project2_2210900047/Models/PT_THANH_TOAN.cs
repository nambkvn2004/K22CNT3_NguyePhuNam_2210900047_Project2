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
    
    public partial class PT_THANH_TOAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PT_THANH_TOAN()
        {
            this.HOA_DON = new HashSet<HOA_DON>();
        }
    
        public int MaPTTT { get; set; }
        public string Ten_PTTT { get; set; }
        public Nullable<byte> Trang_thai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOA_DON> HOA_DON { get; set; }
    }
}
