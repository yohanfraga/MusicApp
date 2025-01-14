using Microsoft.EntityFrameworkCore.Infrastructure;
using MusicApp.Domain.Interfaces;
using MusicApp.Infra.Context;

namespace MusicApp.Infra.ORM.UnitOfWork;

public sealed class UnitOfWork(
    ApplicationContext applicationContext) 
    : IUnitOfWork
{
    private readonly DatabaseFacade _databaseFacade = applicationContext.Database;

    public void Commit()
    {
        try
        {
            _databaseFacade.CommitTransaction();
        }
        catch
        {
            Rollback();
            throw;
        }
    }

    public void Rollback() => _databaseFacade.RollbackTransaction();

    public void Begin() => _databaseFacade.BeginTransaction();
}