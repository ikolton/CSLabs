//program using ArrayList

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//namespace
namespace Zad3_3
{
    //i don't know how to use array instead of array list in inheritance
    class QueueInheritance : ArrayList
    {
        private int front = 0;

        public void Enqueue(Object value) 
        {
            this.Add(value);
        }

        public Object Dequeue() 
        {
            if (this.Count == 0 || front > this.Count - 1)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            Object value = this[front];
            front++;
            return value;
        }
    }
    
    class QueueComposition
    {
        private Object[] array = new Object[100]; // Initial size of 100, can be changed as needed
        private int front = 0;
        private int rear = -1;
        private int size = 0;

        public void Enqueue(Object value) 
        {
            if (size == array.Length)
            {
                throw new InvalidOperationException("Queue is full");
            }
            rear = (rear + 1) % array.Length;
            array[rear] = value;
            size++;
        }

        public Object Dequeue() 
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            Object value = array[front];
            front = (front + 1) % array.Length;
            size--;
            return value;
        }
    }


}