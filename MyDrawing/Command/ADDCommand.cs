using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.Command
{
    public class ADDCommand : ICommand
    {
        Model model;
        string _Choose;
        string _Text;
        string _X;
        string _Y;
        string _W;
        string _H;
        public ADDCommand(Model model, string choose, string text, string x, string y, string h, string w)
        {
            this.model = model;
            this._Choose = choose;
            this._Text = text;
            this._X = x;
            this._Y = y;
            this._W = w;
            this._H = h;
        }
        public void Execute()
        {
            model.AddShape(_Choose, _Text, _X, _Y, _H, _W);
            model.NotifyModelChanged();
        }
        public void UnExecute()
        {
            model.DeleteShape(model.GetShapes().Count - 1);
            model.NotifyModelChanged();
        }
    }
}
