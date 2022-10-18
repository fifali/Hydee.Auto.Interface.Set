namespace Hydee.Auto.Interface.Set
{
    partial class frmDllSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDllSet));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbAdd_D = new System.Windows.Forms.ToolStripButton();
            this.tsbDel_D = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvDll = new System.Windows.Forms.DataGridView();
            this.dllname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dllnamespe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dllclassname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dllprocname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dllparanum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDllPara = new System.Windows.Forms.DataGridView();
            this.dllparaname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dllparavalue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dllparasort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.gbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDllPara)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbDelete,
            this.tsbAdd_D,
            this.tsbDel_D,
            this.tsbSave,
            this.tsbCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(748, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd.Image")));
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(36, 22);
            this.tsbAdd.Text = "添加";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(36, 22);
            this.tsbDelete.Text = "删除";
            this.tsbDelete.Click += new System.EventHandler(this.TsbDelete_Click);
            // 
            // tsbAdd_D
            // 
            this.tsbAdd_D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAdd_D.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd_D.Image")));
            this.tsbAdd_D.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd_D.Name = "tsbAdd_D";
            this.tsbAdd_D.Size = new System.Drawing.Size(48, 22);
            this.tsbAdd_D.Text = "加明细";
            this.tsbAdd_D.Click += new System.EventHandler(this.tsbAdd_D_Click);
            // 
            // tsbDel_D
            // 
            this.tsbDel_D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDel_D.Image = ((System.Drawing.Image)(resources.GetObject("tsbDel_D.Image")));
            this.tsbDel_D.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel_D.Name = "tsbDel_D";
            this.tsbDel_D.Size = new System.Drawing.Size(48, 22);
            this.tsbDel_D.Text = "删明细";
            this.tsbDel_D.Click += new System.EventHandler(this.tsbDel_D_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(36, 22);
            this.tsbSave.Text = "保存";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbCancel
            // 
            this.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCancel.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancel.Image")));
            this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancel.Name = "tsbCancel";
            this.tsbCancel.Size = new System.Drawing.Size(36, 22);
            this.tsbCancel.Text = "取消";
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.splitContainer1);
            this.gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMain.Location = new System.Drawing.Point(0, 25);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(748, 455);
            this.gbMain.TabIndex = 1;
            this.gbMain.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 17);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvDll);
            this.splitContainer1.Panel1MinSize = 60;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDllPara);
            this.splitContainer1.Size = new System.Drawing.Size(742, 435);
            this.splitContainer1.SplitterDistance = 84;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvDll
            // 
            this.dgvDll.AllowUserToAddRows = false;
            this.dgvDll.AllowUserToDeleteRows = false;
            this.dgvDll.AllowUserToOrderColumns = true;
            this.dgvDll.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDll.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDll.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvDll.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDll.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDll.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dllname,
            this.dllnamespe,
            this.dllclassname,
            this.dllprocname,
            this.dllparanum});
            this.dgvDll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDll.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDll.Location = new System.Drawing.Point(0, 0);
            this.dgvDll.MultiSelect = false;
            this.dgvDll.Name = "dgvDll";
            this.dgvDll.RowHeadersVisible = false;
            this.dgvDll.RowTemplate.Height = 23;
            this.dgvDll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDll.Size = new System.Drawing.Size(742, 84);
            this.dgvDll.TabIndex = 1;
            this.dgvDll.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDll_CellEndEdit);
            // 
            // dllname
            // 
            this.dllname.DataPropertyName = "dllname";
            this.dllname.HeaderText = "类库名称";
            this.dllname.Name = "dllname";
            this.dllname.Width = 120;
            // 
            // dllnamespe
            // 
            this.dllnamespe.DataPropertyName = "dllnamespe";
            this.dllnamespe.HeaderText = "命名空间";
            this.dllnamespe.Name = "dllnamespe";
            this.dllnamespe.Width = 120;
            // 
            // dllclassname
            // 
            this.dllclassname.DataPropertyName = "dllclassname";
            this.dllclassname.HeaderText = "函数类名";
            this.dllclassname.Name = "dllclassname";
            this.dllclassname.Width = 120;
            // 
            // dllprocname
            // 
            this.dllprocname.HeaderText = "方法名称";
            this.dllprocname.Name = "dllprocname";
            // 
            // dllparanum
            // 
            this.dllparanum.HeaderText = "参数数量";
            this.dllparanum.Name = "dllparanum";
            // 
            // dgvDllPara
            // 
            this.dgvDllPara.AllowUserToAddRows = false;
            this.dgvDllPara.AllowUserToDeleteRows = false;
            this.dgvDllPara.AllowUserToOrderColumns = true;
            this.dgvDllPara.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDllPara.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDllPara.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvDllPara.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDllPara.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDllPara.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDllPara.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dllparaname,
            this.dllparavalue,
            this.dllparasort});
            this.dgvDllPara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDllPara.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDllPara.Location = new System.Drawing.Point(0, 0);
            this.dgvDllPara.MultiSelect = false;
            this.dgvDllPara.Name = "dgvDllPara";
            this.dgvDllPara.RowHeadersVisible = false;
            this.dgvDllPara.RowTemplate.Height = 23;
            this.dgvDllPara.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDllPara.Size = new System.Drawing.Size(742, 347);
            this.dgvDllPara.TabIndex = 1;
            // 
            // dllparaname
            // 
            this.dllparaname.DataPropertyName = "dllparaname";
            this.dllparaname.HeaderText = "参数名";
            this.dllparaname.Name = "dllparaname";
            this.dllparaname.Width = 120;
            // 
            // dllparavalue
            // 
            this.dllparavalue.DataPropertyName = "dllparavalue";
            this.dllparavalue.HeaderText = "参数值";
            this.dllparavalue.Name = "dllparavalue";
            this.dllparavalue.Width = 120;
            // 
            // dllparasort
            // 
            this.dllparasort.DataPropertyName = "dllparasort";
            this.dllparasort.HeaderText = "排序";
            this.dllparasort.Name = "dllparasort";
            this.dllparasort.Width = 120;
            // 
            // frmDllSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 480);
            this.Controls.Add(this.gbMain);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDllSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "类库（Dll）方法设置";
            this.Load += new System.EventHandler(this.frmDllSet_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDllPara)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbAdd_D;
        private System.Windows.Forms.ToolStripButton tsbDel_D;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvDll;
        private System.Windows.Forms.DataGridView dgvDllPara;
        private System.Windows.Forms.DataGridViewTextBoxColumn dllname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dllnamespe;
        private System.Windows.Forms.DataGridViewTextBoxColumn dllclassname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dllprocname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dllparanum;
        private System.Windows.Forms.DataGridViewTextBoxColumn dllparaname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dllparavalue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dllparasort;
    }
}