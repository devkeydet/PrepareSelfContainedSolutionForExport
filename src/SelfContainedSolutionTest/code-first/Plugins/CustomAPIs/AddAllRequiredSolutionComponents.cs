using Microsoft.Xrm.Sdk;
using SelfContainedSolutionTest.Plugins.Models;
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
            if (localContext == null)
            {
                throw new InvalidPluginExecutionException(nameof(localContext));
            }
            // Obtain the tracing service
            ITracingService tracingService = localContext.TracingService;

            try
            {
                // Obtain the execution context from the service provider.  
                IPluginExecutionContext context = (IPluginExecutionContext)localContext.PluginExecutionContext;

                // Obtain the organization service reference for web service calls.  
                IOrganizationService currentUserService = localContext.CurrentUserService;

                // Get Custom API request parameters
                var solutionId = (Guid)context.InputParameters["SolutionId"];
                var removeEnvironmentVariableCurrentValues = (bool)context.InputParameters["RemoveEnvironmentVariableCurrentValues"];

                var ctx = new DataverseContext(currentUserService);



                List<SolutionComponent> solutionComponents = new List<SolutionComponent>();
                var previousSolutionComponentCount = 0;
                var currentSolutionComponentCount = -1;
                var solutionUniqueName = ctx.SolutionSet.Where(s => s.SolutionId == solutionId).FirstOrDefault().UniqueName;

                while (currentSolutionComponentCount != previousSolutionComponentCount)
                {
                    if (currentSolutionComponentCount != -1)
                    {
                        previousSolutionComponentCount = currentSolutionComponentCount;
                    }

                    solutionComponents = SolutionComponentController.GetSolutionComponents(ctx, solutionId);
                    currentSolutionComponentCount = solutionComponents.Count;

                    foreach (var solutionComponent in solutionComponents)
                    {
                        ctx.AddSolutionComponent(solutionComponent.ObjectId, solutionComponent.ComponentType, solutionUniqueName);
                    }
                }

                var environmentVariableCurrentValues = solutionComponents.Where(sc => sc.ComponentType.Value == 381);

                if (removeEnvironmentVariableCurrentValues)
                {
                    foreach (var environmentVariablCurrentValue in environmentVariableCurrentValues)
                    {
                        ctx.RemoveSolutionComponent(environmentVariablCurrentValue.ObjectId, environmentVariablCurrentValue.ComponentType, solutionUniqueName);
                    }
                }
            }
            // Only throw an InvalidPluginExecutionException. Please Refer https://go.microsoft.com/fwlink/?linkid=2153829.
            catch (Exception ex)
            {
                tracingService?.Trace("An error occurred executing Plugin SelfContainedSolutionTest.Plugins.AddAllRequiredSolutionComponents : {0}", ex.ToString());
                throw new InvalidPluginExecutionException("An error occurred executing Plugin SelfContainedSolutionTest.Plugins.AddAllRequiredSolutionComponents .", ex);
            }
        }        
    }
}