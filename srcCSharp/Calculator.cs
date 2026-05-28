using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharpenerCalculator
{
  class MachineParameters
  {
    public string Name { get; set; }
    public double USBdx { get; set; }

    public double USBdy { get; set; }

    public double USBdiameter { get; set; }

    public MachineParameters(string sName, double dUSBdx, double dUSBdy, double dUSBdiameter)
    {
      // keep the parameters
      Name = sName;
      USBdx = dUSBdx;
      USBdy = dUSBdy;
      USBdiameter = dUSBdiameter;
    }

    public static List<MachineParameters> BuildDefaultMachineList()
    {
      // create the list
      List<MachineParameters> machines = new List<MachineParameters>();
      // add some machines
      machines.Add(new MachineParameters("Toremek T8 USB used on top", 50, 29, 12));
      machines.Add(new MachineParameters("Toremek T8 USB used on the side", 145, 49, 12));
      machines.Add(new MachineParameters("Toremek T4 USB used on top", 50, 20, 12));
      machines.Add(new MachineParameters("Toremek T4 USB used on the side", 120, 40, 12));
      return machines;
    }

    public static void WriteMachineParametersToFile (List<MachineParameters> machines, string Filename)
    {
      // throw exception in case of null
      if (machines == null)
        throw new ArgumentNullException("machines", "The machine list can't be null!");
      if (machines.Count == 0)
        return;
      // throw exception in case of null
      if (Filename == null)
        throw new ArgumentNullException("Filename", "The filename can't be null!");
      // serialize the class
      string output = JsonConvert.SerializeObject(machines, Newtonsoft.Json.Formatting.Indented);
      // and dump it to a file;
      try
      {
        System.IO.File.WriteAllText(Filename, output);
      }
      catch (Exception ex)
      {
        // something went wrong
        throw new System.ArgumentException("Saving settings failed! The filename is: " + Filename + ": " + ex.Message, "Filename");
      }
    }

    public static List<MachineParameters> ReadMachineParametersFromFile (string Filename)
    {
      // throw exception in case of null
      if (Filename == null)
        throw new ArgumentNullException("Filename", "The filename can't be null!");
      // check if the file exist
      System.IO.FileInfo fi = new System.IO.FileInfo(Filename);
      if (!fi.Exists)
        return null;
      // read the file content
      string input = System.IO.File.ReadAllText(Filename);
      // initialize the result
      List<MachineParameters> machines = null;
      try
      {
        machines = JsonConvert.DeserializeObject<List<MachineParameters>>(input);
      }
      catch (Exception e)
      {
        // something went wrong
        throw new System.ArgumentException("Loading settings failed! The filename is: " + Filename + ": " + e.Message, "Filename");
      }
      return machines;
    }
  }

  class Calculator
  {
  
    public Calculator()
    {
      // nothing to do here, it's all static
    }

    public MachineParameters Machine { get; private set; }

    public static double USBHeight(MachineParameters Machine, double WheelDiameter, double JigProjectionLength, double TargetAngle)
    {
      // we need a machine to do the calculations
      if (Machine == null)
        throw new ArgumentException("The machine parameters are required for the calculation!");
      // the diameter is 150 to 250 mm
      if (WheelDiameter <= 0)
        throw new ArgumentException("The wheel diameter should be greater than 0");
      if (JigProjectionLength <= 0)
        throw new ArgumentException("The JigProjectionLength should be greater than 0");
      if (TargetAngle <= 0)
        throw new ArgumentException("The target angle should be greater than 0");
      // the radius of the wheel
      double r = WheelDiameter / 2.0;
      // the jig projection length minus half of the diameter of the USB (12mm for Tormek)
      double k = JigProjectionLength - Machine.USBdiameter / 2;
      // the length from below the USB to the blade
      double l = Math.Sqrt(k * k + Machine.USBdiameter * Machine.USBdiameter);
      // target angle minus the angle build by jigprojectionlength and USB 
      double alpha = TargetAngle - RadianToDegree(12 / (JigProjectionLength - Machine.USBdiameter / 2));
      // and finally the height in two steps
      double m = Math.Pow(r, 2) + Math.Pow(l, 2) - 2 * r * l * Math.Cos(DegreeToRadian(alpha + 90));
      return Math.Sqrt(m - Machine.USBdx * Machine.USBdx) - Machine.USBdy + Machine.USBdiameter / 2;
    }

    public static double USB2Wheel(MachineParameters Machine, double WheelDiameter, double JigProjectionLength, double TargetAngle)
    {
      // we need a machine to do the calculations
      if (Machine == null)
        throw new ArgumentException("The machine parameters are required for the calculation!");
      // the diameter is 150 to 250 mm
      if (WheelDiameter <= 0)
        throw new ArgumentException("The wheel diameter should be greater than 0");
      if (JigProjectionLength <= 0)
        throw new ArgumentException("The JigProjectionLength should be greater than 0");
      if (TargetAngle <= 0)
        throw new ArgumentException("The target angle should be greater than 0");
      // the radius of the wheel
      double r = WheelDiameter / 2.0;
      // correcting the angle
      double alpha = TargetAngle - RadianToDegree(Machine.USBdiameter / (JigProjectionLength - Machine.USBdiameter / 2));
      // and finally the distance in two steps
      double k = Math.Sqrt(Math.Pow(JigProjectionLength - Machine.USBdiameter / 2, 2) + Math.Pow(Machine.USBdiameter, 2));
      double m = Math.Sqrt(Math.Pow(r, 2) + Math.Pow(k, 2) - 2 * r * k * Math.Cos(DegreeToRadian(alpha + 90)));
      return m - r + Machine.USBdiameter / 2;
    }

    static double DegreeToRadian(double degree)
    {
      return degree * Math.PI / 180.0;
    }

    static double RadianToDegree(double radian)
    {
      return radian *  180.0 / Math.PI;
    }
  }
}

