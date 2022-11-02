using System;
using System.Collections.Generic;
using System.Data.Sql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Controladores
{
    public interface IObservador
    {
        void Notificar(int[] telefonos, string[] mails, string asunto, string mensaje);
    }
}
