using System.Linq;
using ProfileEngine.Core.Model.ProfileAggregate;

namespace ProfileEngine.Core.Interfaces
{
    public interface IAchievementLimit
    {
        bool LimitExceeded(IQueryable<Act> recentActivity);
    }
}