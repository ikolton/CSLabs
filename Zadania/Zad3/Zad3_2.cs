//program using ArrayList

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//namespace
namespace Zad3_2
{
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
        private ArrayList list = new ArrayList();
        private int front = 0;

        public void Enqueue(Object value) 
        {
            list.Add(value);
        }

        public Object Dequeue() 
        {
            if (list.Count == 0 || front > list.Count - 1)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            Object value = list[front];
            front++;
            return value;
        }
    }


}