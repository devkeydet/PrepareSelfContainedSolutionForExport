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
    public class TestsForRemoveComponentsFromUnmanagedSolutions : PluginTestBase
    {
        [TestMethod]
        public void TestExecute()
        {
            // Arrange
            IServiceProvider fakeServiceProvider = A.Fake<IServiceProvider>();
            SetupPluginFakes(fakeServiceProvider, out IPluginExecutionContext fakePluginExecutionContext, out IEarlyBoundContext fakeEarlyBoundContext);

            List<SolutionComponent> solutionComponents = new List<SolutionComponent>
            {
                new SolutionComponent
                {
                    Id = Guid.NewGuid(),
                    ObjectId = Guid.NewGuid(),
                    ComponentType = new OptionSetValue(1),
                },
                new SolutionComponent
                {
                    Id = Guid.NewGuid(),
                    ObjectId = Guid.NewGuid(),
                    ComponentType = new OptionSetValue(1),
                },
                new SolutionComponent
                {
                    Id = Guid.NewGuid(),
                    ObjectId = Guid.NewGuid(),
                    ComponentType = new OptionSetValue(1),
                },
                new SolutionComponent
                {
                    Id = Guid.NewGuid(),
                    ObjectId = Guid.NewGuid(),
                    ComponentType = new OptionSetValue(1),
                },
                new SolutionComponent
                {
                    Id = Guid.NewGuid(),
                    ObjectId = Guid.NewGuid(),
                    ComponentType = new OptionSetValue(1),
                }
            };

            IQueryable<SolutionComponent> mock = solutionComponents.AsQueryable().BuildMock();
            A.CallTo(
                () => fakeEarlyBoundContext.SolutionComponentSet
            ).Returns(mock);

            // Act
            RemoveComponentsFromUnmanagedSolutions plugin = new RemoveComponentsFromUnmanagedSolutions();
            plugin.ExecuteForTesting(fakeServiceProvider, fakeEarlyBoundContext);

            //Assert
            EntityCollection entityCollection = (EntityCollection)fakePluginExecutionContext.OutputParameters["Test"];
            Assert.AreEqual(5, entityCollection.Entities.Count);
        }
    }
}