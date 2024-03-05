using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBookApplication
{
    internal class Notebook
    {
        public const string IntroMessage = "Welcome to the PFT Notebook console App v1.0";
        public const string OutroMessage = "Thanks for using the PFT Notebook App v1.0";

        List<IPageable> pages = new List<IPageable>();
        public delegate void SimpleFunction(string command);
        public delegate void BooleanFunction(bool isOn);
        public event SimpleFunction ItemAdded, ItemRemoved, InputBadCommand;
        public event BooleanFunction loggingToggled;

        //a way to associate a key with a value
        private Dictionary<string, SimpleFunction> commandLineArgs = new Dictionary<string, SimpleFunction>();

        //read only variable
        public readonly string show = "show", _new = "new", delete = "delete", log = "logger";

        //show all the pages we have in our notebook
        // getting the index of the dictionary using a delegate
        public SimpleFunction this[string command]
        {
            get { return commandLineArgs[command]; }
        }
        public Notebook()
        {
            commandLineArgs.Add(show, showPage);
            commandLineArgs.Add(_new, NewPage);
            commandLineArgs.Add(delete, DeletePage);
            commandLineArgs.Add(log, Log);
        }
        /// <summary>
        /// create a new notebook with input for commands instead of defaults ones
        /// </summary>
        /// <param name="commandLineKeywords">index 0=show, 1 = new, 2 = delete</param>
        public Notebook(params string[] commandLineKeywords) : this()
        {

            for (int i = 0; i < commandLineKeywords.Length; i++)
            {
                // if nothi8ng is input jump to the next iteration
                if (commandLineKeywords[i] == "")
                {
                    continue;
                }

                switch (i)
                {
                    //show
                    case 0:
                        commandLineArgs.Remove(show);
                        commandLineArgs.Add(show = commandLineKeywords[i], showPage);
                        break;
                    //new
                    case 1:
                        commandLineArgs.Remove(_new);
                        commandLineArgs.Add(_new = commandLineKeywords[i], NewPage);
                        break;
                    //delete
                    case 2:
                        commandLineArgs.Remove(delete);
                        commandLineArgs.Add(delete = commandLineKeywords[i], DeletePage);
                        break;
                }
            }

        }
        private void NewPage(string command)
        {
            Console.WriteLine("- - - - NEW - - - -");

            switch (command)
            {
                case "":
                    Console.WriteLine("New commands");
                    Console.WriteLine("message  create new message page");
                    Console.WriteLine("list\t create new list page");
                    Console.WriteLine("image\t create new image page");

                    break;

                case "message":
                    Console.WriteLine("creating message page");
                    pages.Add(new TextualMessage().Input());

                    if (ItemAdded != null)
                    {
                        ItemAdded("Textual Message");
                    }
                    break;
                case "list":
                    Console.WriteLine("creating list page");
                    pages.Add(new MessageList().Input());
                    if (ItemAdded != null)
                    {
                        ItemAdded("list Message");
                    }
                    break;
                case "image":
                    Console.WriteLine("creating image page");
                    pages.Add(new TextualImage().Input());
                    if (ItemAdded != null)
                    {
                        ItemAdded("image");
                    }
                    break;
                default:
                    if (InputBadCommand != null)
                    {
                        InputBadCommand("you didnt enter message,list, or image please try again");
                    }
                    break;

            }
        }

        private void showPage(string command)
        {
            switch (command)
            {
                case "":

                    Console.WriteLine("- - - - SHOW - - - - ");
                    Console.WriteLine("pages:\t\t   list all created pages");
                    Console.WriteLine("id of page:\t display that page");
                    break;

                case "pages":
                    Console.WriteLine("/- - - - - - - - - - - Pages - - - - - - - - - - -");
                    if (pages.Count == 0)
                    {
                        Console.WriteLine("there are no pages to display\n press enter to continue");

                    }
                    else
                    {
                        for (int i = 0; i < pages.Count; i++)
                        {

                            Console.WriteLine($"ID:\t {i} {pages[i].MyData.title}");
                        }
                    }


                    break;
                default:
                    int number;
                    if (int.TryParse(command, out number))
                    {
                        Console.WriteLine($"showing page {number} ");

                        if (number < pages.Count)
                        {
                            pages[number].Output();

                        }
                        if (InputBadCommand != null)
                        {
                            InputBadCommand("your number was outised of the range of pages please try again");
                        }
                        else if (InputBadCommand != null)
                        {
                            InputBadCommand("you didnt enter pages or a valid number please try again");
                        }
                    }
                    break;


            }
        }

        private void DeletePage(string command)
        {

            switch (command)
            {
                case "":
                    Console.WriteLine("delete commands");
                    Console.WriteLine("all\t   delete all created pages");
                    Console.WriteLine("id of page\t delete that page");

                    break;

                case "all":
                    Console.WriteLine("deleting all pages!");
                    pages.Clear();
                    if (ItemRemoved != null)
                    {
                        ItemRemoved("");
                    }
                    break;
                default:
                    int number;
                    if (int.TryParse(command, out number))
                    {
                        Console.WriteLine($"deleting page {number} ");
                        if (number < pages.Count)
                        {
                            pages.RemoveAt(number);
                            if (ItemRemoved != null)
                            {
                                ItemRemoved(number + "");
                            }
                        }
                        else
                        {
                            if (InputBadCommand != null)
                            {
                                InputBadCommand("your number was out of range of pages please try again");
                            }
                        }
                    }
                    if (InputBadCommand != null)
                    {
                        InputBadCommand("you didnt input all, or your number was out of range of pages please try again");
                    }

                    break;


            }

        }
        private void Log(string command)
        {
            switch (command)
            {
                case "":
                    Console.WriteLine("logger commands:");
                    Console.WriteLine("on       turn logger on");
                    Console.WriteLine("off       turn logger off");
                    break;
                case "on":
                    if (loggingToggled != null)
                    {
                        loggingToggled(true);
                    }
                    break;
                case "off":
                    if (loggingToggled != null)
                    {
                        loggingToggled(false);
                    }
                    break;
                default:
                    if (InputBadCommand != null)
                    {
                        InputBadCommand("please enter on or off after inputting the log command");
                    }
                    break;
            }

        }
    }
}
