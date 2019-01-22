namespace EpsilonActual
{
    public class Bullet
    {
        public int pX, pY, pH, pW;


        public int pShootingCounter = 0;

        public bool shooting = false;

        public Bullet(int x, int y, int h, int w)
        {
            pX = x;
            pY = y;
            pW = w;
            pH = h;


        }

    }
}