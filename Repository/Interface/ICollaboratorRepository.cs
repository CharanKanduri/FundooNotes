using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ICollaboratorRepository
    {
        bool AddCollaborator(CollaboratorModel collaborator);
        List<CollaboratorModel> GetCollaborator(int UserId);
        bool RemoveCollaborator(int collaboratorId);
    }
}
