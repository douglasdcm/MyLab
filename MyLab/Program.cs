using System;

namespace MyLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //*event study
            //EventArgTest.AddOneUsingCharA();
            //EventProgram.Run();
            //MyEventStudy mes = new MyEventStudy();
            //mes.CallEvent();

            //NotifyOnCreate noc = new NotifyOnCreate();
            //noc.Create("joao");
            //noc.Create("maria");
            //noc.Create("jose");
            //noc.Create("santana");
            //noc.Create("sair");

            NotifyOnCreate noc = new NotifyOnCreate();
            noc.Create("test");
            noc.Create("test2");
            noc.Create("test3");
            noc.Create("sair");

        }

    }
}
