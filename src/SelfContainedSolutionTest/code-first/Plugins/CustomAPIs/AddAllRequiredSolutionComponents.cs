using Microsoft.Xrm.Sdk;
using SelfContainedSolutionTest.Plugins.Base;
using SelfContainedSolutionTest.Plugins.EarlyBound;
using SelfContainedSolutionTest.Plugins.TableControllers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SelfContainedSolutionTest.Plugins.CustomAPIs
{
    public class AddAllRequiredSolutionComponents : PluginBase
    {
        public AddAllRequiredSolutionComponents()
                : base(typeof(AddAllRequiredSolutionComponents))
        {
            // TODO: Implement your custom configuration handling.
        }

        protected override void ExecuteDataversePlugin(ILocalPluginContext localContext)
        {
            ThrowExceptionIfLocalContextIsNullAndObtainTracingService(localContext, out ITracingService tracingService);

            try
            {
                // Obtain the execution context from the service provider.
                IPluginExecutionContext context = localContext.PluginExecutionContext;

                // Obtain the organization service reference for web service calls.
                IOrganizationService currentUserService = localContext.CurrentUserService;

                // Get Custom API request parameters
                Guid solutionId = (Guid)context.InputParameters["SolutionId"];
                bool removeEnvironmentVariableCurrentValues = (bool)context.InputParameters["RemoveEnvironmentVariableCurrentValues"];

                IEarlyBoundContext earlyBoundContext = _earlyBoundContext ?? new EarlyBoundContext(currentUserService);

                List<SolutionComponent> solutionComponents = new List<SolutionComponent>();
                int previousSolutionComponentCount = 0;
                int currentSolutionComponentCount = -1;
                string solutionUniqueName = earlyBoundContext.SolutionSet.Where(s => s.SolutionId == solutionId).FirstOrDefault().UniqueName;

                while (currentSolutionComponentCount != previousSolutionComponentCount)
                {
                    if (currentSolutionComponentCount != -1)
                    {
                        previousSolutionComponentCount = currentSolutionComponentCount;
                    }

                    solutionComponents = SolutionComponentController.GetSolutionComponents(earlyBoundContext, solutionId);
                    currentSolutionComponentCount = solutionComponents.Count;

                    foreach (SolutionComponent solutionComponent in solutionComponents)
                    {
                        earlyBoundContext.AddSolutionComponent(solutionComponent.ObjectId, solutionComponent.ComponentType, solutionUniqueName);
                    }
                }

                IEnumerable<SolutionComponent> environmentVariableCurrentValues = solutionComponents.Where(sc => sc.ComponentType.Value == 381);

                if (removeEnvironmentVariableCurrentValues)
                {
                    foreach (SolutionComponent environmentVariablCurrentValue in environmentVariableCurrentValues)
                    {
                        earlyBoundContext.RemoveSolutionComponent(environmentVariablCurrentValue.ObjectId, environmentVariablCurrentValue.ComponentType, solutionUniqueName);
                    }
                }
            }
            // Only throw an InvalidPluginExecutionException. Please Refer https://go.microsoft.com/fwlink/?linkid=2153829.
            catch (Exception ex)
            {
                TraceAndThrow(tracingService, ex, this.ToString());
            }
        }
    }
}