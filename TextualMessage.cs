using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBookApplication
{
    internal class TextualMessage : IPageable
    {
        protected PageData myData;
        protected string message;


        public virtual IPageable Input()
        {
            Console.WriteLine("please input your name");
            myData.author = Console.ReadLine();
            Console.WriteLine("please input the message title");


            myData.title = Console.ReadLine();
            Console.WriteLine("please input the message");
            message = Console.ReadLine();

            return this;

        }

        public void Output()
        {
            Console.WriteLine();
            Console.WriteLine($"/----------- Message -----------");
            Console.WriteLine($"Title:\t {myData.title}");
            Console.WriteLine($"Author:\t {myData.author}");
            Console.WriteLine($"Message:\t \n \n {message}");
            Console.WriteLine($"/-----------\t-----------");


        }
        public PageData MyData
        {
            get { return myData; }
            set { myData = value; }
        }
    }
}
