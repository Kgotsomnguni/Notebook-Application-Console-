using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBookApplication
{

    // structs definition
    public struct PageData {
        public string title;
        public string author;

    }
    internal interface IPageable
    {

        PageData MyData { get; set; }
        // how we are going to input our item
        IPageable Input();

        // how do we output to this item
        void Output();
    }
}
