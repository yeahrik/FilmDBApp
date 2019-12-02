using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace DTO
{
    [DataContract(Name = "CharacterDTO")]
    public class CharacterDTO
    {
        #region variables
        private int characterID;
        private string characterName;

        // foreign keys
        private ICollection<CharacterActorDTO> characterActors;
        #endregion

        #region constructors
        public CharacterDTO()
        {
            // one to many with CharAct
            this.CharacterActors = new HashSet<CharacterActorDTO>();
        }
        public CharacterDTO(int characterID, string characterName)
        {
            CharacterID = characterID;
            CharacterName = characterName;

            // one to many with CharAct
            this.CharacterActors = new HashSet<CharacterActorDTO>();
        }
        #endregion

        #region properties
        [DataMember(Name = "CharacterID")]
        public int CharacterID { get => characterID; set => characterID = value; }
        [DataMember(Name = "CharacterName")]
        public string CharacterName { get => characterName; set => characterName = value; }

        public virtual ICollection<CharacterActorDTO> CharacterActors { get { return characterActors = characterActors ?? new HashSet<CharacterActorDTO>(); } set => characterActors = value; }
        #endregion

        #region methods
        public override string ToString()
        {
            return "(ToString)Character:" +
                "\tCharacterId=" + CharacterID +
                "\tCharacterName=" + CharacterName;
        }
        public void Affiche()
        {
            Console.WriteLine(ToString());
        }
        #endregion

    }
}
