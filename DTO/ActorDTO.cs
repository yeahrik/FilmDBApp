using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DAL
{
    [DataContract(Name = "ActorDTO")]
    public class ActorDTO
    {

        #region variables
        private int actorID;
        private string name;
        private string surname;

        #endregion

        #region constructors
        public ActorDTO()
        {


        }
        public ActorDTO(int actorID, string name, string surname)
        {
            ActorID = actorID;
            Name = name;
            Surname = surname;


        }

        #endregion

        #region properties
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember(Name = "ActorID")]
        public int ActorID { get => actorID; set => actorID = value; }
        [DataMember(Name = "ActorName")]
        public string Name { get => name; set => name = value; }
        [DataMember(Name = "ActorSurname")]
        public string Surname { get => surname; set => surname = value; }

        #endregion

        #region methods
        public override string ToString()
        {
            return "(ToString)Actor:" +
                "\tActorID=" + ActorID +
                "\tName=" + Name +
                "\tSurname=" + Surname;
        }
        public void Affiche()
        {
            Console.WriteLine(ToString());
        }
        #endregion
    }
}
