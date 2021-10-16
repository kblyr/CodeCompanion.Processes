namespace CodeCompanion.Processes
{
    public interface IProcess<TModel, TResult>
    {
        TResult ExecuteAsync(TModel model);
    }
}