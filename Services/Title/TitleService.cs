using Common;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services.Title;

public class TitleService : ITitleService
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public TitleService(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public Task<Result<TitleModel>> SaveTitleAsync(SaveTitleModel inputModel)
    {
        throw new NotImplementedException();
    }

    public Task<Result<TitleModel>> GetTitleByProjectIdAsync(Guid projectId)
    {
        throw new NotImplementedException();
    }
}