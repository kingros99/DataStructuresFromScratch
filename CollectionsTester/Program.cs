
using EyadLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsTester
{
    internal class Program
    {
        static int passed = 0;
        static int failed = 0;

        static void Check(string name, bool condition)
        {
            if (condition)
            {
                passed++;
                Console.WriteLine($"PASS: {name}");
            }
            else
            {
                failed++;
                Console.WriteLine($"FAIL: {name}");
            }
        }

        static void CheckThrows(string name, Action action)
        {
            try
            {
                action();
                Check(name, false);
            }
            catch (ArgumentOutOfRangeException)
            {
                Check(name, true);
            }
            catch (ArgumentException)
            {
                Check(name, true);
            }
            catch (IndexOutOfRangeException)
            {
                Check(name, true);
            }
            catch
            {
                Check(name, false);
            }
        }

        static void CheckContents(
            string name,
            EyadLinkedList<int> list,
            params int[] expected)
        {
            bool correct = list.Length == expected.Length;

            if (correct)
            {
                for (int i = 0; i < expected.Length; i++)
                {
                    try
                    {
                        if (list[i] != expected[i])
                        {
                            correct = false;
                            break;
                        }
                    }
                    catch
                    {
                        correct = false;
                        break;
                    }
                }
            }

            Check(name, correct);
        }

        static void Main(string[] args)
        {
            EyadLinkedList<int> list = new();

            // Empty list
            Check("Initial length", list.Length == 0);

            CheckThrows("Read index 0 on empty list",
                () => { var value = list[0]; });

            CheckThrows("Read negative index",
                () => { var value = list[-1]; });

            // InsertAtEnd
            list.InsertAtEnd(10);
            CheckContents("Insert first element", list, 10);

            list.InsertAtEnd(20);
            list.InsertAtEnd(30);
            CheckContents("Insert multiple elements", list, 10, 20, 30);

            // Insert at beginning
            list.insertAtBegining(5);
            CheckContents("Insert at beginning", list, 5, 10, 20, 30);

            // InsertAfter
            list.InsertAfter(7, 0);
            CheckContents("Insert after first index", list, 5, 7, 10, 20, 30);

            list.InsertAfter(15, 2);
            CheckContents("Insert after middle index", list, 5, 7, 10, 15, 20, 30);

            list.InsertAfter(40, list.Length - 1);
            CheckContents("Insert after last index", list, 5, 7, 10, 15, 20, 30, 40);

            // Indexer
            Check("Read first element", list[0] == 5);
            Check("Read middle element", list[3] == 15);
            Check("Read last element", list[list.Length - 1] == 40);

            CheckThrows("Read index equal to Length",
                () => { var value = list[list.Length]; });

            // ReplaceAt
            list.ReplaceAt(50, 0);
            CheckContents("Replace first element", list, 50, 7, 10, 15, 20, 30, 40);

            list.ReplaceAt(17, 3);
            CheckContents("Replace middle element", list, 50, 7, 10, 17, 20, 30, 40);

            list.ReplaceAt(100, list.Length - 1);
            CheckContents("Replace last element", list, 50, 7, 10, 17, 20, 30, 100);

            // RemoveAt
            list.RemoveAt(3);
            CheckContents("Remove middle element", list, 50, 7, 10, 20, 30, 100);

            list.RemoveAt(0);
            CheckContents("Remove first element", list, 7, 10, 20, 30, 100);

            list.RemoveAt(list.Length - 1);
            CheckContents("Remove last element", list, 7, 10, 20, 30);

            // Delete from beginning and end
            list.DeleteFromBegining();
            CheckContents("Delete from beginning", list, 10, 20, 30);

            list.DeleteFromEnd();
            CheckContents("Delete from end", list, 10, 20);

            // Empty list by deleting
            list.DeleteFromBegining();
            CheckContents("Delete until one remains", list, 20);

            list.DeleteFromEnd();
            CheckContents("Delete final element", list);
            Check("Length after becoming empty", list.Length == 0);

            // Delete from empty list
            CheckThrows("Delete from beginning of empty list",
                () => list.DeleteFromBegining());

            CheckThrows("Delete from end of empty list",
                () => list.DeleteFromEnd());

            CheckContents("List remains empty", list);
            // Reuse after emptying
            list.InsertAtEnd(99);
            list.insertAtBegining(88);
            CheckContents("Reuse empty list", list, 88, 99);

            // Invalid indexes
            CheckThrows("InsertAfter rejects negative index",
                () => list.InsertAfter(1, -1));

            CheckThrows("InsertAfter rejects index equal to Length",
                () => list.InsertAfter(1, list.Length));

            CheckThrows("ReplaceAt rejects negative index",
                () => list.ReplaceAt(1, -1));

            CheckThrows("ReplaceAt rejects index equal to Length",
                () => list.ReplaceAt(1, list.Length));

            CheckThrows("RemoveAt rejects negative index",
                () => list.RemoveAt(-1));

            CheckThrows("RemoveAt rejects index equal to Length",
                () => list.RemoveAt(list.Length));

            // Single-element replacement
            EyadLinkedList<int> single = new();
            single.InsertAtEnd(1);
            single.ReplaceAt(2, 0);
            CheckContents("Replace sole element", single, 2);

            single.InsertAtEnd(3);
            CheckContents("Insert after sole-element replacement", single, 2, 3);

            // Final report
            Console.WriteLine();
            Console.WriteLine("==============================");
            Console.WriteLine($"Passed: {passed}");
            Console.WriteLine($"Failed: {failed}");
            Console.WriteLine($"Total:  {passed + failed}");
            Console.WriteLine("==============================");
        }
    }
}
