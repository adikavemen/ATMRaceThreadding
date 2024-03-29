﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMProject
{
    public partial class ModePicker : Form
    {
        public static Program thisProgram = new Program();

        public ModePicker()
        {
            InitializeComponent();

            //Program thisProgram = new Program();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.raceCond = true;
            string message = "This Will Simulate A Race Condition. Go to withdraw from one ATM, the thread will lock until you withdraw from the second ATM. This is to allow for synronised withdrawals.";
            string info = "Information";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, info, buttons);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                //close the form and open the race condition windows

                //Application.Run(new MainScreenLogin());
                this.Hide();
                Program.startThreading();
                //MainScreenLogin mainScreenLogin = new MainScreenLogin();
                //mainScreenLogin.Show();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.raceCond = false;
            string message = "This Method Uses A Semaphore";
            string info = "Information";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, info, buttons);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                //close the form and open the race condition windows
                this.Close();
                Program.startThreading();
            }
        }
    }
}
