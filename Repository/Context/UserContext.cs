using FandooNotes.Models;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Repository.Context
{
   
        public class UserContext : DbContext
        {
            public UserContext(DbContextOptions<UserContext> options) : base(options)
            { 

            }
            public DbSet<RegisterModel> Users { get; set; }

            public DbSet<NotesModel> Notes { get; set; }
            public DbSet<CollaboratorModel> Collaborators { get; set; }
            public DbSet<LabelModel> Labels { get; set; }

    }

    
}
