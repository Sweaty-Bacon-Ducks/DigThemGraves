using System.Collections.Generic;

namespace DigThemGraves
{
    public interface IPlayerActions : IEnumerable<IPlayerAction>
    {
        ICollection<IPlayerAction> Actions { get; }
    }
}