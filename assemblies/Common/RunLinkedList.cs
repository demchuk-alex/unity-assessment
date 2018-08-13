using System;
using Common.Structures;

namespace Common
{
    class RunLinkedList
    {
        static void Main(string[] args)
        {
            bool proceed = true;
            CustomLinkedList list = new CustomLinkedList();
            Console.WriteLine("Hi man. It's a sorted linked list insertion console app.");
            Console.WriteLine("Please insert any int you want otherwise type:");
            Console.WriteLine("'p' for printing results.");
            Console.WriteLine("'c' to clear list.");
            Console.WriteLine("'s' to stop.");
            while (proceed)
            {
                var res = Console.ReadLine();
                if (int.TryParse(res, out var number))
                {
                    list.AddSorted(new ListNode(number));
                }
                else if (!string.IsNullOrEmpty(res))
                {
                    var key = res.Trim();
                    switch (key)
                    {
                        case "p":
                            Console.WriteLine(list);
                            break;
                        case "s":
                            proceed = false;
                            break;
                        case "c":
                            list = new CustomLinkedList();
                            break;
                        default:
                            Console.WriteLine("Unknown key proceed...");
                            break;
                    } 
                }
            }
        }
    }
}
