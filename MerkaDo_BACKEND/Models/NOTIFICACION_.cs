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
    
    public partial class NOTIFICACION_
    {
        public int notificacionId { get; set; }
        public int rolId { get; set; }
        public int tipoNotificacionId { get; set; }
        public int usuarioReceptorId { get; set; }
        public string mensajeNotificacion { get; set; }
        public System.DateTime fechaNotificacion { get; set; }
    
        public virtual ROL_USUARIO ROL_USUARIO { get; set; }
        public virtual TIPO_NOTIFICACION_ TIPO_NOTIFICACION_ { get; set; }
        public virtual USUARIO__ USUARIO__ { get; set; }
    }
}
