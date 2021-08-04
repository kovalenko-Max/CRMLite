using System;

namespace CRMLite.CRMCore.Entities
{
    public class ConfirmationMessageModel
    {
        public Guid LeadID { get; set; }
        public string ConfirmMessage { get; set; }
    }
}
