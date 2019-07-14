using System.Collections.Generic;

namespace DigThemGraves
{
    public interface IActionCollection<T>
    {
        ICollection<IAction<T>> Actions { get; }
    }
}
