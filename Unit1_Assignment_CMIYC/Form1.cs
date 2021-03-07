//Roxxannia Wang;
//Feb 26, 2019;
//Unit 1 Assignment - Catch Me If You Can: The End Game;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Unit1_Assignment_CMIYC
{

    public partial class Form1 : Form
    {
        //Declare Variable
        int x;
        int y;
        int locx;
        int locy;
        int a;
        int b;
        int score;
        int loca;
        int locb;

        //boolean expression for moveUp, moveDown, moveLeft, moveRight;
        bool moveUp = false;
        bool moveDown = false;
        bool moveLeft = false;
        bool moveRight = false;
        bool isOn;

        public Form1()
        {
            InitializeComponent();
            //set player starting location at (0,0)
            x = 0;
            y = 0;
            picPlayer.Location = new Point(x, y);

            //set Thanos starting location at (100,0) 
            a = 150;
            b = 0;
            picThanos.Location = new Point(a, b);
                       
        }
        //subprogram reset player location to (0,0)
        void ResetPlayer()
        {
            x = 0;
            y = 0;
            picPlayer.Location = new Point(x, y);
        }

        //subprogram reset Thanos location to (150, 0)
        void ResetEnemy()
        {
            a = 150;
            b = 0;
            picThanos.Location = new Point(a, b);
        }

        //subprogram to reset the avengers team to its original location 
        void ResetAvengersTeam()
        {
            Mem_02.Image = null;
            picSpiderman.Location = new Point(253, 145);
            Mem_09.Image = null;
            picThor.Location = new Point(613, 195);
            Mem_10.Image = null;
            picIronman.Location = new Point(1043, 166);
            Mem_06.Image = null;
            picBlackwidow.Location = new Point(1129, 292);
            Mem_08.Image = null;
            picCaptainamerica.Location = new Point(817, 322);
            Mem_03.Image = null;
            picBlackpanther.Location = new Point(171, 283);
            Mem_07.Image = null;
            picHulk.Location = new Point(33, 511);
            Mem_04.Image = null;
            picGroot.Location = new Point(399, 375);
            Mem_05.Image = null;
            picHawkeye.Location = new Point(632, 511);
            Mem_01.Image = null;
            picAntman.Location = new Point(993, 437);
        }

        //set avengers team original location
        void AvengersTeamLocation()
        {
            picAntman.Location = new Point(993, 437);
            picHawkeye.Location = new Point(632, 511);
            picGroot.Location = new Point(399, 375);
            picHulk.Location = new Point(33, 511);
            picBlackpanther.Location = new Point(171, 283);
            picCaptainamerica.Location = new Point(817, 322);
            picBlackwidow.Location = new Point(1129, 292);
            picIronman.Location = new Point(1043, 166);
            picThor.Location = new Point(613, 195);
            picSpiderman.Location = new Point(253, 145);
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {   
            //before the game starts, player needs to click ok to start the game
            MessageBox.Show("Click to Start the game: The End Game");
            //before the game starts, the instruction window is shown, click ok to start the game
            MessageBox.Show("Instruction\r\nUse WSAD or arrow keys to move the Avengers team around to\r\ncollect members and avoid being caught by Thanos.\r\nYou have to collect all 10 superheros to beat Thanos.\r\nOnce you collect all the Superheros,\r\nyou need to chase catch Thanos.\r\nIt will move twice faster away from you.\r\nTo win the game,\r\nyou have to beat Thanos with 10 avengers to catch him.");
            //when the form is loaded, the size of the form is set to maximum;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            lblAvengers.Text = "Avengers Team";
            btnHelp.Visible = true;
            picPause.Visible = true;
            picRestart.Visible = true;
            picResume.Visible = true;
            btnHelp.Text = "Help";
            tmrLoop.Enabled = true;
            tmrEnemy.Enabled = true;
            AvengersTeamLocation();
            pnlPause.Visible = false;
            pnlHelp.Visible = false;
            lblCredits.Visible = false;
            pnlGameover.Visible = false;
            //subprogram random is used;
            Random();
            lblScore.Text = "Score";
            //score starts with 0;
            score = 0;
            lblScorecount.Text = score.ToString(); ;
            pnlWinner.Visible = false;
        }

        //set random number program, generates integers in the set range;
        void Random()
        {
            Random pos = new Random();
            //set both locx and locy range to be between 3 and 4; locx and locy are the orginal moving speed of thanos
            locx = pos.Next(3, 4);
            locy = pos.Next(3, 4);
            //set both loca and locb range to be between 6 and 8; loca and locb are the speed of thanos after Player collected 10 items;
            loca = pos.Next(6, 8);
            locb = pos.Next(6, 8);            
        }

        //keydown event
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //if key W or up arrow key is pressed, player vetically can move up by 3 units
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                y = y - 3;
                moveUp = true;
            }
            //otherwise key S or down arrow key is pressed, player vetically can move down by 3 units
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                y = y + 3;
                moveDown = true;
            }
            //if key A or left arrow key is pressed, player vetically can move left by 3 units
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                x = x - 3;
                moveLeft = true;
            }
            //if key D or right arrow key is pressed, player vetically can move right by 3 units
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                x = x + 3;
                moveRight = true;
            }
        }

        //timer loop event
        private void tmrLoop_Tick(object sender, EventArgs e)
        {
            //set boundries
            //if player is moving up, 
            if (moveUp == true)
            {
                //if vertical component is greater than 0,
                if (y > 0)
                {
                    //the player can not go up and is restricted in the boudries
                    y = y - 3;
                    picPlayer.Location = new Point(x, y);
                }
            }
            //otherwise, if the player is moving down
            else if (moveDown == true)
            {
                //if the vertical component is going beyond the form size
                if (y < this.ClientSize.Height - picPlayer.Height)
                {
                    //the player can not go down and is restricted in the boudries
                    y = y + 3;
                    picPlayer.Location = new Point(x, y);
                }

            }
            //otherwise, if the player is moving left
            else if (moveLeft == true)
            {
                //if horizontal component is greater than 0,
                if (x > 0)
                {
                    //the player can not go more left and is restricted in the boudries
                    x = x - 3;
                    picPlayer.Location = new Point(x, y);
                }
            }
            else if (moveRight == true)
            {
                //if horizontal component is greater than the size of the form
                if (x < this.ClientSize.Width - picPlayer.Width)
                {
                    //the player can not go more right and is restricted in the boudries
                    x = x + 3;
                    picPlayer.Location = new Point(x, y);
                }
            }
            Collisions();
            Gameover();
            PlayerChasing();
        }

        //subprogram of collision events
        void Collisions()
        {
            //when the player intersects with the any of the 10 team members
            //the team member picture will be collected in the team
            //score will go up by one
            //total score is 10
            if (picPlayer.Bounds.IntersectsWith(picAntman.Bounds) == true)
            {
                Mem_01.Image = picAntman.Image;
                picAntman.Location = new Point(2000, 2000);
                lblScorecount.Visible = true;
                score = score + 1;
                lblScorecount.Text = score.ToString();
            }
            if (picPlayer.Bounds.IntersectsWith(picSpiderman.Bounds) == true)
            {
                Mem_02.Image = picSpiderman.Image;
                picSpiderman.Location = new Point(2000, 2000);
                lblScorecount.Visible = true;
                score = score + 1;
                lblScorecount.Text = score.ToString();
            }
            if (picPlayer.Bounds.IntersectsWith(picBlackpanther.Bounds) == true)
            {
                Mem_03.Image = picBlackpanther.Image;
                picBlackpanther.Location = new Point(2000, 2000);
                lblScorecount.Visible = true;
                score = score + 1;
                lblScorecount.Text = score.ToString();
            }
            if (picPlayer.Bounds.IntersectsWith(picGroot.Bounds) == true)
            {
                Mem_04.Image = picGroot.Image;
                picGroot.Location = new Point(2000, 2000);
                lblScorecount.Visible = true;
                score = score + 1;
                lblScorecount.Text = score.ToString();
            }
            if (picPlayer.Bounds.IntersectsWith(picHawkeye.Bounds) == true)
            {
                Mem_05.Image = picHawkeye.Image;
                picHawkeye.Location = new Point(2000, 2000);
                lblScorecount.Visible = true;
                score = score + 1;
                lblScorecount.Text = score.ToString();
            }
            if (picPlayer.Bounds.IntersectsWith(picBlackwidow.Bounds) == true)
            {
                Mem_06.Image = picBlackwidow.Image;
                picBlackwidow.Location = new Point(2000, 2000);
                lblScorecount.Visible = true;
                score = score + 1;
                lblScorecount.Text = score.ToString();
            }
            if (picPlayer.Bounds.IntersectsWith(picHulk.Bounds) == true)
            {
                Mem_07.Image = picHulk.Image;
                picHulk.Location = new Point(2000, 2000);
                lblScorecount.Visible = true;
                score = score + 1;
                lblScorecount.Text = score.ToString();
            }
            if (picPlayer.Bounds.IntersectsWith(picCaptainamerica.Bounds) == true)
            {
                Mem_08.Image = picCaptainamerica.Image;
                picCaptainamerica.Location = new Point(2000, 2000);
                lblScorecount.Visible = true;
                score = score + 1;
                lblScorecount.Text = score.ToString();
            }
            if (picPlayer.Bounds.IntersectsWith(picThor.Bounds) == true)
            {
                Mem_09.Image = picThor.Image;
                picThor.Location = new Point(2000, 2000);
                lblScorecount.Visible = true;
                score = score + 1;
                lblScorecount.Text = score.ToString();
            }
            if (picPlayer.Bounds.IntersectsWith(picIronman.Bounds) == true)
            {
                Mem_10.Image = picIronman.Image;
                picIronman.Location = new Point(2000, 2000);
                lblScorecount.Visible = true;
                score = score + 1;
                lblScorecount.Text = score.ToString();
            }
        }

        //subprogram to reset score
        //when the game is restarted, the score in counted from 0 again
        void ScoreReset()
        {
            score = 0;
            lblScorecount.Text = score.ToString();
            
        }

        //subprogram fo thanos chasing the player
        void ThanosChasing()
        {            
            picThanos.Location = new Point(a, b);
            //when the player is on the right of thanos
            if (picPlayer.Location.X >= picThanos.Location.X)
            {
                //thanos move right by the speed of 3 or 4;
                a += locx;                             
            }
            //when the player is on the left of thanos
            if (picPlayer.Location.X < picThanos.Location.X)
            {
                //thanos move left by the speed of 3 or 4;
                a -= locx;
            }
            //when the player is below of thanos
            if (picPlayer.Location.Y >= picThanos.Location.Y)
            {
                //thanos move down by the speed of 3 or 4;
                b += locy;                
            }
            //when the player is above right of thanos
            if (picPlayer.Location.Y < picThanos.Location.Y)
            {
                //thanos move up by the speed of 3 or 4;
                b -= locy;                
            }
        }

        //subprogram: when the player collects all 10 members
        void Winner()
        {
            //if the player catches Thanos
            if(picPlayer.Bounds.IntersectsWith(picThanos.Bounds) == true)
            {
                lblGameover.Visible = false;
                //panel winner will show
                pnlWinner.Visible = true;
                //both timmer stops;
                tmrLoop.Stop();
                tmrEnemy.Stop();
                //Show test "you saved the universe"
                lblWinner.Text = "You saved the universe!";
                //choice to play the game again
                btnRestartinwinner.Text = "Restart";
            }
        }

        //subprogram: when the player lose
        void Gameover()
        {
            //if the player is caught by Thanos
            if (picThanos.Bounds.IntersectsWith(picPlayer.Bounds) == true)
            {
                //panel Game over shows
                pnlGameover.Visible = true;
                //both timer stops
                tmrLoop.Stop();
                tmrEnemy.Stop();
            }
        }

        //when the restart picture is clicked
        private void picRestart_Click(object sender, EventArgs e)
        {
            //reset position of player, thanos, avengers team, and score
            ResetPlayer();
            ResetEnemy();
            ResetAvengersTeam();
            ScoreReset();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //when help button is clicked, timers stop, help panel displays and pause panel hides;
            tmrLoop.Stop();
            tmrEnemy.Stop();
            pnlHelp.Visible = true;
            pnlPause.Visible = false;
        }

        //when pause button is clicked
        private void picPause_Click(object sender, EventArgs e)
        {
            //timers stop and pause panel displays;
            tmrLoop.Stop();
            tmrEnemy.Stop();
            pnlPause.Visible = true;

        }

        //when pause picture is clicked
        private void pnlPause_Paint(object sender, PaintEventArgs e)
        {
            //show "the game is paused
            lblPause.Text = "The Game is paused";
            //show 3 buttons: help, resume and restart
            btnHelpinpause.Text = "Help";
            btnResume.Text = "Resume";
            btnRestart.Text = "Restart";
        }

        //when button restart is clicked
        private void btnRestart_Click(object sender, EventArgs e)
        {
            //reset position of player, enemy, avengers team
            ResetPlayer();
            ResetEnemy();
            ResetAvengersTeam();
            //start timers
            tmrLoop.Start();
            tmrEnemy.Start();
            //reset score
            ScoreReset();
            pnlPause.Visible = false;
        }
        //when rusume button is clicked
        private void btnResume_Click(object sender, EventArgs e)
        {
            //timers start
            tmrLoop.Start();
            tmrEnemy.Start();
            pnlPause.Visible = false;
        }

        //when panel help is displayer
        private void pnlHelp_Paint(object sender, PaintEventArgs e)
        {
            //show instruction of the game;
            lblInstruction.Text = "Instruction\r\nUse WSAD or arrow keys to move the Avengers team around to\r\ncollect members and avoid being caught by Thanos.\r\nYou have to collect all 10 superheros to beat Thanos.\r\nOnce you collect all the Superheros,\r\nyou need to chase catch Thanos.\r\nIt will move twice faster away from you.\r\nTo win the game,\r\nyou have to beat Thanos with 10 avengers to catch him.";
            //show button help, resume credicts, 
            btnResumeinhelp.Text = "Resume";
            btnViewcredits.Text = "Credits";
            btnRestartinhelp.Text = "Restart";

        }
        //when the resume button in Help panel is clicked
        private void btnResumeinhelp_Click(object sender, EventArgs e)
        {
            //timers start and panel help hides
            tmrLoop.Start();
            tmrEnemy.Start();
            pnlHelp.Visible = false;
        }

        //when restart button in help is clicked
        private void bntRestartinhelp_Click(object sender, EventArgs e)
        {
            //reset position of player, enemy, avengers team
            ResetPlayer();
            ResetEnemy();
            ResetAvengersTeam();
            //help panel hides
            pnlHelp.Visible = false;
            //start timers
            tmrLoop.Start();
            tmrEnemy.Start();
            //reset score
            ScoreReset();
        }

        //when button view credits is clicked
        private void btnViewcredits_Click(object sender, EventArgs e)
        {
            //credits is shown
            lblCredits.Visible = true;
            lblCredits.Text = "Credits\r\nCode:Roxxannia Wang\r\nDesign:Roxxannia Wang\r\nCompany: Catch GG";
            //hide help panel
            pnlHelp.Visible = false;
        }

        //when credits is cliked
        private void lblCredits_Click(object sender, EventArgs e)
        {
            //it goes back to the help panel
            lblCredits.Visible = false;
            pnlHelp.Visible = true;
        }

        //when resume is cliked
        private void picResume_Click(object sender, EventArgs e)
        {
            //timers start
            tmrLoop.Start();
            tmrEnemy.Start();
        }
        //when help button in pause is clicked
        private void btnHelpinpause_Click(object sender, EventArgs e)
        {
            //show help panel and hide pause panel
            pnlHelp.Visible = true;
            pnlPause.Visible = false;
        }

        private void pnlGameover_Paint(object sender, PaintEventArgs e)
        {
            //whne panel gameover is shown, it shows the message indicating the player lost and restart button is shown
            lblGameover.Text = "Thanos snapped and the destroyed the universe";
            lblGameover.Visible = true;
            btnRestartingameover.Text = "Restart";
        }

        //when the restart button in game over is clicked
        private void btnRestartingameover_Click(object sender, EventArgs e)
        {
            //player, enemy, avengers team's position is reseted
            ResetPlayer();
            ResetEnemy();
            ResetAvengersTeam();
            //game over panel hides
            pnlGameover.Visible = false;
            //start both timers
            tmrLoop.Start();
            tmrEnemy.Start();
            //reset score
            ScoreReset();
        }
        //key up event, when the WSAD or arrows keys are lifeted, the corresponing action stops
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                y = y - 5;
                moveUp = false;
            }
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                y = y + 5;
                moveDown = false;
            }
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                x = x - 5;
                moveLeft = false;
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                x = x + 5;
                moveRight = false;
            }
        }

        
        private void tmrEnemy_Tick(object sender, EventArgs e)
        {
            //thanos chaning subprogram suns under Timer enemy
            ThanosChasing();
        }

        //subprogram player chasing
        void PlayerChasing()
        {
            //if the score is greater or equal to 10                  
       
          if (score >= 10)
            {
                if (moveUp == true)
                {
                    y = y - 6;
                }
                else if (moveDown == true)
                {
                    y = y + 6;
                }
                else if (moveRight == true)
                {
                    x = x + 6;
                }
                else if (moveLeft== true)
                {
                    x = x - 6;
                }
                //run subprogram winner
                Winner();
                picThanos.Location = new Point(a, b);
                //if the player's x component is greater than or equal to the x component of thanos
                if (picPlayer.Location.X >= picThanos.Location.X)
                {
                    //thanos move to the left
                    a -= loca;
                    //set boundries
                    if (a<0)
                    {
                        loca = -loca;
                    }
                }
                //if the player's x component is less than the x component of thanos
                else if (picPlayer.Location.X < picThanos.Location.X)
                {
                    //thanos move to right
                    a += loca;
                    //set boundries
                    if (a>this.ClientSize.Width)
                    {
                        loca = -loca;
                    }
                }
                //if the player's y component is greater than or equal to the y component of thanos
                else if (picPlayer.Location.Y >= picThanos.Location.Y)
                {
                    //thanos move up
                    b -= locb;
                    //set boundries
                    if (b<0)
                    {
                        locb = -locb;
                    }
                }
                //if the player's y component is less than the y component of thanos
                else if (picPlayer.Location.Y < picThanos.Location.Y)
                {
                    //thanos moves down
                    b += locb;
                    //set boundries
                    if (b>this.ClientSize.Height)
                    {
                        locb = -locb;
                    }
                }
                
            }
        }

        private void btnRestartinwinner_Click(object sender, EventArgs e)
        {
            //reset everything and start timers
            pnlGameover.Visible = false;
            ResetPlayer();
            ResetEnemy();
            ResetAvengersTeam();
            pnlWinner.Visible = false;
            tmrLoop.Start();
            tmrEnemy.Start();
            ScoreReset();
        }
    }
}
