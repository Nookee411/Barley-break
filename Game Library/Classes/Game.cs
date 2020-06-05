using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Library
{
    public class Game
    {
        static Random rand = new Random();
        Carataker carataker;
        private int[,] field;
        int size;
        int x0;
        int y0;
        int turnCounter;

        public Game(int size)
        {
            this.size = size;
            field = new int[4, 4];
            x0 = 3;
            y0 = 3;
            turnCounter = 0;
            carataker = new Carataker();
        }

        private int CoordinatesToPosition(int x, int y)
        {
            return y * 4 + x;
        }

        private void PositionToCoordinates(int position, out int x, out int y)
        {
            x = position % 4;
            y = position / 4;
            return;
        }

        public void Start()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = CoordinatesToPosition(i, j) + 1;
                }
            }
            x0 = 3;
            y0 = 3;
            field[x0, y0] = 0;
            turnCounter = 0;
        }

        public int GetNumber(int position)
        {
            if (position > 15 || position < 0)
                throw new IndexOutOfRangeException("Position out of range");
            else
            {
                int x, y;
                PositionToCoordinates(position, out x, out y);
                return field[x, y];
            }
        }
        public void Shift(int position)
        {
            int x, y;
            PositionToCoordinates(position, out x, out y);
            if (Math.Abs(x0 - x) + Math.Abs(y0 - y) < 2)
            {
                turnCounter++;
                field[x0, y0] = field[x, y];
                field[x, y] = 0;
                x0 = x;
                y0 = y;
            }
        }

        public void ShiftRandom()
        {
            int a = rand.Next() % 4;
            int x = x0;
            int y = y0;
            if (a == 0)
            {
                if (x == 3)
                    x--;
                else
                    x++;
            }
            else if (a == 1)
            {
                if (x == 0)
                    x++;
                else
                    x--;
            }
            else if (a == 2)
            {
                if (y == 3)
                    y--;
                else
                    y++;
            }
            else
            {
                if (y == 0)
                    y++;
                else
                    y--;
            }
            turnCounter--;
            Shift(CoordinatesToPosition(x, y));
        }

        public int GetTurnCounter
        {
            get { return turnCounter; }
        }

        public bool EndGameCheck()
        {
            if (field[3, 3] == 0)
            {
                for (int i = 0; i < field.GetLength(0); i++)
                {
                    for (int j = 0; j < field.GetLength(1); j++)
                    {
                        if (CoordinatesToPosition(i, j) != 15 && field[i, j] != CoordinatesToPosition(i, j) + 1)
                            return false;
                    }
                }
                return true;
            }
            return false;
        }

        public void Save()
        {
            Memento state = new Memento(field);
            carataker.Save(state);
        }

        public void Restore()
        {
            if(carataker.Size!=0)
            field = carataker.Restore().State;
            FindZero();
            
        }

        private void FindZero()
        {
            for(int i=0;i<4;i++)
            {
                for(int j=0;j<4;j++)
                {
                    if(field[i,j]==0)
                    {
                        x0 = i;
                        y0 = j;
                    }
                }
            }
        }
    }

    

    
}
