using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing
{
    internal class Factory
    {
        public Factory() { }
        public IShape ChoseeShape(string ChooseType, string InputText, string InputX, string InputY, string InputHeight, string InputWidth) //選擇要新增的類別。
        {
            if (ChooseType == "Start") //若輸入的資料為浮點數，則無條件捨去，並轉換為INT。
            {
                return new Start(InputText, (int)double.Parse(InputX), (int)double.Parse(InputY), (int)double.Parse(InputHeight), (int)double.Parse(InputWidth));
            }
            else if (ChooseType == "Terminator")
            {
                return new Terminator(InputText, (int)double.Parse(InputX), (int)double.Parse(InputY), (int)double.Parse(InputHeight), (int)double.Parse(InputWidth));
            }
            else if (ChooseType == "Process")
            {
                return new Process(InputText, (int)double.Parse(InputX), (int)double.Parse(InputY), (int)double.Parse(InputHeight), (int)double.Parse(InputWidth));
            }
            else
            {
                return new Decision(InputText, (int)double.Parse(InputX), (int)double.Parse(InputY), (int)double.Parse(InputHeight), (int)double.Parse(InputWidth));
            }
        }
    }
}
