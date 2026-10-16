
using DataStructures;
using DataStructures.Queues;
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
            catch (InvalidOperationException)
            {
                Check(name, true);

            }
            catch
            {
                Check(name, false);

            }
        }
        static void Test(string name, Action test)
        {
            try
            {
                test();
                Console.WriteLine($"[PASS] {name}");
                passed++;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[FAIL] {name}");
                Console.WriteLine($"       {ex.Message}");
                failed++;
            }
        }

        static void Assert(bool condition, string message)
        {
            if (!condition)
                throw new Exception(message);
        }

        static void AssertEqual<T>(T expected, T actual, string message)
        {
            if (!Equals(expected, actual))
            {
                throw new Exception(
                    $"{message} | Expected: {expected}, Actual: {actual}"
                );
            }
        }

        static void AssertThrows<TException>(Action action)
            where TException : Exception
        {
            try
            {
                action();
            }
            catch (TException)
            {
                return;
            }

            throw new Exception(
                $"Expected {typeof(TException).Name} was not thrown."
            );
        }




        #region Linked List
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
        #endregion

        static void Main(string[] args)
        {
            #region Linked List Test

            //EyadLinkedList<int> list = new();

            //// Empty list
            //Check("Initial length", list.Length == 0);

            //CheckThrows("Read index 0 on empty list",
            //    () => { var value = list[0]; });

            //CheckThrows("Read negative index",
            //    () => { var value = list[-1]; });

            //// InsertAtEnd
            //list.InsertAtEnd(10);
            //CheckContents("Insert first element", list, 10);

            //list.InsertAtEnd(20);
            //list.InsertAtEnd(30);
            //CheckContents("Insert multiple elements", list, 10, 20, 30);

            //// Insert at beginning
            //list.insertAtBegining(5);
            //CheckContents("Insert at beginning", list, 5, 10, 20, 30);

            //// InsertAfter
            //list.InsertAfter(7, 0);
            //CheckContents("Insert after first index", list, 5, 7, 10, 20, 30);

            //list.InsertAfter(15, 2);
            //CheckContents("Insert after middle index", list, 5, 7, 10, 15, 20, 30);

            //list.InsertAfter(40, list.Length - 1);
            //CheckContents("Insert after last index", list, 5, 7, 10, 15, 20, 30, 40);

            //// Indexer
            //Check("Read first element", list[0] == 5);
            //Check("Read middle element", list[3] == 15);
            //Check("Read last element", list[list.Length - 1] == 40);

            //CheckThrows("Read index equal to Length",
            //    () => { var value = list[list.Length]; });

            //// ReplaceAt
            //list.ReplaceAt(50, 0);
            //CheckContents("Replace first element", list, 50, 7, 10, 15, 20, 30, 40);

            //list.ReplaceAt(17, 3);
            //CheckContents("Replace middle element", list, 50, 7, 10, 17, 20, 30, 40);

            //list.ReplaceAt(100, list.Length - 1);
            //CheckContents("Replace last element", list, 50, 7, 10, 17, 20, 30, 100);

            //// RemoveAt
            //list.RemoveAt(3);
            //CheckContents("Remove middle element", list, 50, 7, 10, 20, 30, 100);

            //list.RemoveAt(0);
            //CheckContents("Remove first element", list, 7, 10, 20, 30, 100);

            //list.RemoveAt(list.Length - 1);
            //CheckContents("Remove last element", list, 7, 10, 20, 30);

            //// Delete from beginning and end
            //list.DeleteFromBegining();
            //CheckContents("Delete from beginning", list, 10, 20, 30);

            //list.DeleteFromEnd();
            //CheckContents("Delete from end", list, 10, 20);

            //// Empty list by deleting
            //list.DeleteFromBegining();
            //CheckContents("Delete until one remains", list, 20);

            //list.DeleteFromEnd();
            //CheckContents("Delete final element", list);
            //Check("Length after becoming empty", list.Length == 0);

            //// Delete from empty list
            //CheckThrows("Delete from beginning of empty list",
            //    () => list.DeleteFromBegining());

            //CheckThrows("Delete from end of empty list",
            //    () => list.DeleteFromEnd());

            //CheckContents("List remains empty", list);
            //// Reuse after emptying
            //list.InsertAtEnd(99);
            //list.insertAtBegining(88);
            //CheckContents("Reuse empty list", list, 88, 99);

            //// Invalid indexes
            //CheckThrows("InsertAfter rejects negative index",
            //    () => list.InsertAfter(1, -1));

            //CheckThrows("InsertAfter rejects index equal to Length",
            //    () => list.InsertAfter(1, list.Length));

            //CheckThrows("ReplaceAt rejects negative index",
            //    () => list.ReplaceAt(1, -1));

            //CheckThrows("ReplaceAt rejects index equal to Length",
            //    () => list.ReplaceAt(1, list.Length));

            //CheckThrows("RemoveAt rejects negative index",
            //    () => list.RemoveAt(-1));

            //CheckThrows("RemoveAt rejects index equal to Length",
            //    () => list.RemoveAt(list.Length));

            //// Single-element replacement
            //EyadLinkedList<int> single = new();
            //single.InsertAtEnd(1);
            //single.ReplaceAt(2, 0);
            //CheckContents("Replace sole element", single, 2);

            //single.InsertAtEnd(3);
            //CheckContents("Insert after sole-element replacement", single, 2, 3);

            //// Final report
            //Console.WriteLine();
            //Console.WriteLine("==============================");
            //Console.WriteLine($"Passed: {passed}");
            //Console.WriteLine($"Failed: {failed}");
            //Console.WriteLine($"Total:  {passed + failed}");
            //Console.WriteLine("=============================="); 
            #endregion

            #region Array Stack Test


            //EyadStackArray<int> stack = new(3);



            //// Empty stack
            //CheckThrows("Peek on empty stack", () => stack.Peek());
            //CheckThrows("Pop on empty stack", () => stack.Pop());

            //// Push
            //stack.Push(10);
            //Check("Push first element", stack.Top == 0);
            //Check("Peek first element", stack.Peek() == 10);

            //stack.Push(20);
            //Check("Push second element", stack.Top == 1);
            //Check("Peek second element", stack.Peek() == 20);

            //stack.Push(30);
            //Check("Push third element", stack.Top == 2);
            //Check("Peek last element", stack.Peek() == 30);

            //// Full stack
            //CheckThrows("Push on full stack", () => stack.Push(40));
            //Check("Top unchanged after failed Push", stack.Top == 2);
            //Check("Top value unchanged after failed Push", stack.Peek() == 30);

            //// Pop
            //stack.Pop();
            //Check("Pop top element", stack.Top == 1);
            //Check("Peek after first Pop", stack.Peek() == 20);

            //stack.Pop();
            //Check("Pop second element", stack.Top == 0);
            //Check("Peek after second Pop", stack.Peek() == 10);

            //stack.Pop();
            //Check("Pop final element", stack.Top == -1);

            //// Empty again
            //CheckThrows("Peek after removing all elements", () => stack.Peek());
            //CheckThrows("Pop after removing all elements", () => stack.Pop());

            //// Reuse
            //stack.Push(99);
            //Check("Push after becoming empty", stack.Top == 0);
            //Check("Peek after reuse", stack.Peek() == 99);

            //// Print
            //Console.WriteLine("\nStack output:");
            //stack.Pop();
            //stack.Print();

            //stack.Push(1);
            //stack.Push(2);
            //stack.Push(3);


            //stack.Print();

            //// Results
            //Console.WriteLine();
            //Console.WriteLine("==============================");
            //Console.WriteLine($"Passed: {passed}");
            //Console.WriteLine($"Failed: {failed}");
            //Console.WriteLine($"Total:  {passed + failed}");
            //Console.WriteLine("==============================");
            #endregion







         Console.WriteLine("========== LINEAR QUEUE TESTS ==========\n");

                // 1. Construction

                Test("New queue is empty", () =>
                {
                    var q = new SimpleQueue<int>();
                    Assert(q.IsEmpty, "Queue should be empty.");
                });

                Test("Zero capacity throws", () =>
                {
                    AssertThrows<ArgumentOutOfRangeException>(
                        () => new SimpleQueue<int>(0));
                });

                Test("Negative capacity throws", () =>
                {
                    AssertThrows<ArgumentOutOfRangeException>(
                        () => new SimpleQueue<int>(-1));
                });

                // 2. Basic FIFO operations

                Test("Enqueue one item", () =>
                {
                    var q = new SimpleQueue<int>();
                    q.Enqueue(10);

                    Assert(!q.IsEmpty, "Queue should not be empty.");
                    AssertEqual(10, q.Peek(), "Incorrect front.");
                });

                Test("FIFO order", () =>
                {
                    var q = new SimpleQueue<int>();
                    q.Enqueue(10);
                    q.Enqueue(20);
                    q.Enqueue(30);

                    AssertEqual(10, q.Peek(), "Expected 10.");
                    q.Dequeue();

                    AssertEqual(20, q.Peek(), "Expected 20.");
                    q.Dequeue();

                    AssertEqual(30, q.Peek(), "Expected 30.");
                });

                Test("Dequeue last item makes queue empty", () =>
                {
                    var q = new SimpleQueue<int>();
                    q.Enqueue(10);
                    q.Dequeue();

                    Assert(q.IsEmpty, "Queue should be empty.");
                });

                // 3. Empty queue exceptions

                Test("Dequeue on empty throws", () =>
                {
                    var q = new SimpleQueue<int>();

                    AssertThrows<InvalidOperationException>(
                        () => q.Dequeue());
                });

                Test("Peek on empty throws", () =>
                {
                    var q = new SimpleQueue<int>();

                    AssertThrows<InvalidOperationException>(
                        () => q.Peek());
                });

                Test("Display on empty throws", () =>
                {
                    var q = new SimpleQueue<int>();

                    AssertThrows<InvalidOperationException>(
                        () => q.Display());
                });

                // 4. Full queue exceptions

                Test("Enqueue beyond capacity throws", () =>
                {
                    var q = new SimpleQueue<int>(3);
                    q.Enqueue(1);
                    q.Enqueue(2);
                    q.Enqueue(3);

                    AssertThrows<InvalidOperationException>(
                        () => q.Enqueue(4));
                });

                Test("Failed enqueue preserves existing items", () =>
                {
                    var q = new SimpleQueue<int>(2);
                    q.Enqueue(10);
                    q.Enqueue(20);

                    AssertThrows<InvalidOperationException>(
                        () => q.Enqueue(30));

                    AssertEqual(10, q.Peek(), "Front changed.");
                    q.Dequeue();

                    AssertEqual(20, q.Peek(), "Second item was lost.");
                });

                // 5. Linear queue behavior:
                // Freed positions cannot be reused until fully empty.

                Test("Cannot reuse freed position before empty", () =>
                {
                    var q = new SimpleQueue<int>(3);
                    q.Enqueue(1);
                    q.Enqueue(2);
                    q.Enqueue(3);

                    q.Dequeue();

                    AssertEqual(2, q.Peek(), "Front should be 2.");

                    AssertThrows<InvalidOperationException>(
                        () => q.Enqueue(4));
                });

                Test("Cannot enqueue after partial dequeue at array end", () =>
                {
                    var q = new SimpleQueue<int>(3);
                    q.Enqueue(1);
                    q.Enqueue(2);
                    q.Enqueue(3);

                    q.Dequeue();
                    q.Dequeue();

                    AssertEqual(3, q.Peek(), "Front should be 3.");

                    AssertThrows<InvalidOperationException>(
                        () => q.Enqueue(4));
                });

                Test("Can enqueue again after becoming completely empty", () =>
                {
                    var q = new SimpleQueue<int>(3);
                    q.Enqueue(1);
                    q.Enqueue(2);
                    q.Enqueue(3);

                    q.Dequeue();
                    q.Dequeue();
                    q.Dequeue();

                    Assert(q.IsEmpty, "Queue should be empty.");

                    q.Enqueue(99);

                    AssertEqual(99, q.Peek(), "Refill failed.");
                });

                Test("Repeated complete fill and empty cycles", () =>
                {
                    var q = new SimpleQueue<int>(3);

                    for (int cycle = 0; cycle < 10; cycle++)
                    {
                        q.Enqueue(cycle * 10 + 1);
                        q.Enqueue(cycle * 10 + 2);
                        q.Enqueue(cycle * 10 + 3);

                        q.Dequeue();
                        q.Dequeue();
                        q.Dequeue();

                        Assert(q.IsEmpty,
                            $"Queue not empty after cycle {cycle}.");
                    }
                });

                // 6. Capacity of one

                Test("Capacity one accepts one item", () =>
                {
                    var q = new SimpleQueue<int>(1);
                    q.Enqueue(10);

                    AssertEqual(10, q.Peek(), "Incorrect front.");

                    AssertThrows<InvalidOperationException>(
                        () => q.Enqueue(20));
                });

                Test("Capacity one can be reused after empty", () =>
                {
                    var q = new SimpleQueue<int>(1);
                    q.Enqueue(10);
                    q.Dequeue();
                    q.Enqueue(20);

                    AssertEqual(20, q.Peek(), "Reuse failed.");
                });

                // 7. Special values and generic types

                Test("Zero is a valid item", () =>
                {
                    var q = new SimpleQueue<int>();
                    q.Enqueue(0);

                    Assert(!q.IsEmpty, "Zero must not indicate empty.");
                    AssertEqual(0, q.Peek(), "Zero was lost.");
                });

                Test("Negative values are valid items", () =>
                {
                    var q = new SimpleQueue<int>();
                    q.Enqueue(-10);

                    AssertEqual(-10, q.Peek(), "Negative value was lost.");
                });

                Test("String queue preserves FIFO", () =>
                {
                    var q = new SimpleQueue<string>();
                    q.Enqueue("first");
                    q.Enqueue("second");

                    AssertEqual("first", q.Peek(), "Incorrect first string.");
                    q.Dequeue();

                    AssertEqual("second", q.Peek(), "Incorrect second string.");
                });

                Test("Null is a valid reference-type item", () =>
                {
                    var q = new SimpleQueue<string>();
                    q.Enqueue(null);
                    q.Enqueue("hello");

                    Assert(!q.IsEmpty, "Queue should not be empty.");
                    AssertEqual<string>(null, q.Peek(), "Expected null.");

                    q.Dequeue();

                    AssertEqual("hello", q.Peek(), "Expected hello.");
                });

                // 8. Display smoke test.
                // Your reversed display order is intentionally preserved.

                Test("Display populated queue does not throw", () =>
                {
                    var q = new SimpleQueue<int>();
                    q.Enqueue(10);
                    q.Enqueue(20);
                    q.Enqueue(30);

                    q.Display();
                    Console.WriteLine();
                });

                // 9. Stress test with a linear queue

                Test("FIFO stress test", () =>
                {
                    var q = new SimpleQueue<int>(100);

                    for (int i = 1; i <= 100; i++)
                        q.Enqueue(i);

                    for (int i = 1; i <= 100; i++)
                    {
                        AssertEqual(i, q.Peek(),
                            $"Incorrect front at item {i}.");

                        q.Dequeue();
                    }

                    Assert(q.IsEmpty, "Queue should be empty after draining.");
                });

                // Results

                Console.WriteLine("\n========== RESULTS ==========");
                Console.WriteLine($"Passed: {passed}");
                Console.WriteLine($"Failed: {failed}");
                Console.WriteLine($"Total:  {passed + failed}");

                Console.ReadKey();
            }
        }
    }

    


