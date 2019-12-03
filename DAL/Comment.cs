using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO
{
    public class Comment
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
        public Comment()
        {
        }
        public Comment(int commentID, string content, int rate, string avatar, DateTime? dateComment, int idActor)
        {
            CommentID = commentID;
            Content = content;
            Rate = rate;
            Avatar = avatar;
            DateComment = dateComment;
            ActorID = idActor;
        }
        public Comment(string content, int rate, string avatar, DateTime? dateComment, int idActor)
        {
            Content = content;
            Rate = rate;
            Avatar = avatar;
            DateComment = dateComment;
            ActorID = idActor;
        }

        #endregion

        #region properties
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CommentID { get => commentID; set => commentID = value; }
        public string Content { get => content; set => content = value; }
        public int Rate { get => rate; set => rate = value; }
        public string Avatar { get => avatar; set => avatar = value; }
        public DateTime? DateComment { get => dateComment; set => dateComment = value; }
        public int ActorID { get => idActor; set => idActor = value; }
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
                "\tIdActor=" + ActorID;
        }
        public void Affiche()
        {
            Console.WriteLine(ToString());
        }
        #endregion
    }
}
