using System;
using System.Fakes;

using FakesDemo.Fakes;

using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FakesDemo.Tests
{
  [TestClass]
  public class BadlyDesignedComponentTests
  {
    [TestMethod]
    public void Should_save_current_date_to_database()
    {
      using (ShimsContext.Create())
      {
        var saveWasCalled = false;
        var savedDate = DateTime.MinValue;
        var dateToSave = new DateTime(1, 2, 3, 4, 5, 6, 7);

        ShimDateTime.NowGet = () => dateToSave;
        ShimDatabase.SaveDateTime = x =>
        {
          saveWasCalled = true;
          savedDate = x;
        };

        var sut = new BadlyDesignedComponent();
        sut.Run();

        Assert.IsTrue(saveWasCalled);
        Assert.AreEqual(dateToSave, savedDate);
      }
    }
  }
}
