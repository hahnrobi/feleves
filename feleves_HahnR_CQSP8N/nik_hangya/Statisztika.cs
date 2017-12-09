using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleves_HahnR_CQSP8N
{
    class Statisztika
    {
        Pozicio[] mezok;
        int[] mezokNum;
        int negyzetNum;

        public Pozicio[] Mezok
        {
            get { return mezok; }
        }
        public int[] MezokNum
        {
            get
            {
                return mezokNum;
            }
        }
        public int NegyzetNum
        {
            get { return negyzetNum; }
        }

        public Statisztika(int n)
        {
            this.mezok = new Pozicio[n];
            this.mezokNum = new int[n];
            this.negyzetNum = 0;
        }
        public void Add(Pozicio p)
        {
            if (p.X % 1 == 0 && p.Y % 1 == 0) //Egész szám ==> statisztikához adás
            {
                if (ElsoElofordulasiHely(mezok, p) == -1)
                    TombHozzaad(mezok, p);
                else
                    mezokNum[ElsoElofordulasiHely(mezok, p)]++;
            }
            if (p.X % 1 != 0 && p.Y % 1 != 0) //Ha nem egész szám => négyzeten van
            {
                //Console.WriteLine("négyzet");
                negyzetNum++;
            }
        }
        static void TombHozzaad(Pozicio[] tomb, Pozicio p) //Tömb első null helyére szöveg "beszúrása"
        {
            int i = 0;
            bool megvan = false;
            while (i < tomb.Length && !megvan)
                if (tomb[i++] == null)
                {
                    megvan = true;
                    tomb[i - 1] = p;
                }
        }
        static int ElsoElofordulasiHely(Pozicio[] tomb, Pozicio p) //Tömbön belül keresett elem első előfordulási helye
        {
            int i = 0;
            bool van = false;
            while (i < tomb.Length && !van)
            {
                if (tomb[i] != null)
                {
                    if (tomb[i].X == p.X && tomb[i].Y == p.Y)
                        van = true;
                }
                i++;
            }
            if (i >= tomb.Length)
                i = 0;
            return i - 1;
        }
    }
}
