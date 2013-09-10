using System;

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
        bool saveWasCalled = false;
        DateTime savedDate = DateTime.MinValue;
        var dateToSave = new DateTime(1, 2, 3, 4, 5, 6, 7);

        System.Fakes.ShimDateTime.NowGet = () => dateToSave;
        Fakes.ShimDatabase.SaveDateTime = x =>
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