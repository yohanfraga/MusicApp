namespace MusicApp.Infra.ORM.UnitOfWork.Interfaces;

public interface IUnitOfWork
{
    void Commit();
    void Rollback();
    void Begin();
}