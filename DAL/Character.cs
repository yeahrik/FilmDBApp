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
        #endregion

        #region constructors
        public Character()
        {
        }
        public Character(int characterID, string characterName)
        {
            CharacterID = characterID;
            CharacterName = characterName;
        }
        #endregion

        #region properties
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharacterID { get => characterID; set => characterID = value; }
        public string CharacterName { get => characterName; set => characterName = value; }
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
