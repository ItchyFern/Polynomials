/*
Assignment 1: COIS2020H
By: Seth Hannah 0656551
 */

interface IDegree
{
    bool Order(object obj);
}
public class Polynomial:IDegree
{
    // A reference to the first node of a singly-linked list
    private Node<Term> front;

    //Counter used in special conditions
    public int count{get;set;}

    // Creates the polynomial 0
    public Polynomial ( )
    {
      	//set front to null
        front = new Node<Term> (null);

      	//Set Counter to 0 to represent empty Linked list
        count = 0;
    }

    //method for checking if the polynomial has any 0 coefficient terms and removes them
    private void RemoveZeros()
    {
      	//While front is not null
        if (front.next!=null){

            //create a new node before front
            Node<Term> n = front;
            /*
            if (front.item.Coefficient == 0)
            {
                front=front.next;
            }
            else
            {
              */
          		//while next is not null
                while (n.next!=null)
                {
                  //if item is equal to 0
                    if (n.next.item.Coefficient == 0)
                    {
                      //remove item from list
                        n.next=n.next.next;
                      	count--;
                    }
                  //move to the next node
                    n=n.next;
                }

            //}
        }

    }

    // Inserts the given term t into the current polynomial in its proper order
    public void AddTerm (Term t)
    {
        //check any special cases, such as if the list is empty
        //special case 1, there isn't any terms in the list yet
        if (count==0)
        {
            //set the term to equal the first term in the list
            front.next=new Node<Term>(t, null);

            //Item has been added to the list
            count++;
        }
        else
        {
            //create dummy node pointing to the front variable to allow the loop to add the new term in and replace front
            Node<Term> n = front;

            //loop iterating through the list using n=n.next
            //during this, it will check whether or not it should be entering the term into the list
          	//if it passes fully though the list, then it will add the term to the end
            //flag used for special case; two terms added together on the end of the list equaling 0
          	bool flag = true;
          	while(n.next!=null)
            {
                // if the added term exponent is greater than the term exponent in the polynomial
                if (t.CompareTo(n.next.item)>0)
                {

                    //1. create new node which holds new term
                    //2. Have new node reference what n.next was referencing
                    //3. Have n.next reference the newly created node
                    n.next = new Node<Term>(t, n.next);

                    //Increase value of count to reflect added term
                    count++;
                    break;
                }
                // if the added term exponent is equal to the term exponent in the polynomial
                // in this case, add the coefficients together
                else if (t.CompareTo(n.next.item)==0)
                {
                    n.next.item.Coefficient = (n.next.item.Coefficient)+(t.Coefficient);
                  	//if the coefficient is 0, remove it from the list and flip the flag
                  	if (n.next.item.Coefficient==0){flag=false;n.next=n.next.next;count--;}
                    break;
                }
                //Cycle through the list, and check against the next term
                else
                {
                  	//move to the next term and continue
                    n=n.next;
                }
            }
            //Add the new term to the end of the list, referencing null as its next
            if (n.next==null && flag)
            {
                n.next = new Node<Term>(t);
                count++;
            }
        }
    }






    // Adds the given polynomials p and q to yield a new polynomial
    public static Polynomial operator + (Polynomial p, Polynomial q)
    {
        //New Polynomial to return result of opreator +
        Polynomial ret = new Polynomial();

        //Node n containing front's term and next
        Node<Term> n = new Node<Term>(p.front.next.item, p.front.next.next);
        //run through a loop for each of the polynomials, just repeatedly using the AddTerm method
        //on a new empty polynomial

        while (n!=null)
        {
            //Add term from Polynomial p to new polynomial
            ret.AddTerm(new Term(n.item.Coefficient, n.item.Exponent));

          	//Move to next node
            n=n.next;
        }

		//n equals polynomail q
        n = new Node<Term>(q.front.next.item, q.front.next.next);

        while (n!=null)
        {
          	//Add Terms from Polynomial q to new Polynomial
            ret.AddTerm(new Term(n.item.Coefficient, n.item.Exponent));
          	//Move to next node
            n=n.next;
        }

        ret.RemoveZeros();

        //Return new polynomial
        return ret;

    }

    // Multiplies the given polynomials p and q to yield a new polynomial
    public static Polynomial operator * (Polynomial p, Polynomial q)
    {
        //create the new empty (to be filled) returning polynomial
        Polynomial ret = new Polynomial();

        //Reference to 2 new nodes
        Node<Term> n,m;

      	//Node 1 points to front of polynomial p
        n=p.front.next;

        //create nested loop so for each term in p, multiply but each term in q
        while(n!=null)
        {
            //Node 2 points to front of polynomial q
            m=q.front.next;
            while(m!=null)
            {
                //Multiply Coefficients
                double c = n.item.Coefficient * m.item.Coefficient;
                //Add Exponents
                int e = n.item.Exponent+m.item.Exponent;

                //Defaults exponent to 255 if it becomes greater
                if (e>255)
                {
                    System.Console.WriteLine("Exponent Above Range (255), setting to 255.");
                    e = 255;
                }
                //create new term and add it to the return polynomial
                ret.AddTerm(new Term(c,(byte)e));

                //Move to next node
                m=m.next;
            }
          	//Mov to next node
            n=n.next;
        }

        ret.RemoveZeros();

        //Return new Polynomial
        return ret;
    }

    // Evaluates the current polynomial for a given x
    public double Evaluate (double x)
    {
        Node<Term> n = front.next;
        //Used to return result of evaluate
      	double ret = 0;

      	while (n!=null)
        {
          	ret = ret + n.item.Evaluate(x);
            //Move to next node
        	n = n.next;
        }

        //Return result
      	return ret;

    }

    // Prints the current polynomial
    public void Print ( )
    {
        Node<Term> n = front.next;
        while(n.next != null)
        {
            System.Console.Write("({0})x^{1}  +  ", n.item.Coefficient, n.item.Exponent);
            n = n.next;
        }
        System.Console.WriteLine("({0})x^{1}", n.item.Coefficient, n.item.Exponent);
    }

    public bool Order(object obj)
    {
        Polynomial temp = (Polynomial)obj;
        if (front.next.item.Exponent>=temp.front.next.item.Exponent)
        {
            return true;
        }
        return false;
    }
}
