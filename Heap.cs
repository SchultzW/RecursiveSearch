using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecursiveSorts;

namespace RecursiveSorts
{
    public class Heap
    {
        public static RecSorts sorter = new RecSorts();
        private int[] myHeap;
        public int[] MyHeap { get { return myHeap; } }
        public int Count = 0;//do I need this?
                             //this needs to be a treeish thing no array
        public Heap(int count)
        {
            myHeap = new int[count];

        }

        public Heap()
        {
            myHeap = new int[10];
        }
        //double if full
        public void AddItem(int val)
        {
            if (Count >= myHeap.Length)
            {
                //double size
                Array.Resize(ref myHeap, myHeap.Length * 2);
   
               

            }
            else
            {

                myHeap[Count++] = val;
                BubbleUp(Count - 1);
            }
        }
        //public void Resize()
        //{

        //     Array.Resize(ref myHeap, myHeap.Length * 2);

        //}
        //removes and returns the smallest item
        //throw error if empty
        public int GetItem()
        {
            if (Count <= 0)
            {
                throw new IndexOutOfRangeException("the heap is empty");
            }
            int val = myHeap[0];

            myHeap[0] = myHeap[--Count];
            TrickleDown(0);

            return val;

        }
        private void TrickleDown(int i)
        {
            //get children
            int l = GetLeft(i);
            int r = GetRight(i);

            //end of children
            if(l>=Count)
            {
                return;
            }
            
            
            if (r >= Count)
            {
                //moving around vals
                if (myHeap[l] < myHeap[i])
                {
                    Swap(myHeap, l, i);
                    TrickleDown(l);
                }
            }
            else
            {
                //other side
                if (myHeap[l] < myHeap[r])
                {
                    if(myHeap[l]<myHeap[i])
                    {
                        Swap(myHeap, r, i);
                        TrickleDown(r);
                    }
                
                }
                else
                {
                    if(myHeap[r]<myHeap[i])
                    {
                        Swap(myHeap, r, i);
                        TrickleDown(r);
                    }
                }
            }
            
           
        }
        private int GetParent(int i)
        {
            return (i - 1) / 2;
        }
        private int GetLeft(int i)
        {
            return 2 * i + 2;
        }
        private int GetRight(int i)
        {
            return 2 * i + 2;
        }
        public static int[] Swap(int[] array, int swap, int index)
        {
            int pVal = array[swap];
            int iVal = array[index];
            array[index] = pVal;
            array[swap] = iVal;
            return array;
        }
        private void BubbleUp(int i)
        {
            if (i == 0)
                return;
            int parent = GetParent(i);
            if (myHeap[parent] > myHeap[i])
            {
                Swap(myHeap, parent, i);
                BubbleUp(parent);
            }
            else
                return;
        }
    }
}
