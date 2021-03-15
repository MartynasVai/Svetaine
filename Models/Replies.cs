using System;
using System.ComponentModel.DataAnnotations;

namespace Svetaine.Models
{
    public class Replies
    {
        public int ID { get; set; }
        public int ThreadID { get; set; }//irasas kuriame sukurtas atsakymas
        public string UserID { get; set; }//naudotojas kuris sukure atsakyma

        [DataType(DataType.Text)]
        public string Text { get; set; }//atsakymo tekstas

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }//data kada sukurtas atsakymas

    }
}
