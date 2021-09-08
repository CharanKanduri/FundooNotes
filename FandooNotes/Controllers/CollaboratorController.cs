using Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    public class CollaboratorController : ControllerBase
    {
        private readonly ICollaboratorManager collaboratorManager;

        public CollaboratorController(ICollaboratorManager collaboratorManager)
        {
            this.collaboratorManager = collaboratorManager;
        }

        [HttpPost]
        [Route("api/AddCollaborator")]
        public IActionResult AddCollaborator([FromBody] CollaboratorModel CollaboratorData)
        {
            try
            {
                bool result = this.collaboratorManager.AddCollaborator(CollaboratorData);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Message = "Collaborator Added Successfully" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Email alredy Exits" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/GetCollaborator")]
        public IActionResult GetCollaborator(int NotesId)
        {
            try
            {
                List<CollaboratorModel> collaborators = this.collaboratorManager.GetCollaborator(NotesId);
                if (collaborators != null)
                {
                    return this.Ok(new ResponseModel<List<CollaboratorModel>>() { Status = true, Message = " Successfull ", Data = collaborators });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
       
        [HttpDelete]
        [Route("api/RemoveCollaborator")]
        public IActionResult RemoveCollaborator(int collaboratorId)
        {
            try
            {
                bool result = this.collaboratorManager.RemoveCollaborator(collaboratorId);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Message = "Remove Collaborator Successfully: " });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Sorry can't remove" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
