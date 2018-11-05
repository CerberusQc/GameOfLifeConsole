using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E23Exercice1
{
    public class Coordonnées
    {
        public Coordonnées(int p_PosX1, int p_PosY1, int p_PosX2, int p_PosY2)
        {
            PosX1 = p_PosX1;
            PosY1 = p_PosY1;
            PosX2 = p_PosX2;
            PosY2 = p_PosY2;
        }
        public int PosX1 { get; }
        public int PosY1 { get; }
        public int PosX2 { get; }
        public int PosY2 { get; }

    }
}
