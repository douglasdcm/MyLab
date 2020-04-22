using System;
using System.Collections.Generic;
using System.Text;

namespace MyLab
{
    //define a delegate
    public delegate string MyDel(string str);
    public delegate bool MyDelegate(int i, string s, double d);
    public delegate void NotifySubscribers(string list);

    class EventProgram
    {
        //declare an event to invoke the delegate
        event MyDel MyEvent;

        public EventProgram()
        {
            //instantiation of the event in one line
            //bind a delegate with a method (string (string u))to the event
            //this.MyEvent += new MyDel(this.WelcomeUser);

            //intantiation of the event in two lines
            //instantiate the delegate
            MyDel d = new MyDel(this.WelcomeUser);

            //bind the delegate to the event
            MyEvent += d;
        }

        public string WelcomeUser(string username)
        {
            return "Welcome " + username;
        }

        public static void Run()
        {
            EventProgram obj1 = new EventProgram();
            //send the "Douglas" to the event that involkes the delegate
            //That call the method WelcomeUser
            string result = obj1.MyEvent("Douglas");
            Console.WriteLine(result);
        }
    }

    class MyEventStudy
    {
        //define delegate
        //see the namespace

        //declare the event pointing to the delegate
        public event MyDelegate MyEvent;

        //instantiate the delegate and bind to the event
        public void CallEvent()
        {
            //instance of the delegate
            //add a lambda function to the delegate
            MyDelegate md = new MyDelegate( (i, s, d) =>
            {
                Console.WriteLine("The int i is {0}", i);
                if (i >= 1)
                {

                    return false;
                }
                return true;
            });
            
            //bind the delegate to the event
            MyEvent += md;

            //call the event
            MyEvent.Invoke(1, "str", 1.2);
        }
    }

    //if the create is called, send a messgae to subscribers with the name created
    public class NotifyOnCreate
    {
        event NotifySubscribers EventNotify;
        IList<string> list = new List<string>();
        public void Create(string name)
        {
            //prepare the notify list
            Notify(name);

            if (name == "sair")
            {
                EventNotify.Invoke(name);
            }
        }

        //call the event
        public void Notify(string name)
        {
            list.Add(name);

            //instantiate the delegate
            NotifySubscribers ns = new NotifySubscribers( (l) =>
           {
               Console.WriteLine("Welcome {0}", name);
           });

            //bind the delegate to the event
            EventNotify += ns;
        }
        
    }

    public class NotifyOnCreateUsingEventHadler
    {
        //define the event that receives the delegate
        event EventHandler<EventArgs> EventNotify;
        int i = 0; //counter
        public void Create(string name)
        {
            //prepare the notify list
            Notify();

            if (name == "sair")
            {
                //invoke the notify
                EventNotify.Invoke(this, new EventArgs());
            }
        }

        //call the event
        public void Notify()
        {
            //instantiate the delegate
            EventHandler<EventArgs> eg = new EventHandler<EventArgs>( (s, e) =>
            {         
                i += 1;
                Console.WriteLine("Called {0} times.", i);
            });

            //bind the delegate to the event
            EventNotify += eg;
        }

    }    
}
