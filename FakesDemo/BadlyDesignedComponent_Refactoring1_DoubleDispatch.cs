using System;

namespace FakesDemo
{
  public class BadlyDesignedComponent_Refactoring1_DoubleDispatch
  {
    public void Run(IDatabase database)
    {
      database.Save(DateTime.Now);
    } 
  }

  public interface IDatabase
  {
    void Save(DateTime value);
  }

  class DatabaseAdapter : IDatabase
  {
    public void Save(DateTime value)
    {
      Database.Save(value);
    }
  }
}