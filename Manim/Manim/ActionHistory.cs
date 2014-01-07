using System.Collections.Generic;

namespace Manim
{
    class ActionHistory
    {
        private Stack<ManimAction> actionHistory;

        public ActionHistory()
        {
            actionHistory = new Stack<ManimAction>();
        }

        public void PushAction(ManimAction action)
        {
            actionHistory.Push(action);
        }

        public ManimAction PopAction()
        {
            return actionHistory.Pop();
        }

        public bool HasSavedCurrentFile()
        {
            foreach (var action in actionHistory)
            {
                if (action is FileAction)
                {
                    FileAction fileAction = (FileAction)action;
                    var type = fileAction.Type;
                    switch (type)
                    {
                        case FileAction.ActionType.Open:
                            return false;
                        case FileAction.ActionType.Save:
                        case FileAction.ActionType.SaveAs:
                            return true;
                    }
                }
            }
            // No file has been loaded
            return false;
        }

        public bool HasOpenedAFile()
        {
            foreach (var action in actionHistory)
            {
                if (action is FileAction)
                {
                    FileAction fileAction = (FileAction)action;
                    if (fileAction.Type == FileAction.ActionType.Open)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsEmpty()
        {
            return actionHistory.Count == 0;
        }
    }
}
