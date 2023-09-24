using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }

    private Node Head { get; set; }
    private Node Tail { get; set; }
    public int Count { get; private set; }

    public void AddFirst(T value)
    {
        Node newNode = new Node(value);

        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Next = Head;
            Head.Previous = newNode;
            Head = newNode;
        }

        Count++;
    }

    public void AddLast(T value)
    {
        Node newNode = new Node(value);

        if (Tail == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Previous = Tail;
            Tail.Next = newNode;
            Tail = newNode;
        }

        Count++;
    }

    public bool Remove(T value)
    {
        Node currentNode = Head;

        while (currentNode != null)
        {
            if (EqualityComparer<T>.Default.Equals(currentNode.Value, value))
            {
                if (currentNode.Previous != null)
                {
                    currentNode.Previous.Next = currentNode.Next;
                }
                else
                {
                    Head = currentNode.Next;
                }

                if (currentNode.Next != null)
                {
                    currentNode.Next.Previous = currentNode.Previous;
                }
                else
                {
                    Tail = currentNode.Previous;
                }

                Count--;
                return true;
            }

            currentNode = currentNode.Next;
        }

        return false;
    }

    public void Print()
    {
        Node currentNode = Head;

        while (currentNode != null)
        {
            Console.WriteLine(currentNode.Value);
            currentNode = currentNode.Next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node currentNode = Head;

        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // Индексатор
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            Node currentNode = Head;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            return currentNode.Value;
        }
        set
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            Node currentNode = Head;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Value = value;
        }
    }
}
