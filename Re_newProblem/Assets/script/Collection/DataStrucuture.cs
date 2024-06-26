using System;
using UnityEngine;

namespace DataStrucuture
{
    public class LinkedListNode<T>
    {
        public T Data { get; set; }
        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class LinkedList<T>
    {
        public LinkedListNode<T> head;

        public LinkedList()
        {
            head = null;
        }

        public void Add(T data)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(data);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                LinkedListNode<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }
    }

    public class Queue<T>
    {
        private LinkedList<T> list;

        public Queue()
        {
            list = new LinkedList<T>();
        }

        // 큐에 요소를 추가합니다.
        public void Enqueue(T data)
        {
            list.Add(data);
        }

        // 큐에서 요소를 제거하고 반환합니다.
        public T Dequeue()
        {
            if (list.head == null)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T data = list.head.Data;
            list.head = list.head.Next;
            return data;
        }

        // 큐가 비어 있는지 확인합니다.
        public bool IsEmpty()
        {
            return list.head == null;
        }
    }

    public class Stack<T>
    {
        private Queue<T> Fqueue = new Queue<T>();
        private Queue<T> Lqueue = new Queue<T>();

        public Stack() { }

        public void Push(T data)
        {
            while (!Fqueue.IsEmpty())
            {
                Lqueue.Enqueue(Fqueue.Dequeue());
            }

            Fqueue.Enqueue(data);

            while (!Lqueue.IsEmpty())
            {
                Fqueue.Enqueue(Lqueue.Dequeue());
            }
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return Fqueue.Dequeue();
        }

        public bool IsEmpty()
        {
            return Fqueue.IsEmpty();
        }
    }

}
