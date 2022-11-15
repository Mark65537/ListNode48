using Microsoft.VisualStudio.TestTools.UnitTesting;
using myList;
using System;
using System.Text;

namespace ListNodeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UnitTest()
        {
            //тест на заполнение         
            ListNode<int> list1 = ListNodeExtensions.CreateIntListNode(0, 10);
            ListNode<int> list2 = ListNodeExtensions.CreateIntListNode(11, 20);
            string prStr = ListNodeExtensions.PrintAllList(list1);
            string result = "10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, ";
            Assert.AreEqual(result, prStr);

            //тест на замену элемента
            list1 = ListNodeExtensions.Change(list1, 3, 99);
            prStr = ListNodeExtensions.PrintAllList(list1);
            result = "0, 1, 2, 3, 4, 5, 6, 99, 8, 9, 10, ";
            Assert.AreEqual(result, prStr);

            //тест на объединение
            list1 = ListNodeExtensions.Unite(list1, list2);
            prStr = ListNodeExtensions.PrintAllList(list1);
            result = "11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 10, 9, 8, 99, 6, 5, 4, 3, 2, 1, 0, ";
            Assert.AreEqual(result, prStr);
        }
    }
}

namespace myList
{ 
    public class ListNode<T>
    {
        public readonly T Value;
        public readonly ListNode<T> Next;

        public ListNode(T value) : this(value, null)
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

    public static class ListNodeExtensions
    {
        /// <summary>
        /// функция для заполнения ListNode последовательностью чисел.
        /// </summary>
        /// <param name="start">начало последовательности</param>
        /// <param name="end">конец последовательности</param>
        public static ListNode<int> CreateIntListNode(int start, int end)
        {
            int i = start;
            ListNode<int> list = new ListNode<int>(i);
            for (; i < end;)
            {
                ++i;
                list = new ListNode<int>(i, list);
            }
            return list;
        }
        /// <summary>
        /// функция для создания строки вывода на печать ListNode.
        /// </summary>
        /// <param name="list">список</param>
        /// <returns>string</returns>
        public static string PrintAllList<T>(ListNode<T> list)
        {
            StringBuilder sb=new StringBuilder();
            for (var node = list; node != null; node = node.Next)
            {
                sb.Append($"{node.Value}, ");
            }
            return sb.ToString();
        }

        /// <summary>
        /// функция для объединения двух ListNode.
        /// </summary>
        /// <param name="list1">первый список </param>
        /// <param name="list2">второй список </param>
        /// <returns>новый список со всеми значениями из 2х списков</returns>
        public static ListNode<T> Unite<T>(ListNode<T> list1, ListNode<T> list2)
        {
            if (list1 == null)
                return list2;
            else if (list2 == null)
                return list1;

            ListNode<T> newlist = new ListNode<T>(list1.Value);
            while (list1.Next != null)
            {
                list1 = list1.Next;
                newlist = new ListNode<T>(list1.Value, newlist);
            }
            while (list2.Next != null)
            {
                newlist = new ListNode<T>(list2.Value, newlist);
                list2 = list2.Next;
            }
            newlist = new ListNode<T>(list2.Value, newlist);
            return newlist;
        }

        /// <summary>
        /// функция для замены элемента в ListNode. индекс начинается с 0. 
        /// Элементы считаются с конца
        /// </summary>
        /// <param name="list">list - значение элемента </param>
        /// <param name="index">индекс элемента который нужно заменить</param>
        /// <param name="newvalue">новое значение</param>
        public static ListNode<T> Change<T>(ListNode<T> list, int index, T newvalue)
        {
            int count = 0;
            ListNode<T> newList = list;
            list = new ListNode<T>(index == 0 ? newvalue : list.Value);
            while (newList.Next != null)
            {
                count++;
                newList = newList.Next;
                if (count == index && count > 0)
                {
                    list = new ListNode<T>(newvalue, list);
                }
                else
                    list = new ListNode<T>(newList.Value, list);
            }
            return list;
        }
    }
}
