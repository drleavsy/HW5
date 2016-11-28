using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeArr = 0;
            int[] arrayNew;

            Console.WriteLine("Please select one of the following option: 1=Buble Sort, 2=Insertion Sort, 3=Stack, 4=Circular Buffer");
            Console.Write("Please enter your selection: ");
            //InputSimulator.SimulateKeyDown(VirtualKeyCode.VK_4);
            //InputSimulator.SimulateKeyDown(VirtualKeyCode.RETURN);
            string str = Console.ReadLine();
            switch (str)
            {
                case "1":
                case "Bubble Sort":
                    arrayNew = FillArrayFromConsole(ref sizeArr);
                    BubbleSorter BubbleSort = new BubbleSorter(arrayNew, sizeArr);
                    BubbleSort.PrintArr(arrayNew);
                    BubbleSort.SortBubble();
                    BubbleSort.PrintArr(arrayNew); 
                    break;
                case "2":
                case "Insertion Sort":
                    arrayNew = FillArrayFromConsole(ref sizeArr);
                    InsertionSorter InsertionSort = new InsertionSorter(arrayNew, sizeArr);
                    InsertionSort.PrintArr(arrayNew);
                    InsertionSort.SortInsertion();
                    InsertionSort.PrintArr(arrayNew);
                    break;
                case "3":
                case "Stack":
                    Stack StackInst = new Stack();
                    StackMenu( StackInst );
                    break;
                case "4":
                case "Circular Buffer":
                    Queue QueueInst = new Queue();
                    QueueInst.QueueInit();
                    QueueMenu(QueueInst);
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please select 1, 2, or 3, or 4.");
                    break;
            }
            Console.WriteLine("Press ENTER to quite");
            Console.Read();
        }

        static int[] FillArrayFromConsole(ref int sizeIn)
        {
            string input;
            int i = 0;
            int elem = 0;

            //Random rnd = new Random();
            // read the size of array
            Console.Write("Please write the array size: ");
            // read the size of array from user input
            while (!(int.TryParse(Console.ReadLine(), out sizeIn)))
            {
                Console.WriteLine("Please enter proper array size again: ");
            }
            int[] arrayIn = new int[sizeIn];
            // read from console 1-by-1 separated by ENTER
            Console.WriteLine("Please enter array's elements one-by-one: ");
            while (i < sizeIn)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out elem))
                {
                    arrayIn[i] = /*rnd.Next(9999);*/elem;
                    i++;
                }
                else
                {
                    Console.WriteLine("Enter the proper array element #", i, " again: ");
                }
            }
            Console.Write("The array before sorting: ");
            return arrayIn;
        }

        static void StackMenu(Stack StackInst)
        {
            string str = ""; // for input from console
            int Value = 0; // 
            StackInst.StackInit();
            while (str != "q")
            {
                Console.WriteLine("Please select one of the following option: 1=push, 2=pop, q=quit");
                //Console.WriteLine("Please enter your selection: ");
                str = Console.ReadLine();
                switch (str)
                {
                    case "1":
                    case "push":
                        // return true if stack is still not full, otherwise return false
                        if (!StackInst.IsFull())
                        {
                            Console.Write("Please enter the value to push: ");
                            while (!(int.TryParse(Console.ReadLine(), out Value))) // validate the input from console
                            {
                                Console.Write("Wrong value. Please enter the value to push: ");
                            }
                            StackInst.Push(Value);
                            Console.Write("Your stack is: ");
                            StackInst.Print();// print the stack current status
                        }
                        else
                        {
                            Console.WriteLine("The stack is full");
                        }
                        break;
                    case "2":
                    case "pull":
                        // return true if stack is still not empty, otherwise return false
                        if (!StackInst.IsEmpty())
                        {
                            Console.Write("Your stack is: ");
                            StackInst.Pop();
                            StackInst.Print(); // print the stack current status
                            Console.WriteLine("The value pulled from top is: " + StackInst.Peek());
                        }
                        else
                        {
                            Console.WriteLine("The stack is empty ");
                        }
                        break;
                    case "q":
                    case "quite":
                        break;
                    default:
                        Console.Write("Invalid selection. ");
                        break;
                }
            }
        }
        static void QueueMenu(Queue QueueInst)
        {
            string str = "";
            string input = "";
            int ValueIn = 0;
            //QueueInst.QueueInit();

            while (str != "q")
            {
                Console.WriteLine("Please select one of the following option: 1=enqueue, 2=dequeue q=quit");
                str = Console.ReadLine();  // read user input from the console
                switch (str)
                {
                    case "1":
                    case "enqueue": // write new element to the buffer from the head
                        Console.Write("Please enter the value to enqueue: ");
                        input = Console.ReadLine();

                        if (int.TryParse(input, out ValueIn))
                        {
                            if (!QueueInst.IsFull())
                            {
                                QueueInst.Enqueue(ValueIn);
                                QueueInst.Ptint();
                            }
                        }
                        break;
                    case "2":
                    case "dequeue": // delete first element from the buffer from the tail
                        if (!QueueInst.IsEmpty())
                        {
                            ValueIn = QueueInst.Dequeue();
                            QueueInst.Ptint();
                            Console.WriteLine("The value deleted from the queue: " + ValueIn);
                        }
                        break;
                    case "q":
                    case "quit":
                        break;
                    default:
                        Console.Write("Invalid selection. ");
                        break;
                }
            }
        }
    }
}
