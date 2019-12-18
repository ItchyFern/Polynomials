/*
Assignment 1: COIS2020H
By: Seth Hannah 0656551
 */


using System;
using System.Collections.Generic;
public class Term:IComparable
{
    public double Coefficient{get;set;}
    public byte Exponent{get;set;}
    // Creates a term with the given coefficient and exponent
    public Term (double coefficient, byte exponent)
    {
        // Set of conditions to make sure that both the exponent and coefficient are proper values
        // exponent between 0 and 255, coefficient not equal to 0
        if (Math.Round(coefficient,1) == 0)
        {
            System.Console.WriteLine("Coefficient value can't be 0, setting to 1 instead.");
            coefficient = 1;
        }

        //Once checks are done, set the checked values to the class variables
        Coefficient = coefficient;
        Exponent = exponent;
    }

    // Evaluates the current term for a given x
    public double Evaluate (double x)
    {
        //using math.pow, multiply the coefficient by the value x raised to the power of the exponent
        return Coefficient*Math.Pow(x,Exponent);
    }

    // Returns -1, 0, or 1 if the exponent of the current term
    // is less than, equal to, or greater than the exponent of obj.
    public int CompareTo(object obj)
    {
        Term temp = (Term)obj;
        if (Exponent>temp.Exponent)
        {
            return 1;
        }
        else if(Exponent ==temp.Exponent)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }
    // Read and write properties for each data member
}
