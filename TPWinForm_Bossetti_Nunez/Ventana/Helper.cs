using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventana
{
    class Helper
    {       
        public bool validarNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter) || char.IsPunctuation(caracter)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
