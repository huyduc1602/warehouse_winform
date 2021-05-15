
namespace WareHouseApp
{
    partial class TexboxValidate
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
            this.txtValidate = new System.Windows.Forms.TextBox();
            this.lblValidate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtValidate
            // 
            this.txtValidate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValidate.Location = new System.Drawing.Point(3, 3);
            this.txtValidate.Name = "txtValidate";
            this.txtValidate.Size = new System.Drawing.Size(224, 20);
            this.txtValidate.TabIndex = 0;
            this.txtValidate.Validating += new System.ComponentModel.CancelEventHandler(this.txtValidate_Validating);
            // 
            // lblValidate
            // 
            this.lblValidate.AutoSize = true;
            this.lblValidate.ForeColor = System.Drawing.Color.Crimson;
            this.lblValidate.Location = new System.Drawing.Point(3, 26);
            this.lblValidate.Name = "lblValidate";
            this.lblValidate.Size = new System.Drawing.Size(35, 13);
            this.lblValidate.TabIndex = 1;
            this.lblValidate.Text = "label1";
            // 
            // TexboxValidate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblValidate);
            this.Controls.Add(this.txtValidate);
            this.Name = "TexboxValidate";
            this.Size = new System.Drawing.Size(230, 42);
            this.Load += new System.EventHandler(this.TexboxValidate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValidate;
        private System.Windows.Forms.Label lblValidate;
    }
}
