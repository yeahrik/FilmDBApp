using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace DAL_ConsoleApp
{
    public class FilmParser
    {
        //public string[] filmdetailwords;
        //public string[] genres;
        //public string[] acteurs;
        //public Film f;
        public FilmParser()
        {
        }


        public static Film DecodeFilmText(string filmtext) // Méthode de la classe FilmParser
        {
            Film f = new Film();
            Char[] delimiterChars = { '\u2023' };
            string[] filmdetailwords = filmtext.Split(delimiterChars);
            delimiterChars[0] = '\u2016';
            // Initialisation des champs de base du film
            f.FilmID = Int32.Parse(filmdetailwords[0]);
            f.Title = filmdetailwords[1];
            f.Runtime = Int32.Parse(filmdetailwords[7]);
            //C.Moitroux, D.Schreurs 15 Version 1.3
            f.Posterpath = filmdetailwords[9];
            // Initialisation des champs détails du film
            if (filmdetailwords.Length == 15)
            {
                string[] genres = filmdetailwords[12].Split(delimiterChars);
                foreach (string s in genres)
                {
                    if (s.Length > 0)
                    {
                        FilmType ft = new FilmType(s);

                        f.Filmtypes.Add(ft);
                    }
                }
                string[] acteurs = filmdetailwords[14].Split(delimiterChars);
                foreach (string s in acteurs)
                    if (s.Length > 0)
                        f.Actors.Add(new Actor(s));
            }
            return f;
        }


    }


}
