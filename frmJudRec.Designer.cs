namespace Hydee.Auto.Interface.Set
{
    partial class frmJudRec
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJudRec));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnDel = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.dgvJud = new System.Windows.Forms.DataGridView();
            this.sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftbra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.condition = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.titvalues = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightbra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datatype = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.linktype = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.gbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJud)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnDel,
            this.btnSave,
            this.btnCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(777, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 22);
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(36, 22);
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 22);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(36, 22);
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.dgvJud);
            this.gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMain.Location = new System.Drawing.Point(0, 25);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(777, 358);
            this.gbMain.TabIndex = 1;
            this.gbMain.TabStop = false;
            // 
            // dgvJud
            // 
            this.dgvJud.AllowUserToAddRows = false;
            this.dgvJud.AllowUserToDeleteRows = false;
            this.dgvJud.AllowUserToOrderColumns = true;
            this.dgvJud.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvJud.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvJud.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvJud.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvJud.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvJud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJud.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sort,
            this.leftbra,
            this.titname,
            this.condition,
            this.titvalues,
            this.rightbra,
            this.datatype,
            this.linktype});
            this.dgvJud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvJud.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvJud.Location = new System.Drawing.Point(3, 17);
            this.dgvJud.MultiSelect = false;
            this.dgvJud.Name = "dgvJud";
            this.dgvJud.RowHeadersVisible = false;
            this.dgvJud.RowTemplate.Height = 23;
            this.dgvJud.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJud.Size = new System.Drawing.Size(771, 338);
            this.dgvJud.TabIndex = 1;
            // 
            // sort
            // 
            this.sort.DataPropertyName = "sort";
            this.sort.HeaderText = "排序";
            this.sort.Name = "sort";
            this.sort.Width = 40;
            // 
            // leftbra
            // 
            this.leftbra.DataPropertyName = "leftbra";
            this.leftbra.HeaderText = "(";
            this.leftbra.Name = "leftbra";
            this.leftbra.Width = 30;
            // 
            // titname
            // 
            this.titname.DataPropertyName = "titname";
            this.titname.HeaderText = "XML标签";
            this.titname.Name = "titname";
            this.titname.Width = 200;
            // 
            // condition
            // 
            this.condition.DataPropertyName = "condition";
            this.condition.HeaderText = "条件";
            this.condition.Items.AddRange(new object[] {
            "==",
            "!=",
            ">",
            "<",
            ">=",
            "<=",
            "包含"});
            this.condition.Name = "condition";
            this.condition.Width = 60;
            // 
            // titvalues
            // 
            this.titvalues.DataPropertyName = "titvalues";
            this.titvalues.HeaderText = "值";
            this.titvalues.Name = "titvalues";
            this.titvalues.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.titvalues.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.titvalues.Width = 140;
            // 
            // rightbra
            // 
            this.rightbra.HeaderText = ")";
            this.rightbra.Name = "rightbra";
            this.rightbra.Width = 30;
            // 
            // datatype
            // 
            this.datatype.DataPropertyName = "datatype";
            this.datatype.HeaderText = "值类型";
            this.datatype.Items.AddRange(new object[] {
            "数值",
            "字符"});
            this.datatype.Name = "datatype";
            this.datatype.Width = 60;
            // 
            // linktype
            // 
            this.linktype.DataPropertyName = "linktype";
            this.linktype.HeaderText = "条件连接";
            this.linktype.Items.AddRange(new object[] {
            "并且",
            "或者"});
            this.linktype.Name = "linktype";
            this.linktype.Width = 80;
            // 
            // frmJudRec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 383);
            this.Controls.Add(this.gbMain);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmJudRec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "返回成功判定逻辑设置";
            this.Load += new System.EventHandler(this.frmJudRec_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnDel;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.DataGridView dgvJud;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn leftbra;
        private System.Windows.Forms.DataGridViewTextBoxColumn titname;
        private System.Windows.Forms.DataGridViewComboBoxColumn condition;
        private System.Windows.Forms.DataGridViewTextBoxColumn titvalues;
        private System.Windows.Forms.DataGridViewTextBoxColumn rightbra;
        private System.Windows.Forms.DataGridViewComboBoxColumn datatype;
        private System.Windows.Forms.DataGridViewComboBoxColumn linktype;
    }
}