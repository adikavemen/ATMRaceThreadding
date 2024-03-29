﻿using ATMProject.Properties;
using System;
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
        Image atm = Resources.ATM;
        Image insert = Resources.insert;

        Program thisProgram = ModePicker.thisProgram;
        private static System.Timers.Timer timer = new System.Timers.Timer();
        public MainScreenLogin()
        {
            InitializeComponent();

            accountNumberLbl.Visible = false;
            accountNumberTxtbox.Visible = false;
            pinNumberTxtbox.Visible = false;
            pinNumberLbl.Visible = false;
            mainLbl.Visible = false;
            submitBtn.Visible = false;
            submitLbl.Visible = false;
            gifRenderer.Visible = true;
        }
        private void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {

                //Account current = thisProgram.GetATM().getActiveAccount();
                if (thisProgram.isLoginSuccessful(Int32.Parse(accountNumberTxtbox.Text), Int32.Parse(pinNumberTxtbox.Text)) && thisProgram.GetATM().getActiveAccount().getBlocked() != true)
                {
                    thisProgram.GetATM().getActiveAccount().setAttemptsLeft(3);
                    new MainScreenATM(thisProgram.GetATM().getActiveAccount()).Show();
                    this.Hide();
                }
                else
                {
                    thisProgram.GetATM().getActiveAccount().setAttemptsLeft(thisProgram.GetATM().getActiveAccount().getAttemptsLeft() - 1);
                    if (thisProgram.GetATM().getActiveAccount().getAttemptsLeft() == 0)
                    {
                        thisProgram.GetATM().getActiveAccount().setBlocked(true);
                        MessageBox.Show("The card associated with this account has been blocked because of too many failed attempts", "Card Blocked!", MessageBoxButtons.OK);
                    }
                    else if (thisProgram.GetATM().getActiveAccount().getBlocked() == true)
                    {
                        MessageBox.Show("This card was previously blocked due to successive incorrect PIN entries", "Contact your bank branch!", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Please enter the correct account number or PIN. Your account will be blocked after enough failed attempts", "Login Failed!", MessageBoxButtons.OK);
                    }

                }
            }
            catch (System.FormatException o)
            {
                MessageBox.Show("Please enter the correct account number or PIN", "Login Failed!", MessageBoxButtons.OK);
            }
        }

        private void InsertCardBtn_Click(object sender, EventArgs e)
        {
            InsertCardBtn.Visible = false;
            gifRenderer.Image = insert;
            GifTimer timer = new GifTimer();
            timer.setTimer(1960);
            while (gifRenderer.Visible)
            {
                gifRenderer.Refresh();
                if (!timer.getClock().Enabled)
                {
                    accountNumberLbl.Visible = true;
                    accountNumberTxtbox.Visible = true;
                    pinNumberTxtbox.Visible = true;
                    pinNumberLbl.Visible = true;
                    submitLbl.Visible = true;
                    mainLbl.Visible = true;
                    submitBtn.Visible = true;
                    gifRenderer.Visible = false;
                    gifRenderer.Image = atm;
                }
            }
            gifRenderer.Visible = true;
        }
    }
}

