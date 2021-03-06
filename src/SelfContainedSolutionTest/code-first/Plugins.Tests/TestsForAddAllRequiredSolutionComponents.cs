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
    public class TestsForAddAllRequiredSolutionComponents : PluginTestBase
    {
        [TestMethod]
        public void TestExecute()
        {
            // Arrange
            var fakeServiceProvider = A.Fake<IServiceProvider>();
            SetupPluginFakes(fakeServiceProvider, out var fakePluginExecutionContext, out var fakeEarlyBoundContext);

            var solutions = new List<Solution>
            {
                new Solution
                {
                    Id = Guid.NewGuid(),
                    UniqueName = "foo"
                }
            };

            var solutionSetMock = solutions.AsQueryable().BuildMock();
            A.CallTo(
                () => fakeEarlyBoundContext.SolutionSet
            ).Returns(solutionSetMock);

            var solutionComponents = new List<SolutionComponent>
            {
                new SolutionComponent
                {
                    Id = Guid.NewGuid(),
                    ObjectId = Guid.NewGuid(),
                    ComponentType = new OptionSetValue(1),
                    SolutionId = new EntityReference("solution", solutions[0].Id)
                },
                new SolutionComponent
                {
                    Id = Guid.NewGuid(),
                    ObjectId = Guid.NewGuid(),
                    ComponentType = new OptionSetValue(1),
                    SolutionId = new EntityReference("solution", solutions[0].Id)
                },
                new SolutionComponent
                {
                    Id = Guid.NewGuid(),
                    ObjectId = Guid.NewGuid(),
                    ComponentType = new OptionSetValue(1),
                    SolutionId = new EntityReference("solution", solutions[0].Id)
                },
                new SolutionComponent
                {
                    Id = Guid.NewGuid(),
                    ObjectId = Guid.NewGuid(),
                    ComponentType = new OptionSetValue(1),
                    SolutionId = new EntityReference("solution", solutions[0].Id)
                },
                new SolutionComponent
                {
                    Id = Guid.NewGuid(),
                    ObjectId = Guid.NewGuid(),
                    ComponentType = new OptionSetValue(381),
                    SolutionId = new EntityReference("solution", solutions[0].Id)
                }
            };

            var solutionComponentsSetMock = solutionComponents.AsQueryable().BuildMock();
            A.CallTo(
                () => fakeEarlyBoundContext.SolutionComponentSet
            ).Returns(solutionComponentsSetMock);

            fakePluginExecutionContext.InputParameters["SolutionId"] = solutions[0].Id;
            fakePluginExecutionContext.InputParameters["RemoveEnvironmentVariableCurrentValues"] = true;

            // Act
            var plugin = new AddAllRequiredSolutionComponents(fakeEarlyBoundContext);
            plugin.Execute(fakeServiceProvider);

            //Assert
            A.CallTo(
                () => fakeEarlyBoundContext.AddSolutionComponent(A<Guid>.Ignored, A<OptionSetValue>.Ignored, A<string>.Ignored)
            ).MustHaveHappened(10, Times.Exactly);
        }
    }
}