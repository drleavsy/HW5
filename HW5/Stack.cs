using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    class Stack
    {
        private int[] arrayA; // initialize array
        private int sizeA;
        private int top;
        private int count;
        private int topValue;
         
        public Stack()
        {
            sizeA = 0;
            top = 0; // 
            count = 0; // 
            arrayA = null;
        }
        // method that initialize array of the defined size
        private void ArrayInit(int sizeArray)
        {
            arrayA = new int[sizeArray];
            sizeA = sizeArray;
            for (int i = 0; i < sizeArray; i++)
            {
                arrayA[i] = -1;
            }
        }
        public void Push(int Value)
        {
            arrayA[top] = Value; // push one element
            top++; // move cursor to the top of the stack
            count++; // increase the size of stack
        }
        public int Pop()
        {
            int Value = 0;
            Value = arrayA[top - 1];  // save value from the top and pass it out from the method 
            topValue = Value;
            arrayA[top - 1] = -1; // delete value 
            top--; // move top one step back
            count--;  // increase the size of the stack
            return Value;
        }
        public int Peek()
        {
            return topValue;
        }
        public void StackInit()
        {
            Console.Write("Please write the stack size: ");
            // read the size of array from user input
            while (!(int.TryParse(Console.ReadLine(), out sizeA)))
            {
                Console.Write("Please write the stack size: ");
            }

            ArrayInit(sizeA);
        }
        // print the stack 
        public void Print()
        {
            int count_print = count;
            int i = 0;
            if (count_print == 0)
            {
                Console.Write("[ "); // beginning of the stack which is the same as 1st element in the array
            }
            while (count_print > 0)
            {
                if (i == 0)
                {
                    Console.Write("[ " + arrayA[i]); // print start of the stack
                    i++;
                }
                else
                {
                    Console.Write(", " + arrayA[i]); // print middle of the stack
                    i++;
                }
                count_print--; // reduce the size of the printed elements
            }
            Console.WriteLine(" ]"); // print the last element of the stack
        }
        public bool IsFull()
        {
            if (top >= sizeA) //if stack is full
            {
                return true;
            }
            return false;
        }
        public bool IsEmpty()
        {
            if (top <= 0) // check if stack is not empty already
            {
                return true;
            }
            return false;
        }
    }
}
