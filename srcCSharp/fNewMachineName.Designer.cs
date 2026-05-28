
namespace SharpenerCalculator
{
  partial class fNewMachineName
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
      this.txtName = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.btnOkay = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // txtName
      // 
      this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtName.Location = new System.Drawing.Point(36, 112);
      this.txtName.Margin = new System.Windows.Forms.Padding(4);
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(622, 38);
      this.txtName.TabIndex = 0;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(30, 60);
      this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(507, 31);
      this.label5.TabIndex = 3;
      this.label5.Text = "Please name your new machine settings:";
      // 
      // btnOkay
      // 
      this.btnOkay.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOkay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOkay.Location = new System.Drawing.Point(512, 208);
      this.btnOkay.Name = "btnOkay";
      this.btnOkay.Size = new System.Drawing.Size(146, 60);
      this.btnOkay.TabIndex = 1;
      this.btnOkay.Text = "Okay";
      this.btnOkay.UseVisualStyleBackColor = true;
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnCancel.Location = new System.Drawing.Point(340, 208);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(146, 60);
      this.btnCancel.TabIndex = 2;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // fNewMachineName
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(686, 318);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOkay);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.label5);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "fNewMachineName";
      this.Text = "Addin new machine";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button btnOkay;
    private System.Windows.Forms.Button btnCancel;
    public System.Windows.Forms.TextBox txtName;
  }
}