using Microsoft.Xrm.Sdk;
using SelfContainedSolutionTest.Plugins.Base;
using SelfContainedSolutionTest.Plugins.EarlyBound;
using System;
using System.Linq;

namespace SelfContainedSolutionTest.Plugins.CustomAPIs
{
    public class Example : PluginBase
    {
        public Example()
                : base(typeof(Example))
        {
            // TODO: Implement your custom configuration handling.
        }

        protected override void ExecuteDataversePlugin(ILocalPluginContext localContext)
        {
            ThrowExceptionIfLocalContextIsNullAndObtainTracingService(localContext, out ITracingService tracingService);

            try
            {
                // Obtain the execution context from the service provider.
                IPluginExecutionContext pluginContext = localContext.PluginExecutionContext;

                // Obtain the organization service reference for web service calls.
                IOrganizationService currentUserService = localContext.CurrentUserService;

                IEarlyBoundContext EarlyBoundContext = _earlyBoundContext ?? new EarlyBoundContext(currentUserService);

                IQueryable<SolutionComponent> solutionComponents = EarlyBoundContext.SolutionComponentSet.Take(5);

                EntityCollection entityCollection = new EntityCollection
                {
                    EntityName = "solutioncomponent"
                };

                foreach (SolutionComponent item in solutionComponents)
                {
                    Entity entity = new Entity("solutioncomponent");
                    entity["componenttype"] = item.ComponentType;
                    entity["solutioncomponentid"] = item.SolutionComponentId;
                    entity["objectid"] = item.ObjectId;
                    entityCollection.Entities.Add(entity);
                }

                pluginContext.OutputParameters["Test"] = entityCollection;
            }
            // Only throw an InvalidPluginExecutionException. Please Refer https://go.microsoft.com/fwlink/?linkid=2153829.
            catch (Exception ex)
            {
                TraceAndThrow(tracingService, ex, this.ToString());
            }
        }
    }
}