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
    
    public partial class TIPO_NOTIFICACION_
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIPO_NOTIFICACION_()
        {
            this.LOG_ACTION_CLIENTE = new HashSet<LOG_ACTION_CLIENTE>();
            this.LOG_ACTION_USUARIO = new HashSet<LOG_ACTION_USUARIO>();
            this.NOTIFICACION_ = new HashSet<NOTIFICACION_>();
        }
    
        public int tipoNotificacionId { get; set; }
        public string nombreTipoNotificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOG_ACTION_CLIENTE> LOG_ACTION_CLIENTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOG_ACTION_USUARIO> LOG_ACTION_USUARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTIFICACION_> NOTIFICACION_ { get; set; }
    }
}
