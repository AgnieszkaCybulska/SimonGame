using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Memory_game : Form
    {
        public Memory_game()
        {
            InitializeComponent();
            generateActivButton();
        }

        private void showSequence()
        {
            Button[] allButtons = {this.button1, this.button2, this.button3,
                                    this.button4, this.button5, this.button6,
                                    this.button7, this.button8, this.button9};

            if (index < drawnButtons.Count)
            {
                allButtons[drawnButtons[index]].BackColor = Color.DeepSkyBlue;
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Button[] allButtons = {this.button1, this.button2, this.button3,
                                    this.button4, this.button5, this.button6,
                                    this.button7, this.button8, this.button9};
            timer1.Stop();
            if (isLight == true)
            {
                this.pictureBox3.BackgroundImage = this.pictureBox4.BackgroundImage = this.pictureBox5.BackgroundImage =
                this.pictureBox6.BackgroundImage = this.pictureBox7.BackgroundImage = (Image)test.Properties.Resources.diode_off;
            }
            if(endGame == true)
            {
                Application.Exit();
            }
            if (enabledButtons == true)
            {
                this.button1.BackColor = this.button2.BackColor = this.button3.BackColor =
                this.button4.BackColor = this.button5.BackColor = this.button6.BackColor =
                this.button7.BackColor = this.button8.BackColor = this.button9.BackColor = Color.Black;
                index++;
                showSequence();
            }
        }

        private void repeatGame()
        {
            this.button10.BackColor = this.button11.BackColor = this.button12.BackColor =
            this.button13.BackColor = this.button14.BackColor = this.button15.BackColor =
            this.button16.BackColor = this.button17.BackColor = this.button18.BackColor = Color.DimGray;

            drawnButtons.Clear();
            selectedButtons.Clear();
            nameDrawnButtons.Clear();

            this.button10.Enabled = this.button11.Enabled = this.button12.Enabled =
            this.button13.Enabled = this.button14.Enabled = this.button15.Enabled =
            this.button16.Enabled = this.button17.Enabled = this.button18.Enabled = true;
            enabledButtons = true;
            generateActivButton();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            if (pressedButton == true)
            {
                clickedButton.BackColor = Color.DimGray;
                pressedButton = false;
            }
            if (enabledButtons == false)
            {
                counter = 0;
                pictureCounter = 12;
                repeatGame();
                enabledButtons = true;
            }
        }
        private void generateActivButton()
        {
            Button[] allButtons = {this.button1, this.button2, this.button3,
                                    this.button4, this.button5, this.button6,
                                    this.button7, this.button8, this.button9};
            buttons = allButtons;

            Random random = new Random();
            randomButton = random.Next(allButtons.Length);
            nameRandomButton = "button" + (randomButton + 10);
            drawnButtons.Add(randomButton);
            nameDrawnButtons.Add(nameRandomButton);

            if (drawnButtons.Count == 6)
            {
                end_label.Enabled = end_label.Visible = true;
                endGame = true;
                timer1.Start();
            }
            else
            {
                index = 0;
                showSequence();
            }
            timer1.Enabled = true;
        }

        private void buttons_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            
            pressedButton = true;
            clickedButton = button;
            clickedButton.BackColor = Color.DeepSkyBlue;
            timer2.Start();
            selectedButtons.Add(button.Name);

            if(nameDrawnButtons.Count > 0)
            {
                if (selectedButtons[counter] == nameDrawnButtons[counter])
                {
                    lightRightDiods();

                    if (counter == (nameDrawnButtons.Count - 1))
                    {
                        generateActivButton();
                        lightLeftDiods();
                        selectedButtons.Clear();
                        counter = 0;
                        pictureCounter--;
                    }
                    else
                    {
                        counter++;
                    }
                }
                else
                {
                    wrongButton();
                }
            }
        }
        private void wrongButton()
        {
            this.pictureBox8.BackgroundImage = this.pictureBox9.BackgroundImage = this.pictureBox10.BackgroundImage =
            this.pictureBox11.BackgroundImage = this.pictureBox12.BackgroundImage = (Image)test.Properties.Resources.diode_off;

            this.button10.BackColor = this.button11.BackColor = this.button12.BackColor =
            this.button13.BackColor = this.button14.BackColor = this.button15.BackColor =
            this.button16.BackColor = this.button17.BackColor = this.button18.BackColor = Color.Red;

            this.button10.Enabled = this.button11.Enabled = this.button12.Enabled =
            this.button13.Enabled = this.button14.Enabled = this.button15.Enabled =
            this.button16.Enabled = this.button17.Enabled = this.button18.Enabled = false;
            enabledButtons = false;

            timer1.Start();
        }
        private void lightRightDiods()
        {
            switch (counter)
            {
                case 0:
                    pictureBox3.BackgroundImage = (Image)test.Properties.Resources.diode_on;
                    break;
                case 1:
                    pictureBox3.BackgroundImage = pictureBox4.BackgroundImage = (Image)test.Properties.Resources.diode_on;
                    break;
                case 2:
                    pictureBox3.BackgroundImage = pictureBox4.BackgroundImage = pictureBox5.BackgroundImage = (Image)test.Properties.Resources.diode_on;
                    break;
                case 3:
                    pictureBox3.BackgroundImage = pictureBox4.BackgroundImage = pictureBox5.BackgroundImage =
                    pictureBox6.BackgroundImage = (Image)test.Properties.Resources.diode_on;
                    break;
                case 4:
                    this.pictureBox3.BackgroundImage = this.pictureBox4.BackgroundImage = this.pictureBox5.BackgroundImage =
                    this.pictureBox6.BackgroundImage = this.pictureBox7.BackgroundImage = (Image)test.Properties.Resources.diode_on;
                    break;
            }
            isLight = true;
        }

        private void lightLeftDiods()
        {
            pictureBox12.BackgroundImage = (Image)test.Properties.Resources.diode_on;

            switch(pictureCounter)
            {
                case 11:
                    pictureBox11.BackgroundImage = (Image)test.Properties.Resources.diode_on;
                    break;
                case 10:
                    pictureBox10.BackgroundImage = (Image)test.Properties.Resources.diode_on;
                    break;
                case 9:
                    pictureBox9.BackgroundImage = (Image)test.Properties.Resources.diode_on;
                    break;
                case 8:
                    pictureBox8.BackgroundImage = (Image)test.Properties.Resources.diode_on;
                    break;
            }
        }
    }
}

