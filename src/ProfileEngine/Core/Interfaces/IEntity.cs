using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfileEngine.Core.Model;

namespace ProfileEngine.Core.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
