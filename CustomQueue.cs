using System;

public class CustomQueue
{
    private class Node
    {
        public Match data;
        public Node next;

        public Node(Match matchData)
        {
            data = matchData;
            next = null;
        }
    }

    private Node front;
    private Node back;
    private int size;

    public CustomQueue()
    {
        front = null;
        back = null;
        size = 0;
    }

    public void enqueue(Match data)
    {
        Node newNode = new Node(data);

        if (front == null)
        {
            front = newNode;
            back = newNode;
        }
        else
        {
            back.next = newNode;
            back = newNode;
        }

        size++;
    }

    public Match dequeue()
    {
        if (front == null)
        {
            Console.WriteLine("Queue is empty, no operation done.");
            return null;
        }
        else
        {
            Match info = front.data;
            front = front.next;
            if (front == null)
            {
                back = null;
            }
            size--;
            return info;
        }
    }

    public Match peek()
    {
        if (front == null)
        {
            Console.WriteLine("Queue is empty, no operation done.");
            return null;
        }
        else
        {
            Match info = front.data;
            return info;
        }
    }

    public bool isEmpty()
    {
        return front == null;
    }

    public int getSize()
    {
        return size;
    }

    public Match getMatchAt(int queueIndex)
    {
        if (queueIndex < 0 || queueIndex >= size)
        {
            return null;
        }

        Node current = front;
        int currIndex = 0;

        while (current != null)
        {
            if (currIndex == queueIndex)
            {
                return current.data;
            }

            current = current.next;
            ++currIndex;
        }

        return null;
    }

    public void displayQueue()
    {
        Node current = front;
        int matchNumber = 1;

        while (current != null)
        {
            Console.WriteLine("Match Number " + matchNumber + " Data: " + current.data + "\n");
            current = current.next;
            ++matchNumber;
        }
        Console.WriteLine();
    }
}