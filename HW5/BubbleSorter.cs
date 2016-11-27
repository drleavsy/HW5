using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    class BubbleSorter
    {
        private int[] arrayA; // initialize array
        private int sizeA;
        private int ind1; // start sorting from thr 1st element
        private int ind2; // start comparison from the 2nd element
        int ind_last;
        private int swapCounter;

        public BubbleSorter()
        {
            sizeA = 0;
            ind1 = 0; // start sorting from thr 1st element
            ind2 = 1; // start comparison from the 2nd element
            swapCounter = 1;
            ind_last = 0;
            arrayA = null;
        }
        // method that initialize array of the defined size
        public BubbleSorter(int[] arrayB, int sizeArray ) : this()
        {
            arrayA = new int[sizeArray];
            sizeA = sizeArray;
            for (int i = 0; i < sizeArray; i++)
            {
                arrayA[i] = arrayB[i];
            }
        }
        public BubbleSorter(int[] arrayB) : this()
        {
            sizeA = arrayB.Length;
            arrayA = new int[sizeA];
            for (int i = 0; i < sizeA; i++)
            {
                arrayA[i] = arrayB[i];
            }
        }

        static private bool swapArr(int[] arrayIn, int sizeIn, int inx1, int inx2)
        {
            int temp1 = 0;
            int temp2 = 0;

            if (inx1 < sizeIn && inx2 < sizeIn) // check if index is array 
            {
                if (arrayIn[inx1] > arrayIn[inx2]) // check if 1st element is greater than 2nd
                {                                  // if yes swap and return true , if no - return false
                    temp1 = arrayIn[inx1];
                    temp2 = arrayIn[inx2];
                    arrayIn[inx1] = temp2;
                    arrayIn[inx2] = temp1;
                    return true;
                }
                else                              // if 2nd element is greater than 1st one: return false, no swap
                {
                    return false;
                }
            }
            return false; // if index is larger than array size 
        }

        public void SortBubble()
        {
            ind_last = sizeA + 1; // initilize last first sorted index for buble sort: index until which sorting is done, above this index array will be sorted
                                   //  which means initially array is unsorted by default
           //Stopwatch sw = Stopwatch.StartNew(); // count time for buble sort
            while (swapCounter >= 0)
            {
                if (ind1 == ind_last || ind1 == sizeA) // if we compared all elements in the array, then we go to the beginning of the array 
                {                   // and start comparison cycle all over again
                    if (swapCounter == 0)  // if at the end of array there were no any swaps, then 
                    {
                        break;
                    }
                    ind_last = ind1 - 1; // set index to the last sorted index 
                                         // (- 1 because even after the index was already sorted, it is incremented in the end of while loop)
                    ind1 = 0;       // start comparison cycle from the beginning of the array,
                    ind2 = 1;       // meaning reset all indexes--
                    swapCounter = 0;
                }
                if (ind2 < ind_last && swapArr(arrayA, sizeA, ind1, ind2))
                {
                    swapCounter++;
                }
                ind1++;
                ind2++;
            }
            Console.Write("Your buble sorted array:  ");
            PrintArr(arrayA);
            Console.WriteLine("Press ENTER to quit");
            Console.Read();
        }

        public void PrintArr (int[] arrayIn)
        {
            Console.Write("[ ");
            foreach (var item in arrayIn)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine("]");
        }
    }
}
