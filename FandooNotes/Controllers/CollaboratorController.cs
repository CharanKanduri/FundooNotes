namespace FundooNotes.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Manager.Interface;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    /// <summary>
    /// Collaborator controller all paths are defined.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    public class CollaboratorController : ControllerBase
    {
        /// <summary>
        /// The collaborator manager.
         /// </summary>
        private readonly ICollaboratorManager collaboratorManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorController"/> class.
        /// </summary>
        /// <param name="collaboratorManager">The collaborator.</param>
        public CollaboratorController(ICollaboratorManager collaboratorManager)
        {
            this.collaboratorManager = collaboratorManager;
        }

        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="collaboratorData">The collaborator model.</param>
        /// <returns>Success data and message.</returns>
        [HttpPost]
        [Route("api/AddCollaborator")]
        public IActionResult AddCollaborator([FromBody] CollaboratorModel collaboratorData)
        {
            try
            {
                bool result = this.collaboratorManager.AddCollaborator(collaboratorData);
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

        /// <summary>
        /// GetCollaborator.
        /// </summary>
        /// <param name="notesId">The collaborator model.</param>
        /// <returns>Success data and message.</returns>
        [HttpPost]
        [Route("api/GetCollaborator")]
        public IActionResult GetCollaborator(int notesId)
        {
            try
            {
                List<CollaboratorModel> collaborators = this.collaboratorManager.GetCollaborator(notesId);
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

        /// <summary>
        /// RemoveCollaborator.
        /// </summary>
        /// <param name="collaboratorId">The collaborator model.</param>
        /// <returns>Success data and message.</returns>
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
