using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockQueryable.FakeItEasy;
using SelfContainedSolutionTest.Plugins.CustomAPIs;
using SelfContainedSolutionTest.Plugins.EarlyBound;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Plugins.Tests
{
    [TestClass]
    public class TestsForGetSolutionComponentName : PluginTestBase
    {
        [TestMethod]
        public void TestExecute()
        {
            // Arrange
            var fakeServiceProvider = A.Fake<IServiceProvider>();
            SetupPluginFakes(fakeServiceProvider, out var fakePluginExecutionContext, out var fakeEarlyBoundContext);

            var guidString = Guid.NewGuid().ToString();
            var mockDisplayName = "Foo";

            var msdyn_solutioncomponentsummaries = new List<msdyn_solutioncomponentsummary>
            {
                new msdyn_solutioncomponentsummary
                {
                    msdyn_objectid = guidString,
                    msdyn_displayname = mockDisplayName
                }
            };

            var mock = msdyn_solutioncomponentsummaries.AsQueryable().BuildMock();
            A.CallTo(() => fakeEarlyBoundContext.msdyn_solutioncomponentsummarySet).Returns(mock);

            fakePluginExecutionContext.InputParameters["ObjectId"] = guidString;

            // Act
            var plugin = new GetSolutionComponentName(fakeEarlyBoundContext);
            plugin.Execute(fakeServiceProvider);

            //Assert
            var displayName = (string)fakePluginExecutionContext.OutputParameters["DisplayName"];
            Assert.AreEqual(mockDisplayName, displayName);
        }
    }
}