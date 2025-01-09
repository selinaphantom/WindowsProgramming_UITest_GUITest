using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.Command
{
    public class DeleteCommand : ICommand
    {
        Model model;
        IShape shape;
        int _Index;
        public DeleteCommand(Model model, IShape shape, int Index)
        {
            this.model = model;
            this.shape = shape;
            this._Index = Index;
        }
        public void Execute()
        {
            model.DeleteShape(_Index);
            model.NotifyModelChanged();
        }
        public void UnExecute()
        {
            model.GetShapes().Insert(_Index, shape);

        }
    }
}
