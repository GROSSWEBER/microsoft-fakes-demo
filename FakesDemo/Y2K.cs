using System;

namespace FakesDemo
{
  public static class Y2K
  {
    public static bool CheckForY2K()
    {
      if (DateTime.Now == new DateTime(2000, 01, 01))
      {
        return true;
      }
      return false;
    }
  }
}