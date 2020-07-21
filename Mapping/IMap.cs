namespace Infra.Mapping
{
    public interface IMap<in TIn, out TOut>
    {
        TOut Get(TIn value);
    }
}