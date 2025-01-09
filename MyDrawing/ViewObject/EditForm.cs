using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MyDrawing.ViewObject
{
    public class EditForm : Form
    {
        private TextBox textBox;
        private Button confirmButton;
        private Button cancelButton;
        public string EditedContent { get; private set; }
        public string Content { get; private set; }

        public EditForm(string content)
        {
            // 設定表單屬性
            this.Text = "文字編輯方塊"; // 標題文字
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // 固定大小的對話框
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 300;
            this.Height = 180;
            this.BackColor = Color.White;
            this.Content = content;

            // 初始化標題標籤
            Label titleLabel = new Label
            {
                Text = "",
                Font = new Font("微軟正黑體", 10, FontStyle.Bold),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 30
            };

            // 初始化文字框
            textBox = new TextBox
            {
                Text = content,
                Width = 200,
                Location = new Point((this.ClientSize.Width - 200) / 2, 50),
                Name = "EditText"
            };
            textBox.TextChanged += ModityText;

            // 初始化確認按鈕
            confirmButton = new Button
            {
                Text = "確認",
                Width = 80,
                Enabled = false,
                Location = new Point(this.ClientSize.Width / 2 - 90, 100)
            };
            confirmButton.Click += ConfirmButton_Click;

            // 初始化取消按鈕
            cancelButton = new Button
            {
                Text = "取消",
                Width = 80,
                Location = new Point(this.ClientSize.Width / 2 + 10, 100)
            };
            cancelButton.Click += CancelButton_Click;

            // 將控制項添加到表單
            this.Controls.Add(titleLabel);
            this.Controls.Add(textBox);
            this.Controls.Add(confirmButton);
            this.Controls.Add(cancelButton);
        }
        private void ModityText(object sender, EventArgs e)
        {
            if (Content != textBox.Text)
                confirmButton.Enabled = true;
            else confirmButton.Enabled = false;
        }
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            EditedContent = textBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // EditForm
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EditForm";
            this.ResumeLayout(false);

        }
    }
}

