//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PMPhanLop
{
    using System;
    using System.Collections.Generic;
    
    public partial class khach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public khach()
        {
            this.chitietdoans = new HashSet<chitietdoan>();
        }
    
        public int idkhach { get; set; }
        public string hoten { get; set; }
        public string cmnd { get; set; }
        public Nullable<bool> gioitinh { get; set; }
        public string sodt { get; set; }
        public string diachi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietdoan> chitietdoans { get; set; }
    }
}