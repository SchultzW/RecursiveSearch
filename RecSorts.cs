using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveSorts
{
    public class RecSorts
    {
        //If the index of a given node is n, its parent is at (n-1)/2, its left child at 2n+1 and its right child at 2n+2.
        public static void BubbleUp(int index, int[] array)
        {
            if (index == 0)
                return;
            int parent = GetParent(index);
            if (array[parent] < array[index])
            {
                //int pVal = array[parent];
                //int iVal = array[index];
                //array[index] = pVal;
                //array[parent] = iVal;

                array = Swap(array, parent, index);
                BubbleUp(parent, array);
            }
            else
                return ;
        }
        public static int[] Swap(int[] array, int swap, int index)
        {
            int pVal = array[swap];
            int iVal = array[index];
            array[index] = pVal;
            array[swap] = iVal;
            return array;
        }
        public static int GetParent(int index)
        {
            return ((index - 1) / 2);
        }
        public static int TrickleDown(int index,int[]array)
        {
            int left = GetLeft(index);
            int right = GetRight(index);

            if(left>=array.Length)
            {
                //no children
                return -1;
            }
            if(right>=array.Length)
            {
                if (array[left] > array[index]);
                array = Swap(array, left, index);
                TrickleDown(left, array);
            }
            else
            {
                if(array[left]>array[right])
                {
                    if (array[left] > array[index]) ;
                    array = Swap(array, left, index);
                    TrickleDown(left, array);
                }
                else
                {
                    if(array[right]>array[index])
                    {
                        array = Swap(array, right, index);
                        TrickleDown(right, array);
                    }
                }
            }
            return -1;
        }

        private static int GetRight(int index)
        {
            // right child at 2n+2.
            return (2 * index) + 2;
        }

        private static int GetLeft(int index)
        {
            //left child at 2n+1 
            return (2 * index) + 1;
        }
        //sorts from smallest to largest
        public static int[] MergeSort(int [] array, int num_val)
        {
            if(array.Length<=1)
            {
                return array;
            }
            int middle = array.Length / 2;
            int[] leftArray = new int[middle];
            int[] rightArray = new int[middle+1];

            for(int i=0;i<middle;i++)
            {
                leftArray[i] = array[i];
            }
            for(int i=middle, j=0;i<array.Count()-1;i++,j++)
            {
                rightArray[j] = array[i];
            }
            leftArray = MergeSort(leftArray,num_val);
            rightArray = MergeSort(rightArray,num_val);
            return Merge(leftArray, rightArray);
        }

        private static int[] Merge(int[] leftArray, int[] rightArray)
        {
            List<int>leftList= leftArray.ToList();
            List<int> rightList = rightArray.ToList();


            int count = 0;
            List<int> result = new List<int>();
            while(leftList.Count()>0||rightList.Count()>0)
            {
                if(leftList.Count()>0 && rightList.Count()>0)
                {
                    if(leftList.First()<=rightList.First())
                    {
                        result.Add(rightList.First());
                        leftList.Remove(leftList.First());
                    }
                    else
                    {
                        result.Add(rightList.First());
                        rightList.Remove(rightList.First());
                    }
                }
                else if(leftList.Count>0)
                {
                    result.Add(leftList.First());
                    leftList.Remove(leftList.First());


                }
                else if(rightList.Count>0)
                {
                    result.Add(rightList.First());
                    rightList.Remove(rightList.First());
                }
            }
            return result.ToArray();
        }

        public static void GoQuickSort(int[]array,int first, int last)
        {
            if(first<last)
            {
                int pivot = Partition(array, first, last);

                GoQuickSort(array, first, pivot - 1);
                GoQuickSort(array, pivot + 1, last);
            }
        }
        public static void StartQuickSort(int []array,int first,int last)
        {
            GoQuickSort(array, first, last);
        }

        private static int Partition(int[] array, int first, int last)
        {
            int j = first;
            int piviotEle = array[first];
            //int index = first + 1;
            for(int i= first+1;i<-last;i++)
            {
                if(array[i]<=piviotEle)
                {
                    j++;
                    Swap(array, first, i);
                    

                }
            }
            Swap(array, first, j);
            return j;
        }
        public static  void HeapSortStart(int[]array, int num_vals)
        {
            int length = array.Length;
            //for(int i=(length/2)-1;i>=0;i--)
            //{
            //    HeapSort(array, length, i);
            //}
            //for(int i=length-1;i>0;i--)
            //{
            //    int temp = array[0];
            //    array[0] = array[i];
            //    array[i] = temp;
            //    HeapSort(array, i, 0);
            //}
            HeapSort(array, length);
        }
        private static void HeapSort(int []array, int length)
        {
            //int largest = length;
            //int right = GetRight(index);
            //int left = GetLeft(index);

            //if(left<length && array[left]>array[largest])
            //{
            //    largest = right;
            //}
            //if(largest!=index)
            //{
            //    int temp = array[index];
            //    array[index] = array[largest];
            //    array[largest] = temp;

            //    HeapSort(array, length, largest);
            //}

            //fix this no while loops. use for loop >_< use either the first part or the 2nd dont need both
            int index = 0;
            while(index<length)
            {
                BubbleUp(index, array);
                index++;
            }

            index = length - 1;
            while(index>0)
            {
                TrickleDown(index,array);
            }
            int last = length - 1;
            while(last>0)
            {
                Swap(array, last, 0);
                TrickleDown(0, array);
                last--;
            }
            return;


        }
        public static string FindNth(int[] findArray, int nUM_VALUES, int v)
        {
            throw new NotImplementedException();
        }

    }
}
