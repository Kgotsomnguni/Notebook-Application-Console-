namespace NoteBookApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //declaration
            Notebook notebook = new Notebook();
            NotebookLogger notebookLogger = new NotebookLogger(notebook);
            const string ExitProgramKeyword = "exit";
            string commandPrompt = "please enter " + notebook.show + ", " + notebook.delete + ",or " + notebook._new + ", or" + notebook.log;
            string input = "";


            // opening statements of the NoteBook V1.0 APP
            Console.WriteLine(Notebook.IntroMessage);
            Console.WriteLine(commandPrompt);

            do
            {
                input = Console.ReadLine();
                string[] commands = input.Split();

                try
                {
                    //get the first command... show, new or delete
                    // and pass the second command to the function
                    if ((commands.Length > 1))
                    {
                        //get the first command... show, new or delete
                        // and pass the second command to the function
                        notebook[commands[0]](commands[1]);
                    }
                    else
                    {

                        notebook[commands[0]]("");
                        if (commands[0] != null)
                        {

                            input = Console.ReadLine();

                            notebook[commands[0]](input);


                        }
                    }
                }
                // catching the exception in a case where the key is not found
                catch (KeyNotFoundException)
                {
                    if (input != ExitProgramKeyword)
                    {
                        Console.WriteLine(commandPrompt);

                    }
                }
                Console.WriteLine();
            }
            while (input != ExitProgramKeyword);
            Console.WriteLine(Notebook.OutroMessage);

        }
    }
}
