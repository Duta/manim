using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manim
{
    class FileAction : ManimAction
    {
        public string FilePath { get; set; }
        public ActionType Type { get; set; }

        public FileAction(string filePath, ActionType type)
        {
            FilePath = filePath;
            Type = type;
        }

        public enum ActionType
        {
            Open,
            Save,
            SaveAs
        }
    }
}
