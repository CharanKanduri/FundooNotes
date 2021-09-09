﻿using Models;
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
        public string EditLabelUsingEdit(LabelModel lableModel, string newLabelName)
        public string RemoveLabelUsingLabelId(int lableId);
        public List<LabelModel> GetLabelByNoteId(int noteId);
        public List<LabelModel> GetLabelUsingUserId(int userId);
    }
}
