using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace harrpeetFireGame
{
    public partial class Form1 : Form
    {
        Setting obj = new Setting();
        Random bulletno = new Random();
        int sound = 0,bullet=0;
        int shootClk = 0;
        
        public Form1()
        {
            InitializeComponent();

            

            pbGun.Image= Properties.Resources.bullet;
            MessageBox.Show("Wel Come to the Game \n You have only two bullet in first Chance \n if you want to play again then click on try again after that the game is over ");
            groupBox1.Visible = true;
            button2.Enabled = true;
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            pb_Gun.Image=Properties.Resources.load;
            button3.Enabled = true;
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sound = obj.fire();
            pb_Gun.Image = Properties.Resources.spin;
            button4.Enabled = true;
            button6.Enabled = true;

            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // this code is uused when we click on the shoot away button to fire 

            pb_Gun.Image = Properties.Resources.gun;

            shootClk++;
            //if the clik and sound generation value is equal then the message will print and create the sound of fire other wise the empty sound will sound
            if (shootClk == sound)
            {
                pbGun.Visible = true;

                // enable the timer to work
                timer1.Start();
                // generate the sound of the  fire trigger 
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.fire);
                player.Play();
                findWinner();
               
                
            }else {
                // generate the sound of the  empty trigger 
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.Empty);
                player.Play();
                MessageBox.Show("Retry to Shoot ");

            }
            if (shootClk==4 && shootClk!=sound) {
                MessageBox.Show("congrats! your player is survive ");
                button4.Enabled = false;
                button5.Enabled = true;
            }

        }
         //tooe code to find the winner of the game if the player win the game other wise it will generate an error 
        public void findWinner() {
            button6.Enabled = false;
            button4.Enabled = false;
            button5.Visible = true;

            MessageBox.Show("Player is dead ! Click on retry to play again");
            pbGun.Visible = false;
            pbGun.Left = 195;
        }
            // when this is last chance then the game over messsage will display and reset the game will print 

          
           
        
        // this code is used to try again the game again to play 
        public void reset() {

            //reset all global variable 
            bullet = 0;
            shootClk = 0;
            //calling the method of the sound 
            sound = obj.rd.Next(1, 6);
            //reseet the gun image 
            pb_Gun.Image = Properties.Resources._1st;
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Visible = false;
            groupBox1.Visible = true;
            button2.Enabled = true;

            bullet = 0;
            shootClk = 0;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            bullet++;
            if (bullet == sound)
            {

                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.fire);
                player.Play();
                MessageBox.Show("Thank God ! Player is alive ");
                button6.Enabled = false;
                button5.Visible = true;
            }
            else {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.Empty);
                player.Play();
            }

            if (bullet==2) {

                MessageBox.Show("Ending up!!");
                button6.Enabled = false;
                button5.Visible = true;
                bullet = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // when the bullet will reach at destination then the timer will stop automatically 
            if (pbGun.Left>600) {
                timer1.Stop();

            }
            // move the image of the bullet 
            pbGun.Left = pbGun.Left + obj.rd.Next(1, 34);

            //button1.Text = "" + pbGun.Left;
        }
    }
}
