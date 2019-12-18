/*
Assignment 1: COIS2020H
By: Seth Hannah 0656551
 */

using System;
using System.Collections.Generic;
public class Polynomials
{
    public List<Polynomial> P;

    // Creates an empty list of polynomials
    public Polynomials ( )
    {
        P = new List<Polynomial>();
    }

    // Retrieves the polynomial stored at position i-1 in the list
    public Polynomial Retrieve (int i)
    {
        if (i>P.Count || i<0)
        {
            System.Console.WriteLine("There is/are only {0} polynomial(s) to choose from.", P.Count);
            System.Console.WriteLine("Choosing first item in the list instead");
            return P[0];

        }
        else
        {
            return P[i];
        }

    }

    // Inserts polynomial p into the list of polynomials
    public void Insert (Polynomial p)
    {
        //create flag to know whether or not it broke out of the loop early
        bool flag = true;
        //loop to compare to all values in list
        for(int x = 0; x<P.Count; x++)
        {
            //Check to see if polynomial p is not greater than or equal to polynomial P at x
            if (!P[x].Order(p))
            {
                // insert polynomial p at location x
                P.Insert(x,p);
                //change breakout flag to false then break
                flag = false;
                break;
            }
        }
        //if it exits by finishing the for loop (not breaking out)
        //just add entry to the end of the list
        if (flag)
        {
            P.Add(p);
        }
    }

    // Deletes the polynomial at index i-1
    public void Delete (int i)
    {
        P.RemoveAt(i-1);
    }

    // Prints out the list of polynomials (beginning with polynomial 1)
    public void Print ( )
    {
        int x;
        //loop through all entries of the list printing each
        for(x=0;x<P.Count;x++)
        {
            System.Console.Write("{0}. ", x+1);
            P[x].Print();
        }
    }

}
