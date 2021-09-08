using Manager.Interface;
using Microsoft.AspNetCore.Http;
using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Manager
{
    public class NotesManager : INotesManager
    {
        private readonly INotesRepository notesRepository;

        public NotesManager(INotesRepository notesRepository)
        {
            this.notesRepository = notesRepository;
        }

        public bool color(int noteId, string colorName)
        {
            try
            {
                return this.notesRepository.color(noteId,colorName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool CreateNotes(NotesModel notesData)
        {
            try
            {
                return this.notesRepository.CreateNotes(notesData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public bool IsArchieve(int noteId)
        {
            try
            {
                return this.notesRepository.IsArchieve(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IsDelete(int noteId)
        {
            try
            {
                return this.notesRepository.IsDelete(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Ispin(int noteId)
        {
            try
            {
                return this.notesRepository.Ispin(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IsRestore(int noteId)
        {
            try
            {
                return this.notesRepository.IsRestore(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool PermanentDelete(int noteId)
        {
            try
            {
                return this.notesRepository.PermanentDelete(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool RemindMe(int noteId, string date)
        {
            try
            {
                return this.notesRepository.RemindMe(noteId, date);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool RemoveReminder(int noteId)
        {
            try
            {
                return this.notesRepository.RemoveReminder(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(int noteId, string title, string description)
        {
            try
            {
                return this.notesRepository.Update(noteId,title, description);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<NotesModel> GetNotes(int UserId)
        {
            try
            {
                return this.notesRepository.GetNotes(UserId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<NotesModel> GetFromTrash(int UserId)
        {
            try
            {
                return this.notesRepository.GetFromTrash(UserId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<NotesModel> GetAllRemainders(int UserId)
        {
            try
            {
                return this.notesRepository.GetAllRemainders(UserId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<NotesModel> GetFromArchieve(int UserId)
        {
            try
            {
                return this.notesRepository.GetFromArchieve(UserId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool EmptyTrash(int UserId)
        {
            try
            {
                return this.notesRepository.EmptyTrash(UserId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool AddImage(int noteId, IFormFile image)
        {
            try
            {
                return this.notesRepository.AddImage( noteId,image);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool RemoveImage(int noteId)
        {
            try
            {
                return this.notesRepository.RemoveImage(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
