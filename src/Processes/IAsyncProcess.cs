namespace CodeCompanion.Processes
{
    public interface IAsyncProcess<TModel, TResult>
    {
        Task<TResult> ExecuteAsync(TModel model, CancellationToken cancellationToken = default);
    }
}