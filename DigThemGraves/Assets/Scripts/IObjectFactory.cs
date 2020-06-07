namespace DigThemGraves
{
    /// <summary>
    /// Generic interface for factories that read data from one object and write it to another.
    /// </summary>
    /// <typeparam name="S">Type from which data is read.</typeparam>
    /// <typeparam name="D">Type to which data is written.</typeparam>
    public interface IObjectFactory<D>
    {
        D Create();
    }
}
