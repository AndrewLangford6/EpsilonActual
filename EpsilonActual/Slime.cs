using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonActual
{
    public class Slime
    {
        
        public int sX,sY, sH, sW, sSpeed, sRange;

        public bool sJumping = false;
        public bool sFacingR = true;

        public int sJumpingCounter = 0;
        public int sJumpSpeed = 6;
        public int sGravity = 8;

        public Slime(int x, int y, int h, int w, int s, int r)
        {
            sX = x;
            sY = y;
            sH = h;
            sW = w;
            sSpeed = s;
            sRange = r;
        }
    }
}
