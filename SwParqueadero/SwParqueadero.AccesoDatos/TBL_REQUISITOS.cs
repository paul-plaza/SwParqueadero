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
    
    public partial class TBL_REQUISITOS
    {
        public int REQ_CODIGO { get; set; }
        public bool REQ_FACTURA { get; set; }
        public bool REQ_LICENCIA { get; set; }
        public bool REQ_CARNET_CONADIS { get; set; }
        public bool REQ_MATRICULA_VEHICULAR { get; set; }
        public int SOL_CODIGO { get; set; }
        public string REQ_FACTURA_IMAGEN { get; set; }
        public string REQ_LICENCIA_IMAGEN { get; set; }
        public string REQ_CARNET_CONADIS_IMAGEN { get; set; }
        public string REQ_MATRICULA_IMAGEN { get; set; }
    
        public virtual TBL_SOLICITUD TBL_SOLICITUD { get; set; }
    }
}