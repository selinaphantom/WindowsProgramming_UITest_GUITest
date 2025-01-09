using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.Command
{
    public class DrawCommand : ICommand
    {
        Model model;
        IShape shape;
        public DrawCommand(Model model, IShape shape)
        {
            this.model = model;
            this.shape = shape;
        }
        public void Execute()
        {
            model.ADDShapeFormDrawState(shape);
            model.NotifyModelChanged();
        }
        public void UnExecute()
        {
            model.DeleteShape(model.GetShapes().Count - 1);
            model.NotifyModelChanged();
        }
    }
}
