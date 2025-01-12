using DrawingForm;
using MyDrawing.Command;
using MyDrawing.Shape;
using MyDrawing.ViewObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace MyDrawing
{
    public partial class _MyDrawingForm : Form
    {
        Panel _Canvas = new DoubleBufferedPanel();
        public _MyDrawingForm()
        {
            InitializeComponent();
            //修改_canvas的屬性。
            _Canvas.Parent = this;
            _Canvas.Name = "Canvas";
            _Canvas.Location = new Point(_GroupBox.Width, _DataDisplay.Location.Y);
            _Canvas.Width = _DataDisplay.Location.X - _GroupBox.Width;
            _Canvas.Height = _DataDisplay.Height;
            _Canvas.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
            _Canvas.AutoSize = true;
            _Canvas.MouseDown += MouseDownProcess;
            _Canvas.MouseUp += MouseUpProcess;
            _Canvas.MouseMove += MouseMoveProcess;
            _Canvas.Paint += GraphicsPaint;
            _Canvas.MouseDoubleClick += CanvasMouseDoubleClick;
            _LabelText.ForeColor = Color.FromName(presentationModel.Textcolor);
            _LabelX.ForeColor = Color.FromName(presentationModel.Xcolor);
            _LabelY.ForeColor = Color.FromName(presentationModel.Ycolor);
            _LabelW.ForeColor = Color.FromName(presentationModel.Widthcolor);
            _LabelH.ForeColor = Color.FromName(presentationModel.Heightcolor);
            model.modelChanged += ModelChangedEventHandler;
            //建立databinding
            _AddShape.DataBindings.Add("Enabled", presentationModel, "AddShapeEnabled");
            SaveAutoIinit();
            this.FormClosing += MainForm_FormClosing;
        }
        Model model = new Model();
        PresentationStateModel presentationModel = new PresentationStateModel();
        private static System.Timers.Timer aTimer;
        private void AddShape_Click(object sender, EventArgs e)
        {
            AddOrHintShape();
        }
        private void SaveAutoIinit()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string folderName = "drawing_backup";
            string folderPath = Path.Combine(basePath, folderName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Console.WriteLine($"資料夾已建立：{folderPath}");
            }
            else
            {
                Console.WriteLine($"資料夾已存在：{folderPath}");
            }
            aTimer = new System.Timers.Timer(30000);
            aTimer.Elapsed += OnTimedEvent; // 綁定事件
            aTimer.AutoReset = true; // 是否自動重置
            aTimer.Enabled = true; // 啟用計時器
        }
        private async void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (model._modelChange)
            {
                if (this.InvokeRequired)
                    this.Invoke(new Action(() => { this.Text = "MyDrawing (Auto saving...)"; }));
                else
                    this.Text = "MyDrawing (Auto saving...)";
                string _backupFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "drawing_backup");
                DateTime now = DateTime.Now;
                string formattedDateTime = now.ToString("yyyyMMddHHmmss");
                await presentationModel.SaveShapesAsync(model, _backupFolder + "\\" + formattedDateTime + "_bak.mydrawing");
                model._modelChange = false;
                if (this.InvokeRequired)
                    this.Invoke(new Action(() => { this.Text = "MyDrawing"; }));
                else
                    this.Text = "MyDrawing";
                string basePath = AppDomain.CurrentDomain.BaseDirectory;

                string backupFolder = Path.Combine(basePath, "drawing_backup");
                presentationModel.checkfilenum(backupFolder);
            }
        }
        private void AddOrHintShape() //決定要顯示錯誤訊息或將新增資料且顯示在DataGridView上。
        {
            model.AddCommand(new ADDCommand(model, "Using" + _ChooseType.SelectedItem.ToString(), _InputText.Text, _InputX.Text, _InputY.Text, _InputH.Text, _InputW.Text));
            _ChooseType.SelectedIndex = -1; //重製顯示內容
            _InputText.Text = ""; //重製顯示內容
            _InputX.Text = ""; //重製顯示內容
            _InputY.Text = ""; //重製顯示內容
            _InputH.Text = ""; //重製顯示內容
            _InputW.Text = ""; //重製顯示內容
            UpdataToolBarStatus();
            UpdateDisplay();
        }
        private void CanvasMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (model.CheckMouseInCricle(e.X, e.Y))
            {
                EditForm form = new EditForm(model.selectshape._ShapeText);
                DialogResult result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    model.AddCommand(new TextChangeCommand(model, model.selectshape, form.EditedContent, model.selectshape._ShapeText));
                }
            }
            UpdataToolBarStatus();
            UpdateDisplay();
        }
        private void DataView_CellContentClick(object sender, DataGridViewCellEventArgs e) //刪除指定的內容。
        {
            presentationModel.DataViewDelClick(model, e.ColumnIndex, _DataView.Columns["_DeleteShape"].Index, e.RowIndex);
            UpdateDisplay();
            UpdataToolBarStatus();
        }
        private void ToolBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)//檢查ToolBar的狀態及保持選擇的單一性。
        {
            presentationModel.ButtonChecked(model, e.ClickedItem.Text);
            if (presentationModel.CurrentState)
            {
                _Canvas.Cursor = Cursors.Cross;
            }
            else
            {
                _Canvas.Cursor = Cursors.Default;
            }
            UpdataToolBarStatus();
            UpdateDisplay();
        }
        private void UpdataToolBarStatus()
        {
            _UsingStart.Checked = presentationModel.StartState;
            _UsingTerminator.Checked = presentationModel.TerminatorState;
            _UsingProcess.Checked = presentationModel.ProcessState;
            _UsingDecision.Checked = presentationModel.DecisionState;
            _UsingLine.Checked = presentationModel.LineState;
            _Undo.Enabled = model.GetCommandUndoState();
            _Redo.Enabled = model.GetCommandRedoState();
        }
        private void UpdateDisplay() //更新DataGridView的內容。
        {
            _DataView.Rows.Clear();
            presentationModel._DataSize = 0;
            List<IShape> shapes = model.GetShapes();
            List<Line> lines = model.GetLines();
            for (int i = 0; i < shapes.Count; i++)
            {
                IShape shape = shapes[i];
                _DataView.Rows.Add("刪除", i + 1, shape._ShapeName, shape._ShapeText, shape._ShapeX, shape._ShapeY, shape._ShapeHeight, shape._ShapeWidth);
                presentationModel._DataSize = i + 1;
            }
            for (int i = 0; i < lines.Count; i++)
            {
                Line line = lines[i];
                _DataView.Rows.Add("刪除", i + presentationModel._DataSize + 1, "Line", line.FristShape._ShapeText + "->" + line.FinalShape._ShapeText, line.GetPointX(line.FristShape, line.FristPoint), line.GetPointY(line.FristShape, line.FristPoint), line.GetPointX(line.FinalShape, line.FinalPoint), line.GetPointY(line.FinalShape, line.FinalPoint));
            }
        }

        private void TextChangedCheck(object sender, EventArgs e)//更新標籤的顏色
        {
            presentationModel.CheckError(_ChooseType.SelectedIndex, _InputText.Text, _InputX.Text, _InputY.Text, _InputH.Text, _InputW.Text, model);
            _LabelText.ForeColor = Color.FromName(presentationModel.Textcolor);
            _LabelX.ForeColor = Color.FromName(presentationModel.Xcolor);
            _LabelY.ForeColor = Color.FromName(presentationModel.Ycolor);
            _LabelW.ForeColor = Color.FromName(presentationModel.Widthcolor);
            _LabelH.ForeColor = Color.FromName(presentationModel.Heightcolor);
        }
        private void _ChooseType_SelectedIndexChanged(object sender, EventArgs e)//檢查輸入格式是否有錯。
        {
            presentationModel.CheckError(_ChooseType.SelectedIndex, _InputText.Text, _InputX.Text, _InputY.Text, _InputH.Text, _InputW.Text, model);
        }

        void MouseDownProcess(object sender, MouseEventArgs e)
        {
            model.PointerDown(e.X, e.Y);
        }
        void MouseMoveProcess(object sender, MouseEventArgs e)
        {
            model.PointerMoved(e.X, e.Y);
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 停止計時器
            if (aTimer != null)
            {
                aTimer.Stop();
            }
        }
        void MouseUpProcess(object sender, MouseEventArgs e)//完成繪圖內容，更新圖形狀態及DataGridView的內容。
        {
            model.PointerUp(e.X, e.Y);
            presentationModel.ButtonChecked(model);
            _Canvas.Cursor = Cursors.Default;
            UpdataToolBarStatus();
            UpdateDisplay();
        }
        private void GraphicsPaint(object sender, PaintEventArgs e)//繪製圖形。ADD
        {
            model.Draw(new PresentationModel.FormGraphicsAdaptor(e.Graphics));
        }
        public void ModelChangedEventHandler()//初始化並重繪畫布內容。
        {
            _Canvas.Invalidate(true);
        }

        private void _Undo_Click(object sender, EventArgs e)
        {
            model.UndoCommand();
            UpdataToolBarStatus();
            UpdateDisplay();
        }

        private void _Redo_Click(object sender, EventArgs e)
        {
            model.RedoCommand();
            UpdataToolBarStatus();
            UpdateDisplay();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog //跳出選擇畫面
            {
                Filter = "MyDrawing files (*.mydrawing)|*.mydrawing|All files (*.*)|*.*",
                Title = "選擇載入檔案"
            })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        presentationModel.LoadShapes(model, openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"載入失敗: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            UpdataToolBarStatus();
            UpdateDisplay();
        }

        private async void Save_Click(object sender, EventArgs e)
        {
            _Save.Enabled = false; // 禁用 Save 按鈕
            using (SaveFileDialog saveFileDialog = new SaveFileDialog //跳出選擇畫面
            {
                Filter = "MyDrawing files (*.mydrawing)|*.mydrawing|All files (*.*)|*.*",
                Title = "選擇儲存位置"
            })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        await presentationModel.SaveShapesAsync(model, saveFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"儲存失敗: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            _Save.Enabled = true;
            UpdataToolBarStatus();
            UpdateDisplay();
        }

    }
}
