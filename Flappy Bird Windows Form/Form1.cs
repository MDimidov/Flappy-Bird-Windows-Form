using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird_Windows_Form
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 4;
        int pipeSpeedSaveScore = 0;
        int gravity = 8;
        int score = 0;

        int lengthBetweenPipes = 146;
        int pipesWidth = 52;
        int pipeTopMinHeight = 63;



        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            
            flappyBird.Top += gravity;      //move the bird to Upper
            pipeTop.Left -= pipeSpeed;      //move the top pipe to Left
            pipeBottom.Left -= pipeSpeed;   //move the botom pipeto Left

            scoreText.Text = $"Score: {score}";  //show current score ont the screen

            //if the pipes disapear we show them again
            if(pipeTop.Left < -50)
            {
                pipeTop.Left = 500;
                score++;                    //add score for every passed pipe
            }
            if(pipeBottom.Left < -50)
            {
                pipeBottom.Left = 500;

            }

            //Increase the speed on evry 5 sucssful passed pipes
            if (score % 5 == 0 && score != pipeSpeedSaveScore)
            {
                pipeSpeed++;
                pipeSpeedSaveScore = score;
            }

            //End the game when you touch the objects
            if (flappyBird.Bounds.IntersectsWith(pipeTop.Bounds)
                || flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds)
                || flappyBird.Bounds.IntersectsWith(ground.Bounds)
                || flappyBird.Top < -10)
            {
                endGame();
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -11;
            }

            
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 8;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over!!!";
        }
    }
}
