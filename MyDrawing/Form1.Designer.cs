namespace MyDrawing
{
    partial class _MyDrawingForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_MyDrawingForm));
            this._DataDisplay = new System.Windows.Forms.GroupBox();
            this._LabelW = new System.Windows.Forms.Label();
            this._InputW = new System.Windows.Forms.TextBox();
            this._LabelH = new System.Windows.Forms.Label();
            this._LabelY = new System.Windows.Forms.Label();
            this._LabelX = new System.Windows.Forms.Label();
            this._LabelText = new System.Windows.Forms.Label();
            this._DataView = new System.Windows.Forms.DataGridView();
            this._DeleteShape = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._ShapeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._H = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._W = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._InputX = new System.Windows.Forms.TextBox();
            this._InputY = new System.Windows.Forms.TextBox();
            this._InputH = new System.Windows.Forms.TextBox();
            this._InputText = new System.Windows.Forms.TextBox();
            this._ChooseType = new System.Windows.Forms.ComboBox();
            this._AddShape = new System.Windows.Forms.Button();
            this.內容CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.索引IToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.搜尋SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.關於AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自訂CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.選項OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.復原UToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消復原RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.全選AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.另存新檔AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.結束XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.說明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.關於ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._GroupBox = new System.Windows.Forms.GroupBox();
            this._button2 = new System.Windows.Forms.Button();
            this._button1 = new System.Windows.Forms.Button();
            this._ToolBar = new System.Windows.Forms.ToolStrip();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this._UsingStart = new System.Windows.Forms.ToolStripButton();
            this._UsingTerminator = new System.Windows.Forms.ToolStripButton();
            this._UsingDecision = new System.Windows.Forms.ToolStripButton();
            this._UsingProcess = new System.Windows.Forms.ToolStripButton();
            this._UsingLine = new System.Windows.Forms.ToolStripButton();
            this._NormalState = new System.Windows.Forms.ToolStripButton();
            this._Undo = new System.Windows.Forms.ToolStripButton();
            this._Redo = new System.Windows.Forms.ToolStripButton();
            this._Save = new System.Windows.Forms.ToolStripButton();
            this._Load = new System.Windows.Forms.ToolStripButton();
            this.剪下TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.複製CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.貼上PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開啟OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.儲存SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.列印PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.預覽列印VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._DataDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._DataView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this._GroupBox.SuspendLayout();
            this._ToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // _DataDisplay
            // 
            this._DataDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._DataDisplay.AutoSize = true;
            this._DataDisplay.Controls.Add(this._LabelW);
            this._DataDisplay.Controls.Add(this._InputW);
            this._DataDisplay.Controls.Add(this._LabelH);
            this._DataDisplay.Controls.Add(this._LabelY);
            this._DataDisplay.Controls.Add(this._LabelX);
            this._DataDisplay.Controls.Add(this._LabelText);
            this._DataDisplay.Controls.Add(this._DataView);
            this._DataDisplay.Controls.Add(this._InputX);
            this._DataDisplay.Controls.Add(this._InputY);
            this._DataDisplay.Controls.Add(this._InputH);
            this._DataDisplay.Controls.Add(this._InputText);
            this._DataDisplay.Controls.Add(this._ChooseType);
            this._DataDisplay.Controls.Add(this._AddShape);
            this._DataDisplay.Location = new System.Drawing.Point(1097, 64);
            this._DataDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._DataDisplay.Name = "_DataDisplay";
            this._DataDisplay.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._DataDisplay.Size = new System.Drawing.Size(436, 701);
            this._DataDisplay.TabIndex = 0;
            this._DataDisplay.TabStop = false;
            this._DataDisplay.Text = "資料顯示";
            // 
            // _LabelW
            // 
            this._LabelW.AutoSize = true;
            this._LabelW.Location = new System.Drawing.Point(389, 24);
            this._LabelW.Name = "_LabelW";
            this._LabelW.Size = new System.Drawing.Size(20, 15);
            this._LabelW.TabIndex = 12;
            this._LabelW.Text = "W";
            // 
            // _InputW
            // 
            this._InputW.Location = new System.Drawing.Point(375, 46);
            this._InputW.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._InputW.Name = "_InputW";
            this._InputW.Size = new System.Drawing.Size(41, 25);
            this._InputW.TabIndex = 11;
            this._InputW.TextChanged += new System.EventHandler(this.TextChangedCheck);
            // 
            // _LabelH
            // 
            this._LabelH.AutoSize = true;
            this._LabelH.Location = new System.Drawing.Point(343, 24);
            this._LabelH.Name = "_LabelH";
            this._LabelH.Size = new System.Drawing.Size(17, 15);
            this._LabelH.TabIndex = 10;
            this._LabelH.Text = "H";
            // 
            // _LabelY
            // 
            this._LabelY.AutoSize = true;
            this._LabelY.Location = new System.Drawing.Point(297, 24);
            this._LabelY.Name = "_LabelY";
            this._LabelY.Size = new System.Drawing.Size(17, 15);
            this._LabelY.TabIndex = 9;
            this._LabelY.Text = "Y";
            // 
            // _LabelX
            // 
            this._LabelX.AutoSize = true;
            this._LabelX.BackColor = System.Drawing.SystemColors.Control;
            this._LabelX.ForeColor = System.Drawing.SystemColors.ControlText;
            this._LabelX.Location = new System.Drawing.Point(251, 24);
            this._LabelX.Name = "_LabelX";
            this._LabelX.Size = new System.Drawing.Size(17, 15);
            this._LabelX.TabIndex = 8;
            this._LabelX.Text = "X";
            // 
            // _LabelText
            // 
            this._LabelText.AutoSize = true;
            this._LabelText.Location = new System.Drawing.Point(173, 24);
            this._LabelText.Name = "_LabelText";
            this._LabelText.Size = new System.Drawing.Size(37, 15);
            this._LabelText.TabIndex = 7;
            this._LabelText.Text = "文字";
            // 
            // _DataView
            // 
            this._DataView.AllowUserToAddRows = false;
            this._DataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._DataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._DataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._DeleteShape,
            this.ID,
            this._ShapeType,
            this._Text,
            this._X,
            this._Y,
            this._H,
            this._W});
            this._DataView.Location = new System.Drawing.Point(5, 78);
            this._DataView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._DataView.Name = "_DataView";
            this._DataView.RowHeadersVisible = false;
            this._DataView.RowHeadersWidth = 51;
            this._DataView.RowTemplate.Height = 27;
            this._DataView.Size = new System.Drawing.Size(445, 614);
            this._DataView.TabIndex = 6;
            this._DataView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataView_CellContentClick);
            // 
            // _DeleteShape
            // 
            this._DeleteShape.HeaderText = "刪";
            this._DeleteShape.MinimumWidth = 6;
            this._DeleteShape.Name = "_DeleteShape";
            this._DeleteShape.ReadOnly = true;
            this._DeleteShape.Text = "刪除";
            this._DeleteShape.Width = 35;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 30;
            // 
            // _ShapeType
            // 
            this._ShapeType.HeaderText = "形狀";
            this._ShapeType.MinimumWidth = 6;
            this._ShapeType.Name = "_ShapeType";
            this._ShapeType.ReadOnly = true;
            this._ShapeType.Width = 55;
            // 
            // _Text
            // 
            this._Text.HeaderText = "文字";
            this._Text.MinimumWidth = 6;
            this._Text.Name = "_Text";
            this._Text.ReadOnly = true;
            this._Text.Width = 60;
            // 
            // _X
            // 
            this._X.HeaderText = "X";
            this._X.MinimumWidth = 6;
            this._X.Name = "_X";
            this._X.ReadOnly = true;
            this._X.Width = 35;
            // 
            // _Y
            // 
            this._Y.HeaderText = "Y";
            this._Y.MinimumWidth = 6;
            this._Y.Name = "_Y";
            this._Y.ReadOnly = true;
            this._Y.Width = 35;
            // 
            // _H
            // 
            this._H.HeaderText = "H";
            this._H.MinimumWidth = 6;
            this._H.Name = "_H";
            this._H.ReadOnly = true;
            this._H.Width = 35;
            // 
            // _W
            // 
            this._W.HeaderText = "W";
            this._W.MinimumWidth = 6;
            this._W.Name = "_W";
            this._W.ReadOnly = true;
            this._W.Width = 35;
            // 
            // _InputX
            // 
            this._InputX.Location = new System.Drawing.Point(237, 46);
            this._InputX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._InputX.Name = "_InputX";
            this._InputX.Size = new System.Drawing.Size(41, 25);
            this._InputX.TabIndex = 5;
            this._InputX.TextChanged += new System.EventHandler(this.TextChangedCheck);
            // 
            // _InputY
            // 
            this._InputY.Location = new System.Drawing.Point(284, 46);
            this._InputY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._InputY.Name = "_InputY";
            this._InputY.Size = new System.Drawing.Size(41, 25);
            this._InputY.TabIndex = 4;
            this._InputY.TextChanged += new System.EventHandler(this.TextChangedCheck);
            // 
            // _InputH
            // 
            this._InputH.Location = new System.Drawing.Point(331, 46);
            this._InputH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._InputH.Name = "_InputH";
            this._InputH.Size = new System.Drawing.Size(41, 25);
            this._InputH.TabIndex = 3;
            this._InputH.TextChanged += new System.EventHandler(this.TextChangedCheck);
            // 
            // _InputText
            // 
            this._InputText.Location = new System.Drawing.Point(152, 46);
            this._InputText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._InputText.Name = "_InputText";
            this._InputText.Size = new System.Drawing.Size(79, 25);
            this._InputText.TabIndex = 2;
            this._InputText.TextChanged += new System.EventHandler(this.TextChangedCheck);
            // 
            // _ChooseType
            // 
            this._ChooseType.FormattingEnabled = true;
            this._ChooseType.Items.AddRange(new object[] {
            "Start",
            "Terminator",
            "Process",
            "Decision"});
            this._ChooseType.Location = new System.Drawing.Point(87, 48);
            this._ChooseType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._ChooseType.Name = "_ChooseType";
            this._ChooseType.Size = new System.Drawing.Size(59, 23);
            this._ChooseType.TabIndex = 1;
            this._ChooseType.Text = "形狀";
            this._ChooseType.SelectedIndexChanged += new System.EventHandler(this._ChooseType_SelectedIndexChanged);
            // 
            // _AddShape
            // 
            this._AddShape.Cursor = System.Windows.Forms.Cursors.Default;
            this._AddShape.Enabled = false;
            this._AddShape.Location = new System.Drawing.Point(5, 24);
            this._AddShape.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._AddShape.Name = "_AddShape";
            this._AddShape.Size = new System.Drawing.Size(75, 48);
            this._AddShape.TabIndex = 0;
            this._AddShape.Text = "新增";
            this._AddShape.UseVisualStyleBackColor = true;
            this._AddShape.Click += new System.EventHandler(this.AddShape_Click);
            // 
            // 內容CToolStripMenuItem
            // 
            this.內容CToolStripMenuItem.Name = "內容CToolStripMenuItem";
            this.內容CToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.內容CToolStripMenuItem.Text = "內容(&C)";
            // 
            // 索引IToolStripMenuItem
            // 
            this.索引IToolStripMenuItem.Name = "索引IToolStripMenuItem";
            this.索引IToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.索引IToolStripMenuItem.Text = "索引(&I)";
            // 
            // 搜尋SToolStripMenuItem
            // 
            this.搜尋SToolStripMenuItem.Name = "搜尋SToolStripMenuItem";
            this.搜尋SToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.搜尋SToolStripMenuItem.Text = "搜尋(&S)";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 6);
            // 
            // 關於AToolStripMenuItem
            // 
            this.關於AToolStripMenuItem.Name = "關於AToolStripMenuItem";
            this.關於AToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.關於AToolStripMenuItem.Text = "關於(&A)...";
            // 
            // 自訂CToolStripMenuItem
            // 
            this.自訂CToolStripMenuItem.Name = "自訂CToolStripMenuItem";
            this.自訂CToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.自訂CToolStripMenuItem.Text = "自訂(&C)";
            // 
            // 選項OToolStripMenuItem
            // 
            this.選項OToolStripMenuItem.Name = "選項OToolStripMenuItem";
            this.選項OToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.選項OToolStripMenuItem.Text = "選項(&O)";
            // 
            // 復原UToolStripMenuItem
            // 
            this.復原UToolStripMenuItem.Name = "復原UToolStripMenuItem";
            this.復原UToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.復原UToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.復原UToolStripMenuItem.Text = "復原(&U)";
            // 
            // 取消復原RToolStripMenuItem
            // 
            this.取消復原RToolStripMenuItem.Name = "取消復原RToolStripMenuItem";
            this.取消復原RToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.取消復原RToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.取消復原RToolStripMenuItem.Text = "取消復原(&R)";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(223, 6);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(223, 6);
            // 
            // 全選AToolStripMenuItem
            // 
            this.全選AToolStripMenuItem.Name = "全選AToolStripMenuItem";
            this.全選AToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.全選AToolStripMenuItem.Text = "全選(&A)";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(221, 6);
            // 
            // 另存新檔AToolStripMenuItem
            // 
            this.另存新檔AToolStripMenuItem.Name = "另存新檔AToolStripMenuItem";
            this.另存新檔AToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.另存新檔AToolStripMenuItem.Text = "另存新檔(&A)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // 結束XToolStripMenuItem
            // 
            this.結束XToolStripMenuItem.Name = "結束XToolStripMenuItem";
            this.結束XToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.結束XToolStripMenuItem.Text = "結束(&X)";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.說明ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1581, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 說明ToolStripMenuItem
            // 
            this.說明ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.關於ToolStripMenuItem});
            this.說明ToolStripMenuItem.Name = "說明ToolStripMenuItem";
            this.說明ToolStripMenuItem.Size = new System.Drawing.Size(53, 26);
            this.說明ToolStripMenuItem.Text = "說明";
            // 
            // 關於ToolStripMenuItem
            // 
            this.關於ToolStripMenuItem.Name = "關於ToolStripMenuItem";
            this.關於ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.關於ToolStripMenuItem.Text = "關於";
            // 
            // _GroupBox
            // 
            this._GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._GroupBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._GroupBox.Controls.Add(this._button2);
            this._GroupBox.Controls.Add(this._button1);
            this._GroupBox.Location = new System.Drawing.Point(0, 64);
            this._GroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._GroupBox.Name = "_GroupBox";
            this._GroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._GroupBox.Size = new System.Drawing.Size(200, 705);
            this._GroupBox.TabIndex = 2;
            this._GroupBox.TabStop = false;
            // 
            // _button2
            // 
            this._button2.Location = new System.Drawing.Point(7, 156);
            this._button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._button2.Name = "_button2";
            this._button2.Size = new System.Drawing.Size(187, 150);
            this._button2.TabIndex = 1;
            this._button2.UseVisualStyleBackColor = true;
            // 
            // _button1
            // 
            this._button1.Location = new System.Drawing.Point(7, 14);
            this._button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._button1.Name = "_button1";
            this._button1.Size = new System.Drawing.Size(187, 136);
            this._button1.TabIndex = 0;
            this._button1.UseVisualStyleBackColor = true;
            // 
            // _ToolBar
            // 
            this._ToolBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._ToolBar.AutoSize = false;
            this._ToolBar.Dock = System.Windows.Forms.DockStyle.None;
            this._ToolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._UsingStart,
            this._UsingTerminator,
            this._UsingDecision,
            this._UsingProcess,
            this._UsingLine,
            this._NormalState,
            this._Undo,
            this._Redo,
            this._Save,
            this._Load});
            this._ToolBar.Location = new System.Drawing.Point(0, 30);
            this._ToolBar.Name = "_ToolBar";
            this._ToolBar.Size = new System.Drawing.Size(1581, 34);
            this._ToolBar.TabIndex = 3;
            this._ToolBar.Text = "ToolBar";
            this._ToolBar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolBar_ItemClicked);
            // 
            // _UsingStart
            // 
            this._UsingStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._UsingStart.Image = global::MyDrawing.Properties.Resources.Start_Icon;
            this._UsingStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._UsingStart.Name = "_UsingStart";
            this._UsingStart.Size = new System.Drawing.Size(29, 31);
            this._UsingStart.Text = "Start";
            this._UsingStart.ToolTipText = "Start";
            // 
            // _UsingTerminator
            // 
            this._UsingTerminator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._UsingTerminator.Image = global::MyDrawing.Properties.Resources.Terminator_Icon;
            this._UsingTerminator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._UsingTerminator.Name = "_UsingTerminator";
            this._UsingTerminator.Size = new System.Drawing.Size(29, 31);
            this._UsingTerminator.Text = "Terminator";
            // 
            // _UsingDecision
            // 
            this._UsingDecision.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._UsingDecision.Image = global::MyDrawing.Properties.Resources.Decision_Icon;
            this._UsingDecision.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._UsingDecision.Name = "_UsingDecision";
            this._UsingDecision.Size = new System.Drawing.Size(29, 31);
            this._UsingDecision.Text = "Decision";
            // 
            // _UsingProcess
            // 
            this._UsingProcess.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._UsingProcess.Image = global::MyDrawing.Properties.Resources.Process_Icon;
            this._UsingProcess.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._UsingProcess.Name = "_UsingProcess";
            this._UsingProcess.Size = new System.Drawing.Size(29, 31);
            this._UsingProcess.Text = "Process";
            // 
            // _UsingLine
            // 
            this._UsingLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._UsingLine.Image = global::MyDrawing.Properties.Resources.Line_Icon;
            this._UsingLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._UsingLine.Name = "_UsingLine";
            this._UsingLine.Size = new System.Drawing.Size(29, 31);
            this._UsingLine.Text = "Line";
            // 
            // _NormalState
            // 
            this._NormalState.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._NormalState.Image = global::MyDrawing.Properties.Resources.Normal_Icon;
            this._NormalState.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._NormalState.Name = "_NormalState";
            this._NormalState.Size = new System.Drawing.Size(29, 31);
            this._NormalState.Text = "normalstate";
            // 
            // _Undo
            // 
            this._Undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._Undo.Enabled = false;
            this._Undo.Image = global::MyDrawing.Properties.Resources.Undo_Icon;
            this._Undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._Undo.Name = "_Undo";
            this._Undo.Size = new System.Drawing.Size(29, 31);
            this._Undo.Text = "Undo";
            this._Undo.Click += new System.EventHandler(this._Undo_Click);
            // 
            // _Redo
            // 
            this._Redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._Redo.Enabled = false;
            this._Redo.Image = global::MyDrawing.Properties.Resources.Redo_Icon;
            this._Redo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._Redo.Name = "_Redo";
            this._Redo.Size = new System.Drawing.Size(29, 31);
            this._Redo.Text = "Redo";
            this._Redo.Click += new System.EventHandler(this._Redo_Click);
            // 
            // _Save
            // 
            this._Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._Save.Image = global::MyDrawing.Properties.Resources.Save;
            this._Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._Save.Name = "_Save";
            this._Save.Size = new System.Drawing.Size(29, 31);
            this._Save.Text = "Save";
            this._Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // _Load
            // 
            this._Load.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._Load.Image = global::MyDrawing.Properties.Resources.Load;
            this._Load.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._Load.Name = "_Load";
            this._Load.Size = new System.Drawing.Size(29, 31);
            this._Load.Text = "Load";
            this._Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // 剪下TToolStripMenuItem
            // 
            this.剪下TToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("剪下TToolStripMenuItem.Image")));
            this.剪下TToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.剪下TToolStripMenuItem.Name = "剪下TToolStripMenuItem";
            this.剪下TToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.剪下TToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.剪下TToolStripMenuItem.Text = "剪下(&T)";
            // 
            // 複製CToolStripMenuItem
            // 
            this.複製CToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("複製CToolStripMenuItem.Image")));
            this.複製CToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.複製CToolStripMenuItem.Name = "複製CToolStripMenuItem";
            this.複製CToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.複製CToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.複製CToolStripMenuItem.Text = "複製(&C)";
            // 
            // 貼上PToolStripMenuItem
            // 
            this.貼上PToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("貼上PToolStripMenuItem.Image")));
            this.貼上PToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.貼上PToolStripMenuItem.Name = "貼上PToolStripMenuItem";
            this.貼上PToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.貼上PToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.貼上PToolStripMenuItem.Text = "貼上(&P)";
            // 
            // 新增NToolStripMenuItem
            // 
            this.新增NToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("新增NToolStripMenuItem.Image")));
            this.新增NToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.新增NToolStripMenuItem.Name = "新增NToolStripMenuItem";
            this.新增NToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.新增NToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.新增NToolStripMenuItem.Text = "新增(&N)";
            // 
            // 開啟OToolStripMenuItem
            // 
            this.開啟OToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("開啟OToolStripMenuItem.Image")));
            this.開啟OToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.開啟OToolStripMenuItem.Name = "開啟OToolStripMenuItem";
            this.開啟OToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.開啟OToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.開啟OToolStripMenuItem.Text = "開啟(&O)";
            // 
            // 儲存SToolStripMenuItem
            // 
            this.儲存SToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("儲存SToolStripMenuItem.Image")));
            this.儲存SToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.儲存SToolStripMenuItem.Name = "儲存SToolStripMenuItem";
            this.儲存SToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.儲存SToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.儲存SToolStripMenuItem.Text = "儲存(&S)";
            // 
            // 列印PToolStripMenuItem
            // 
            this.列印PToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("列印PToolStripMenuItem.Image")));
            this.列印PToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.列印PToolStripMenuItem.Name = "列印PToolStripMenuItem";
            this.列印PToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.列印PToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.列印PToolStripMenuItem.Text = "列印(&P)";
            // 
            // 預覽列印VToolStripMenuItem
            // 
            this.預覽列印VToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("預覽列印VToolStripMenuItem.Image")));
            this.預覽列印VToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.預覽列印VToolStripMenuItem.Name = "預覽列印VToolStripMenuItem";
            this.預覽列印VToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.預覽列印VToolStripMenuItem.Text = "預覽列印(&V)";
            // 
            // _MyDrawingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1581, 752);
            this.Controls.Add(this._ToolBar);
            this.Controls.Add(this._GroupBox);
            this.Controls.Add(this._DataDisplay);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "_MyDrawingForm";
            this.Text = "MyDrawing";
            this._DataDisplay.ResumeLayout(false);
            this._DataDisplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._DataView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this._GroupBox.ResumeLayout(false);
            this._ToolBar.ResumeLayout(false);
            this._ToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _DataDisplay;
        private System.Windows.Forms.TextBox _InputX;
        private System.Windows.Forms.TextBox _InputY;
        private System.Windows.Forms.TextBox _InputH;
        private System.Windows.Forms.TextBox _InputText;
        private System.Windows.Forms.ComboBox _ChooseType;
        private System.Windows.Forms.Button _AddShape;
        private System.Windows.Forms.DataGridView _DataView;
        private System.Windows.Forms.ToolStripMenuItem 內容CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 索引IToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 搜尋SToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem 關於AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自訂CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 選項OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 復原UToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消復原RToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 剪下TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 複製CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 貼上PToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 全選AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開啟OToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem 儲存SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存新檔AToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 列印PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 預覽列印VToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 結束XToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 說明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 關於ToolStripMenuItem;
        private System.Windows.Forms.Label _LabelText;
        private System.Windows.Forms.Label _LabelH;
        private System.Windows.Forms.Label _LabelY;
        private System.Windows.Forms.Label _LabelX;
        private System.Windows.Forms.Label _LabelW;
        private System.Windows.Forms.TextBox _InputW;
        private System.Windows.Forms.GroupBox _GroupBox;
        private System.Windows.Forms.Button _button2;
        private System.Windows.Forms.Button _button1;
        private System.Windows.Forms.ToolStrip _ToolBar;
        private System.Windows.Forms.ToolStripButton _UsingStart;
        private System.Windows.Forms.ToolStripButton _UsingTerminator;
        private System.Windows.Forms.ToolStripButton _UsingProcess;
        private System.Windows.Forms.ToolStripButton _UsingDecision;
        private System.Windows.Forms.DataGridViewButtonColumn _DeleteShape;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _ShapeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Text;
        private System.Windows.Forms.DataGridViewTextBoxColumn _X;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn _H;
        private System.Windows.Forms.DataGridViewTextBoxColumn _W;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ToolStripButton _NormalState;
        private System.Windows.Forms.ToolStripButton _UsingLine;
        private System.Windows.Forms.ToolStripButton _Undo;
        private System.Windows.Forms.ToolStripButton _Redo;
        private System.Windows.Forms.ToolStripButton _Save;
        private System.Windows.Forms.ToolStripButton _Load;
    }
}

