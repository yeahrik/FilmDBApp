using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace DTO
{        
    [DataContract(Name = "FilmTypeDTO")]
    public class FilmTypeDTO
    {
        private int filmTypeid;
        private string name;
        // foreign keys
        private ICollection<FilmDTO> films;

        #region constructors
        public FilmTypeDTO()
        {

        }
        #endregion

        [Key]
        [DataMember(Name = "FilmTypeID")]
        public int FilmTypeID { get => filmTypeid; set => filmTypeid = value; }
        [DataMember(Name = "FilmTypeName")]
        public string Name { get => name; set => name = value; }

        public virtual ICollection<FilmDTO> Films { get { return films = films ?? new HashSet<FilmDTO>(); } set => films = value; }

    }
}
