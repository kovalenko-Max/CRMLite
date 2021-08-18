using System;
using CRMLite.Core.Contracts.Statuses;

namespace CRMLite.CRMCore.Entities
{
    public class ConfirmationMessageModel
    {
        public Guid LeadID { get; set; }
        public StatusType StatusType { get; set; }
        public string ConfirmMessage { get; set; }
    }
}
