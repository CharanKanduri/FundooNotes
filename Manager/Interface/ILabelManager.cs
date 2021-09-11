// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICollaboratorManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Charan Kanduri"/>
// ----------------------------------------------------------------------------------------------------------
namespace Manager.Interface
{
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Interface containing method declaration.
    /// </summary>
    public interface ILabelManager
    { /// <summary>
      /// Adds the Label using Edit Labels.
      /// </summary>
      /// <param name="lable">The model.</param>
      /// <returns>Returns success message.</returns>
        string AddLableUsingEditLabels(LabelModel lable);

        /// <summary>
        /// Create note for lables.
        /// </summary>
        /// <param name="lable">The model.</param>
        /// <returns>Returns success message.</returns>
        string CreateLabelForNote(LabelModel lable);

        /// <summary>
        /// Create note for lables.
        /// </summary>
        /// <param name="lableModel">The model.</param>
        /// <param name="userId">The uSER iD FROM model.</param>
        /// <returns>Returns success message.</returns>
        string RemoveLabelUsingEditLebels(LabelModel lableModel, int userId);

        /// <summary>
        /// Rename Label.
        /// </summary>
        /// <param name="lableModel">The model.</param>
        /// <param name="newLabelName">New label Name input.</param>
        /// <returns>Returns success message.</returns>
        public string EditLabelUsingEdit(LabelModel lableModel, string newLabelName);

        /// <summary>
        /// Remove Labels Using NotesId.
        /// </summary>
        /// <param name="noteId">The uSER iD FROM model.</param>
        /// <returns>Returns success message.</returns>
        public string RemoveLabelUsingNoteId(int noteId);

        /// <summary>
        /// Create note for lables.
        /// </summary>
        /// <param name="lableId">The Label iD FROM model.</param>
        /// <returns>Returns success message.</returns>
        public string RemoveLabelUsingLabelId(int lableId);

        /// <summary>
        /// Get Label by note Id.
        /// </summary>
        /// <param name="noteId">The Note iD FROM model.</param>
        /// <returns>Returns success message.</returns>
        public List<LabelModel> GetLabelByNoteId(int noteId);

        /// <summary>
        /// Get labels using label Id.
        /// </summary>
        /// <param name="labelId">The Label Id.</param>
        /// <returns>Returns success message.</returns>
        public List<LabelModel> GetLabelUsingLabelId(int labelId);

        /// <summary>
        /// Get Label Using UserID
        /// </summary>
        /// <param name="userId">The uSER iD FROM model.</param>
        /// <returns>Returns success message.</returns>
        public List<LabelModel> GetLabelUsingUserId(int userId);
    }
}
