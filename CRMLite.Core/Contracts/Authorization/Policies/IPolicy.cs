using System.Collections.Generic;

namespace CRMLite.Core.Contracts.Authorization.Policies
{
    public interface IPolicy
    {
        string Title { get; }
        List<string> Roles { get; }
    }
}
