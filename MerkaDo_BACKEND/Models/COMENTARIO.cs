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
    
    public partial class COMENTARIO
    {
        public int comentarioId { get; set; }
        public int usuarioId { get; set; }
        public int productoId { get; set; }
        public short estrellaComentario { get; set; }
        public string mensajeComentario { get; set; }
    
        public virtual PRODUCTO__ PRODUCTO__ { get; set; }
        public virtual USUARIO__ USUARIO__ { get; set; }
    }
}
