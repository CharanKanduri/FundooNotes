using Models;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly UserContext userContext;

        public CollaboratorRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }


        public bool AddCollaborator(CollaboratorModel collaborator)
        {
            try
            {
                bool result;
                if (collaborator != null)
                {
                    this.userContext.Collaborators.Add(collaborator);
                    this.userContext.SaveChanges();
                    result = true;
                    return result;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public List<CollaboratorModel> GetCollaborator(int notesId)
        {
            try
            {
                List<CollaboratorModel> collaborators = new List<CollaboratorModel>();
                var resultData = this.userContext.Collaborators.Where(p => p.NotesId == notesId).FirstOrDefault();
                if (resultData != null)
                {
                    var data = from user in this.userContext.Collaborators where user.NotesId == notesId select user;
                    foreach(var item in data)
                    {
                        collaborators.Add(item);
                    }
                    return collaborators;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool RemoveCollaborator(int collaboratorId)
        {
            try
            {
                var resultData = this.userContext.Collaborators.Find(collaboratorId);
                if (resultData != null)
                {
                    this.userContext.Remove(resultData);
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
