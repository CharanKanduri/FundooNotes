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
        string RemoveLabelUsingEditLebels(string lable, int userId);
        public string EditLabelUsingEdit(int userId, string labelName, string newLabelName);
        public string RemoveLabelUsingLabelId(int lableId);
    }
}
