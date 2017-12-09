using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;    
namespace feleves_HahnR_CQSP8N
{

    class Program
    {
        static void Main(string[] args)
        {
            string[] fajl = FajlKezelo.BeolvasTombbe("RACS.BE");

            Hangya h = new Hangya(int.Parse(fajl[0].Split(' ')[0]), int.Parse(fajl[0].Split(' ')[1])); //Fájl első sorával létrehozza a Hangyát.

            h.StatGenStart(fajl.Length - 1); //Előrelátható mennyi lépés van, így készíthető megfelelő méretű tömb a statisztikához.

            //Console.WriteLine("X: {0}, Y: {1}", h.P.X, h.P.Y); //Kezdeti pozíció
            for (int i = 1; i < fajl.Length; i++)
            {
                //Fájlban lévő irányokon végighaladva mozgatjuk a Hangyát.
                h.Mozgas(fajl[i]);
                //Console.WriteLine("X: {0}, Y: {1}", h.P.X, h.P.Y); //JUST DEBUG
            }
            FajlKezelo.AdatMentes("RACS.KI", h);
        }
    }
}
