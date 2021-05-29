using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EVAL_2.Models
{
    public class _Pasajero
    {
        public int id_pasajero { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int pasaje { get; set; }
        public int vuelo { get; set; }
    }
}