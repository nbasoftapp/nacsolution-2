//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace nacsolution.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NBA_Entry_Points
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NBA_Entry_Points()
        {
            this.NBA_Agwy = new HashSet<NBA_Agwy>();
        }
    
        public int ENTRY_ID { get; set; }
        public string description { get; set; }
        public string x_cordinates { get; set; }
        public string y_cordinates { get; set; }
        public Nullable<int> ID { get; set; }
    
        public virtual NBA_PR NBA_PR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NBA_Agwy> NBA_Agwy { get; set; }
    }
}
