//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLPXetNghiemYTe.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            this.HoSoXNBNs = new HashSet<HoSoXNBN>();
        }
    
        public int ID { get; set; }
        public string HoTen { get; set; }
        public System.DateTime SN { get; set; }
        public string SDT { get; set; }
        public int PhongBanID { get; set; }
        public int ChucVuID { get; set; }
    
        public virtual ChucVu ChucVu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoSoXNBN> HoSoXNBNs { get; set; }
        public virtual PhongBan PhongBan { get; set; }
    }
}
