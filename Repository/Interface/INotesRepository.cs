using Microsoft.AspNetCore.Http;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface INotesRepository
    {
        bool CreateNotes(NotesModel notesData);
        bool Ispin(int noteId);
        bool IsArchieve(int noteId);

        bool IsDelete(int noteId);
        bool IsRestore(int noteId);
        bool color(int noteId, string colorName);
        bool RemindMe(int noteId, string date);
        bool RemoveReminder(int noteId);
        bool Update(int noteId, string title, string description);
        bool PermanentDelete(int noteId);
        List<NotesModel> GetNotes(int UserId);
        List<NotesModel> GetFromTrash(int UserId);
        List<NotesModel> GetAllRemainders(int UserId);
        List<NotesModel> GetFromArchieve(int UserId);
        bool EmptyTrash(int UserId);
        bool AddImage(int noteId, IFormFile image);
        bool RemoveImage(int noteId);
    }
}
