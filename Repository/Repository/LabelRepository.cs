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
    public class LabelRepository : ILabelRepository
    {
        private readonly UserContext userContext;

        public LabelRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }
        public string AddLableUsingEditLabels(LabelModel lableModel)
        {
            try
            {
                var oldLabel = this.userContext.Labels.Where(label => label.LabelName == lableModel.LabelName && label.UserId == lableModel.UserId && label.NotesId == null).SingleOrDefault();
                if (oldLabel == null)
                {
                    this.userContext.Labels.Add(lableModel);
                    this.userContext.SaveChanges();
                    return "Label created";
                }

                return "Label already exists";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string RemoveLabelUsingEditLebels(LabelModel lableModel,int userId)
        {
            try
            {
                var labelList = this.userContext.Labels.Where(label => label.LabelName == lableModel.LabelName && label.UserId == userId).ToList();
                if (labelList.Count != 0)
                {
                    this.userContext.Labels.RemoveRange(labelList);
                    this.userContext.SaveChanges();
                    return "Label deleted";
                }

                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string EditLabelUsingEdit(LabelModel lableModel, string newLabelName)
        {
            try
            {
                string message = "";
                var checkExisting = this.userContext.Labels.Where(label => label.LabelName==newLabelName && label.NotesId == null && label.UserId == userId).SingleOrDefault();
                var labelList = this.userContext.Labels.Where(label => label.LabelName == labelName && label.UserId == userId).ToList();
              
                if (labelList.Count != 0)
                {   
                    if (checkExisting != null)
                    {
                        this.userContext.Labels.Remove(checkExisting);
                        this.userContext.SaveChanges();
                        message = "Merge the '" + labelName + "' label with the '" + newLabelName + "' label? All notes labeled with '" + labelName + "' will be labeled with '" + newLabelName + "', and the '" + labelName + "' label will be deleted.";
                        return message;
                    }
                    foreach (var label in labelList)
                    {
                        label.LabelName = newLabelName;
                    }

                    this.userContext.UpdateRange(labelList);
                    this.userContext.SaveChanges();

                    return "Label Updated";
                }
                return "Couldn't update Label";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string CreateLabelForNote(LabelModel lableModel)
        {
            try
            {
                var oldLabel = this.userContext.Labels.Where(label => label.LabelName == lableModel.LabelName && label.UserId == lableModel.UserId && label.NotesId == lableModel.NotesId).SingleOrDefault();
                if (oldLabel == null)
                {
                    this.userContext.Labels.Add(lableModel);
                    this.userContext.SaveChanges();
                    lableModel.NotesId = null;
                    lableModel.LabelId = 0; 
                    this.AddLableUsingEditLabels(lableModel);
                    return "Label created";
                }

                return "Label already exists";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string RemoveLabelUsingLabelId(int lableId)
        {
            try
            {
                var noteLabel = this.userContext.Labels.Where(x => x.LabelId == lableId).SingleOrDefault();
                if (noteLabel != null)
                {
                    this.userContext.Labels.Remove(noteLabel);
                    this.userContext.SaveChanges();
                    return "Label is removed";
                }

                return "Remove label failed";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<LabelModel> GetLabelUsingUserId(int userId)
        {
            try
            {
                var listLabel = this.userContext.Labels.Where(label => userId == label.UserId && label.NotesId == null).ToList();
                if (listLabel.Count != 0)
                {
                    return listLabel;
                }

                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<LabelModel> GetLabelByNoteId(int noteId)
        {
            try
            {
                var label = this.userContext.Labels.Where(x => x.NotesId == noteId).ToList();
                if (label.Count != 0)
                {
                    return label;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
