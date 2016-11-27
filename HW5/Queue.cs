using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    class Queue
    {
        private int[] arrayA; // initialize array
        private int sizeA;
        private int count;
        private int head;
        private int tail;
        private int Value;

        public bool IsFull()
        {
            if (count < sizeA)  // check if the buffer is not full yet
            {
                return false;
            }
            else
            {
                Console.WriteLine("The buffer is full.");
                return true;
            }
        }
        public bool IsEmpty()
        {
            if (count <= sizeA && count > 0) // check if stack is not empty already
            {
                return false;
            }
            else
            {
                Console.WriteLine("The buffer is empty.");
                return true;
            }
        }
        public void QueueInit()
        {
            Console.Write("Please write the stack size: ");
            // read the size of array from user input
            while (!(int.TryParse(Console.ReadLine(), out sizeA)))
            {
                Console.Write("Please write the stack size: ");
            }

            arrayA = new int[sizeA];
            for (int i = 0; i < sizeA; i++)
            {
                arrayA[i] = -1;
            }
        }
        public void Enqueue(int ValueIn)
        {
            if (head < sizeA)  // check if head index is less than the array size
            {
                arrayA[head] = ValueIn; // adding new element
                head++; // move "writing" index one ste forward
                count++; // increase the size of buffer
            }
            else // if (head == sizeIn) , if head index reached the end of array
            {
                head = 0; // move the head "write index" to the beginning of the array
                arrayA[head] = ValueIn; // add new element to the beginning of the array
                count++;// increase the size of buffer
                head++; // move the head index to the 2nd cell of array, after the first one was already written
            }
        }
        public int Dequeue()
        {
            if (tail < sizeA) // if the tail is less than the size of array
            {
                Value = arrayA[tail];
                arrayA[tail] = -1; // remove element at the tail index (first index in the ring buffer)
                tail++; // move tail step forward
                count--; // reduce the size of the buffer
            }
            else // if (tail == sizeIn)
            {
                tail = 0; // if last remove was at the end of the array , then set tail to the beginning of the array
                Value = arrayA[tail];
                arrayA[tail] = -1; // remove element under tail index
                count--; // reduce the size of buffer
                tail++; // move tail one step forward
            }
            return Value;
        }
        // prints ring buffer
        public void Ptint()
        {
            int i = tail;
            int count_print = count;
            if (count_print == 0) // if buffer is empty print [ ]
            {
                Console.Write("[ ]\n");
            }
            while (count_print > 0)
            {
                if (i < sizeA) // if printed element is less than the maximum of the array
                {
                    if (tail == i)
                    {
                        Console.Write("[ " + arrayA[i]); // print the first element sof the buffer
                        i++;
                    }
                    else if (tail != i)
                    {
                        Console.Write(", " + arrayA[i]); // middle element
                        i++;
                    }
                }
                else if (i >= sizeA) // if index exceed the size of the array
                {
                    i = 0;
                    if (tail == sizeA) // print start position of the buffer
                    {
                        Console.Write("[ " + arrayA[i]);
                        i++;
                    }
                    else // print the middle elements of the buffer
                    {
                        Console.Write(", " + arrayA[i]);
                        i++;
                    }
                }
                count_print--; // reduce the size of printed array
                if (count_print == 0)
                {
                    Console.Write(" ]\n");
                }
            }
        }
    }
}
