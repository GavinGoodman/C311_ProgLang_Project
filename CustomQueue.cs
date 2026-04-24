/*
Name: Gavin Goodman
Class: CSCI - C311 Programming Languages
Date: April 9, 2026
Program Name: CustomQueue.cs

General Description:
This is our custom queue class that will store information about
the matches in nodes to be accessed and obtained in use of the 
general analyzer. IN this class, we have the general queue structure 
as taught in Data Structure of a public queue with a private Node. 
This will give the public Match data and public Node next for pointers
and getting information from Match objects. It will also have a public 
Node storing the match data as an argument with data being the match
data value and the next point set to null. We also have the queue 
functions of enqueue, dequeue, peek, isEmpty, displayQueue, and we
have a method getMatchAt to find a specific match in the queu as well. 
This is the general queue function and class we will implement.
*/

using System;                               // allows use of system namespace

public class CustomQueue
/*
This is the public CustomQueue class that encapsulates this whole file for
use. Within this class, we house the methods from the general description in the
class. Additionally, we have the class of the Node and the data it will store. 
The node specifically is created, storing the match data which will allow it 
to be accessed and utilized to form the insights needed to run the program.
*/
{
    private class Node
    /*
    This is the private Node class within the CustomQueue class. This is 
    how the node is not only created but also gets the information to be stored.
    This outer node class is for the node structure, creating the Match data and
    Node next variable as a pointer. The inner Public Node with parameter Match
    matchData will store the individual match data and put the next pointer to
    null but will be used to point to other nodes in the queue as it fills.
    */
    {
        public Match data;                          // variable for Match object
        public Node next;                           // Node pointer to next in queue 

        public Node(Match matchData)                // Node creation process for what is stored
        {
            data = matchData;                       // stores the match information and 
            next = null;                            // pointer to the next node in queue
        }
    }

    private Node front;                             // Node to point to front of queue 
    private Node back;                              // Node to point to back of the queue
    private int size;                               // variable to track size of queue

    public CustomQueue()
    /*
    This is the custom queue constructor. This is a no argument constructor
    as well. In this constructor, we are instatiating the custom queue object 
    and setting the front and back points to null with size set to zero.
    */
    {
        front = null;
        back = null;
        size = 0;
    }

    public void enqueue(Match data)
    /*
    This is the queue's enqueue function. This will take a match object that
    is created and allow it to be enqueued into the queue. This is done by
    created a newNode with the match information. If the queue is empty, it 
    will set both nodes to the front and back, but if there are other objects
    already, the next node for back will point to the newNode, essentially creating
    a new node and then point to the back. In both cases, we will increment size.
    */
    {
        Node newNode = new Node(data);                  // Node creation for match data

        if (front == null)                              // checks if the queue is empty
        {                                               // to properly enqueue the first
            front = newNode;                            // match object
            back = newNode;
        }
        else
        {                                               // if queue is not empty, it will
            back.next = newNode;                        // put the new node at the back
            back = newNode;                             // of the queue.
        }

        size++;                                         // size is incremented
    }

    public Match dequeue()
    /*
    This is the dequeue method of the queue, its purpose is to remove the front
    of the queue object and decrement the size of the queue. It will also return
    the information of the Match object being removed as a result of this. We will
    first check to see if the queue is empty. If this is true, we will let the user
    know that the queue is empty. If not empty, we will get the front queue pointer
    information and move the front pointer forward. If this happens to empty the 
    queue, we will set back to null so both are pointing to null again. Otherwise
    we will decrement the size variable of the queue and return the object information.
    */
    {
        if (front == null)                                                  // checks to see if the queue is empty
        {
            Console.WriteLine("Queue is empty, no operation done.");        // if empty, will let user know
            return null;
        }
        else
        {
            Match info = front.data;                                        // If the queue is not empty, we will
            front = front.next;                                             // retreive the first node information on
            if (front == null)                                              // the match and return it. This will
            {                                                               // set the back pointer to null if the
                back = null;                                                // operation empties the queue and decrement
            }                                                               // the size variable of the queue
            size--;
            return info;
        }
    }

    public Match peek()
    /*
    This is the typical peek operation of the queue and is very similar to the 
    dequeue operatoin; however, it will not remove a node and delete it. The
    purpose of this operation is to return the match object at the front of the
    queue. It does this again by checking if the queue is empty and returning a
    message stating it is if this is true. If not, we will get the information
    form the front point Match object and return it to the user to see. 
    */
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
    /*
    This is the method that checks if the queue is empty and is more of a 
    helper in the custom queue versus a mandatory function. In this method,
    there is one line where it will return true if the front pointer is null.
    */
    {
        return front == null;
    }

    public int getSize()
    /*
    This method, again, is not needed but is a good helper for the queue class.
    In this method, we are simply returning the size of the queue that is altered
    when enqueue and dequeue operations are called, it is used heavily in 
    some of the other classes when totaling or averaging stats for the player.
    */
    {
        return size;
    }

    public Match getMatchAt(int queueIndex)
    /*
    This is a custom method I created to get information from specific matches at
    any points in the queue and is used to compare two back to back matches for trends
    in the player with less of a sample size. We first check if the size of the queue 
    entered is good to use. If this is not, a message will be returned and if it is
    true, it will operate. In the operation we will initialize a current node at front
    and int index variable to 0. This will then increment current to the next node and 
    increment the index to find the node sought after. Once found, it will let the user
    know and provide the information or allow access to that information to be used/
    */
    {
        if (queueIndex < 0 || queueIndex >= size)               // checks if queue size entered is correct
        {
            return null;
        }

        Node current = front;                                   // Node current points to the front of 
        int currIndex = 0;                                      // the queue and a variable tracks an the
                                                                // current index being looked at in queue
        while (current != null)                                 // while the queue is not empty, it will 
        {                                                       // check to see if current index is equal 
            if (currIndex == queueIndex)                        // to input queueIndex. If true, allows
            {                                                   // access to match information If not,
                return current.data;                            // it will go to the next node in queue.
            }

            current = current.next;
            ++currIndex;
        }

        return null;
    }

    public void displayQueue()
    /*
    This is a simple method to display the contents of the queue and utilizes
    the toString within the Match class file to print each match information
    for the user to read the match specific statistics stored in the queue.
    */
    {
        Node current = front;                                       // starts in the front of
        int matchNumber = 1;                                        // the queue and will iterate
                                                                    // through the entire queue
        while (current != null)
        {
            Console.WriteLine("Match Number " + matchNumber + " Data: " + current.data + "\n");
            current = current.next;
            ++matchNumber;
        }
        Console.WriteLine();
    }
}