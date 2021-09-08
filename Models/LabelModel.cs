using FandooNotes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LabelModel
    {
       
        [Key]
        public int LabelId { get; set; }

     
        [Required]
        public string LabelName { get; set; }

       
        [ForeignKey("NotesModel")]
        public int? NotesId { get; set; }

      
        public NotesModel NotesModel { get; set; }

      
        [ForeignKey("RegisterModel")]
        public int UserId { get; set; }

     
        public RegisterModel RegisterModel { get; set; }


    }
}
