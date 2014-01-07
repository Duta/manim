using System.Collections.Generic;

namespace Manim
{
    class ManipulationHistory
    {
        private Stack<Manipulation> undoHistory;
        private Stack<Manipulation> redoHistory;
        private ActionMan actionMan;

        public ManipulationHistory(ActionMan _actionMan)
        {
            undoHistory = new Stack<Manipulation>();
            redoHistory = new Stack<Manipulation>();
            actionMan = _actionMan;
        }

        public void Add(Manipulation manipulation)
        {
            undoHistory.Push(manipulation);
            redoHistory.Clear();
            actionMan.Apply(manipulation);
        }

        public void Undo()
        {
            if (undoHistory.Count == 0) return;
            var manipulation = undoHistory.Pop();
            redoHistory.Push(manipulation);
            actionMan.ReverseLast();
        }

        public void Redo()
        {
            if (redoHistory.Count == 0) return;
            var manipulation = redoHistory.Pop();
            undoHistory.Push(manipulation);
            actionMan.Apply(manipulation);
        }

        public void Clear()
        {
            undoHistory.Clear();
            redoHistory.Clear();
            actionMan.Rebase();
            actionMan.ReverseAll();
        }
    }
}
