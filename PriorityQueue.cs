using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveSorts
{
    public class PriorityQueue
    {
        private Heap myHeap;
        public  Heap MyHeap { get { return myHeap; } }
    
        public PriorityQueue(int size)
        {
             myHeap = new Heap(size);
            
        }
        public PriorityQueue()
        {
            myHeap = new Heap();
            
        }
        public int Top { get; set; }



        public void AddItem(int val)
        {
            myHeap.AddItem(val);
        }
        //returns smallest num
        public int GetItem()
        {
            return myHeap.GetItem();
            
        }
    }
}
