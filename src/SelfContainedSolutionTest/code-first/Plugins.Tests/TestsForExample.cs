using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using MockQueryable.FakeItEasy;
using SelfContainedSolutionTest.Plugins.CustomAPIs;
using SelfContainedSolutionTest.Plugins.EarlyBound;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Plugins.Tests
{
    [TestClass]
    public class TestsForExample : PluginTestBase
    {
        [TestMethod]
        public void TestExecuteForHappyPath()
        {
            // Arrange
            var fakeServiceProvider = A.Fake<IServiceProvider>();
            SetupPluginFakes(fakeServiceProvider, out var fakePluginExecutionContext, out var fakeEarlyBoundContext);

            var solutionComponents = new List<SolutionComponent>
            {
                new SolutionComponent
                {
                    Id = Guid.NewGuid(),
                    ObjectId = Guid.NewGuid(),
                    ComponentType = new OptionSetValue(1),
                    SolutionId = new EntityReference(Solution.EntityLogicalName, Guid.NewGuid())
                },
                new SolutionComponent
                {
                    Id = Guid.NewGuid(),
                    ObjectId = Guid.NewGuid(),
                    ComponentType = new OptionSetValue(1),
                    SolutionId = new EntityReference(Solution.EntityLogicalName, Guid.NewGuid())
                },
                new SolutionComponent
                {
                    Id = Guid.NewGuid(),
                    ObjectId = Guid.NewGuid(),
                    ComponentType = new OptionSetValue(1),
                    SolutionId = new EntityReference(Solution.EntityLogicalName, Guid.NewGuid())
                },
                new SolutionComponent
                {
                    Id = Guid.NewGuid(),
                    ObjectId = Guid.NewGuid(),
                    ComponentType = new OptionSetValue(1),
                    SolutionId = new EntityReference(Solution.EntityLogicalName, Guid.NewGuid())
                },
                new SolutionComponent
                {
                    Id = Guid.NewGuid(),
                    ObjectId = Guid.NewGuid(),
                    ComponentType = new OptionSetValue(1),
                    SolutionId = new EntityReference(Solution.EntityLogicalName, Guid.NewGuid())
                }
            };

            var mock = solutionComponents.AsQueryable().BuildMock();
            A.CallTo(() => fakeEarlyBoundContext.SolutionComponentSet).Returns(mock);

            // Act
            var plugin = new Example(fakeEarlyBoundContext);
            plugin.Execute(fakeServiceProvider);

            //Assert
            var entityCollection = (EntityCollection)fakePluginExecutionContext.OutputParameters["Test"];
            Assert.AreEqual(5, entityCollection.Entities.Count);
        }
    }
}