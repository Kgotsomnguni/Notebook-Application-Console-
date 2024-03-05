using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBookApplication
{
    internal class MessageList : TextualMessage
    {
        private enum BulletType
        {
            Dashed, Numbered, Star
        }
        private BulletType bulletType;

        //define later
        public override IPageable Input()
        {
            Console.WriteLine("please input your name");
            myData.author = Console.ReadLine();
            Console.WriteLine("please input the message title");
            myData.title = Console.ReadLine();
            Console.WriteLine("what type of bullet point would you like to use?");
            Console.WriteLine("please enter dashed, numbered, or star");

            bool goodInput = false;
            while (!goodInput)
            {
                goodInput = true;
                switch (Console.ReadLine())
                {
                    case "dashed":
                        bulletType = BulletType.Dashed;
                        break;
                    case "numbered":
                        bulletType = BulletType.Numbered;
                        break;
                    case "star":
                        bulletType = BulletType.Star;
                        break;
                    default:
                        Console.WriteLine("please enter dashed, numbered, or star");
                        break;

                }
            }
            Console.WriteLine(" start typing your list. Everytime you enter a new item will be created.");
            Console.WriteLine("Press enter with a blank list item to end your list input.");

            // write list
            bool finishedList = false;
            int i = 1;
            while (!finishedList)
            {
                string input = Console.ReadLine();

                //if they enter nothing our list is finished
                if (input == "")
                {
                    finishedList = true;
                }
                else
                {
                    switch (bulletType)
                    {
                        case BulletType.Dashed:
                            message += $"- {input} \n";
                            break;
                        case BulletType.Numbered:
                            message += $"{i} {input} \n";
                            i++;
                            break;
                        case BulletType.Star:
                            message += $"* {input} \n";
                            break;
                    }
                }
            }
            return this;
        }


    }
}
