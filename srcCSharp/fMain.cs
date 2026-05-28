using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace SharpenerCalculator
{
  public partial class fMain : Form
  {
    public fMain()
    {
      InitializeComponent();
    }

    List<MachineParameters> _machines = null;
    string _machinesConfigFile;
    private void fMain_Load(object sender, EventArgs e)
    {
      // the filename for our settings file
      _machinesConfigFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "cmbTea\\MachineParameters.machinedb");
      // try to load it
      _machines = MachineParameters.ReadMachineParametersFromFile(_machinesConfigFile);
      // if it fails, build the default list
      if (_machines == null)
      { 
        _machines = MachineParameters.BuildDefaultMachineList();
        // and save it
        try
        {
          // write the file
          MachineParameters.WriteMachineParametersToFile(_machines, _machinesConfigFile);
        }
        catch (Exception ex)
        {
          // something went wrong
          MessageBox.Show("Error writing " + _machinesConfigFile + ". Error message is: " + ex.Message, "Error", MessageBoxButtons.OK);
        }
      }
      // create a custom machine
      MachineParameters custom = new MachineParameters("Custom", 50, 29, 12);
      // add it to the list
      _machines.Add(custom);
      // add the machines to the combo box
      foreach (MachineParameters machine in _machines)
        cbMachines.Items.Add(machine.Name);
      // load defaults
      cbMachines.SelectedIndex = Properties.Settings.Default.SelectedMachineIndex;
      txtWheelDiameter.Text = Properties.Settings.Default.WheelDiameter.ToString("0.0");
      txtJigProjectionLength.Text = Properties.Settings.Default.JigProjectionLength.ToString("0.0");
      txtTargetAngle.Text = Properties.Settings.Default.TargetAngle.ToString("0.0");
      // calculate it
      Calculate();
    }

    private void fMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      // check if there were changes in the machine list
      if (_machinesChanged)
      {
        // show a dialog box
        if (MessageBox.Show("You made changes in the machine list. Do you want to save these changes?", "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {        
          try
          {
            // write the file
            MachineParameters.WriteMachineParametersToFile(_machines, _machinesConfigFile);
          }
          catch (Exception ex)
          {
            // something went wrong
            MessageBox.Show("Error writing " + _machinesConfigFile + ". Error message is: " + ex.Message, "Error", MessageBoxButtons.OK);
          }
        }
      }
      // save defaults
      Properties.Settings.Default.SelectedMachineIndex = cbMachines.SelectedIndex;
      Properties.Settings.Default.WheelDiameter = double.Parse(txtWheelDiameter.Text);
      Properties.Settings.Default.JigProjectionLength = double.Parse(txtJigProjectionLength.Text);
      Properties.Settings.Default.TargetAngle = double.Parse(txtTargetAngle.Text);
      Properties.Settings.Default.Save();
    }

    private void Calculate ()
    {
      // get the values
      double wheelDiameter;
      double.TryParse(txtWheelDiameter.Text, out wheelDiameter);
      double jigProjectionLength;
      double.TryParse(txtJigProjectionLength.Text, out jigProjectionLength);
      double targetAngle;
      double.TryParse(txtTargetAngle.Text, out targetAngle);
      // check them
      if ((wheelDiameter <= 0) || (jigProjectionLength <= 0) || (targetAngle <= 0))
      {
        lblUSBtoHousing.Text = "-";
        lblUSBtoWheel.Text = "-";
        return;
      }
      // get the selected machine
      MachineParameters machine = _machines[cbMachines.SelectedIndex];
      // calculate it
      lblUSBtoHousing.Text = Calculator.USBHeight(machine, wheelDiameter, jigProjectionLength, targetAngle).ToString("0.00");
      lblUSBtoWheel.Text = Calculator.USB2Wheel(machine, wheelDiameter, jigProjectionLength, targetAngle).ToString("0.00");
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Calculate();
    }

    private void cbMachines_SelectedIndexChanged(object sender, EventArgs e)
    {
      // show the values
      txtMachineName.Text = _machines[cbMachines.SelectedIndex].Name;
      txtUSBdiameter.Text = _machines[cbMachines.SelectedIndex].USBdiameter.ToString("0.0");
      txtUSBDx.Text = _machines[cbMachines.SelectedIndex].USBdx.ToString("0.0");
      txtUSBDy.Text = _machines[cbMachines.SelectedIndex].USBdy.ToString("0.0");
      // enable text edit if it is a custom machine, but not it's name as it is protected
      txtMachineName.Enabled = false;
      txtUSBdiameter.Enabled = cbMachines.Text == "Custom" ? true : false;
      txtUSBDx.Enabled = cbMachines.Text == "Custom" ? true : false;
      txtUSBDy.Enabled = cbMachines.Text == "Custom" ? true : false;
      // the custom machine can't be removed
      btnRemove.Enabled = cbMachines.Text == "Custom" ? false : true;
      // only the custom machine can be added
      btnAdd.Enabled = cbMachines.Text == "Custom" ? true : false;
      // calculate it
      Calculate();
    }

    private void txtParameter_TextChanged(object sender, EventArgs e)
    {
      // re-calculate
      Calculate();
    }

    private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      string d = System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator;
      // verify that the pressed key isn't CTRL or any non-numeric digit
      if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != d[0]))
      {
        e.Handled = true;
      }

      // if you want, you can allow decimal (float) numbers
      if ((e.KeyChar == d[0]) && ((sender as TextBox).Text.IndexOf(d) > -1))
      {
        e.Handled = true;
      }
    }

    private void miRestoreDefaultMachineList_Click(object sender, EventArgs e)
    {
      // load the default machine data
      _machines = MachineParameters.BuildDefaultMachineList();
      // create a custom machine
      MachineParameters custom = new MachineParameters("Custom", 50, 29, 12);
      // add it to the list
      _machines.Add(custom);
      // clear the combo box
      cbMachines.Items.Clear();
      // add the machines to the combo box
      foreach (MachineParameters machine in _machines)
        cbMachines.Items.Add(machine.Name);
      // select the first
      cbMachines.SelectedIndex = 0;
      // flag that the machines have been changed
      _machinesChanged = true;
    }

    private void miSaveMachineList_Click(object sender, EventArgs e)
    {
      // execute the save file dialog
      if (sfd.ShowDialog() == DialogResult.OK)
      {
        try
        {
          // save the database
          MachineParameters.WriteMachineParametersToFile(_machines, sfd.FileName);
        }
        catch (Exception ex)
        {
          // display a hint
          MessageBox.Show("Error saving machine database: " + ex.Message, "Error writing file!");
        }
      }
    }

    private void miLoadMachineList_Click(object sender, EventArgs e)
    {
      // execute the open file dialog
      if (ofd.ShowDialog() == DialogResult.OK)
      {
        try 
        { 
          // load the database
          List<MachineParameters> machines = MachineParameters.ReadMachineParametersFromFile(ofd.FileName);
          // save the new machines
          _machines = machines;
          // clear the combo box
          cbMachines.Items.Clear();
          // add the machines to the combo box
          foreach (MachineParameters machine in _machines)
            cbMachines.Items.Add(machine.Name);
          // select the first
          cbMachines.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
          // display a hint
          MessageBox.Show("Error loading machine database: " + ex.Message, "Error loading file!");
        }
      }
    }

    private bool _machinesChanged = false;
    private void btnRemove_Click(object sender, EventArgs e)
    {
      // give a chance to stop this
      if (MessageBox.Show("Do you really want to delete the settings for the " + txtMachineName.Text + " ?", 
                          "Attention", 
                          MessageBoxButtons.YesNo, 
                          MessageBoxIcon.Question) == DialogResult.Yes)
      {
        cbMachines.Items.RemoveAt(cbMachines.SelectedIndex);
        // select the first again if there is still one
        if (cbMachines.Items.Count > 0)
          cbMachines.SelectedIndex = 0;
        // flag that the machines have been changed
        _machinesChanged = true;
      }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      // create a show a dialog to enter the name for this machine
      fNewMachineName dlg = new fNewMachineName();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        // check the name
        if ((dlg.txtName.Text == "") || (dlg.txtName.Text.Trim() == "Custom"))
        {
          MessageBox.Show("Please provide a valid name for this machine. Don't use the name 'Custom' as this is a reserved name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
        // create a new machine
        MachineParameters newMachine = new MachineParameters(dlg.txtName.Text,
                                                             double.Parse(txtUSBDx.Text),
                                                             double.Parse(txtUSBDy.Text),
                                                             double.Parse(txtUSBdiameter.Text));
        // add it to our list
        _machines.Add(newMachine);
        // add it to the combo
        cbMachines.Items.Add(newMachine.Name);
        // select it
        cbMachines.SelectedIndex = _machines.Count - 1;
        // flag that the machines have been changed
        _machinesChanged = true;
      }

    }
  }
}
