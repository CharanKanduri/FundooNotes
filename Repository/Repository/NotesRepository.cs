using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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
   public class NotesRepository :INotesRepository
    {
        
        private readonly UserContext userContext;
        private readonly IConfiguration configuration;

        public NotesRepository(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;

        }

        public bool color(int noteId, string colorName)
        {
            try
            {
                var resultData = this.userContext.Notes.Find(noteId);
                if (resultData != null && resultData.Trash != true)
                {
                    resultData.Color = colorName;
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

        public bool CreateNotes(NotesModel notesData)
        {
            try
            {
                
                if (notesData != null)
                {
                    this.userContext.Notes.Add(notesData);
                    this.userContext.SaveChanges();

                    return true;
                }
                else 
                { return false; 
                }
               
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IsArchieve(int noteId)
        {
            try
            {

                var resultData = this.userContext.Notes.Find(noteId);
                if (resultData != null && resultData.Trash != true)
                {
                    if (resultData.Archieve == true)
                    {
                        resultData.Archieve = false;
                        this.userContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        resultData.Archieve = true;
                        this.userContext.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IsDelete(int noteId)
        {
            try
            {
                var resultData = this.userContext.Notes.Find(noteId);
                if (resultData != null && resultData.Trash != true)
                {
                        resultData.Trash = true;
                        this.userContext.SaveChanges();
                        return true;
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Ispin(int noteId)
        {
            try
            {
                
                var resultData = this.userContext.Notes.Find(noteId);
                if (resultData != null && resultData.Trash != true)
                {
                    if (resultData.Pin == true)
                    {
                        resultData.Pin = false;
                        this.userContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        resultData.Pin = true;
                        this.userContext.SaveChanges();
                        return true;
                    } 
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IsRestore(int noteId)
        {
            try
            {

                var resultData = this.userContext.Notes.Find(noteId);
                if (resultData != null && resultData.Trash == true)
                {
                    
                    resultData.Trash = false;
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool PermanentDelete(int noteId)
        {
            try
            {
                var resultData = this.userContext.Notes.Find(noteId);
                if (resultData != null && resultData.Trash != true)
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

        public bool RemindMe(int noteId, string date)
        {
            try
            {
                var resultData = this.userContext.Notes.Find(noteId);
                if (resultData != null && resultData.Trash != true)
                {
                    resultData.RemindMe = date;
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

        public bool RemoveReminder(int noteId)
        {
            try
            {
                var resultData = this.userContext.Notes.Find(noteId);
                if (resultData != null && resultData.Trash != true)
                {
                    resultData.RemindMe = null;
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

        public bool Update(int noteId,NotesModel noteData)
        {
            try
            {
                var resultData = this.userContext.Notes.Find(noteId);
                if (resultData != null && resultData.Trash != true)
                {
                    resultData.Title = noteData.Title;
                    resultData.Description = noteData.Description;
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

        public List<NotesModel> GetNotes(int UserId)
        {
            try
            {
                var resultData = this.userContext.Notes.Where(x=> x.UserId == UserId && x.Trash==false && x.Archieve==false).ToList();
                if (resultData != null)
                {
                    return resultData;
                }
                return null;
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
                var resultData = this.userContext.Notes.Where(x => x.UserId == UserId && x.Trash == true && x.Archieve == false).ToList();
                if (resultData != null)
                {
                    return resultData;
                }
                return null;
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
                var resultData = this.userContext.Notes.Where(x => x.UserId == UserId && x.Trash == false && x.Archieve == true).ToList();
                if (resultData != null)
                {
                    return resultData;
                }
                return null;
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
                var resultData = this.userContext.Notes.Where(x => x.UserId == UserId && x.Trash == true && x.RemindMe!=null).ToList();
                if (resultData != null)
                {
                    return resultData;
                }
                return null;
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
                var resultData = this.userContext.Notes.Where(x => x.UserId == UserId && x.Trash == true).ToList();
                if (resultData.Count> 0)
                {
                    this.userContext.BulkDelete(resultData);
                    return true;
                }
                return false;
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
                var noteData = this.userContext.Notes.Find(noteId);
                if (noteData != null)
                {
                    Account account = new Account(configuration["CloudinaryAccount:CloudName"], configuration["CloudinaryAccount:ApiKey"], configuration["CloudinaryAccount:ApiSecret"]);
                    Cloudinary cloudinary = new Cloudinary(account);
                    ImageUploadParams uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(image.FileName, image.OpenReadStream())
                    };
                    var uploadResult = cloudinary.Upload(uploadParams);
                    noteData.Image = uploadResult.Url.ToString();
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool RemoveImage(int noteId)
        {
            try
            {
                var noteData = this.userContext.Notes.Find(noteId);
                if (noteData != null)
                {
                    noteData.Image = null;
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
