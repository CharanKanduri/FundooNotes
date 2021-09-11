// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Charan Kanduri"/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes.Controllers
{
    using System;
    using System.Collections.Generic;
    using Manager.Interface;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    /// <summary>
    /// Notes controller where all route for application is defines.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Authorize]
    public class NotesController : ControllerBase
    {
        /// <summary>
        /// variable of Interface note manager.
        /// </summary>
        private readonly INotesManager notesManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesController"/> class.
        /// </summary>
        /// <param name="notesManager">The notes.</param>
        public NotesController(INotesManager notesManager)
        {
            this.notesManager = notesManager;
        }
        /// <summary>
        /// Create a note.
        /// </summary>
        /// <param name="noteData">Note data variable</param>
        /// <returns>Retrieve success message</returns>
        [HttpPost]
        [Route("api/CreateNote")]
        public IActionResult CreateNote([FromBody] NotesModel noteData)
        {
            try
            {
                bool result = this.notesManager.CreateNotes(noteData);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Message = "New Note called " + noteData.Title + " is Add Successfull" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Note added Unsuccessfull" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        /// <summary>
        /// Is pin Method.
        /// </summary>
        /// <param name="noteId">Note data variable</param>
        /// <returns>Retrieve success message</returns>
        [HttpPost]
        [Route("api/Ispin")]
        public IActionResult Ispin(int noteId)
        {
            try
            {
                bool result = this.notesManager.Ispin(noteId);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Message = "Pin changed successfully" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Unsuccessful Make sure Notes is not in Trash" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        /// <summary>
        /// Is Archieve Method.
        /// </summary>
        /// <param name="noteId">Note data variable</param>
        /// <returns>Retrieve success message</returns>
        [HttpPost]
        [Route("api/IsArchieve")]
        public IActionResult IsArchieve(int noteId)
        {
            try
            {
                bool result = this.notesManager.IsArchieve(noteId);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Message = "Archive done successfully" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Unsuccessful Make sure Notes is not in Trash" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        /// <summary>
        /// Is Delete Method.
        /// </summary>
        /// <param name="noteId">Note data variable</param>
        /// <returns>Retrieve success message</returns>
        [HttpPost]
        [Route("api/IsDelete")]
        public IActionResult IsDelete(int noteId)
        {
            try
            {
                bool result = this.notesManager.IsDelete(noteId);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Message = "Delete successfully" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Unsuccessful Make sure Notes is not in Trash" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        /// <summary>
        /// Is Restore Method.
        /// </summary>
        /// <param name="noteId">Note data variable</param>
        /// <returns>Retrieve success message</returns>
        [HttpPost]
        [Route("api/IsRestore")]
        public IActionResult IsRestore(int noteId)
        {
            try
            {
                bool result = this.notesManager.IsRestore(noteId);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Message = "Restored successfully" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Unsuccessful Make sure Notes is not in Trash" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        /// <summary>
        /// Add colour Method.
        /// </summary>
        /// <param name="noteId">Note data variable</param>
        /// <param name="colorName">color name string.</param>
        /// <returns>Retrieve success message</returns>
        [HttpPost]
        [Route("api/color")]
        public IActionResult Color(int noteId, string colorName)
        {
            try
            {
                bool result = this.notesManager.color(noteId, colorName);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Message = "color changed successfully" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Unsuccessful color change" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        /// <summary>
        /// Add Reminder Method.
        /// </summary>
        /// <param name="noteId">Note data variable</param>
        /// <param name="date">date string.</param>
        /// <returns>Retrieve success message</returns>
        [HttpPost]
        [Route("api/RemindMe")]
        public IActionResult RemindMe(int noteId, string date)
        {
            try
            {
                bool result = this.notesManager.RemindMe(noteId, date);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Message = "Reminded added successfully on: " + date });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Sorry can't set reminder !! check trash" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Remove Reminder Method.
        /// </summary>
        /// <param name="noteId">Note data variable.</param>
        /// <returns>Retrieve success message.</returns>
        [HttpPost]
        [Route("api/RemoveReminder")]
        public IActionResult RemoveReminder(int noteId)
        {
            try
            {
                bool result = this.notesManager.RemoveReminder(noteId);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Message = "Removed Reminder Successfully: " });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Sorry can't remove reminder !! check if notes in trash" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Update Method.
        /// </summary>
        /// <param name="noteId">Note data variable.</param>
        /// <param name="noteData">Note model variable.</param>
        /// <returns>Retrieve success message.</returns>
        [HttpPost]
        [HttpPost]
        [Route("api/Update")]
        public IActionResult Update(int noteId, [FromBody] NotesModel noteData)
        {
            try
            {
                bool result = this.notesManager.Update(noteId, noteData);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Message = "Notes Updated Successfully: " });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Sorry can't Update" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// permanent Method.
        /// </summary>
        /// <param name="noteId">Note data variable.</param>
        /// <returns>Retrieve success message.</returns>
        [HttpDelete]
        [Route("api/PermanentDelete")]
        public IActionResult PermanentDelete(int noteId)
        {
            try
            {
                bool result = this.notesManager.PermanentDelete(noteId);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Message = "Permanent Delete Successfull: " });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Sorry can't Find notes" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get Notes Method.
        /// </summary>
        /// <param name="userId">Note data variable.</param>
        /// <returns>Retrieve success message.</returns>
        [HttpPost]
        [Route("api/GetNotes")]
        public IActionResult GetNotes(int userId)
        {
            try
            {
                List<NotesModel> currentNotes = this.notesManager.GetNotes(userId);

                if (currentNotes != null)
                {
                    return this.Ok(new ResponseModel<List<NotesModel>>() { Status = true, Message = "Successful", Data = currentNotes });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Sorry can't Perform activity" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get notes from trash Method.
        /// </summary>
        /// <param name="userId">Note data variable.</param>
        /// <returns>Retrieve success message.</returns>
        [HttpPost]
        [Route("api/GetFromTrash")]
        public IActionResult GetFromTrash(int userId)
        {
            try
            {
                List<NotesModel> currentNotes = this.notesManager.GetFromTrash(userId);
                if (currentNotes != null)
                {
                    return this.Ok(new ResponseModel<List<NotesModel>>() { Status = true, Message = " Successfull ", Data = currentNotes });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Can't find notes in Trash, Check Again" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get All reminders Method.
        /// </summary>
        /// <param name="userId">Note data variable.</param>
        /// <returns>Retrieve success message.</returns>
        [HttpPost]
        [Route("api/GetAllRemainders")]
        public IActionResult GetAllRemainders(int userId)
        {
            try
            {
                List<NotesModel> currentNotes = this.notesManager.GetAllRemainders(userId);
                if (currentNotes != null)
                {
                    return this.Ok(new ResponseModel<List<NotesModel>>() { Status = true, Message = " Successfull ", Data = currentNotes });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Can't find notes in Trash, Check Again" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get notes from Archievers Method.
        /// </summary>
        /// <param name="userId">Note data variable.</param>
        /// <returns>Retrieve success message.</returns>
        [HttpPost]
        [Route("api/GetFromArchieve")]
        public IActionResult GetFromArchieve(int userId)
        {
            try
            {
                List<NotesModel> currentNotes = this.notesManager.GetFromArchieve(userId);
                if (currentNotes != null)
                {
                    return this.Ok(new ResponseModel<List<NotesModel>>() { Status = true, Message = " Successfull ", Data = currentNotes });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Can't find notes in Archieve , Check Again" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Empty trash Method.
        /// </summary>
        /// <param name="userId">Note data variable.</param>
        /// <returns>Retrieve success message.</returns>
        [HttpDelete]
        [Route("api/EmptyTrash")]
        public IActionResult EmptyTrash(int userId)
        {
            try
            {
                bool result = this.notesManager.EmptyTrash(userId);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<List<NotesModel>>() { Status = true, Message = " Empty trash Successfull " });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Trash Is Empty Already" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Add image Method.
        /// </summary>
        /// <param name="noteId">Note data variable.</param>
        /// <param name="image">I form file type.</param>
        /// <returns>Retrieve success message.</returns>
        [HttpPost]
        [Route("api/AddImage")]
        public IActionResult AddImage(int noteId, IFormFile image)
        {
            try
            {
                bool result = this.notesManager.AddImage(noteId, image);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Message = "Image is added Successfull" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Image is added UnSuccessfull" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Remove image Method.
        /// </summary>
        /// <param name="noteId">Note data variable.</param>
        /// <returns>Retrieve success message.</returns>
        [HttpPut]
        [Route("api/RemoveImage")]
        public IActionResult RemoveImage(int noteId)
        {
            try
            {
                bool result = this.notesManager.RemoveImage(noteId);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Result = "Image Removed Successfull " });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "Image Removed Unsuccessfull " });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
