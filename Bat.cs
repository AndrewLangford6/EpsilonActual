using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonActual
{
    public class Bat
    {

        public int bX, bY, bH, bW, bSpeed, bRange;

        public bool bJumping = false;
        public bool bFacingR = true;

        public int bJumpingCounter = 0;
        public int bJumpSpeed = 6;
        public int bGravity = 8;

        public Slime(int x, int y, int h, int w, int r)
        {
            bX = x;
            bY = y;
            bH = h;
            bW = w;
            bRange = r;
        }
    }
}
//garbage