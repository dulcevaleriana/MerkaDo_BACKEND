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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBA_MERKAEntities : DbContext
    {
        public DBA_MERKAEntities()
            : base("name=DBA_MERKAEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CARRITO_COMPRAS_> CARRITO_COMPRAS_ { get; set; }
        public virtual DbSet<CATEGORIA_PRODUCTO> CATEGORIA_PRODUCTO { get; set; }
        public virtual DbSet<CLIENTES__> CLIENTES__ { get; set; }
        public virtual DbSet<COMENTARIO> COMENTARIOs { get; set; }
        public virtual DbSet<COMPRA__> COMPRA__ { get; set; }
        public virtual DbSet<CORREO_EMAIL_MARKETING_> CORREO_EMAIL_MARKETING_ { get; set; }
        public virtual DbSet<CUPONES_> CUPONES_ { get; set; }
        public virtual DbSet<DESCUENTOS_> DESCUENTOS_ { get; set; }
        public virtual DbSet<DIA_FERIADO_> DIA_FERIADO_ { get; set; }
        public virtual DbSet<EMPRESAS__> EMPRESAS__ { get; set; }
        public virtual DbSet<ENTREGAS_> ENTREGAS_ { get; set; }
        public virtual DbSet<ESTADISTICAS_> ESTADISTICAS_ { get; set; }
        public virtual DbSet<GENERO> GENEROes { get; set; }
        public virtual DbSet<HISTORIAL_COMPRA_> HISTORIAL_COMPRA_ { get; set; }
        public virtual DbSet<LISTA_PRODUCTO_> LISTA_PRODUCTO_ { get; set; }
        public virtual DbSet<LISTADO_PAQUETE_COMPRA_> LISTADO_PAQUETE_COMPRA_ { get; set; }
        public virtual DbSet<LOG_ACTION__> LOG_ACTION__ { get; set; }
        public virtual DbSet<MENSAJE__> MENSAJE__ { get; set; }
        public virtual DbSet<METODO_ENVIO> METODO_ENVIO { get; set; }
        public virtual DbSet<NOTIFICACION_> NOTIFICACION_ { get; set; }
        public virtual DbSet<PREGUNTAS_FRECUENTES_> PREGUNTAS_FRECUENTES_ { get; set; }
        public virtual DbSet<PRODUCTO__> PRODUCTO__ { get; set; }
        public virtual DbSet<ROL_USUARIO> ROL_USUARIO { get; set; }
        public virtual DbSet<SALA__> SALA__ { get; set; }
        public virtual DbSet<SALA_USUARIO__> SALA_USUARIO__ { get; set; }
        public virtual DbSet<SOBRE_NOSOTROS_> SOBRE_NOSOTROS_ { get; set; }
        public virtual DbSet<STATUS_COMPRA_> STATUS_COMPRA_ { get; set; }
        public virtual DbSet<SUCURSAL_> SUCURSAL_ { get; set; }
        public virtual DbSet<SUPERMERCADO_> SUPERMERCADO_ { get; set; }
        public virtual DbSet<TARJETA_CREDITO_> TARJETA_CREDITO_ { get; set; }
        public virtual DbSet<TARJETA_MEMBRESIA_> TARJETA_MEMBRESIA_ { get; set; }
        public virtual DbSet<TARJETA_REGALO_> TARJETA_REGALO_ { get; set; }
        public virtual DbSet<TIPO_DOCUMENTO> TIPO_DOCUMENTO { get; set; }
        public virtual DbSet<TIPO_ESTADISTICAS_> TIPO_ESTADISTICAS_ { get; set; }
        public virtual DbSet<TIPO_MENSAJE__> TIPO_MENSAJE__ { get; set; }
        public virtual DbSet<TIPO_NOTIFICACION_> TIPO_NOTIFICACION_ { get; set; }
        public virtual DbSet<TIPO_SALA__> TIPO_SALA__ { get; set; }
        public virtual DbSet<TIPO_STATUS_COMPRA> TIPO_STATUS_COMPRA { get; set; }
        public virtual DbSet<USUARIO__> USUARIO__ { get; set; }
    }
}
