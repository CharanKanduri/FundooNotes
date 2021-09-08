using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CollaboratorModel
    {   [Key]
        public int CollaboratorId { get; set; }

        [ForeignKey("NotesModel")]
        public int NotesId { get; set; }
        public virtual NotesModel NotesModel { get; set; }
        public string OwnerEmail { get; set; }
        public string CollaboratorEmail { get; set; }
       

    }
}
