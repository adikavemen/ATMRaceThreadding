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
    public partial class MainScreenLogin : Form
    {
        Program thisProgram = new Program();
        public MainScreenLogin()
        {
            InitializeComponent();
        }
        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (thisProgram.isLoginSuccessful(Int32.Parse(accountNumberTxtbox.Text), Int32.Parse(pinNumberTxtbox.Text)))
            {
                //TODO:Implement Success Condition
                new MainScreenATM(thisProgram.GetATM().getActiveAccount()).Show();
                new MainScreenATM(thisProgram.GetATM().getActiveAccount()).Show();
                this.Hide();
            }
            else
            {
                //TODO:Implement Failure Condition
                MessageBox.Show("Please enter the correct account number or PIN", "Login Failed!", MessageBoxButtons.OK);

            }
        }

    }
}

