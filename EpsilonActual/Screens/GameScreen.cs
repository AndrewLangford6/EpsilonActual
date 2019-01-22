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
        Boolean leftArrowDown, downArrowDown, rightArrowDown, zDown, xDown, bDown, nDown, mDown, upArrowDown;

        //player2 button control keys - DO NOT CHANGE
        Boolean aDown, sDown, dDown, wDown, cDown, vDown, spaceDown;


        List<Slime> slimeList = new List<Slime>();
        List<Bat> batList = new List<Bat>();

        List<Bullet> bullet1List = new List<Bullet>();
        List<Bullet> bullet2List = new List<Bullet>();
        List<Bullet> bullet3List = new List<Bullet>();
        List<Bullet> bullet4List = new List<Bullet>();

        // List<Ground> groundList = new List<Ground>();



        private void GameScreen_Load(object sender, EventArgs e)
        {

        }

        //TODO create your global game variables here
        int hp, score, heroX, heroY, heroSize, heroSpeed, gravity, sGravity, groundY, groundX, groundS, sX, sY, sW, sH, sSpeed, sRange, bX, bY, bW, bH, pX, pY, pW, pH;

        int walkCounterR = 0;
        int walkCounterL = 0;
        int jumpSpeed = 4;

        bool facingR = true;
        bool jumping = false;
        SolidBrush heroBrush = new SolidBrush(Color.Yellow);
        SolidBrush groundBrush = new SolidBrush(Color.Brown);

        // SoundPlayer gamePlayer = new SoundPlayer(Properties.Resources.Quiet);





        public GameScreen()    //Mainline
        {
            InitializeComponent();
            InitializeGameValues();

            Slime Slime1 = new Slime(sX, sY, sH, sW, sSpeed, sRange);
            Slime Slime2 = new Slime(sX - 200, sY, sH, sW, sSpeed, sRange);
            Slime Slime3 = new Slime(sX - 100, sY, sH, sW, sSpeed, sRange);
            Rectangle groundRec1 = new Rectangle(groundX, groundY, groundS, 325);
            //groundList.Add(groundRec1);
            // Ground groundRec2 = new Ground(groundX + 325, groundY - 32, groundS);
            // groundList.Add(groundRec2);

            Bat Bat1 = new Bat(bX, bY, bH, bW);

            batList.Add(Bat1);
            slimeList.Add(Slime1);
            // slimeList.Add(Slime2);
            // slimeList.Add(Slime3);

            //gamePlayer.PlayLooping();

        }

        public void InitializeGameValues()
        {
            //TODO - setup all your initial game values here. Use this method
            // each time you restart your game to reset all values. 
            hp = 200;
            score = 0;

            heroSize = 32;
            heroX = this.Width / 2 - (heroSize / 2);
            heroY = 0;
            heroSpeed = 10;

            sX = 250;
            sY = 100;
            sW = 32;
            sH = 16;
            sSpeed = 10;
            sRange = 32;

            gravity = 12;
            groundY = 200;
            groundX = -180;
            groundS = 1000;

            bX = 10;
            bY = groundY - 50;
            bW = 32;
            bH = 32;

            pH = 1;
            pW = 10;

            
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // opens a pause screen is escape is pressed. Depending on what is pressed
            // on pause screen the program will either continue or exit to main menu
            if (e.KeyCode == Keys.Escape && gameTimer.Enabled)
            {
                gameTimer.Enabled = false;
                rightArrowDown = leftArrowDown = zDown = downArrowDown = upArrowDown = false;

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
                case Keys.Z:
                    if (!jumping && heroY == groundY - heroSize)
                    {
                        jumping = true;
                    }
                    zDown = true;
                    break;
                case Keys.X:
                    xDown = true;
                    

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
                case Keys.Z:
                    zDown = false;
                    if (jumping)
                    {
                        jumping = false;
                    }
                    break;
                case Keys.X:
                    xDown = false;

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
            try
            {
                hpLabel.Text = "hp:";
                hpBar.Value = hp;
            }
            catch
            {
                Thread.Sleep(1000);
                MainForm.ChangeScreen(this, "MenuScreen");
                gameTimer.Enabled = false;
                //gamePlayer.Stop();
                rightArrowDown = leftArrowDown = zDown = downArrowDown = false;
            }
            if (hp <= 1)
            {
                Thread.Sleep(1000);
                MainForm.ChangeScreen(this, "MenuScreen");
                gameTimer.Enabled = false;
                //gamePlayer.Stop();
                rightArrowDown = leftArrowDown = zDown = downArrowDown = false;
            }

            scoreLabel.Text = "Score:  " + score;
            walkCounterL++;
            walkCounterR++;

            //TODO move main character 
            if (heroY > this.Height)
            {
                Thread.Sleep(1000);
                MainForm.ChangeScreen(this, "MenuScreen");
                gameTimer.Enabled = false;
                //gamePlayer.Stop();
                rightArrowDown = leftArrowDown = zDown = downArrowDown = false;
            }
            if (jumping && gravity < 0)
            {
                jumping = false;
            }
            if (leftArrowDown == true)
            {
                foreach (Slime slime in slimeList)
                {
                    slime.sX = slime.sX + heroSpeed;
                }

                foreach (Bat bat in batList)
                {
                    bat.bX = bat.bX + heroSpeed;
                }

                //ground.groundX = ground.groundX + heroSpeed;
                groundX = groundX + heroSpeed;
                facingR = false;
            }
            if (downArrowDown == true)
            {

            }
            if (rightArrowDown == true)
            {
                foreach (Slime slime in slimeList)
                {
                    slime.sX = slime.sX - heroSpeed;
                }
                foreach (Bat bat in batList)
                {
                    bat.bX = bat.bX - heroSpeed;
                }
                //ground.groundX = ground.groundX - heroSpeed;
                groundX = groundX - heroSpeed;
                facingR = true;
            }
            if (zDown == true)
            {

            }
            if (jumping)
            {
                jumpSpeed = -4;
                gravity--;
            }
            else
            {
                jumpSpeed = 4;
            }
            heroY = heroY + jumpSpeed;

            //TODO move npc characters
            foreach (Bat bat in batList)
            {
                bat.bJumpingCounter++;

                Rectangle batRec = new Rectangle(bat.bX, bat.bY, bat.bW, bat.bH);


                if (bat.bJumpingCounter > 20)
                {
                    bat.bJumpSpeed = 3;
                    bat.bGravity--;
                }
                else if (bat.bGravity <= 20)
                {
                    bat.bJumpSpeed = -3;
                    bat.bGravity++;
                }
                if (bat.bJumpingCounter > 39)
                {
                    bat.bJumpingCounter = 0;
                    bat.bGravity = 8;
                }
                bat.bY = bat.bY + bat.bJumpSpeed;
            }

            foreach (Slime slime in slimeList)
            {

                slime.sJumpingCounter++;

                Rectangle slimeRec = new Rectangle(slime.sX, slime.sY, slime.sW, slime.sH);

                //slime movement
                if (heroX + heroSize / 2 > slime.sX && slime.sY == groundY - slime.sH)
                {

                    slime.sFacingR = true;


                }
                else if (heroX + heroSize / 2 < slime.sX && slime.sY == groundY - slime.sH)
                {
                    // if the slimes x plus the slimes height plus the range is more than the hero x  
                    // AND half the heros width + hero x is less than the slime x

                    slime.sFacingR = false;
                }
                //right chase
                if (heroX > slime.sX + slime.sW + slime.sRange && slime.sFacingR == true)
                {
                    slime.sChase = true;
                }
                //left chase
                else if (heroX + heroSize > slime.sX - slime.sRange && slime.sFacingR == false)
                {
                    slime.sChase = true;
                }
                if (slime.sChase)
                {
                    if (slime.sJumping == true && slime.sGravity < 0)
                    {
                        slime.sJumping = false;
                    }
                    if (slime.sJumping == true && !slime.sFacingR)
                    {
                        slime.sX = slime.sX - 2;
                        slime.sJumpSpeed = -4;
                        slime.sGravity--;
                    }
                    else if (slime.sJumping == true && slime.sFacingR)
                    {
                        slime.sX = slime.sX + 2;
                        slime.sJumpSpeed = -4;
                        slime.sGravity--;
                    }
                    else     //comment what else is
                    {
                        slime.sJumpSpeed = 4;
                    }
                    if (!slime.sJumping && !(slime.sY == groundY - slime.sH) && slime.sFacingR)
                    {
                        slime.sX = slime.sX + 2;
                    }
                    else if (!slime.sJumping && !(slime.sY == groundY - slime.sH) && !slime.sFacingR)
                    {
                        slime.sX = slime.sX - 2;
                    }


                }

                slime.sY = slime.sY + slime.sJumpSpeed;
                //colision of slime
                if (slime.sX > groundX - slime.sW && slime.sX < groundX + groundS)
                {
                    if (slime.sY > groundY && slime.sX > groundX - slime.sX && slime.sX < groundX + groundS && slime.sFacingR == true)
                    {
                        slime.sX = groundX - slime.sX + 16;
                        rightArrowDown = false;
                    }
                    else if (slime.sY > groundY && slime.sX > groundX - slime.sX && slime.sX < groundX + groundS && slime.sFacingR == false)
                    {
                        slime.sX = groundX + groundS - 16;
                        leftArrowDown = false;
                    }
                    else if (slime.sY > groundY - slime.sH && slime.sFacingR)
                    {
                        slime.sY = groundY - slime.sH;
                    }
                    else if (slime.sY > groundY - slime.sH && !slime.sFacingR)
                    {
                        slime.sY = groundY - slime.sH;
                    }
                    if (slime.sY == groundY - slime.sH)
                    {
                        if (slime.sJumpingCounter > 40)
                        {
                            slime.sJumping = true;
                            slime.sJumpingCounter = 0;
                        }
                        slime.sGravity = 8;

                    }

                }
                if (slime.sY == groundY - slime.sH)
                {
                    if (slime.sJumpingCounter > 40)
                    {
                        slime.sJumping = true;
                        slime.sJumpingCounter = 0;
                    }
                    slime.sGravity = 8;

                }
            }
            //calls the GameScreen_Paint method to draw the screen.
            Refresh();

        }
        //Everything that is to be drawn on the screen should be done here
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {

            Rectangle heroRec = new Rectangle(heroX, heroY, heroSize, heroSize);
           
           // e.Graphics.FillRectangle(groundBrush, groundX, groundY, groundS - 10, groundS);
            //draw rectangle to screen





            //Rectangle groundRec = new Rectangle(ground.groundX, ground.groundY, ground.groundS, ground.groundS);
            //e.Graphics.DrawImage(   Properties.Resources.FLOOR , ground.groundX, ground.groundY, ground.groundS + 50, ground.groundS);
            //e.Graphics.DrawImage(Properties.Resources.FLOOR, ground.groundX, ground.groundY - 18, ground.groundS, ground.groundS);



            foreach (Bat bat in batList)
            {
                Rectangle batRec = new Rectangle(bat.bX, bat.bY, bat.bW, bat.bH);
                if (batRec.IntersectsWith(heroRec))
                {
                    hp--;
                }

                e.Graphics.FillRectangle(heroBrush, bat.bX, bat.bY, bat.bW, bat.bH);
            }

            foreach (Slime slime in slimeList)
            {
                Rectangle slimeRec = new Rectangle(slime.sX, slime.sY, slime.sW, slime.sH);
                if (slimeRec.IntersectsWith(heroRec))
                {
                    hp--;
                }

                //draw slime
                if (slime.sFacingR == false && slime.sY != groundY - slime.sH)
                {
                    e.Graphics.DrawImage(Properties.Resources.slime_LJ, slime.sX, slime.sY, slime.sW, slime.sH);
                }
                if (slime.sFacingR == false && slime.sJumpingCounter > 20 && slime.sJumpingCounter < 40)
                {
                    e.Graphics.DrawImage(Properties.Resources.slime_LC, slime.sX, slime.sY, slime.sW, slime.sH);
                }
                else if (slime.sFacingR == false && slime.sJumpingCounter <= 20)
                {
                    e.Graphics.DrawImage(Properties.Resources.slime_L, slime.sX, slime.sY, slime.sW, slime.sH);
                }

                if (slime.sFacingR == true && slime.sY != groundY - slime.sH)
                {
                    e.Graphics.DrawImage(Properties.Resources.slime_RJ, slime.sX, slime.sY, slime.sW, slime.sH);
                }
                if (slime.sFacingR == true && slime.sJumpingCounter > 20 && slime.sJumpingCounter < 40)
                {
                    e.Graphics.DrawImage(Properties.Resources.slime_RC, slime.sX, slime.sY, slime.sW, slime.sH);
                }
                else if (slime.sFacingR == true && slime.sJumpingCounter <= 20)
                {
                    e.Graphics.DrawImage(Properties.Resources.slime_R, slime.sX, slime.sY, slime.sW, slime.sH);
                }
            }


            
            









            if (heroX > groundX - heroSize && heroX < groundX + groundS)
            {
                if (heroY > groundY && heroX > groundX - heroSize && heroX < groundX + groundS && facingR == true)
                {
                    heroX = groundX - heroSize + 16;
                    rightArrowDown = false;
                }
                else if (heroY > groundY && heroX > groundX - heroSize && heroX < groundX + groundS && facingR == false)
                {
                    heroX = groundX + groundS - 16;
                    leftArrowDown = false;
                }
                else if (heroY > groundY - heroSize)
                {
                    heroY = groundY - heroSize;
                }

                if (heroY == groundY - heroSize && !jumping)
                {
                    this.gravity = 12;
                }
            }


            //


            //hero facing

            if (facingR == true)
            {
                if (downArrowDown == true)
                {
                    e.Graphics.DrawImage(Properties.Resources.crouch_R, heroRec);
                }
                else if (upArrowDown && zDown == true)
                {
                    e.Graphics.DrawImage(Properties.Resources.Lookup_R, heroRec);
                }
                else if (zDown == true && jumping)
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
                else if (upArrowDown && zDown == true)
                {
                    e.Graphics.DrawImage(Properties.Resources.Lookup_L, heroRec);
                }
                else if (zDown == true)
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

            if (xDown)
            {
                if (facingR == true && upArrowDown == true)
                {
                    Bullet bullet1 = new Bullet(heroX + 25, heroY + 4, pH, pW);
                    bullet1List.Add(bullet1);
                }
                else if (facingR == true)
                {
                    Bullet bullet2 = new Bullet(heroX + 29, heroY - 22, pW, pH);
                    bullet1List.Add(bullet2);
                }
                if (facingR == false && upArrowDown == true)
                {
                    Bullet bullet3 = new Bullet(heroX + 7, heroY + 4, pH, pW);
                    bullet1List.Add(bullet3);
                }
                else if (facingR == false)
                {
                    Bullet bullet4 = new Bullet(heroX + 4, heroY + 22, pW, pH);
                    bullet1List.Add(bullet4);
                }
            }

            foreach (Bullet bullet in bullet1List)
            {
                bullet.pShootingCounter++;

                Rectangle b1 = new Rectangle(heroX + 25, heroY - 4, bullet.pH, bullet.pW);
                e.Graphics.FillRectangle(heroBrush, heroX + 25, heroY - 4, bullet.pH, bullet.pW);
            }
            foreach (Bullet bullet in bullet2List)
            {
                bullet.pShootingCounter++;

                Rectangle b2 = new Rectangle(heroX + 29, heroY - 22, bullet.pW, bullet.pH);
                e.Graphics.FillRectangle(heroBrush, b2);
            }
            foreach (Bullet bullet in bullet3List)
            {
                bullet.pShootingCounter++;

                Rectangle b3 = new Rectangle(heroX + 7, heroY + 22, bullet.pW, bullet.pH);
                e.Graphics.FillRectangle(heroBrush, b3);
            }
            foreach (Bullet bullet in bullet4List)
            {
                bullet.pShootingCounter++;

                Rectangle b4 = new Rectangle(heroX + 4, heroY + 22, bullet.pW, bullet.pH);
                e.Graphics.FillRectangle(heroBrush, b4);
            }





            e.Graphics.DrawImage(Properties.Resources.floor_complete, groundX, groundY + 8, groundS, groundS);
        }
    }
}


