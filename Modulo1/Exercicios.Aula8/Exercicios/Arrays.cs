using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios
{
    internal class Arrays
    {
        internal static int PegarValor(Array arr, int index)
        {
            if (arr.Length <= index)
                throw new IndexOutOfRangeException("Índice fora do alcance do array.");
            else
                return (int)arr.GetValue(index);
        }
    }
}
