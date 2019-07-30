using System.Collections.Generic;

namespace DigThemGraves
{
    public interface IActionCollection
    {
        ICollection<IAction> Actions { get; }
    }
}
