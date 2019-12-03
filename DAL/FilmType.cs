using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL
{
    public class FilmType
    {
        private int filmTypeid;
        private string name;
        // foreign keys
        private ICollection<Film> films;


        public FilmType()
        {

        }

        public FilmType(string text) // Constructeur de FilmType (type de film)
        {
            string[] genredetail;
            Char[] delimiterChars = { '\u2024' };
            genredetail = text.Split(delimiterChars);
            FilmTypeID = Int32.Parse(genredetail[0]);
            Name = genredetail[1];

            // many to many with Films
            this.Films = new HashSet<Film>();
        }

        [Key]
        public int FilmTypeID { get => filmTypeid; set => filmTypeid = value; }
        public string Name { get => name; set => name = value; }

        public virtual ICollection<Film> Films { get { return films = films ?? new HashSet<Film>(); } set => films = value; }

    }
}
