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
    
    public partial class USUARIO__
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO__()
        {
            this.COMENTARIOs = new HashSet<COMENTARIO>();
            this.DESCUENTOS_ = new HashSet<DESCUENTOS_>();
            this.ENTREGAS_ = new HashSet<ENTREGAS_>();
            this.ENTREGAS_1 = new HashSet<ENTREGAS_>();
            this.HISTORIAL_COMPRA_ = new HashSet<HISTORIAL_COMPRA_>();
            this.LISTADO_PAQUETE_COMPRA_ = new HashSet<LISTADO_PAQUETE_COMPRA_>();
            this.LOG_ACTION__ = new HashSet<LOG_ACTION__>();
            this.MENSAJE__ = new HashSet<MENSAJE__>();
            this.NOTIFICACION_ = new HashSet<NOTIFICACION_>();
            this.SALA_USUARIO__ = new HashSet<SALA_USUARIO__>();
            this.STATUS_COMPRA_ = new HashSet<STATUS_COMPRA_>();
            this.STATUS_COMPRA_1 = new HashSet<STATUS_COMPRA_>();
            this.TARJETA_CREDITO_ = new HashSet<TARJETA_CREDITO_>();
            this.TARJETA_MEMBRESIA_ = new HashSet<TARJETA_MEMBRESIA_>();
            this.TARJETA_REGALO_ = new HashSet<TARJETA_REGALO_>();
        }
    
        public int usuarioId { get; set; }
        public string nombreUsuario { get; set; }
        public string apellidoUsuario { get; set; }
        public string imagenUsuario { get; set; }
        public int cedulaUsuario { get; set; }
        public int generoId { get; set; }
        public string correoCorporativoUsuario { get; set; }
        public int TtelefonoUsuario { get; set; }
        public int sucursalId { get; set; }
        public int rolId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMENTARIO> COMENTARIOs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DESCUENTOS_> DESCUENTOS_ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ENTREGAS_> ENTREGAS_ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ENTREGAS_> ENTREGAS_1 { get; set; }
        public virtual GENERO GENERO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORIAL_COMPRA_> HISTORIAL_COMPRA_ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LISTADO_PAQUETE_COMPRA_> LISTADO_PAQUETE_COMPRA_ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOG_ACTION__> LOG_ACTION__ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MENSAJE__> MENSAJE__ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTIFICACION_> NOTIFICACION_ { get; set; }
        public virtual ROL_USUARIO ROL_USUARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SALA_USUARIO__> SALA_USUARIO__ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STATUS_COMPRA_> STATUS_COMPRA_ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STATUS_COMPRA_> STATUS_COMPRA_1 { get; set; }
        public virtual SUCURSAL_ SUCURSAL_ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TARJETA_CREDITO_> TARJETA_CREDITO_ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TARJETA_MEMBRESIA_> TARJETA_MEMBRESIA_ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TARJETA_REGALO_> TARJETA_REGALO_ { get; set; }
    }
}
