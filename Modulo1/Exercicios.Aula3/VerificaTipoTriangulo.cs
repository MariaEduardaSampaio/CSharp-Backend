using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios
{
    internal class VerificaTipoTriangulo
    {
        public static bool EhValido(float c1, float c2, float h)
        {
            if (c1 + c2 > h && c1 + h > c2 && c2 + h > c1)
                return true;
            else
                return false;
        }
        public static bool EhEquilatero(float c1, float c2, float h)
        {
            if (c1 == c2 && c2 == h) 
                return true;
            else 
                return false;
        }

        public static bool EhIsosceles(float c1, float c2, float h)
        {
            if (c1 == c2 && c2 != h) 
                return true;
            else
                return false;
        }

        public static bool EhRetangulo(float c1, float c2, float h)
        {
            if ((Math.Pow(c1, 2) + Math.Pow(c2, 2)) == Math.Pow(h, 2))
                return true;
            else
                return false;
        }

        public static bool EhEscaleno(float c1, float c2, float h)
        {
            if (c1 != c2 && c2 != h && c1 != h)
                return true;
            else
                return false;
        }
    }
}
