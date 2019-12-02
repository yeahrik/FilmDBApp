using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
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

        [Key]
        public int FilmTypeID { get => filmTypeid; set => filmTypeid = value; }
        public string Name { get => name; set => name = value; }

        public virtual ICollection<Film> Films { get { return films = films ?? new HashSet<Film>(); } set => films = value; }

    }
}
