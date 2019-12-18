/*
Assignment 1: COIS2020H
By: Seth Hannah 0656551
 */

public class Node<T>
{
    public T item {get;set;}

    public Node<T> next {get;set;}

    public Node (T item, Node<T> next=null)
    {
        this.item = item;
        this.next = next;
    }
    // Read and write properties for each data member
}
