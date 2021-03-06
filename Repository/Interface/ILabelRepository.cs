using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ILabelRepository
    {
        string AddLableUsingEditLabels(LabelModel lable);
        string CreateLabelForNote(LabelModel lable);
        string RemoveLabelUsingEditLebels(LabelModel lableModel, int userId);
        public string RemoveLabelUsingNoteId(int noteId);
        public string EditLabelUsingEdit(LabelModel lableModel, string newLabelName);
        public List<LabelModel> GetLabelUsingLabelId(int labelId);
        public string RemoveLabelUsingLabelId(int lableId);
        public List<LabelModel> GetLabelByNoteId(int noteId);
        public List<LabelModel> GetLabelUsingUserId(int userId);
    }
}
