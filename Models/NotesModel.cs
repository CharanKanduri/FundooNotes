using FandooNotes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class NotesModel
    {
        [Key]
        public int NotesId { get; set; }


        [ForeignKey("RegisterModel")]
        public int UserId { get; set; }
        public RegisterModel RegisterModel { get; set; }
 
        public string Title { get; set; }

        public string Description { get; set; }

        [DefaultValue(false)]
        public bool Pin { get; set; }

        public string RemindMe { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        [DefaultValue(false)]
        public bool Archieve { get; set; }
        [DefaultValue(false)]
        public bool Trash { get; set; }

    }
}
