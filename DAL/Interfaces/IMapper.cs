namespace BLL.Interfaces
{
    using System.Linq;

    public interface IMapper
    {
        TDest Map<TSource, TDest>(TSource source);

        IQueryable<TDest> Map<TSource, TDest>(IQueryable<TSource> sourceQuery);

        void Map<T1, T2>(T1 source, T2 dest);
    }
}
