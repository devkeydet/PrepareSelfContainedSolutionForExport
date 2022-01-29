using FakeItEasy;
using Microsoft.Xrm.Sdk;
using SelfContainedSolutionTest.Plugins.EarlyBound;
using System;

namespace Plugins.Tests
{
    public class PluginTestBase
    {
        internal void SetupPluginFakes(IServiceProvider fakeServiceProvider, out IPluginExecutionContext fakePluginExecutionContext, out IEarlyBoundContext fakeEarlyBoundContext)
        {
            fakePluginExecutionContext = A.Fake<IPluginExecutionContext>();
            var fakeExecutionContext = A.Fake<IExecutionContext>();
            var fakeTracingService = A.Fake<ITracingService>();
            var fakeServiceEndpointNotificationService = A.Fake<IServiceEndpointNotificationService>();
            var fakeOrganizationServiceFactory = A.Fake<IOrganizationServiceFactory>();
            fakeEarlyBoundContext = A.Fake<IEarlyBoundContext>();

            A.CallTo(
                () => fakeServiceProvider.GetService(typeof(IPluginExecutionContext))
            ).Returns(fakePluginExecutionContext);

            A.CallTo(
                () => fakeServiceProvider.GetService(typeof(IExecutionContext))
            ).Returns(fakeExecutionContext);

            A.CallTo(
                () => fakeServiceProvider.GetService(typeof(ITracingService))
            ).Returns(fakeTracingService);

            A.CallTo(
                () => fakeServiceProvider.GetService(typeof(IServiceEndpointNotificationService))
            ).Returns(fakeServiceEndpointNotificationService);

            A.CallTo(
                () => fakeServiceProvider.GetService(typeof(IOrganizationServiceFactory))
            ).Returns(fakeOrganizationServiceFactory);
        }
    }
}