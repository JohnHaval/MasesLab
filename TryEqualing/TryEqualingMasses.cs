using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryEqualing
{
    public static class TryEqualingMasses
    {
        public static bool IsEqualSequance { get; private set; }
    /// <summary>
    /// Сравнивает массивы на различность элементов без учета их порядка. Если отличий нет, кроме порядка, 
    /// </summary>
    /// <param name="firstMas"></param>
    /// <param name="secondMas"></param>
    /// <returns>true - если равны, (не важен порядок)</returns>
        public static bool TryEqualMasses(int[] firstMas, int[] secondMas)
        {
            if (firstMas == null || secondMas == null) return false;
            if (firstMas.Length != secondMas.Length) return false;
            int length = firstMas.Length;
            bool[] prvCheck = new bool[length];
            IsEqualSequance = true;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (firstMas[i] == secondMas[j] && !prvCheck[j])
                    {
                        if (i != j) IsEqualSequance = false;                        
                        prvCheck[j] = true;
                        break;
                    }
                }
            }
            for (int i = 0; i < length; i++)
            {
                if (!prvCheck[i]) return false;
            }
            return true;
        }
    }
}
