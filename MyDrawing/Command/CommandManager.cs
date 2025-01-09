using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.Command
{
    public class CommandManager
    {
        Stack<ICommand> _Undo = new Stack<ICommand>();
        Stack<ICommand> _Redo = new Stack<ICommand>();
        public void Execute(ICommand cmd)
        {
            cmd.Execute();
            _Undo.Push(cmd);    // push command 進 undo stack
            _Redo.Clear();      // 清除redo stack
        }

        public void Undo()
        {
            if (_Undo.Count <= 0)
            {
                return;
            }
            ICommand cmd = _Undo.Pop();
            _Redo.Push(cmd);
            cmd.UnExecute();
        }

        public void Redo()
        {
            if (_Redo.Count <= 0)
            {
                return;
            }
            ICommand cmd = _Redo.Pop();
            _Undo.Push(cmd);
            cmd.Execute();
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _Redo.Count != 0;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _Undo.Count != 0;
            }
        }
        public void ClearALL()
        {
            _Redo.Clear();
            _Undo.Clear();
        }
    }
}