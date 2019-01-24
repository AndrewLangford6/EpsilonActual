using System;
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
        Boolean leftArrowDown, downArrowDown, rightArrowDown, zDown, xDown, upArrowDown;



        List<Slime> slimeList = new List<Slime>();
        List<Bat> batList = new List<Bat>();

        List<Bullet> bullet1List = new List<Bullet>();
        List<Bullet> bullet2List = new List<Bullet>();
        List<Bullet> bullet3List = new List<Bullet>();
        List<Bullet> bullet4List = new List<Bullet>();


        int hp, score, heroX, heroY, heroSize, heroSpeed, gravity, groundY, groundX, groundS, sX, sY, sW, sH, sSpeed, sRange, bX, bY, bW, bH, pW, pH;

        private void scoreLabel_Click(object sender, EventArgs e)
        {

        }

        int walkCounterR = 0;
        int walkCounterL = 0;
        int pShootingCounter = 0;
        int jumpSpeed = 4;

        bool facingR = true;
        bool jumping = false;
        SolidBrush bulletBrush = new SolidBrush(Color.White);
        SolidBrush groundBrush = new SolidBrush(Color.Brown);

        // SoundPlayer gamePlayer = new SoundPlayer(Properties.Resources.Quiet);

        public GameScreen()    //Mainline
        {
            InitializeComponent();
            InitializeGameValues();

            Slime Slime1 = new Slime(sX, sY, sH, sW, sSpeed, sRange);
            Slime Slime2 = new Slime(sX + 600, sY, sH, sW, sSpeed, sRange);
            Slime Slime3 = new Slime(sX - 100, sY, sH, sW, sSpeed, sRange);
            Slime Slime4 = new Slime(sX + 200, sY, sH, sW, sSpeed, sRange);
            Slime Slime5 = new Slime(sX + 400, sY, sH, sW, sSpeed, sRange);
            Slime Slime6 = new Slime(sX - 300, sY, sH, sW, sSpeed, sRange);

            slimeList.Add(Slime1);
            slimeList.Add(Slime2);
            slimeList.Add(Slime3);
            slimeList.Add(Slime4);
            slimeList.Add(Slime5);
            slimeList.Add(Slime6);

            Rectangle groundRec1 = new Rectangle(groundX, groundY, groundS, 325);

            Bat Bat1 = new Bat(bX, bY, bH, bW);
            Bat Bat2 = new Bat(bX - 100, bY, bH, bW);
            Bat Bat3 = new Bat(bX + 300, bY, bH, bW);

            batList.Add(Bat1);
            batList.Add(Bat2);
            batList.Add(Bat3);

            //gamePlayer.PlayLooping();

        }

        public void InitializeGameValues()
        {
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
            sRange = 64;

            gravity = 12;

            groundY = 200;
            groundX = -338;
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
                winloseLabel.Visible = false;
                gameTimer.Enabled = false;
                rightArrowDown = leftArrowDown = zDown = xDown = downArrowDown = upArrowDown = false;

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

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if((slimeList.Count() + batList.Count() + 7) * 100 == score)
            {
                winloseLabel.Text = "You Win!\nScore: " + score;
                winloseLabel.Visible = true;
            }
            //hitpoints
            try
            {
                hpLabel.Text = "hp:";
                hpBar.Value = hp;
                if (hp <= 1)
                {
                    winloseLabel.Text = "Game Over!\nScore: " + score;
                    winloseLabel.Visible = true;
                    rightArrowDown = leftArrowDown = zDown = xDown = downArrowDown = upArrowDown = false;

                }
            }
            catch
            {
                winloseLabel.Text = "Game Over!\nScore: " + score;
                winloseLabel.Visible = true;
                rightArrowDown = leftArrowDown = zDown = xDown = downArrowDown = upArrowDown = false;

            }

            //show score
            scoreLabel.Text = "Score:  " + score;

            //increase counters
            walkCounterL++;
            walkCounterR++;
            pShootingCounter++;

            // move main character 
            if (heroY > this.Height)
            {
                winloseLabel.Text = "Game Over!\nScore: " + score;
                winloseLabel.Visible = true;
                rightArrowDown = leftArrowDown = zDown = xDown = downArrowDown = upArrowDown = false;
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

                foreach (Bullet bullet in bullet1List)
                {
                    bullet.pX = bullet.pX + heroSpeed;
                }
                foreach (Bullet bullet in bullet2List)
                {
                    bullet.pX = bullet.pX + heroSpeed;
                }
                foreach (Bullet bullet in bullet3List)
                {
                    bullet.pX = bullet.pX + heroSpeed;
                }
                foreach (Bullet bullet in bullet4List)
                {
                    bullet.pX = bullet.pX + heroSpeed;
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

                foreach (Bullet bullet in bullet1List)
                {
                    bullet.pX = bullet.pX - heroSpeed;
                }
                foreach (Bullet bullet in bullet2List)
                {
                    bullet.pX = bullet.pX - heroSpeed;
                }
                foreach (Bullet bullet in bullet3List)
                {
                    bullet.pX = bullet.pX - heroSpeed;
                }
                foreach (Bullet bullet in bullet4List)
                {
                    bullet.pX = bullet.pX - heroSpeed;
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

            // move npc characters
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
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //create bullets
            if (xDown)
            {
                if (pShootingCounter > 10)
                {
                    if (facingR == true && upArrowDown == true)
                    {
                        Bullet bullet1 = new Bullet(heroX + 25, heroY + 4, pH, pW);
                        bullet1List.Add(bullet1);
                    }
                    else if (facingR == true)
                    {
                        Bullet bullet2 = new Bullet(heroX + 19, heroY + 19, pH, pW);
                        bullet2List.Add(bullet2);
                    }
                    if (facingR == false && upArrowDown == true)
                    {
                        Bullet bullet3 = new Bullet(heroX + 7, heroY + 4, pH, pW);
                        bullet3List.Add(bullet3);
                    }
                    else if (facingR == false)
                    {
                        Bullet bullet4 = new Bullet(heroX + 4, heroY + 21, pH, pW);
                        bullet4List.Add(bullet4);
                    }
                    pShootingCounter = 0;
                }
            }

            //create the hero recangle
            Rectangle heroRec = new Rectangle(heroX, heroY - 6, heroSize, heroSize);

            //drawing each bat and intersecting with hero
            foreach (Bat bat in batList)
            {
                Rectangle batRec = new Rectangle(bat.bX, bat.bY, bat.bW, bat.bH);
                if (batRec.IntersectsWith(heroRec))
                {
                    hp--;
                }

                if (bat.bGravity < 0)
                {
                    e.Graphics.DrawImage(Properties.Resources.bat_d, bat.bX, bat.bY, bat.bW, bat.bH);
                }
                else if (bat.bGravity > 7)
                {
                    e.Graphics.DrawImage(Properties.Resources.bat_u, bat.bX, bat.bY, bat.bW, bat.bH);
                }
                else
                {
                    e.Graphics.DrawImage(Properties.Resources.bat_r, bat.bX, bat.bY, bat.bW, bat.bH);
                }
            }

            //drawing each slime and intersecting with hero
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

            //hero intersections
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


            //bullets, one list for each way to shoot
            foreach (Bullet bullet in bullet1List.AsEnumerable().Reverse())
            {
                bullet.pY = bullet.pY - 5;

                Rectangle b1 = new Rectangle(bullet.pX, bullet.pY, bullet.pH, bullet.pW);
                e.Graphics.FillRectangle(bulletBrush, b1);

                if (bullet.pY < 0)
                {
                    bullet1List.Remove(bullet);
                }

                foreach (Bat bat in batList.AsEnumerable().Reverse())
                {
                    Rectangle batRec = new Rectangle(bat.bX, bat.bY, bat.bW, bat.bH);

                    if (b1.IntersectsWith(batRec))
                    {
                        bullet1List.Remove(bullet);
                        batList.Remove(bat);
                        score = score + 100;
                    }
                }

                foreach (Slime slime in slimeList.AsEnumerable().Reverse())
                {
                    Rectangle slimeRec = new Rectangle(slime.sX, slime.sY, slime.sW, slime.sH);

                    if (b1.IntersectsWith(slimeRec))
                    {

                        bullet1List.Remove(bullet);
                        slimeList.Remove(slime);
                        score = score + 100;
                    }
                }




            }
            foreach (Bullet bullet in bullet2List.AsEnumerable().Reverse())
            {

                bullet.pX = bullet.pX + 5;

                Rectangle b2 = new Rectangle(bullet.pX, bullet.pY, bullet.pW, bullet.pH);
                e.Graphics.FillRectangle(bulletBrush, b2);

                if (bullet.pX > this.Width)
                {
                    bullet1List.Remove(bullet);
                }

                foreach (Bat bat in batList.AsEnumerable().Reverse())
                {
                    Rectangle batRec = new Rectangle(bat.bX, bat.bY, bat.bW, bat.bH);

                    if (b2.IntersectsWith(batRec) && bullet.pX < heroX + 147)
                    {
                        bullet2List.Remove(bullet);
                        batList.Remove(bat);
                        score = score + 100;
                    }
                }

                foreach (Slime slime in slimeList.AsEnumerable().Reverse())
                {
                    Rectangle slimeRec = new Rectangle(slime.sX, slime.sY, slime.sW, slime.sH);

                    if (b2.IntersectsWith(slimeRec) && bullet.pX < heroX + 147)
                    {
                        bullet2List.Remove(bullet);
                        slimeList.Remove(slime);
                        score = score + 100;
                    }
                }

            }
            foreach (Bullet bullet in bullet3List.AsEnumerable().Reverse())
            {


                bullet.pY = bullet.pY - 5;
                Rectangle b3 = new Rectangle(bullet.pX, bullet.pY, bullet.pH, bullet.pW);
                e.Graphics.FillRectangle(bulletBrush, b3);

                if (bullet.pY < 0)
                {
                    bullet1List.Remove(bullet);
                }

                foreach (Bat bat in batList.AsEnumerable().Reverse())
                {
                    Rectangle batRec = new Rectangle(bat.bX, bat.bY, bat.bW, bat.bH);

                    if (b3.IntersectsWith(batRec))
                    {
                        bullet3List.Remove(bullet);
                        batList.Remove(bat);
                        score = score + 100;
                    }
                }

                foreach (Slime slime in slimeList.AsEnumerable().Reverse())
                {
                    Rectangle slimeRec = new Rectangle(slime.sX, slime.sY, slime.sW, slime.sH);

                    if (b3.IntersectsWith(slimeRec))
                    {
                        bullet3List.Remove(bullet);
                        slimeList.Remove(slime);
                        score = score + 100;
                    }
                }

            }
            foreach (Bullet bullet in bullet4List.AsEnumerable().Reverse())
            {

                bullet.pX = bullet.pX - 5;

                if (bullet.pX < 0)
                {
                    bullet1List.Remove(bullet);
                }

                Rectangle b4 = new Rectangle(bullet.pX, bullet.pY, bullet.pW, bullet.pH);
                e.Graphics.FillRectangle(bulletBrush, b4);

                foreach (Bat bat in batList.AsEnumerable().Reverse())
                {
                    Rectangle batRec = new Rectangle(bat.bX, bat.bY, bat.bW, bat.bH);

                    if (b4.IntersectsWith(batRec) && bullet.pX > heroX - 147)
                    {
                        bullet4List.Remove(bullet);
                        batList.Remove(bat);
                        score = score + 100;
                    }
                }
                foreach (Slime slime in slimeList.AsEnumerable().Reverse())
                {
                    Rectangle slimeRec = new Rectangle(slime.sX, slime.sY, slime.sW, slime.sH);

                    if (b4.IntersectsWith(slimeRec) && bullet.pX > heroX - 147)
                    {
                        bullet4List.Remove(bullet);
                        slimeList.Remove(slime);
                        score = score + 100;
                    }
                }

            }





            e.Graphics.DrawImage(Properties.Resources.floor_complete, groundX, groundY - 16, groundS, groundS - 675);
        }
    }
}


