using MyDrawing.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.Command
{
    public class DeleteLineCommand : ICommand
    {
        Model model;
        Line _Line;
        int _Index;
        public DeleteLineCommand(Model model, Line line, int Index)
        {
            this.model = model;
            this._Line = line;
            this._Index = Index;
        }
        public void Execute()
        {
            model.DeleteLine(_Index);
            model.NotifyModelChanged();
        }
        public void UnExecute()
        {
            model.GetLines().Insert(_Index, _Line);

        }
    }
}
