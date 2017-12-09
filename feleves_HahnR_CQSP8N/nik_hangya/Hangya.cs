using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleves_HahnR_CQSP8N
{
    class Hangya
    {
        Pozicio p;
        Statisztika s;

        bool stat = false;

        public Hangya(int xpos, int ypos)
        {
            if ((1 <= xpos && xpos <= 100) && (1 <= ypos && ypos <= 100))
            {
                this.p = new Pozicio(xpos, ypos);
            }
            else
            {
                Console.WriteLine("A hangya valamelyik koorinátája nem a megadott 1-100 intervallumba esik. Alap X: 1, Y: 1 koordináták lesznek beállítva.");
                this.p = new Pozicio(1, 1);
            }
        }

        public Pozicio P
        {
            get { return p; }
            set { P = value; }
        }
        public Statisztika S
        {
            get { return s; }
        }

        public void StatGenStart(int mozgasNum)
        {
            this.stat = true;
            this.s = new Statisztika(mozgasNum);
            this.s.Add(P);
        } //Üres mezok[] és mezokNum[] méretének beállítása az előrelátható mozgások számának alapján
        private bool MozgasLehetseges(double x, double y)
        {
            if (P.X > 100 || P.Y > 100 || P.X < 1 || P.Y < 1 )
                return false;
            return true;
        }
        public void Mozgas(string irany, bool csakFelet = false)
        {
            if (irany.Length <= 2)
            {
                if (irany.Length > 1) //Két karakteres (átlós) irányok lekezelése
                    for (int i = 0; i < irany.Length; i++)
                        Mozgas(irany[i].ToString(), true);
                else
                {
                    double mozgMenny = 1;
                    if (csakFelet)
                        mozgMenny = 0.5;                    
                    switch (irany)
                    {
                        case "D":
                            if (MozgasLehetseges(p.X, p.Y - mozgMenny))
                            {
                                this.P.Y -= mozgMenny;
                            }
                            else Console.WriteLine("Mozgás visszautasítva! Elérné a lap szélét!");
                            break;
                        case "E":
                            if (MozgasLehetseges(p.X, p.Y + mozgMenny))
                                this.P.Y += mozgMenny;
                            else
                                Console.WriteLine("Mozgás visszautasítva! Elérné a lap szélét!");
                            break;
                        case "N":
                            if (MozgasLehetseges(p.X-mozgMenny, P.Y))
                                this.P.X -= mozgMenny;
                            else
                                Console.WriteLine("Mozgás visszautasítva! Elérné a lap szélét!");
                            break;
                        case "K":
                            if (MozgasLehetseges(p.X + mozgMenny, p.Y))
                                this.P.X += mozgMenny;
                            else
                                Console.WriteLine("Mozgás visszautasítva! Elérné a lap szélét!");
                            break;
                    }
                    if (stat) //Ha koordináta egész szám => koordináta logolása
                        s.Add(p);
                }
            }
            else
            {
                Console.WriteLine("ÉRVÉNYTELEN KOORDINÁTA. Elfogadható értékek: E, D, K, N, EN, EK, DN, DK");
            }
        } //Hangya mozgazása irány segítségével

    }
}
