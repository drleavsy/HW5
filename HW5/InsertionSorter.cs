using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    class InsertionSorter
    {
        private int[] arrayA; // initialize array
        private int sizeA;
        private int ind1; // start sorting from thr 1st element
        private int ind2; // start comparison from the 2nd element
        private int swapCounter;

        public InsertionSorter()
        {
            sizeA = 0;
            ind1 = 0; // start sorting from thr 1st element
            ind2 = 0; // start comparison from the 2nd element
            swapCounter = 1;
            arrayA = null;
        }
        // method that initialize array of the defined size
        public InsertionSorter(int[] arrayB, int sizeArray) : this()
        {
            arrayA = new int[sizeArray];
            sizeA = sizeArray;
            for (int i = 0; i < sizeArray; i++)
            {
                arrayA[i] = arrayB[i];
            }
        }
        public InsertionSorter(int[] arrayB) : this()
        {
            sizeA = arrayB.Length;
            arrayA = new int[sizeA];
            for (int i = 0; i < sizeA; i++)
            {
                arrayA[i] = arrayB[i];
            }
        }

        public void PrintArr(int[] arrayIn)
        {
            Console.Write("[ ");
            foreach (var item in arrayIn)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine("]");
        }

        public void SortInsertion()
        {
            while (ind2 < sizeA)
            {
                ind1 = ind2;
                ind2++;
                while (ind1 >= 0 && swapArr(arrayA, sizeA, ind1, ind2))
                {
                    ind1--;
                    ind2--;
                }
            }
            Console.Write("Insertion sorted array:   ");
            PrintArr(arrayA);
            Console.WriteLine("Press ENTER to quit");
            Console.Read();
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
    }
}
