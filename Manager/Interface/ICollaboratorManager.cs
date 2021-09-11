// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICollaboratorManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Charan Kanduri"/>
// ----------------------------------------------------------------------------------------------------------
namespace Manager.Interface
{
    using Models;
    using System.Collections.Generic;
    /// <summary>
    /// Interface containing method declaration
    /// </summary>
    public interface ICollaboratorManager
    { 
      ///<summary>
      /// Adds the collaborator.
      /// </summary>
      /// <param name="model">The model.</param>
      /// <returns>Returns success message</returns>
      bool AddCollaborator(CollaboratorModel collaborator);
        /// <summary>
        /// Gets the collaborator.
        /// </summary>
        /// <param name="UserId">The notes identifier.</param>
        /// <returns>Returns list of collaborators</returns>
        List<CollaboratorModel> GetCollaborator(int userId);

        /// <summary>
        /// Removes the collaborator.
        /// </summary>
        /// <param name="UserId">The collaboration identifier.</param>
        /// <returns>Returns success message</returns>
      bool RemoveCollaborator(int collaboratorId);
    }
}
