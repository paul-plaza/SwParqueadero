//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class TBL_OBSERVACIONES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_OBSERVACIONES()
        {
            this.TBL_OBSERVACION_SOLICITUD = new HashSet<TBL_OBSERVACION_SOLICITUD>();
        }
    
        public int OBS_CODIGO { get; set; }
        public string OBS_DESCRIPCION { get; set; }
        public string OBS_USU { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_OBSERVACION_SOLICITUD> TBL_OBSERVACION_SOLICITUD { get; set; }
    }
}
