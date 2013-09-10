using System;

using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FakesDemo.Tests
{
  [TestClass]
  public class Y2KTests
  {
    [TestMethod]
    public void Should_return_true_on_January_1st_2000()
    {
      using (ShimsContext.Create())
      {
        System.Fakes.ShimDateTime.NowGet = () => new DateTime(2000, 1, 1);

        var isY2K = Y2K.CheckForY2K();
        Assert.IsTrue(isY2K);
      }
    }
    
    [TestMethod]
    public void Should_return_false_on_any_other_date()
    {
      using (ShimsContext.Create())
      {
        System.Fakes.ShimDateTime.NowGet = () => DateTime.MinValue;

        var isY2K = Y2K.CheckForY2K();
        Assert.IsFalse(isY2K);
      }
    }
  }
}