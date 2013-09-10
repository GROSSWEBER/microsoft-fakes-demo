using System;

namespace FakesDemo
{
  public class BadlyDesignedComponent
  {
    public void Run()
    {
      Database.Save(DateTime.Now);
    } 
  }

  public static class Database
  {
    public static void Save(DateTime value)
    {
    }
  }
}