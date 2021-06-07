//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MerkaDo_BACKEND.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SUCURSAL_
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SUCURSAL_()
        {
            this.PRODUCTO__ = new HashSet<PRODUCTO__>();
            this.USUARIO__ = new HashSet<USUARIO__>();
        }
    
        public int sucursalId { get; set; }
        public string nombreSucursal { get; set; }
        public string direccionSucursal { get; set; }
        public int supermercadoId { get; set; }
        public System.DateTime horarioApertura { get; set; }
        public System.DateTime horarioCierre { get; set; }
        public bool diaFeriado { get; set; }
        public System.DateTime horarioAperturaSabado { get; set; }
        public System.DateTime horarioCierreSabado { get; set; }
        public System.DateTime horarioAperturaDomingo { get; set; }
        public System.DateTime horarioCierreDomingo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTO__> PRODUCTO__ { get; set; }
        public virtual SUPERMERCADO_ SUPERMERCADO_ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO__> USUARIO__ { get; set; }
    }
}
