﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SwParqueadero.AccesoDatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbParqueoEntities : DbContext
    {
        public DbParqueoEntities()
            : base("name=DbParqueoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TBL_ASIGNACION_PARQUEADERO> TBL_ASIGNACION_PARQUEADERO { get; set; }
        public virtual DbSet<TBL_DIA_ASIGNACION> TBL_DIA_ASIGNACION { get; set; }
        public virtual DbSet<TBL_DIAS> TBL_DIAS { get; set; }
        public virtual DbSet<TBL_DIMENSION> TBL_DIMENSION { get; set; }
        public virtual DbSet<TBL_JORNADA> TBL_JORNADA { get; set; }
        public virtual DbSet<TBL_MARCA> TBL_MARCA { get; set; }
        public virtual DbSet<TBL_MODELO> TBL_MODELO { get; set; }
        public virtual DbSet<TBL_OBSERVACION_SOLICITUD> TBL_OBSERVACION_SOLICITUD { get; set; }
        public virtual DbSet<TBL_OBSERVACIONES> TBL_OBSERVACIONES { get; set; }
        public virtual DbSet<TBL_PARQUEADERO> TBL_PARQUEADERO { get; set; }
        public virtual DbSet<TBL_PUESTOS> TBL_PUESTOS { get; set; }
        public virtual DbSet<TBL_REQUISITOS> TBL_REQUISITOS { get; set; }
        public virtual DbSet<TBL_SOLICITUD> TBL_SOLICITUD { get; set; }
        public virtual DbSet<TBL_TIPO_USUARIO> TBL_TIPO_USUARIO { get; set; }
        public virtual DbSet<TBL_USUARIO> TBL_USUARIO { get; set; }
        public virtual DbSet<TBL_VEHICULO> TBL_VEHICULO { get; set; }
    }
}
