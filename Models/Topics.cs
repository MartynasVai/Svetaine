using System;
using System.ComponentModel.DataAnnotations;

namespace Svetaine.Models
{
    public class Topics //Forumo temos
    {
        public int ID { get; set; }
        public string Title { get; set; }//forumo temos pavadinimas
        public int Priority { get; set; }//Prioritetas, kuo mazesnis tuo auksciau bus parodyta

    }
}
