using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListNode48
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListNode<int> list1 = CreateListNode(0,10);
            ListNode<int> list2 = CreateListNode(11,20);
            list1 = Unite(list1, list2);
            //list1 = Change(list1, 3, 99);
            PrintAllList(list1);
            //ListNode<int> lm = new ListNode<int>(2);
            //Console.WriteLine("lm.Value+"+ lm.Value);
            Console.Read();
        }

        /// <summary>
        /// функция для замены элемента в ListNode. индекс начинается с 0. 
        /// Элементы считаются с конца
        /// </summary>
        /// <param name="list">list - значение элемента </param>
        /// <param name="index">индекс элемента который нужно заменить</param>
        /// <param name="newvalue">новое значение</param>
        public static ListNode<int> Change(ListNode<int> list, int index, int newvalue)
        {
            int count=0;
            ListNode<int> newList = list;
            list = new ListNode<int>(index==0 ? newvalue : list.Value, null);
            while (newList.Next!=null)
            {
                count++;
                newList = newList.Next;                
                if (count == index && count>0)
                {
                    list = new ListNode<int>(newvalue, list);
                }
                else
                    list = new ListNode<int>(newList.Value, list);                
            }
            return list;
        }
        /// <summary>
        /// функция для объединения двух ListNode.
        /// </summary>
        /// <param name="list1">первый список </param>
        /// <param name="list2">второй список </param>
        public static ListNode<int> Unite(ListNode<int> list1, ListNode<int> list2)
        {
            if (list1 == null)
                return list2;
            else if(list2 == null)
                return list1;

            ListNode<int> newlist= new ListNode<int>(list1.Value, null);
            while (list1.Next != null)
            {
                list1 = list1.Next;
                newlist = new ListNode<int>(list1.Value, newlist);
            }
            while (list2.Next != null)
            {
                list2 = list2.Next;
                newlist = new ListNode<int>(list2.Value, newlist);
            }
            return newlist;
        }

        public class ListNode<T>
        {
            public readonly T Value;
            public readonly ListNode<T> Next;

            public ListNode()
            {
            }

            /// <summary>
            /// Конструктор
            /// </summary>
            /// <param name="value">T - значение элемента </param>
            /// <param name="next">ListNode<T>- следующий элемент</param>
            public ListNode(T value, ListNode<T> next)
            {
                Value = value;
                Next = next;
            }
        }

        public static ListNode<int> CreateListNode(int start,int end)
        {
            int i = start;
            ListNode<int> list = new ListNode<int>(i,null);
            for (; i< end; )
            {
                ++i;
                list = new ListNode<int>(i, list);
            }
            return list;
        }

        public static void PrintAllList(ListNode<int> list)
        {
            for (var node = list; node != null; node = node.Next)
            {
                Console.WriteLine(node.Value+", ");
            }
        }
    }   
}
