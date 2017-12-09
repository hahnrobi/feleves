using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace feleves_HahnR_CQSP8N
{
    class FajlKezelo
    {
        public static string[] BeolvasTombbe(string file)
        {
            StreamReader sr = new StreamReader(file, Encoding.Default);
            int counter = 0;
            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                counter++;
            }

            sr.BaseStream.Position = 0;

            string[] s = new string[counter];
            counter = 0;
            while (!sr.EndOfStream)
                s[counter++] = sr.ReadLine();
            sr.Close();
            return s;
        }
        public static void AdatMentes(string file, Hangya h)
        {
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine(h.S.NegyzetNum); //Érintett négyzetek száma
            sw.WriteLine(h.P.X + " " + h.P.Y);  //Hova jutott a Hangya

            int hanyMezotTobbszor = 0;
            for (int i = 0; i < h.S.Mezok.Length; i++)
            {
                if (h.S.MezokNum[i] > 1)
                    hanyMezotTobbszor++;
            }
            sw.Write(hanyMezotTobbszor); //Többször érintett mezők megszámlálása
            sw.Close();
        }
    }
}
