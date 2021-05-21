
namespace SharpenerCalculator
{
  partial class fMain
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
      this.lblUSBtoHousing = new System.Windows.Forms.Label();
      this.lblUSBtoWheel = new System.Windows.Forms.Label();
      this.cbMachines = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.txtMachineName = new System.Windows.Forms.TextBox();
      this.txtUSBDx = new System.Windows.Forms.TextBox();
      this.txtUSBDy = new System.Windows.Forms.TextBox();
      this.txtUSBdiameter = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.txtWheelDiameter = new System.Windows.Forms.TextBox();
      this.txtJigProjectionLength = new System.Windows.Forms.TextBox();
      this.txtTargetAngle = new System.Windows.Forms.TextBox();
      this.label11 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.btnRemove = new System.Windows.Forms.Button();
      this.btnAdd = new System.Windows.Forms.Button();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.miRestoreDefaultMachineList = new System.Windows.Forms.ToolStripMenuItem();
      this.miSaveMachineList = new System.Windows.Forms.ToolStripMenuItem();
      this.miLoadMachineList = new System.Windows.Forms.ToolStripMenuItem();
      this.ofd = new System.Windows.Forms.OpenFileDialog();
      this.sfd = new System.Windows.Forms.SaveFileDialog();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.menuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // lblUSBtoHousing
      // 
      this.lblUSBtoHousing.AutoSize = true;
      this.lblUSBtoHousing.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblUSBtoHousing.Location = new System.Drawing.Point(264, 367);
      this.lblUSBtoHousing.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.lblUSBtoHousing.Name = "lblUSBtoHousing";
      this.lblUSBtoHousing.Size = new System.Drawing.Size(14, 17);
      this.lblUSBtoHousing.TabIndex = 8;
      this.lblUSBtoHousing.Text = "-";
      this.toolTip1.SetToolTip(this.lblUSBtoHousing, "Distance between housing and the top of the universal support bar in mm");
      // 
      // lblUSBtoWheel
      // 
      this.lblUSBtoWheel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
      this.lblUSBtoWheel.AutoSize = true;
      this.lblUSBtoWheel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblUSBtoWheel.Location = new System.Drawing.Point(264, 395);
      this.lblUSBtoWheel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.lblUSBtoWheel.Name = "lblUSBtoWheel";
      this.lblUSBtoWheel.Size = new System.Drawing.Size(14, 17);
      this.lblUSBtoWheel.TabIndex = 9;
      this.lblUSBtoWheel.Text = "-";
      this.toolTip1.SetToolTip(this.lblUSBtoWheel, "Distance between the wheel and the top of the universal support bar");
      // 
      // cbMachines
      // 
      this.cbMachines.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cbMachines.FormattingEnabled = true;
      this.cbMachines.Location = new System.Drawing.Point(126, 24);
      this.cbMachines.Margin = new System.Windows.Forms.Padding(2);
      this.cbMachines.Name = "cbMachines";
      this.cbMachines.Size = new System.Drawing.Size(240, 24);
      this.cbMachines.TabIndex = 0;
      this.toolTip1.SetToolTip(this.cbMachines, "Select one of the pre-defined machine parameters or choose custom machine setting" +
        "s");
      this.cbMachines.SelectedIndexChanged += new System.EventHandler(this.cbMachines_SelectedIndexChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(16, 25);
      this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(92, 17);
      this.label3.TabIndex = 13;
      this.label3.Text = "Machine type";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(16, 67);
      this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(104, 17);
      this.label4.TabIndex = 14;
      this.label4.Text = "Machine name:";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(16, 107);
      this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(225, 17);
      this.label5.TabIndex = 15;
      this.label5.Text = "USB axis horizontal distance [mm]:";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(16, 144);
      this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(208, 17);
      this.label6.TabIndex = 16;
      this.label6.Text = "USB axis vertical distance [mm]:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(16, 181);
      this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(133, 17);
      this.label7.TabIndex = 17;
      this.label7.Text = "USB diameter [mm]:";
      // 
      // txtMachineName
      // 
      this.txtMachineName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtMachineName.Location = new System.Drawing.Point(126, 66);
      this.txtMachineName.Margin = new System.Windows.Forms.Padding(2);
      this.txtMachineName.Name = "txtMachineName";
      this.txtMachineName.Size = new System.Drawing.Size(240, 23);
      this.txtMachineName.TabIndex = 7;
      // 
      // txtUSBDx
      // 
      this.txtUSBDx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtUSBDx.Location = new System.Drawing.Point(268, 105);
      this.txtUSBDx.Margin = new System.Windows.Forms.Padding(2);
      this.txtUSBDx.Name = "txtUSBDx";
      this.txtUSBDx.Size = new System.Drawing.Size(98, 23);
      this.txtUSBDx.TabIndex = 10;
      this.txtUSBDx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
      // 
      // txtUSBDy
      // 
      this.txtUSBDy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtUSBDy.Location = new System.Drawing.Point(268, 142);
      this.txtUSBDy.Margin = new System.Windows.Forms.Padding(2);
      this.txtUSBDy.Name = "txtUSBDy";
      this.txtUSBDy.Size = new System.Drawing.Size(98, 23);
      this.txtUSBDy.TabIndex = 11;
      this.txtUSBDy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
      // 
      // txtUSBdiameter
      // 
      this.txtUSBdiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtUSBdiameter.Location = new System.Drawing.Point(268, 179);
      this.txtUSBdiameter.Margin = new System.Windows.Forms.Padding(2);
      this.txtUSBdiameter.Name = "txtUSBdiameter";
      this.txtUSBdiameter.Size = new System.Drawing.Size(98, 23);
      this.txtUSBdiameter.TabIndex = 12;
      this.txtUSBdiameter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(16, 244);
      this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(145, 17);
      this.label8.TabIndex = 18;
      this.label8.Text = "Wheel diameter [mm]:";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label9.Location = new System.Drawing.Point(16, 277);
      this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(173, 17);
      this.label9.TabIndex = 19;
      this.label9.Text = "Jig projection length [mm]:";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label10.Location = new System.Drawing.Point(16, 313);
      this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(111, 17);
      this.label10.TabIndex = 20;
      this.label10.Text = "Target angle [°]:";
      // 
      // txtWheelDiameter
      // 
      this.txtWheelDiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtWheelDiameter.Location = new System.Drawing.Point(268, 242);
      this.txtWheelDiameter.Margin = new System.Windows.Forms.Padding(2);
      this.txtWheelDiameter.Name = "txtWheelDiameter";
      this.txtWheelDiameter.Size = new System.Drawing.Size(98, 23);
      this.txtWheelDiameter.TabIndex = 1;
      this.toolTip1.SetToolTip(this.txtWheelDiameter, "Enter the wheel diameter in mm");
      this.txtWheelDiameter.TextChanged += new System.EventHandler(this.txtParameter_TextChanged);
      this.txtWheelDiameter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
      // 
      // txtJigProjectionLength
      // 
      this.txtJigProjectionLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtJigProjectionLength.Location = new System.Drawing.Point(268, 276);
      this.txtJigProjectionLength.Margin = new System.Windows.Forms.Padding(2);
      this.txtJigProjectionLength.Name = "txtJigProjectionLength";
      this.txtJigProjectionLength.Size = new System.Drawing.Size(98, 23);
      this.txtJigProjectionLength.TabIndex = 2;
      this.toolTip1.SetToolTip(this.txtJigProjectionLength, "Enter the jig projection length in mm");
      this.txtJigProjectionLength.TextChanged += new System.EventHandler(this.txtParameter_TextChanged);
      this.txtJigProjectionLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
      // 
      // txtTargetAngle
      // 
      this.txtTargetAngle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtTargetAngle.Location = new System.Drawing.Point(268, 311);
      this.txtTargetAngle.Margin = new System.Windows.Forms.Padding(2);
      this.txtTargetAngle.Name = "txtTargetAngle";
      this.txtTargetAngle.Size = new System.Drawing.Size(98, 23);
      this.txtTargetAngle.TabIndex = 3;
      this.toolTip1.SetToolTip(this.txtTargetAngle, "Enter the target angle in °");
      this.txtTargetAngle.TextChanged += new System.EventHandler(this.txtParameter_TextChanged);
      this.txtTargetAngle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label11.Location = new System.Drawing.Point(16, 367);
      this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(192, 17);
      this.label11.TabIndex = 21;
      this.label11.Text = "USB top to housing [mm]:";
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label12.Location = new System.Drawing.Point(16, 395);
      this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(176, 17);
      this.label12.TabIndex = 22;
      this.label12.Text = "USB top to wheel [mm]:";
      // 
      // btnRemove
      // 
      this.btnRemove.Location = new System.Drawing.Point(368, 24);
      this.btnRemove.Margin = new System.Windows.Forms.Padding(2);
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.Size = new System.Drawing.Size(24, 24);
      this.btnRemove.TabIndex = 4;
      this.btnRemove.Text = "-";
      this.toolTip1.SetToolTip(this.btnRemove, "Remove the current machine parameters from the list");
      this.btnRemove.UseVisualStyleBackColor = true;
      this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
      // 
      // btnAdd
      // 
      this.btnAdd.Location = new System.Drawing.Point(368, 66);
      this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(24, 24);
      this.btnAdd.TabIndex = 5;
      this.btnAdd.Text = "+";
      this.toolTip1.SetToolTip(this.btnAdd, "Add new machine parameters to the list");
      this.btnAdd.UseVisualStyleBackColor = true;
      this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
      // 
      // menuStrip1
      // 
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
      this.menuStrip1.Size = new System.Drawing.Size(774, 24);
      this.menuStrip1.TabIndex = 6;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRestoreDefaultMachineList,
            this.miSaveMachineList,
            this.miLoadMachineList});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // miRestoreDefaultMachineList
      // 
      this.miRestoreDefaultMachineList.Name = "miRestoreDefaultMachineList";
      this.miRestoreDefaultMachineList.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
      this.miRestoreDefaultMachineList.Size = new System.Drawing.Size(261, 22);
      this.miRestoreDefaultMachineList.Text = "Restore default machine list";
      this.miRestoreDefaultMachineList.Click += new System.EventHandler(this.miRestoreDefaultMachineList_Click);
      // 
      // miSaveMachineList
      // 
      this.miSaveMachineList.Name = "miSaveMachineList";
      this.miSaveMachineList.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.miSaveMachineList.Size = new System.Drawing.Size(261, 22);
      this.miSaveMachineList.Text = "Save machine list";
      this.miSaveMachineList.Click += new System.EventHandler(this.miSaveMachineList_Click);
      // 
      // miLoadMachineList
      // 
      this.miLoadMachineList.Name = "miLoadMachineList";
      this.miLoadMachineList.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.miLoadMachineList.Size = new System.Drawing.Size(261, 22);
      this.miLoadMachineList.Text = "Load machine list";
      this.miLoadMachineList.Click += new System.EventHandler(this.miLoadMachineList_Click);
      // 
      // ofd
      // 
      this.ofd.DefaultExt = "*.machinedb";
      this.ofd.Filter = "Machine databases|*.machinedb";
      this.ofd.Title = "Open machine database";
      // 
      // sfd
      // 
      this.sfd.DefaultExt = "*.machinedb";
      this.sfd.Filter = "Machine databases|*.machinedb";
      this.sfd.Title = "Save machine database";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::SharpenerCalculator.Properties.Resources.sketch;
      this.pictureBox1.Location = new System.Drawing.Point(397, 24);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(365, 454);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pictureBox1.TabIndex = 23;
      this.pictureBox1.TabStop = false;
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(16, 423);
      this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(350, 55);
      this.label1.TabIndex = 24;
      this.label1.Text = "In case you use any adapter or extender please use the custom type and fill in pr" +
    "oper values for the USB axis vertical and horizontal distance.";
      // 
      // fMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(774, 492);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.btnAdd);
      this.Controls.Add(this.btnRemove);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.txtTargetAngle);
      this.Controls.Add(this.txtJigProjectionLength);
      this.Controls.Add(this.txtWheelDiameter);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.txtUSBdiameter);
      this.Controls.Add(this.txtUSBDy);
      this.Controls.Add(this.txtUSBDx);
      this.Controls.Add(this.txtMachineName);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.cbMachines);
      this.Controls.Add(this.lblUSBtoWheel);
      this.Controls.Add(this.lblUSBtoHousing);
      this.Controls.Add(this.menuStrip1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip1;
      this.Margin = new System.Windows.Forms.Padding(2);
      this.MaximizeBox = false;
      this.Name = "fMain";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fMain_FormClosing);
      this.Load += new System.EventHandler(this.fMain_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblUSBtoHousing;
    private System.Windows.Forms.Label lblUSBtoWheel;
    private System.Windows.Forms.ComboBox cbMachines;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox txtMachineName;
    private System.Windows.Forms.TextBox txtUSBDx;
    private System.Windows.Forms.TextBox txtUSBDy;
    private System.Windows.Forms.TextBox txtUSBdiameter;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox txtWheelDiameter;
    private System.Windows.Forms.TextBox txtJigProjectionLength;
    private System.Windows.Forms.TextBox txtTargetAngle;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Button btnRemove;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem miRestoreDefaultMachineList;
    private System.Windows.Forms.ToolStripMenuItem miSaveMachineList;
    private System.Windows.Forms.ToolStripMenuItem miLoadMachineList;
    private System.Windows.Forms.OpenFileDialog ofd;
    private System.Windows.Forms.SaveFileDialog sfd;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label label1;
  }
}

