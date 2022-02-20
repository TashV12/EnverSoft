﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
namespace ConsoleApplication1
{
    class Program
    {
        public static void Main(string[] args)
        {
            //You have two arrays/lists as follows
            int[] list1 = new int[] { 1, 2, 3, 4, 5 };
            int[] list2 = new int[] { 3, 4, 5, 6, 7 };
            //a. Show the common elements in both lists. E.g the common elements are "3 4 5", because they
            //are contained in both lists.
            var intersect = list1.Intersect(list2);
            foreach(int value in intersect)
            {
                int[] list3 = new int[] {value};
                Console.WriteLine(string.Join(" ", list3));
            }

            //b. Show the elements from list 1, but is not found in list2. E.g 1 2"
            var exceptl2 =  list1.Except(list2);
            foreach (int value in exceptl2)
            {
                int[] list4 = new int[] { value };
                Console.WriteLine(string.Join("", list4));
            }

            ////c. Complete here
            ////Show the elements from list 2, but is not found in list1. E.g 6 7"
            //Console.WriteLine(string.Join(" ", list5));
            var exceptl = list2.Except(list1);
            foreach (int value in exceptl)
            {
                int[] list5 = new int[] { value };
                Console.WriteLine(string.Join("", list5));
            }

        
            Console.ReadLine();
        }
    }
}
