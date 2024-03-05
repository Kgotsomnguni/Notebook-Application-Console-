using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NoteBookApplication
{
    internal class TextualImage : IPageable
    {
        private PageData myData;
        private string AsciiImage;


        public IPageable Input()
        {
            Console.WriteLine(" Please input your name");
            myData.author = Console.ReadLine();

            Console.WriteLine(" Please input your image title");
            myData.author = Console.ReadLine();

            Console.WriteLine("start inputting your image . press enter to create as many lines as you like.");
            Console.WriteLine("press Ctrl+D then enter on a single line to stop creating your image");
            bool finishedImage = false;
            while (!finishedImage)
            {
                string input = Console.ReadLine();
                if ((input.Length > 0) && (input[0] == 4))
                {
                    finishedImage = true;
                }
                else
                {
                    AsciiImage += "\t" + input + "\n";
                }

            }
            return this;
        }

        public void Output()
        {
            Console.WriteLine();
            Console.WriteLine($"/----------- IMAGE -----------");
            Console.WriteLine($"Title:\t {myData.title}");
            Console.WriteLine($"Author:\t {myData.author}\n");
            Console.WriteLine(AsciiImage);
            Console.WriteLine($"/-----------\t-----------");
        }
        public PageData MyData
        {
            get { return myData; }
            set { myData = value; }
        }
    }
}
