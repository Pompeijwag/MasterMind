using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterMind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PictureBox[] guesses = new PictureBox[41];      
        Button[] input = new Button[9];
        PictureBox[] hints = new PictureBox[41];
        PictureBox[] answerkey = new PictureBox[5];
        public static int[] hidden = new int[5];
        public static int[] guessing = new int[5];
        public static int[] temp = new int[5];
        Random generator = new Random();
        public int cursor = 1;                      // The current inputing box
        public int row = 0;                         // The current row of the input
        public int hintshown = 1;                   
        public static int pressed = 0;
        public static int redpips = 0, whitepips = 0;
        public bool finished = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            guesses[1] = pictureBox1;               // Assigning the objects to arrays
            guesses[2] = pictureBox2;
            guesses[3] = pictureBox3;
            guesses[4] = pictureBox4;
            guesses[5] = pictureBox5;
            guesses[6] = pictureBox6;
            guesses[7] = pictureBox7;
            guesses[8] = pictureBox8;
            guesses[9] = pictureBox9;
            guesses[10] = pictureBox10;
            guesses[11] = pictureBox11;
            guesses[12] = pictureBox12;
            guesses[13] = pictureBox13;
            guesses[14] = pictureBox14;
            guesses[15] = pictureBox15;
            guesses[16] = pictureBox16;
            guesses[17] = pictureBox17;
            guesses[18] = pictureBox18;
            guesses[19] = pictureBox19;
            guesses[20] = pictureBox20;
            guesses[21] = pictureBox21;
            guesses[22] = pictureBox22;
            guesses[23] = pictureBox23;
            guesses[24] = pictureBox24;
            guesses[25] = pictureBox25;
            guesses[26] = pictureBox26;
            guesses[27] = pictureBox27;
            guesses[28] = pictureBox28;
            guesses[29] = pictureBox29;
            guesses[30] = pictureBox30;
            guesses[31] = pictureBox31;
            guesses[32] = pictureBox32;
            guesses[33] = pictureBox33;
            guesses[34] = pictureBox34;
            guesses[35] = pictureBox35;
            guesses[36] = pictureBox36;
            guesses[37] = pictureBox37;
            guesses[38] = pictureBox38;
            guesses[39] = pictureBox39;
            guesses[40] = pictureBox40;
            answerkey[1] = pictureBox42;
            answerkey[2] = pictureBox43;
            answerkey[3] = pictureBox44;
            answerkey[4] = pictureBox45;
            input[1] = button1;
            input[2] = button2;
            input[3] = button3;
            input[4] = button4;
            input[5] = button5;
            input[6] = button6;
            input[7] = button7;
            input[8] = button8;
            hints[1] = pictureBox49;
            hints[2] = pictureBox50;
            hints[3] = pictureBox51;
            hints[4] = pictureBox52;
            hints[5] = pictureBox53;
            hints[6] = pictureBox54;
            hints[7] = pictureBox55;
            hints[8] = pictureBox56;
            hints[9] = pictureBox57;
            hints[10] = pictureBox58;
            hints[11] = pictureBox59;
            hints[12] = pictureBox60;
            hints[13] = pictureBox61;
            hints[14] = pictureBox62;
            hints[15] = pictureBox63;
            hints[16] = pictureBox64;
            hints[17] = pictureBox65;
            hints[18] = pictureBox66;
            hints[19] = pictureBox67;
            hints[20] = pictureBox68;
            hints[21] = pictureBox69;
            hints[22] = pictureBox70;
            hints[23] = pictureBox71;
            hints[24] = pictureBox72;
            hints[25] = pictureBox73;
            hints[26] = pictureBox74;
            hints[27] = pictureBox75;
            hints[28] = pictureBox76;
            hints[29] = pictureBox77;
            hints[30] = pictureBox78;
            hints[31] = pictureBox79;
            hints[32] = pictureBox80;
            hints[33] = pictureBox81;
            hints[34] = pictureBox82;
            hints[35] = pictureBox83;
            hints[36] = pictureBox84;
            hints[37] = pictureBox85;
            hints[38] = pictureBox86;
            hints[39] = pictureBox87;
            hints[40] = pictureBox88;
            for (int i = 1; i <= 8; i++)
            {
                input[i].Click += allbuttons;
            }
        }
        private void allbuttons(object sender, EventArgs e)     // Code for all the color buttons
        {  
            if (cursor <= 4)                                    
            {
                guessing[cursor] = pressed;                     // Enters the inputed sequence into guessing array
                if (pressed == 1)                               // Applies the color of the input
                {
                    guesses[(cursor + (4 * row))].BackColor = Color.Red;
                }
                else if (pressed == 2)
                {
                    guesses[(cursor + (4 * row))].BackColor = Color.Blue;
                }
                else if (pressed == 3)
                {
                    guesses[(cursor + (4 * row))].BackColor = Color.Green;
                }
                else if (pressed == 4)
                {
                    guesses[(cursor + (4 * row))].BackColor = Color.Yellow;
                }
                else if (pressed == 5)
                {
                    guesses[(cursor + (4 * row))].BackColor = Color.Orange;
                }
                else if (pressed == 6)
                {
                    guesses[(cursor + (4 * row))].BackColor = Color.Purple;
                }
                else if (pressed == 7)
                {
                    guesses[(cursor + (4 * row))].BackColor = Color.Cyan;
                }
                else if (pressed == 8)
                {
                    guesses[(cursor + (4 * row))].BackColor = Color.Black;
                }
                cursor = cursor + 1;
            }
        }
        

        private void button11_Click(object sender, EventArgs e)     // Start button
        {
            if (finished == true)                                   // Triggers when the program is re-ran
            {
                for (int i = 1; i <= 40; i++)                       // Restores all buttons and pictureboxes to original color
                {
                    guesses[i].BackColor = SystemColors.Control;
                    hints[i].BackColor = SystemColors.ButtonShadow;
                }
                for (int i = 1; i <= 4; i++)
                {
                    answerkey[i].Image = global::MasterMind.Properties.Resources._3005564;
                    answerkey[i].BackColor = SystemColors.Control;
                }
                finished = false;
            }
            row = 0; pressed = 0; cursor = 1; hintshown = 1;        // Restores all relevant variables
            for (int i = 1; i <= 4; i++)                            // Generates a random sequence
            {
                hidden[i] = generator.Next(1, 9);
                temp[i] = hidden[i];                                

            }
            button11.Visible = false;                               // Removes the start button
            for (int i = 1; i <= 8; i++)
            {
                input[i].Visible = true;
            }
            button9.Visible = true;
            button10.Visible = true;
            //label2.Text = "";                                     // Turn on to reveal answer on top right corner
            //for (int i = 1; i <= 4; i++)
            //{
            //    label2.Text = label2.Text + (Convert.ToString(hidden[i]));
            //}
        }

        private void button1_Click(object sender, EventArgs e)      // To know which button was pressed
        {
            pressed = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pressed = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pressed = 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pressed = 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pressed = 5;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pressed = 6;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pressed = 7;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pressed = 8;
        }

        private void button9_Click(object sender, EventArgs e)      // Delete button
        {
            if (cursor > 1)                                         // Removes the latest input
            {
                cursor = cursor - 1;
                guesses[(cursor + (4 * row))].BackColor = SystemColors.Control;
                guessing[cursor] = 0;
            }
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)        // Timer to flash the error message 
        {
            textBox1.Visible = false;
            timer1.Enabled = false;
        }

        private void button10_Click(object sender, EventArgs e)     // Enter button
        {
            if (cursor > 4)                                         
            {
                row = row + 1;                                      // Increases row by one
                cursor = 1;                 
                for (int i = 1; i <= 4; i++)                        // Checks for all the possible redpips
                {
                    if (hidden[i] == guessing[i])
                    {
                        redpips = redpips + 1;
                        hidden[i] = 0;                              // The guessing and answer sequence made to unreasonable numbers to remove them temperarily so it won't be used again in the same guess
                        guessing[i] = 99;
                    }                
                }
                for (int i = 1; i <= 4; i++)                        // Checking for all white pips
                {
                    for (int j = 1; j <= 4; j++)
                    {
                        if (i != j)                                 // Ignores the possible red pips
                        {
                            if (guessing[i] == hidden[j])
                            {
                                whitepips = whitepips + 1;
                                hidden[j] = 0;
                                guessing[i] = 99;
                            }
                        }
                    }
                    
                }
                if (redpips > 0)                                    // Shows the redpips 
                {
                    for (int i = 1; i <= redpips; i++)
                    {
                        hints[hintshown].BackColor = Color.Red; 
                        hintshown = hintshown + 1;
                    }
                }
                if (whitepips > 0)                                  // Shows the white pips
                {
                    for (int i = 1; i <= whitepips; i++)
                    {
                        hints[hintshown].BackColor = Color.White;
                        hintshown = hintshown + 1;
                    }
                }
                for (int i = 1; i <= 4; i++)                        // Restoring the hidden sequence
                {
                    hidden[i] = temp[i];
                }
                if (redpips == 4)                                   // Checking if the sequence is solved
                {
                    MessageBox.Show("You solved the sequence in " + row + " guesses!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    button11.Visible = true;
                    finished = true;

                }
                else if (row == 10)                                 // Failing the game if sequence is not solved after tenth guess
                {
                    MessageBox.Show("You didn't solve the sequence.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    button11.Visible = true;
                    finished = true;
                }
                hintshown = (row * 4) + 1;                          // Jumping hints to the next set of boxes
                whitepips = 0;                                      // resetting the red and white pips
                redpips = 0;
                if (finished == true)                               // If the game is finished, shows the hidden sequence up top
                {
                    for(int i = 1; i <= 4; i++)
                    {
                        answerkey[i].Image = null;
                        if (hidden[i] == 1)
                        {
                            answerkey[i].BackColor = Color.Red;
                        }
                        else if (hidden[i] == 2)
                        {
                            answerkey[i].BackColor = Color.Blue;
                        }
                        else if (hidden[i] == 3)
                        {
                            answerkey[i].BackColor = Color.Green;
                        }
                        else if (hidden[i] == 4)
                        {
                            answerkey[i].BackColor = Color.Yellow;
                        }
                        else if (hidden[i] == 5)
                        {
                            answerkey[i].BackColor = Color.Orange;
                        }
                        else if (hidden[i] == 6)
                        {
                            answerkey[i].BackColor = Color.Purple;
                        }
                        else if (hidden[i] == 7)
                        {
                            answerkey[i].BackColor = Color.Cyan;
                        }
                        else if (hidden[i] == 8)
                        {
                            answerkey[i].BackColor = Color.Black;
                        }
                        for (int j = 1; j <= 8; j++)                    // Hides the playable buttons
                        {
                            input[j].Visible = false;
                        }
                        button9.Visible = false;
                        button10.Visible = false;
                    }
                }
            }
            else                                                        // Activates the error message
            {
                timer1.Enabled = true;      
                textBox1.Visible = true;
            }
        }
    }
}
