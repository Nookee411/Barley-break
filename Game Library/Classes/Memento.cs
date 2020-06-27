using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Library
{
    public class Memento
    {
        //Field state
        int[,] field;

        public Memento(int[,] s)
        {
            field = new int[s.GetLength(0), s.GetLength(1)];
            for (int i = 0; i < s.GetLength(0); i++)
            {
                for (int j = 0; j < s.GetLength(1); j++)
                    field[i, j] = s[i, j];
            }
        }

        /// <summary>
        /// Gets or sets state of game
        /// </summary>
        public int[,] State
        {
            get
            {
                return this.field;
            }
        }
    }
}
