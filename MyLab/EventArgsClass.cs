using System;
using System.Collections.Generic;
using System.Text;

namespace MyLab
{
    class Counter
    {
        private int threshold;
        private int total;

        public Counter(int passedThreshold)
        {
            threshold = passedThreshold;
        }

        public void Add(int x)
        {
            total += x;
            if (total >= threshold)
            {
                ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
                args.Threshold = threshold;
                args.TimeReached = DateTime.Now;

                //pass the values to event handler
                OnThresholdReached(args);

            }
        }

        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            //the hander receives the method binded  int the instance of the delegate
            EventHandler<ThresholdReachedEventArgs> handler = ThresholdReached;
            if (handler != null)
            {
                //invoke the delegate passing the Counther class and the EventArgs
                handler(this, e);
            }
        }

        //define the event
        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;
    }

    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }

    public class EventArgTest
    {
        public static void AddOneUsingCharA()
        {
            //*event args study
            Counter c = new Counter(new Random().Next(10));

            //instantiate the delegate with the method that print a message and exit the program
            c.ThresholdReached += c_ThresholdReached;

            Console.WriteLine("press 'a' key to increase total");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one");
                c.Add(1);
            }
        }

        static void c_ThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
            Environment.Exit(0);
        }
    }
}
