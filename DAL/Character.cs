using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL
{
    public class Character
    {
        #region variables
        private int characterID;
        private string characterName;

        // foreign keys
        private ICollection<CharacterActor> characterActors;
        #endregion

        #region constructors
        public Character()
        {
            // one to many with CharAct
            this.CharacterActors = new HashSet<CharacterActor>();
        }
        public Character(int characterID, string characterName)
        {
            CharacterID = characterID;
            CharacterName = characterName;

            // one to many with CharAct
            this.CharacterActors = new HashSet<CharacterActor>();
        }
        #endregion

        #region properties
        public int CharacterID { get => characterID; set => characterID = value; }
        public string CharacterName { get => characterName; set => characterName = value; }

        public virtual ICollection<CharacterActor> CharacterActors { get { return characterActors = characterActors ?? new HashSet<CharacterActor>(); } set => characterActors = value; }
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
