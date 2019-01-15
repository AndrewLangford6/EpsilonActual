﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameSystemServices;
using System.Threading;
using System.Media;

namespace EpsilonActual
{
    public partial class GameScreen : UserControl
    {
        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, downArrowDown, rightArrowDown, spaceDown, bDown, nDown, mDown, upArrowDown;

        //player2 button control keys - DO NOT CHANGE
        Boolean aDown, sDown, dDown, wDown, cDown, vDown, xDown, zDown;



        private void GameScreen_Load(object sender, EventArgs e)
        {

        }

        //TODO create your global game variables here
        int heroX, heroY, heroSize, heroSpeed, gravity, ground1Y, ground1X, groundEnd1;
        int i = 0;
        int walkCounterR = 0;
        int walkCounterL = 0;
        int jumpSpeed;
        bool facingR = true;
        bool jumping = false;
        SolidBrush heroBrush = new SolidBrush(Color.Black);
        SolidBrush groundBrush = new SolidBrush(Color.Brown);

       // SoundPlayer gamePlayer = new SoundPlayer(Properties.Resources.Quiet);





        public GameScreen()
        {
            InitializeComponent();
            InitializeGameValues();
            //gamePlayer.PlayLooping();

        }

        public void InitializeGameValues()
        {
            //TODO - setup all your initial game values here. Use this method
            // each time you restart your game to reset all values. 

            heroSize = 32;
            heroX = this.Width / 2 - (heroSize / 2);
            heroY = 0;
            heroSpeed = 10;


            gravity = 8;
            ground1Y = 200;
            ground1X = -25;
            groundEnd1 = 350;
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // opens a pause screen is escape is pressed. Depending on what is pressed
            // on pause screen the program will either continue or exit to main menu
            if (e.KeyCode == Keys.Escape && gameTimer.Enabled)
            {
                gameTimer.Enabled = false;
                rightArrowDown = leftArrowDown = spaceDown = downArrowDown = upArrowDown = false;

                DialogResult result = PauseForm.Show();

                if (result == DialogResult.Cancel)
                {
                    gameTimer.Enabled = true;
                }
                else if (result == DialogResult.Abort)
                {
                    MainForm.ChangeScreen(this, "MenuScreen");
                }
            }

            //TODO - basic player 1 key down bools set below. Add remainging key down
            // required for player 1 or player 2 here.

            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Space:
                    if (!jumping && heroY == ground1Y - heroSize)
                    {
                        jumping = true;
                    }
                    spaceDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.M:
                    mDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //TODO - basic player 1 key up bools set below. Add remainging key up
            // required for player 1 or player 2 here.

            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Space:
                    spaceDown = false;
                    if (jumping)
                    {
                        jumping = false;
                    }
                    break;
            }
        }

        /// <summary>
        /// This is the Game Engine and repeats on each interval of the timer. For example
        /// if the interval is set to 16 then it will run each 16ms or approx. 50 times
        /// per second
        /// </summary>
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            walkCounterL++;
            walkCounterR++;
            Graphics g = this.CreateGraphics();

            //TODO move main character 
            if (heroY > this.Height)
            {
                Thread.Sleep(1000);
                MainForm.ChangeScreen(this, "MenuScreen");
                gameTimer.Enabled = false;
                //gamePlayer.Stop();
                rightArrowDown = leftArrowDown = spaceDown = downArrowDown = false;
            }
            if (gravity < 4)
            {
                gravity = gravity - (1 / 2);
            }
            if (jumping && gravity < 0)
            {
                jumping = false;
            }
            if (leftArrowDown == true)
            {
                ground1X = ground1X + heroSpeed;
                facingR = false;
            }
            if (downArrowDown == true)
            {

            }
            if (rightArrowDown == true)
            {
                ground1X = ground1X - heroSpeed;
                facingR = true;
            }
            if (spaceDown == true)
            {

            }
            if (jumping)
            {
                jumpSpeed = -8;
                gravity--;
            }
            else
            {
                jumpSpeed = 8;
            }
            heroY = heroY + jumpSpeed;

            //TODO move npc characters

            List<Rectangle> groundRec = new List<Rectangle>();
            groundRec.Add(new Rectangle(ground1X, ground1Y, groundEnd1, ground1Y));

            for (int i = 0; i < groundRec.Count(); i++)
            {

            }





            //TODO collisions checks 




            if (heroX > ground1X - heroSize && heroX < ground1X + groundEnd1)
            {
                if (heroY > ground1Y && heroX > ground1X - heroSize && heroX < ground1X + groundEnd1 && facingR == true)
                {
                    heroX = ground1X - heroSize + 16;
                    rightArrowDown = false;
                }
                else if (heroY > ground1Y && heroX > ground1X - heroSize && heroX < ground1X + groundEnd1 && facingR == false)
                {
                    heroX = ground1X + groundEnd1 - 16;
                    leftArrowDown = false;
                }
                else if (heroY > ground1Y - heroSize)
                {
                    heroY = ground1Y - heroSize;
                }

                if (heroY == ground1Y - heroSize && !jumping)
                {
                    gravity = 8;
                }


            }

            //calls the GameScreen_Paint method to draw the screen.
            Refresh();
        }


        //Everything that is to be drawn on the screen should be done here
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {

            //draw rectangle to screen

            Rectangle heroRec = new Rectangle(heroX, heroY, heroSize, heroSize);
            Rectangle groundRec = new Rectangle(ground1X, ground1Y, groundEnd1, ground1Y);

            if (facingR == true)
            {
                if (downArrowDown == true)
                {
                    e.Graphics.DrawImage(Properties.Resources.crouch_R, heroRec);
                }
                else if (upArrowDown && spaceDown == true)
                {
                    e.Graphics.DrawImage(Properties.Resources.Lookup_R, heroRec);
                }
                else if (spaceDown == true && jumping)
                {
                    e.Graphics.DrawImage(Properties.Resources.jump_R, heroRec);
                }
                else if (upArrowDown)
                {
                    e.Graphics.DrawImage(Properties.Resources.Lookup_R, heroRec);
                }
                else
                {
                    if (rightArrowDown == true)
                    {
                        if (walkCounterR > 5)
                        {
                            e.Graphics.DrawImage(Properties.Resources.base_R, heroRec);
                        }
                        else
                        {
                            e.Graphics.DrawImage(Properties.Resources.walk_R, heroRec);
                        }
                        if (walkCounterR > 10)
                        {
                            walkCounterR = 0;
                        }
                    }
                    else
                    {
                        e.Graphics.DrawImage(Properties.Resources.base_R, heroRec);
                    }
                }
            }
            else if (facingR == false)
            {
                if (downArrowDown == true)
                {
                    e.Graphics.DrawImage(Properties.Resources.crouch_L, heroRec);
                }
                else if (upArrowDown && spaceDown == true)
                {
                    e.Graphics.DrawImage(Properties.Resources.Lookup_L, heroRec);
                }
                else if (spaceDown == true)
                {
                    e.Graphics.DrawImage(Properties.Resources.jump_L, heroRec);
                }
                else if (upArrowDown)
                {
                    e.Graphics.DrawImage(Properties.Resources.Lookup_L, heroRec);
                }
                else
                {
                    if (leftArrowDown == true)
                    {
                        if (walkCounterL > 5)
                        {
                            e.Graphics.DrawImage(Properties.Resources.base_L, heroRec);
                        }
                        else
                        {
                            e.Graphics.DrawImage(Properties.Resources.walk_L, heroRec);
                        }
                        if (walkCounterL > 10)
                        {
                            walkCounterL = 0;
                        }
                    }
                    else
                    {
                        e.Graphics.DrawImage(Properties.Resources.base_L, heroRec);
                    }
                }
            }
            e.Graphics.DrawImage(Properties.Resources.FLOOR, ground1X, ground1Y - 10, groundEnd1, ground1Y);
        }
    }

}
