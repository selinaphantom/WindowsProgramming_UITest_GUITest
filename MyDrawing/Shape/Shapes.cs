using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawing
{
    public class Shapes
    {
        public List<IShape> shapes = new List<IShape>(); //紀錄Shape的儲存空間。
        Factory factory = new Factory(); //使用Factory做類別的選擇。
        public Shapes() { }
        public void CreateShape(string ChooseType, string InputText, string InputX, string InputY, string InputHeight, string InputWidth) //新增Shape。
        {
            //和Model一樣為避免圖形的Height或Width為零，因此參考powerpoint新增圖形的方法來解決這個問題。
            if (InputHeight == "0")
            {
                InputHeight = "10";
            }
            if (InputWidth == "0")
            {
                InputWidth = "10";
            }
            shapes.Add(factory.ChoseeShape(ChooseType, InputText, InputX, InputY, InputHeight, InputWidth)); //用Factory來判斷新增的類別後，加入到儲存空間。
        }
        public void RemoveShape(int Index) //根據對應的位址刪除對應的空間。
        {
            if (GetAllShape().Count > Index && Index >= 0)//確保不會出現Index小於0或大於資料量。
                shapes.RemoveAt(Index);
        }
        public List<IShape> GetAllShape() //輸出目前記錄的所有Shapes內容。
        {
            return shapes;
        }
    }
}
