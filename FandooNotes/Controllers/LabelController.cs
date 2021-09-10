namespace FundooNotes.Controllers
{
    using System;
    using System.Collections.Generic;
    using Manager.Interface;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    /// <summary>
    /// Label controller is where all route for application is defines.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase"/>
    public class LabelController : ControllerBase
    { /// <summary>
      /// The label manager.
      /// </summary>
        private readonly ILabelManager labelManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelController"/> class.
        /// </summary>
        /// <param name="lableManager">The label manager.</param>
        public LabelController(ILabelManager lableManager)
        {
            this.labelManager = lableManager;
        }

        /// <summary>
        /// Adds the label using edit.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>Returns exception.</returns>
        [HttpPost]
        [Route("api/AddLabelUsingEdit")]
        public IActionResult AddLableUsingEditLabels([FromBody] LabelModel labelModel)
        {
            try
            {
                string result = this.labelManager.AddLableUsingEditLabels(labelModel);
                if (result == "Label created")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// create the label using edit.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>Returns exception.</returns>
        [HttpPost]
        [Route("api/CreateLabelForNote")]
        public IActionResult CreateLabelForNote([FromBody] LabelModel labelModel)
        {
            try
            {
                string result = this.labelManager.CreateLabelForNote(labelModel);
                if (result != "Label added")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// remove the label using edit.
        /// </summary>
        /// <param name="lableModel">The label model.</param>
        /// <param name="userId">The user id.</param>
        /// <returns>Returns exception.</returns>
        [HttpDelete]
        [Route("api/RemoveLabelUsingEditLebels")]
        public IActionResult RemoveLabelUsingEditLebels(LabelModel lableModel, int userId)
        {
            try
            {
                string result = this.labelManager.RemoveLabelUsingEditLebels(lableModel, userId);
                if (result == "Label deleted")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// edit the label using editLabels.
        /// </summary>
        /// <param name="lableModel">The label model.</param>
        /// <param name="newLabelName">The new label name.</param>
        /// <returns>Returns exception.</returns>
        [HttpPut]
        [Route("api/EditLabelUsingEdit")]
        public IActionResult EditLabelUsingEdit(LabelModel lableModel, string newLabelName)
        {
            try
            {
                string result = this.labelManager.EditLabelUsingEdit(lableModel, newLabelName);
                if (result != "Couldn't update Label")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// remove the label using edit.
        /// </summary>
        /// <param name="lableId">The label id.</param>
        /// <returns>Returns exception.</returns>
        [HttpDelete]
        [Route("api/RemoveLabel")]
        public IActionResult RemoveLabelUsingLabelId(int lableId)
        {
            try
            {
                string result = this.labelManager.RemoveLabelUsingLabelId(lableId);
                if (result != "Label is removed")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get the label using User level.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>Returns exception.</returns>
        [HttpGet]
        [Route("api/GetLabelUsingUserId")]
        public IActionResult GetLabelUsingUserId(int userId)
        {
            try
            {
                List<LabelModel> result = this.labelManager.GetLabelUsingUserId(userId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<List<LabelModel>>() { Status = true, Message = "Retrieved Label", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<List<LabelModel>>() { Status = false, Message = "Couldn't retrieve", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get the label using User level.
        /// </summary>
        /// <param name="notesId">The notes id.</param>
        /// <returns>Returns exception.</returns>
        [HttpGet]
        [Route("api/GetLabelUsingNotesId")]
        public IActionResult GetLabelUsingNotesId(int notesId)
        {
            try
            {
                List<LabelModel> result = this.labelManager.GetLabelUsingUserId(notesId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<List<LabelModel>>() { Status = true, Message = "Retrieved Label", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<List<LabelModel>>() { Status = false, Message = "Couldn't retrieve", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        /// <summary>
        /// Get the label using User level.
        /// </summary>
        /// <param name="labelId">The notes id.</param>
        /// <returns>Returns exception.</returns>
        [HttpGet]
        [Route("api/GetLabelUsingNotesId")]
        public IActionResult GetLabelUsingLabelId(int labelId)
        {
            try
            {
                List<LabelModel> result = this.labelManager.GetLabelUsingUserId(labelId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<List<LabelModel>>() { Status = true, Message = "Retrieved Label", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<List<LabelModel>>() { Status = false, Message = "Couldn't retrieve", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get the label at note level.
        /// </summary>
        /// <param name="noteId">The note id.</param>
        /// <returns>Returns exception.</returns>
        [HttpGet]
        [Route("api/GetLabelByNoteId")]
        public IActionResult GetLabelByNoteId(int noteId)
        {
            try
            {
                List<LabelModel> result = this.labelManager.GetLabelByNoteId(noteId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<List<LabelModel>>() { Status = true, Message = "Retrieved Label", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<List<LabelModel>>() { Status = false, Message = "Couldn't retrieve", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
