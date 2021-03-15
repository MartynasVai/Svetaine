using System;
using System.ComponentModel.DataAnnotations;

namespace Svetaine.Models
{
    public class Threads //forumo irasai
    {
        public int ID { get; set; }
        public int TopicID { get; set; }//kurioje temoja sukurtas irasas
        public string UserID { get; set; }//naudotojas kuris sukure irasa

        [DataType(DataType.Text)]
        public string Text { get; set; }//iraso tekstas
        public bool Pinned { get; set; }//Ar prisegtas irasas
        public bool Locked { get; set; }//ar uzrakintas( ar galima rasyti atsakymus )

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }//data kada sukurtas irasas


    }
}
