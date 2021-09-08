using Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    public class LabelController :ControllerBase
    {
        private readonly ILabelManager labelManager;
        public LabelController(ILabelManager lableManager)
        {
            this.labelManager = lableManager;
        }
        [HttpPost]
        [Route("api/AddLabelUsingEdit")]
        public IActionResult AddLableUsingEditLabels([FromBody] LabelModel labelModel)
        {
            try
            {
                string result = this.labelManager.AddLableUsingEditLabels(labelModel);
                if (result == "Label created")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/CreateLabelForNote")]
        public IActionResult CreateLabelForNote([FromBody] LabelModel labelModel)
        {
            try
            {
            
                string result = this.labelManager.CreateLabelForNote(labelModel);
                if (result != "Label added")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpDelete]
        [Route("api/RemoveLabelUsingEditLebels")]
        public IActionResult RemoveLabelUsingEditLebels(string labelName, int userId)
        {
            try
            {
             
                string result = this.labelManager.RemoveLabelUsingEditLebels(labelName, userId);
                if (result == "Label deleted")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("api/EditLabelUsingEdit")]
        public IActionResult EditLabelUsingEdit(int userId, string labelName, string newLabelName)
        {
            try
            {
               
                string result = this.labelManager.EditLabelUsingEdit(userId, labelName, newLabelName);
                if (result != "Couldn't update Label")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpDelete]
        [Route("api/RemoveLabel")]
        public IActionResult RemoveLabelUsingLabelId(int lableId)
        {
            try
            {
                
                string result = this.labelManager.RemoveLabelUsingLabelId(lableId);
                if (result != "Label is removed")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

    }
}
