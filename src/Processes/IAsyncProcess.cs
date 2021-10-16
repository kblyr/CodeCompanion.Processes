namespace CodeCompanion.Processes
{
    public interface IAsyncProcess<TModel, TResult>
    {
        Task<TResult> ExecuteAsync(IProcessContext processContext, TModel model, CancellationToken cancellationToken = default);
    }
}