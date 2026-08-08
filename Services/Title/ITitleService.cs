using Common;
using Models;

namespace Services.Title;

public interface ITitleService
{
    public Task<Result<TitleModel>> SaveTitleAsync(SaveTitleModel inputModel);

    public Task<Result<TitleModel>> GetTitleByProjectIdAsync(Guid projectId);
}