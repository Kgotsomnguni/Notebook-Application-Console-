using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBookApplication
{
    internal class NotebookLogger
    {
        private Notebook trackedNotebook;
        private bool logging = true;

        public NotebookLogger(Notebook trackedNotebook)
        {
            this.trackedNotebook = trackedNotebook;
            Attach();
            trackedNotebook.loggingToggled += ToggleLogging;

        }
        private void PrintAdded(string TypeItemAdded)
        {

            Console.WriteLine(TypeItemAdded + " was added to the notebook");
        }
        private void PrintDeleted(string idOfDeleted)
        {

            if (idOfDeleted != "")
            {
                Console.WriteLine($"Item {idOfDeleted} was deleted from the notebook.");
            }
            else
            {
                Console.WriteLine("everything was deleted from the notbook");
            }

        }
        private void IncorrectCommand(string messageToPrint)
        {
            Console.WriteLine($"bad command: {messageToPrint}");
        }
        public void ToggleLogging(bool turnOn)
        {
            string output = "Logger already " + ((turnOn) ? "on" : "off");

            if (logging)
            {
                if (!turnOn)
                {
                    Detach();
                    logging = false;
                    output = "logger turned off.";

                }
                else
                {
                    if (turnOn)
                    {
                        Detach();
                        logging = true;
                        output = "logger turned on.";

                    }
                }
                Console.WriteLine(output);
            }

        }

        private void Attach()
        {
            trackedNotebook.ItemAdded += PrintAdded;
            trackedNotebook.ItemRemoved += PrintDeleted;
            trackedNotebook.InputBadCommand += IncorrectCommand;

        }


        private void Detach()
        {
            trackedNotebook.ItemAdded -= PrintAdded;
            trackedNotebook.ItemRemoved -= PrintDeleted;
            trackedNotebook.InputBadCommand -= IncorrectCommand;

        }
    }
}
