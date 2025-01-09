using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.Command
{
    public interface ICommand
    {
        void Execute();//執行對應命令。
        void UnExecute();//執行取消對應命令。
    }
}
