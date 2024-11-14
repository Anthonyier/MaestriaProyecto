using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntConciliacionCarroGuia
    {
        public int id {get;set;}
        public double it { get; set; }
        public double Rastreo { get; set; }
        public double Depositos { get; set; }
        public double Telefonia { get; set; }
        public double TotalPagable { get; set; }
        public double Diferencias { get; set; }
        public double Pagos { get; set;}
        public int IdDetalleCarroGuia { get; set; }
        public int IdRastreo { get; set; }
        public int IdTelefono1 { get; set; }
        public int IdTelefono2 { get; set; }
        public int IdPeriodo { get; set; }
        public int IdAño { get; set; }
        public int Aprobado { get; set; }
        public int Solicitud { get; set; }
        public int IdPersona { get; set; }
        public int IdRegion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaSolicitud { get; set; }

    }
}