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
                var oldLabel = this.userContext.Labels.Where(label => label.LabelName == lableModel.LabelName && label.UserId == lableModel.UserId && label.NotesId == lableModel.NotesId).SingleOrDefault();
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
        public string RemoveLabelUsingEditLebels(string labelName, int userId)
        {
            try
            {
                var labelList = this.userContext.Labels.Where(label => label.LabelName == labelName && label.UserId == userId).ToList();
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
        public string EditLabelUsingEdit(int userId, string labelName, string newLabelName)
        {
            try
            {
                var labelList = this.userContext.Labels.Where(label => label.LabelName == labelName && label.UserId == userId).ToList();
              
                if (labelList.Count != 0)
                {
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
    }
}
