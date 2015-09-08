using System;

using FakeItEasy;

using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FakesDemo.Tests
{
  [TestClass]
  public class BadlyDesignedComponentTests_Refactoring1_DoubleDispatch
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
        // Or use any other faking framework, see below.
        var database = new Fakes.StubIDatabase
                             {
                         SaveDateTime = x =>
                         {
                           saveWasCalled = true;
                           savedDate = x;
                         }
                       };

        var sut = new BadlyDesignedComponent_Refactoring1_DoubleDispatch();
        sut.Run(database);

        Assert.IsTrue(saveWasCalled);
        Assert.AreEqual(dateToSave, savedDate);
      }
    }

    [TestMethod]
    public void Should_save_current_date_to_database_with_FakeItEasy()
    {
      using (ShimsContext.Create())
      {
        var dateToSave = new DateTime(1, 2, 3, 4, 5, 6, 7);

        System.Fakes.ShimDateTime.NowGet = () => dateToSave;
        // Or use any other faking framework, see above.
        var database = A.Fake<IDatabase>();

        var sut = new BadlyDesignedComponent_Refactoring1_DoubleDispatch();
        sut.Run(database);

        A
          .CallTo(() => database.Save(dateToSave))
          .MustHaveHappened();
      }
    }
  }
}