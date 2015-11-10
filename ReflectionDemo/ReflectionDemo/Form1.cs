using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace ReflectionDemo
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Implement Button Click Commands
        private void button1_Click(object sender, EventArgs e)
        {
            //Creating Machines
            var car = MachineFactory.CreateMachine("Car");
            var microwave = MachineFactory.CreateMachine("Microwave");
            var tv = MachineFactory.CreateMachine("TV");
            var computer = MachineFactory.CreateMachine("Computer");
            var freezer = MachineFactory.CreateMachine("Freezer");

            //Setting Error labels to non-visable
            label4.Visible = false;
            label5.Visible = false;


            //If statement to determine if combobox selection was made and which message to add to output
            if (comboBox1.SelectedIndex == -1)
            {
                label4.Visible = true;
            }
            else if (comboBox1.SelectedItem.ToString() == "Car")
            {
                label1.Text = car.Message;
            }
            else if (comboBox1.SelectedItem.ToString() == "Microwave")
            {
                label1.Text = microwave.Message;
            }
            else if (comboBox1.SelectedItem.ToString() == "TV")
            {
                label1.Text = tv.Message;
            }
            else if (comboBox1.SelectedItem.ToString() == "Computer")
            {
                label1.Text = computer.Message;
            }
            else if (comboBox1.SelectedItem.ToString() == "Freezer")
            {
                label1.Text = freezer.Message;
            }


            //If statement to determine if a radio button was selected and to add starting/stopping message to output
            if (radioButton1.Checked && label4.Visible == false)
            {
                label1.Text = label1.Text + " is starting...";
            }
            else if (radioButton2.Checked && label4.Visible == false)
            {
               label1.Text = label1.Text + " is stopping...";
            }
            else if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                label5.Visible = true;
            }


            //If statement to make output visible once error labels are non-visible
            if (label4.Visible == false && label5.Visible == false)
            {
                label1.Visible = true;
            }

        }

        // Exit Button
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Reset Button clears all fields and makes error and output labels non-visible
        private void button2_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            comboBox1.SelectedIndex = -1;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
    }


    //IMachine Interace
    public interface IMachine
    {
        string Message { get; }
    }

    //Class Car with inheritance from IMachine and sets message
    public class Car : IMachine
    {
        private string _message;

        public string Message
        {
            get { return _message; }
        }

        public Car()
        {
            this._message = "Car";
        }
    }

    //Class Microwave with inheritance from IMachine and sets message
    public class Microwave : IMachine
    {
        private string _message;

        public string Message
        {
            get { return _message; }
        }

        public Microwave()
        {
            this._message = "Microwave";
        }
    }

    //Class TV with inheritance from IMachine and sets message
    public class TV : IMachine
    {
        private string _message;

        public string Message
        {
            get { return _message; }
        }

        public TV()
        {
            this._message = "TV";
        }
    }

    //Class Computer with inheritance from IMachine and sets message
    public class Computer : IMachine
    {
        private string _message;

        public string Message
        {
            get { return _message; }
        }

        public Computer()
        {
            this._message = "Computer";
        }
    }

    //Class Freezer with inheritance from IMachine and sets message
    public class Freezer : IMachine
    {
        private string _message;

        public string Message
        {
            get { return _message; }
        }

        public Freezer()
        {
            this._message = "Freezer";
        }
    }


    //Machine Factory 
    public static class MachineFactory
    {

        //Implements IMachine 
        public static IMachine CreateMachine(string selection)
        {
            //Get the correct type using reflection
            var machineType = Assembly.GetCallingAssembly()
                .GetTypes()
                .Where(t => t.Name.Equals(selection, StringComparison.CurrentCulture))
                .FirstOrDefault();

            //Activator.CreateInstance to create a new machineType for newMachine
            var newMachine = (IMachine)Activator.CreateInstance(machineType);

            //return newMachine
            return newMachine;
        }
    }

}
