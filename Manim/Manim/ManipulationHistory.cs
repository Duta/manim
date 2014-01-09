using System.Collections.Generic;

namespace Manim
{
    class ManipulationHistory
    {
        private readonly Stack<Manipulation> _undoHistory;
        private readonly Stack<Manipulation> _redoHistory;
        private readonly ActionMan _actionMan;

        public ManipulationHistory(ActionMan actionMan)
        {
            _undoHistory = new Stack<Manipulation>();
            _redoHistory = new Stack<Manipulation>();
            _actionMan = actionMan;
        }

        public void Add(Manipulation manipulation)
        {
            _undoHistory.Push(manipulation);
            _redoHistory.Clear();
            _actionMan.Apply(manipulation);
        }

        public void Undo()
        {
            if (_undoHistory.Count == 0) return;
            var manipulation = _undoHistory.Pop();
            _redoHistory.Push(manipulation);
            _actionMan.ReverseLast();
        }

        public void Redo()
        {
            if (_redoHistory.Count == 0) return;
            var manipulation = _redoHistory.Pop();
            _undoHistory.Push(manipulation);
            _actionMan.Apply(manipulation);
        }

        public void Clear()
        {
            _undoHistory.Clear();
            _redoHistory.Clear();
            _actionMan.Rebase();
            _actionMan.ReverseAll();
        }
    }
}
