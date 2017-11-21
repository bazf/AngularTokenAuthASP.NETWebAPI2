namespace BLL.Mapping
{
    using System.Linq;

    public interface IMapper
    {
        TDest Map<TSource, TDest>(TSource source);

        IQueryable<TDest> Map<TSource, TDest>(IQueryable<TSource> sourceQuery);

        TDest Map<TSource, TDest>(TSource source, TDest dest);
    }
}
