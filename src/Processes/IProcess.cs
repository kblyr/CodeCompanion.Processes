namespace CodeCompanion.Processes
{
    public interface IProcess<TModel, TResult>
    {
        TResult ExecuteAsync(IProcessContext processContext, TModel model);
    }
}