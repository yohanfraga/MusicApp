namespace MusicApp.Domain.Interfaces;

public interface IUnitOfWork
{
    void Commit();
    void Rollback();
    void Begin();
}