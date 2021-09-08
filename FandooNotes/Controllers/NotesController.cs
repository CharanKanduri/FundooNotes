using Manager.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{   [Authorize]
    public class NotesController : ControllerBase
    {
        private readonly INotesManager notesManager;

        public NotesController(INotesManager notesManager)
        {
            this.notesManager = notesManager;
        }

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

        [HttpPost]
        [Route("api/color")]
        public IActionResult color(int noteId, string colorName)
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
        [HttpPost]
        [Route("api/Update")]
        public IActionResult Update(int noteId, string title, string description)
        {
            try
            {
                bool result = this.notesManager.Update(noteId, title, description);
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
        [HttpPost]
        [Route("api/GetNotes")]
        public IActionResult GetNotes(int UserId)
        {
            try
            {
                List<NotesModel> currentNotes = this.notesManager.GetNotes(UserId);

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
        [HttpPost]
        [Route("api/GetFromTrash")]
        public IActionResult GetFromTrash(int UserId)
        {
            try
            {
                List<NotesModel> currentNotes = this.notesManager.GetFromTrash(UserId);
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
        [HttpPost]
        [Route("api/GetAllRemainders")]
        public IActionResult GetAllRemainders(int UserId)
        {
            try
            {
                List<NotesModel> currentNotes = this.notesManager.GetAllRemainders(UserId);
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
        [HttpPost]
        [Route("api/GetFromArchieve")]
        public IActionResult GetFromArchieve(int UserId)
        {
            try
            {
                List<NotesModel> currentNotes = this.notesManager.GetFromArchieve(UserId);
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
        [HttpDelete]
        [Route("api/EmptyTrash")]
        public IActionResult EmptyTrash(int UserId)
        {
            try
            {
                bool result = this.notesManager.EmptyTrash(UserId);
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
