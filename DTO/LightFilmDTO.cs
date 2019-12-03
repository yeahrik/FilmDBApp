using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DTO
{
    [DataContract(Name = "LightFilmDTO")]
    public class LightFilmDTO
    {
        #region variables
        private string _title;
        private decimal _score;


        #endregion

        #region proprietes
        [DataMember(Name = "LightFilmTitle")]
        public string Title { get => _title; set => _title = value; }

        [DataMember(Name = "LightFilmScore")]
        public decimal Score { get => _score; set => _score = value; }



        #endregion

        public LightFilmDTO(string title, decimal score)
        {
            Title = title;
            Score = score;
        }
        public LightFilmDTO()
        {

        }

        #region methods
        public override string ToString()
        {
            return "(ToString)Film:" +
                "\tLightFilmTitle=" + Title +
                "\tLightFilmScore=" + Score;
        }
        public void Affiche()
        {
            Console.WriteLine(ToString());
        }
        #endregion


    }
}
