using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DTO
{
    [DataContract(Name = "FullActorDTO")]
    public class FullActorDTO : ActorDTO
    {



        #region variables
        // foreign keys
        private ICollection<FilmDTO> films;
        private ICollection<CharacterActorDTO> characterActors;
        #endregion

        #region constructors
        public FullActorDTO()
        {
            // many to many with Films
            this.Films = new HashSet<FilmDTO>();
            // one to many with CharAct
            this.CharacterActors = new HashSet<CharacterActorDTO>();

        }
        public FullActorDTO(int actorID, string name, string surname, List<FilmDTO> filmsDTO, List<CharacterActorDTO> characteractorsDTO) : base (actorID, name, surname)
        {

            // many to many with Films
            this.Films = filmsDTO;
            // one to many with CharAct
            this.CharacterActors = characteractorsDTO;

        }


        #endregion

        #region properties
        [DataMember(Name = "FullActorDTOFilms")]
        public virtual ICollection<FilmDTO> Films { get { return films = films ?? new HashSet<FilmDTO>(); } set => films = value; }
        [DataMember(Name = "FullActorDTOCharacterActors")]

        public virtual ICollection<CharacterActorDTO> CharacterActors { get { return characterActors = characterActors ?? new HashSet<CharacterActorDTO>(); } set => characterActors = value; }

        #endregion




    }
}
