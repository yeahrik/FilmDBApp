using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL
{
    public class FilmTypeDTO
    {
        private int filmTypeid;
        private string name;


        public FilmTypeDTO()
        {

        }

        public FilmTypeDTO(string text) // Constructeur de FilmType (type de film)
        {
            string[] genredetail;
            Char[] delimiterChars = { '\u2024' };
            genredetail = text.Split(delimiterChars);
            FilmTypeID = Int32.Parse(genredetail[0]);
            Name = genredetail[1];

        }

        [Key]
        public int FilmTypeID { get => filmTypeid; set => filmTypeid = value; }
        public string Name { get => name; set => name = value; }

        #region methods
        public override string ToString()
        {
            return "(ToString)FilmTypeDTO:" +
                "\tFilmTypeDTOId=" + FilmTypeID +
                "\tName=" + Name; // +
                //"\tReleaseDate=" + ReleaseDate +
                //"\tVoteAverage=" + VoteAverage +
                //"\tRuntime=" + Runtime +
                //"\tPosterpath=" + Posterpath;
        }
        public void Affiche()
        {
            Console.WriteLine(ToString());
        }
        #endregion
    }
}
