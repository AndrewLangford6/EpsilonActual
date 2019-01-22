using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonActual
{
    public class Bat
    {

        public int bX, bY, bH, bW;

        public int hp = 5;
        public int bJumpingCounter = 0;

        public bool bJumping = false;
        public bool bFacingR = true;
        
        public int bJumpSpeed = 6;
        public int bGravity = 8;


        public Bat(int x, int y, int h, int w)
        {
            bX = x;
            bY = y;
            bW = w;
            bH = h;


        }
    }
}



                

