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

        public string EditLabelUsingEdit(int userId, string labelName, string newLabelName)
        {
            try
            {
                return this.labelRepository.EditLabelUsingEdit(userId, labelName, newLabelName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string RemoveLabelUsingEditLebels(string lable, int userId)
        {
            try
            {
                return this.labelRepository.RemoveLabelUsingEditLebels(lable,userId);
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
