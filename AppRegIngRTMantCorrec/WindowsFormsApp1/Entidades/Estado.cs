using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class Estado
    {
        string nombre { get; set; }
        string ambito { get; set; }
        bool esReservable { get; set; }
        bool esCancelable { get; set; }
    }
}
