using SelfContainedSolutionTest.Plugins.Base;
using SelfContainedSolutionTest.Plugins.EarlyBound;
using SelfContainedSolutionTest.Plugins.TableControllers;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace SelfContainedSolutionTest.Plugins.CustomAPIs
{
    public class AddAllRequiredSolutionComponents : PluginBase
    {
        [ExcludeFromCodeCoverage]
        public AddAllRequiredSolutionComponents()
                : base(typeof(AddAllRequiredSolutionComponents))
        {
            // TODO: Implement your custom configuration handling.
        }

        public AddAllRequiredSolutionComponents(IEarlyBoundContext earlyBoundContext)
                : base(typeof(AddAllRequiredSolutionComponents), earlyBoundContext)
        {
            // TODO: Implement your custom configuration handling.
        }

        protected override void Execute(ILocalPluginContext localContext)
        {
            Execute(() =>
            {
                // Obtain the execution context from the service provider.
                var context = localContext.PluginExecutionContext;

                // Get Custom API request parameters
                var solutionId = (Guid)context.InputParameters["SolutionId"];
                var removeEnvironmentVariableCurrentValues = (bool)context.InputParameters["RemoveEnvironmentVariableCurrentValues"];

                var solutionComponents = new List<SolutionComponent>();
                var previousSolutionComponentCount = 0;
                var currentSolutionComponentCount = -1;
                var solutionUniqueName = EarlyBoundContext.SolutionSet.Where(s => s.SolutionId == solutionId).FirstOrDefault().UniqueName;

                while (currentSolutionComponentCount != previousSolutionComponentCount)
                {
                    if (currentSolutionComponentCount != -1)
                    {
                        previousSolutionComponentCount = currentSolutionComponentCount;
                    }

                    solutionComponents = SolutionComponentController.GetSolutionComponents(EarlyBoundContext, solutionId);
                    currentSolutionComponentCount = solutionComponents.Count;

                    foreach (var solutionComponent in solutionComponents)
                    {
                        EarlyBoundContext.AddSolutionComponent(solutionComponent.ObjectId, solutionComponent.ComponentType, solutionUniqueName);
                    }
                }

                var environmentVariableCurrentValues = solutionComponents.Where(sc => sc.ComponentType.Value == 381);

                if (removeEnvironmentVariableCurrentValues)
                {
                    foreach (var environmentVariablCurrentValue in environmentVariableCurrentValues)
                    {
                        EarlyBoundContext.RemoveSolutionComponent(environmentVariablCurrentValue.ObjectId, environmentVariablCurrentValue.ComponentType, solutionUniqueName);
                    }
                }
            });
        }
    }
}