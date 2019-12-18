/*
Assignment 1: COIS2020H
By: Seth Hannah 0656551
 */


using System;


namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynomials MyPolynomials = new Polynomials();

            //Options

            //0. Exit program
            //1. Create polynomial and insert it into the list
            //2. Add two polynomial together and insert result into list
            //3. Multiply two polynomials and insert
            //4. Delete Polynomial at given index
            //5. Evaluate polynomial

            //declare variable for later use
            Polynomial temppoly;

            //While menu has not been exited by user
            while (true)
            {
                System.Console.WriteLine("\n\n\n\nAssignment 1 Main Menu");
                System.Console.WriteLine("Please choose one of the options below");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("0. Exit program");
                System.Console.WriteLine("1. Create polynomial");
                System.Console.WriteLine("2. Add two polynomials");
                System.Console.WriteLine("3. Multiply two polynomials");
                System.Console.WriteLine("4. Delete a polynomial");
                System.Console.WriteLine("5. Evaluate a polynomial at a given x\n");
                System.Console.Write("Choose a number: ");

                //get choice by user
                string entry = System.Console.ReadLine();

                //User exits the program
                if (entry.Equals("0")){
                    Environment.Exit(0);
                }
                //create a temporary polynomial for use
                temppoly = new Polynomial();

                //User adding terms
                if (entry.Equals("1")){
                    System.Console.WriteLine("Press x at anytime to finish adding terms");

                    //Variables used to gather user input
                    int tempce = 0;
                    byte tempe = 0;
                    string entry1 = "";

                    //Until user presses x, add Coefficient and Exponent
                    //If user enters 0 for Coefficient, will prompt user
                    //to reenter term.
                    while(true)
                    {
                        try
                        {
                            System.Console.Write("Coefficient: ");
                            entry1 = System.Console.ReadLine();
                            if (entry1.Contains("x")){break;}
                            tempce = System.Convert.ToInt32(entry1);

                            System.Console.Write("Exponent: ");
                            entry1 = System.Console.ReadLine();
                            if (entry1=="x"){break;}
                            tempe = System.Convert.ToByte(entry1);

                            temppoly.AddTerm(new Term(tempce, tempe));

                        }
                        //Any invalid input will be caught and have a message returned
                        catch
                        {
                            System.Console.WriteLine("Error, try again.");
                        }
                    }

                    //add the newly created term to list of polynomials
                    if (temppoly.count>0){
                        MyPolynomials.Insert(temppoly);
                        System.Console.Write("\nPolynomial Added: ");
                        temppoly.Print();
                    }
                }
                //User tries to add Polynomial
                if (entry.Equals("2")){

                    //temp variables
                    string entry2 = "";
                    int polychoice1 = 0;
                    int polychoice2 = 0;

                    //Ask user to select desire polynomials to add
                    while(true && MyPolynomials.P.Count>0)
                    {
                        try
                        {
                            System.Console.Write("First Polynomial: ");
                            entry2 = System.Console.ReadLine();
                            polychoice1 = System.Convert.ToInt32(entry2);

                            System.Console.Write("Second Polynomial: ");
                            entry2 = System.Console.ReadLine();
                            polychoice2 = System.Convert.ToInt32(entry2);

                            //Add polynomials together and exit to main
                            temppoly = MyPolynomials.Retrieve(polychoice1-1)+MyPolynomials.Retrieve(polychoice2-1);
                            break;
                        }

                        //Any invalid user input prints a message and prompts
                        //them to select again.
                        catch
                        {
                            System.Console.WriteLine("Error, try again.");
                        }
                    }
                    //Add the polynomial to the list
                    if (temppoly.count>0){
                        MyPolynomials.Insert(temppoly);
                        System.Console.Write("\nPolynomial Added: ");
                        temppoly.Print();
                    }
                }

                //User selects to multiply polynomials
                if (entry.Equals("3")){

                    //temp variables
                    string entry2 = "";
                    int polychoice1 = 0;
                    int polychoice2 = 0;

                    //While the list is not empty
                    while(true && MyPolynomials.P.Count>0)
                    {
                        try
                        {
                            System.Console.Write("First Polynomial: ");
                            entry2 = System.Console.ReadLine();
                            polychoice1 = System.Convert.ToInt32(entry2);

                            System.Console.Write("Second Polynomial: ");
                            entry2 = System.Console.ReadLine();
                            polychoice2 = System.Convert.ToInt32(entry2);

                            //Multiply polynomials and add it to new polynomial
                            temppoly = MyPolynomials.Retrieve(polychoice1-1)*MyPolynomials.Retrieve(polychoice2-1);
                            break;
                        }

                        //Invalid user input prints message and prompts
                        //to make another selection
                        catch
                        {
                            System.Console.WriteLine("Error, try again.");
                        }
                    }

                    //Add polynomial to list of polynomials
                    if (temppoly.count>0){
                        MyPolynomials.Insert(temppoly);
                        System.Console.Write("\nPolynomial Added: ");
                        temppoly.Print();
                    }
                }

                //User deletes item
                if (entry.Equals("4"))
                {
                    //Temp variables
                    string entry2 = "";
                    int delchoice = 0;

                    //While there is something to delete in the list of polynomials
                    while(true && MyPolynomials.P.Count>0)
                    {
                        try
                        {
                            System.Console.Write("Polynomial to Delete: ");
                            entry2 = System.Console.ReadLine();
                            delchoice = System.Convert.ToInt32(entry2);

                            System.Console.WriteLine("\nPolynomial deleted.");

                            //Delete Polynomial
                            MyPolynomials.Delete(delchoice);
                            break;
                        }

                        //Invalid user input returns error
                        //and for user to make another choice
                        catch
                        {

                            System.Console.WriteLine("Error, try again.");
                        }
                    }
                }

                //User wants to evaluate over a given x
                if (entry.Equals("5")){
                    string entry2 = "";
                    double xchoice = 0;
                    int polychoice = 0;

                    //While the list of polynomials is not empty
                    while(true && MyPolynomials.P.Count>0)
                    {
                        try
                        {
                            System.Console.Write("Polynomial to Evaluate: ");
                            entry2 = System.Console.ReadLine();
                            polychoice = System.Convert.ToInt32(entry2);

                            System.Console.Write("X Value: ");
                            entry2 = System.Console.ReadLine();
                            xchoice = System.Convert.ToDouble(entry2);
                            System.Console.Write("\nPolynomial{0}({1}) = ",polychoice, xchoice);

                            //Evalute the Term
                            System.Console.WriteLine(MyPolynomials.Retrieve(polychoice-1).Evaluate(xchoice));
                            break;
                        }

                        //Invalid user input returns error message
                        //and prompts user to make another selection
                        catch
                        {
                            System.Console.WriteLine("Error, try again.");
                        }
                    }
                }

                //Print List to user
                System.Console.WriteLine("\nYour polynomial list:");
                MyPolynomials.Print();
                System.Console.WriteLine("End of your polynomials\n");


            }




        }
    }
}
