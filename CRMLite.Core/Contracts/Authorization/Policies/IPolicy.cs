using System;
using System.Collections.Generic;
using System.Text;

namespace CRMLite.Core.Contracts.Authorization.Policies
{
    public interface IPolicy
    {
        string Title { get; }
        List<string> Roles { get; }
    }
}
