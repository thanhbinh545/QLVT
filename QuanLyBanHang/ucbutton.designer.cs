namespace QuanLyBanHang
{
    partial class ucbutton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucbutton));
            this.btXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btThem = new DevExpress.XtraEditors.SimpleButton();
            this.btSua = new DevExpress.XtraEditors.SimpleButton();
            this.btLuu = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btXoa
            // 
            this.btXoa.Image = ((System.Drawing.Image)(resources.GetObject("btXoa.Image")));
            this.btXoa.Location = new System.Drawing.Point(132, 0);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(60, 23);
            this.btXoa.TabIndex = 2;
            this.btXoa.Text = "Delete";
            this.btXoa.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // btThem
            // 
            this.btThem.Image = ((System.Drawing.Image)(resources.GetObject("btThem.Image")));
            this.btThem.Location = new System.Drawing.Point(0, 0);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(60, 23);
            this.btThem.TabIndex = 3;
            this.btThem.Text = "Add";
            // 
            // btSua
            // 
            this.btSua.Image = ((System.Drawing.Image)(resources.GetObject("btSua.Image")));
            this.btSua.Location = new System.Drawing.Point(66, 0);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(60, 23);
            this.btSua.TabIndex = 4;
            this.btSua.Text = "Edit";
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btLuu
            // 
            this.btLuu.Enabled = false;
            this.btLuu.Image = ((System.Drawing.Image)(resources.GetObject("btLuu.Image")));
            this.btLuu.Location = new System.Drawing.Point(198, 0);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(60, 23);
            this.btLuu.TabIndex = 5;
            this.btLuu.Text = "Save";
            // 
            // ucbutton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btLuu);
            this.Controls.Add(this.btSua);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.btXoa);
            this.MaximumSize = new System.Drawing.Size(266, 26);
            this.MinimumSize = new System.Drawing.Size(266, 26);
            this.Name = "ucbutton";
            this.Size = new System.Drawing.Size(266, 26);
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton btSua;
        public DevExpress.XtraEditors.SimpleButton btThem;
        public DevExpress.XtraEditors.SimpleButton btXoa;
        public DevExpress.XtraEditors.SimpleButton btLuu;
    }
}
