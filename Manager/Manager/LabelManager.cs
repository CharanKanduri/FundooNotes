using Manager.Interface;
using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Manager
{
    public class LabelManager : ILabelManager
    {
        private readonly ILabelRepository labelRepository;

        public LabelManager(ILabelRepository lableRepository)
        {
            this.labelRepository = lableRepository;
        }

        public string AddLableUsingEditLabels(LabelModel label)
        {
            try
            {
                return this.labelRepository.AddLableUsingEditLabels(label);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CreateLabelForNote(LabelModel lable)
        {
            try
            {
                return this.labelRepository.CreateLabelForNote(lable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string EditLabelUsingEdit(LabelModel lableModel, string newLabelName)
        {
            try
            {
                return this.labelRepository.EditLabelUsingEdit(lableModel, newLabelName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<LabelModel> GetLabelByNoteId(int noteId)
        {
            try
            {
                return this.labelRepository.GetLabelByNoteId(noteId);
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
                return this.labelRepository.GetLabelUsingUserId(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public string RemoveLabelUsingEditLebels(LabelModel lableModel, int userId)
        {
            try
            {
                return this.labelRepository.RemoveLabelUsingEditLebels(lableModel, userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string RemoveLabelUsingLabelId(int lableId)
        {
            try
            {
                return this.labelRepository.RemoveLabelUsingLabelId(lableId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
