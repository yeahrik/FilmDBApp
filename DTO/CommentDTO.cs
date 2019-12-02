using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace DTO
{
    [DataContract(Name = "CommentDTO")]
    public class CommentDTO
    {
        #region variables
        private int commentID;
        private string content;
        private int rate;
        private int idActor;
        private string avatar;
        private DateTime? dateComment;
        #endregion

        #region constructors
        public CommentDTO()
        {
        }
        public CommentDTO(int commentID, string content, int rate, string avatar, DateTime? dateComment, int idActor)
        {
            CommentID = commentID;
            Content = content;
            Rate = rate;
            Avatar = avatar;
            DateComment = dateComment;
            IdActor = idActor;
        }
        public CommentDTO(string content, int rate, string avatar, DateTime? dateComment, int idActor)
        {
            Content = content;
            Rate = rate;
            Avatar = avatar;
            DateComment = dateComment;
            IdActor = idActor;
        }

        #endregion

        #region properties
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember(Name = "CommentID")]
        public int CommentID { get => commentID; set => commentID = value; }
        [DataMember(Name = "CommentContent")]
        public string Content { get => content; set => content = value; }
        [DataMember(Name = "CommentRate")]
        public int Rate { get => rate; set => rate = value; }
        [DataMember(Name = "CommentAvatar")]
        public string Avatar { get => avatar; set => avatar = value; }
        [DataMember(Name = "CommentDateComment")]
        public DateTime? DateComment { get => dateComment; set => dateComment = value; }
        [DataMember(Name = "CommentIdActor")]
        public int IdActor { get => idActor; set => idActor = value; }
        #endregion

        #region methods
        public override string ToString()
        {
            return "(ToString)Comment:" +
                "\tCommentID=" + CommentID +
                "\tContent=" + Content +
                "\tRate=" + Rate +
                "\tAvatar=" + Avatar +
                "\tDateComment=" + DateComment +
                "\tIdActor=" + IdActor;
        }
        public void Affiche()
        {
            Console.WriteLine(ToString());
        }
        #endregion
    }
}
