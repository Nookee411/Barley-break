using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Library
{
    public class Carataker
    {
        /// <summary>
        /// Stack of game states
        /// </summary>
        Stack<Memento> Mementos;

        public Carataker()
        {
            Mementos = new Stack<Memento>();
        }

        public int Size => Mementos.Count;
        /// <summary>
        /// Adds state to stack
        /// </summary>
        /// <param name="state"></param>
        public void Save(Memento state)
        {
            if(Mementos.Count<=50)
                Mementos.Push(state);
        }

        /// <summary>
        /// Restores and deletes from stack
        /// </summary>
        /// <returns></returns>
        public Memento Restore()
        {
            return Mementos.Pop();
        }
    }


}
