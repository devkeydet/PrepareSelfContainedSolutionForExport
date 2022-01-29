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
            var fakeServiceProvider = A.Fake<IServiceProvider>();
            SetupPluginFakes(fakeServiceProvider, out var fakePluginExecutionContext, out var fakeEarlyBoundContext);
            var solutionIdA = Guid.NewGuid();
            var solutionIdB = Guid.NewGuid();

            var solutionComponents = new List<Entity>
            {
                new SolutionComponent
                {
                    Id = Guid.NewGuid(),
                    ObjectId = Guid.NewGuid(),
                    ComponentType = new OptionSetValue(1),
                    SolutionId = new EntityReference(Solution.EntityLogicalName, solutionIdA)
                },
                new SolutionComponent
                {
                    Id = Guid.NewGuid(),
                    ObjectId = Guid.NewGuid(),
                    ComponentType = new OptionSetValue(1),
                    SolutionId = new EntityReference(Solution.EntityLogicalName, solutionIdB)
                },
                new SolutionComponent
                {
                    Id = Guid.NewGuid(),
                    ObjectId = Guid.NewGuid(),
                    ComponentType = new OptionSetValue(1),
                    SolutionId = new EntityReference(Solution.EntityLogicalName, solutionIdA)
                },
                new SolutionComponent
                {
                    Id = Guid.NewGuid(),
                    ObjectId = Guid.NewGuid(),
                    ComponentType = new OptionSetValue(1),
                    SolutionId = new EntityReference(Solution.EntityLogicalName, solutionIdB)
                },
                new SolutionComponent
                {
                    Id = Guid.NewGuid(),
                    ObjectId = Guid.NewGuid(),
                    ComponentType = new OptionSetValue(1),
                    SolutionId = new EntityReference(Solution.EntityLogicalName, solutionIdA)
                }
            };

            var solutions = new List<Solution>
            {
                new Solution { Id = solutionIdA, UniqueName = "A" },
                new Solution { Id = solutionIdB, UniqueName = "B" }
            };

            var mock = solutions.AsQueryable().BuildMock();
            A.CallTo(() => fakeEarlyBoundContext.SolutionSet).Returns(mock);

            fakePluginExecutionContext.InputParameters["SolutionComponents"] = new EntityCollection(solutionComponents);

            // Act
            var plugin = new RemoveComponentsFromUnmanagedSolutions(fakeEarlyBoundContext);
            plugin.Execute(fakeServiceProvider);

            //Assert
            A.CallTo(
                () => fakeEarlyBoundContext.RemoveSolutionComponent(A<Guid>.Ignored, A<OptionSetValue>.Ignored, A<string>.Ignored)
            ).MustHaveHappened(5, Times.Exactly);
        }
    }
}