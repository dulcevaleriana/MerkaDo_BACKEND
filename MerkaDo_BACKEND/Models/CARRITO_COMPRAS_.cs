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
    
    public partial class CARRITO_COMPRAS_
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CARRITO_COMPRAS_()
        {
            this.COMPRA__ = new HashSet<COMPRA__>();
            this.FACTURAs = new HashSet<FACTURA>();
            this.HISTORIAL_COMPRA_ = new HashSet<HISTORIAL_COMPRA_>();
            this.LISTADO_PAQUETE_COMPRA_ = new HashSet<LISTADO_PAQUETE_COMPRA_>();
        }
    
        public int carritoComprasId { get; set; }
        public int listaProductosId { get; set; }
        public decimal totalPago { get; set; }
    
        public virtual LISTA_PRODUCTO_ LISTA_PRODUCTO_ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMPRA__> COMPRA__ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FACTURA> FACTURAs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORIAL_COMPRA_> HISTORIAL_COMPRA_ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LISTADO_PAQUETE_COMPRA_> LISTADO_PAQUETE_COMPRA_ { get; set; }
    }
}
