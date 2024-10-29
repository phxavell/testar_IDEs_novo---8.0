
namespace WEBCAM
{
    partial class WEBCAM_RECFACE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WEBCAM_RECFACE));
            cboDevice = new System.Windows.Forms.ComboBox();
            lblTime = new System.Windows.Forms.Label();
            lblConfirme = new System.Windows.Forms.Label();
            pic = new System.Windows.Forms.PictureBox();
            button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)pic).BeginInit();
            SuspendLayout();
            // 
            // cboDevice
            // 
            cboDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cboDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            cboDevice.FormattingEnabled = true;
            cboDevice.Location = new System.Drawing.Point(14, 82);
            cboDevice.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cboDevice.Name = "cboDevice";
            cboDevice.Size = new System.Drawing.Size(944, 24);
            cboDevice.TabIndex = 0;
            cboDevice.SelectedIndexChanged += cboDevice_SelectedIndexChanged;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.BackColor = System.Drawing.Color.Transparent;
            lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblTime.ForeColor = System.Drawing.Color.DarkBlue;
            lblTime.Location = new System.Drawing.Point(601, 670);
            lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTime.Name = "lblTime";
            lblTime.Size = new System.Drawing.Size(0, 24);
            lblTime.TabIndex = 17;
            // 
            // lblConfirme
            // 
            lblConfirme.AutoSize = true;
            lblConfirme.BackColor = System.Drawing.Color.Transparent;
            lblConfirme.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblConfirme.ForeColor = System.Drawing.Color.DarkBlue;
            lblConfirme.Location = new System.Drawing.Point(14, 670);
            lblConfirme.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblConfirme.Name = "lblConfirme";
            lblConfirme.Size = new System.Drawing.Size(418, 24);
            lblConfirme.TabIndex = 16;
            lblConfirme.Text = "VERIFICAR O RECONHECIMENTO FACIAL";
            // 
            // pic
            // 
            pic.Location = new System.Drawing.Point(14, 129);
            pic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pic.Name = "pic";
            pic.Size = new System.Drawing.Size(945, 525);
            pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pic.TabIndex = 1;
            pic.TabStop = false;
            pic.Click += pic_Click;
            // 
            // button1
            // 
            button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button1.Location = new System.Drawing.Point(818, 703);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(141, 42);
            button1.TabIndex = 18;
            button1.Text = "REPARO";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // WEBCAM_RECFACE
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1004, 757);
            Controls.Add(button1);
            Controls.Add(lblTime);
            Controls.Add(lblConfirme);
            Controls.Add(pic);
            Controls.Add(cboDevice);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WEBCAM_RECFACE";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "WEBCAM_RECFACE";
            TopMost = true;
            FormClosing += WEBCAM_RECFACE_FormClosing;
            Load += WEBCAM_RECFACE_Load;
            ((System.ComponentModel.ISupportInitialize)pic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cboDevice;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblConfirme;
        private System.Windows.Forms.Button button1;
    }
}