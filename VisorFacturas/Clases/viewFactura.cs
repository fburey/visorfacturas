using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisorFacturas.Clases
{
    public class viewFactura
    {
        // Esta clase se usa para llenar el Grid de las Facturas del formulario frmFacturas

        public String cli_codig { get; set; }
        public String cli_nom { get; set; }
        public String cli_dir { get; set; }
        public String cli_ruc { get; set; }
        public String cli_regimen { get; set; }
        public String ord_numero { get; set; }
        public DateTime fecha { get; set; }
        public int fac_fac_nu { get; set; }
        public Double fac_tasa { get; set; }
        public Double fac_amo_do { get; set; }
        public Char fac_dolcor { get; set; }
        public Char tipo { get; set; }
        public Double fac_amount { get; set; }
        public Double fac_pagado { get; set; }
        public Double fac_pag_do { get; set; }
    }
}
