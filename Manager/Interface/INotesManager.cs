using Microsoft.AspNetCore.Http;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Interface
{
    public interface INotesManager
    {
        bool CreateNotes(NotesModel noteData);
        bool Ispin(int noteId);
        bool IsArchieve(int noteId);
        bool IsDelete(int noteId);
        bool IsRestore(int noteId);
        bool color(int noteId, string colorName);
        bool RemindMe(int noteId, string date);
        bool RemoveReminder(int noteId);
        bool Update(int noteId, NotesModel noteData);
        bool PermanentDelete(int noteId);
        List<NotesModel> GetNotes(int UserId);
        List<NotesModel> GetFromTrash(int UserId);
        List<NotesModel> GetAllRemainders(int UserId);
        List<NotesModel> GetFromArchieve(int UserId);
        bool EmptyTrash(int UserId);
        bool RemoveImage(int noteId);
        bool AddImage(int noteId, IFormFile image);
    }
}
