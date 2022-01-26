using Microsoft.Xrm.Sdk;
using SelfContainedSolutionTest.Plugins.TableControllers;
using SelfContainedSolutionTest.Plugins.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SelfContainedSolutionTest.Plugins.CustomAPIs
{

    public class FindDuplicatesInUnmanagedSolutions : PluginBase
    {
        public FindDuplicatesInUnmanagedSolutions()
                : base(typeof(FindDuplicatesInUnmanagedSolutions))
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

                var ctx = new DataverseContext(currentUserService);

                var defaultSolutionId = new Guid("fd140aaf-4df4-11dd-bd17-0019b9312238");
                var cdsDefaultSolutionId = new Guid("00000001-0000-0000-0001-00000000009b");
                var activeSolutionId = new Guid("fd140aae-4df4-11dd-bd17-0019b9312238");
                List<SolutionComponent> solutionComponents;
                solutionComponents = SolutionComponentController.GetSolutionComponents(ctx, solutionId);
                var entityCollection = new EntityCollection();

                foreach (var solutionComponent in solutionComponents)
                {
                    var solutionComponentsInOtherSolutionsQuery =
                        from sc in ctx.SolutionComponentSet
                        where
                            sc.ObjectId == solutionComponent.ObjectId &&
                            sc.SolutionId.Id != solutionId &&
                            sc.SolutionId.Id != defaultSolutionId &&
                            sc.SolutionId.Id != cdsDefaultSolutionId &&
                            sc.SolutionId.Id != activeSolutionId
                        select new SolutionComponent
                        {
                            Id = sc.Id,
                            ObjectId = sc.ObjectId,
                            SolutionId = sc.SolutionId,
                            ComponentType = sc.ComponentType
                        };

                    var solutions = solutionComponentsInOtherSolutionsQuery.ToList<Entity>();
                    foreach (var solution in solutions)
                    {
                        entityCollection.Entities.Add(solution.ToEntity<Entity>());
                    }

                    //foreach (var item in solutionComponentsInOtherSolutionsQuery.ToList())
                    //{
                    //    var entity = new Entity("someentity");
                    //    entity["objectid"] = item.ObjectId;
                    //    entity["solutioncomponentid"] = item.SolutionComponentId;
                    //    entity["solutionid"] = item.SolutionId;
                    //    entity["componenttype"] = item.ComponentType;
                    //    entityCollection.Entities.Add(entity);

                    //}
                }

                //var entityCollection = new EntityCollection();
                //var solutions = solutionComponentsInOtherSolutionsQuery.ToList<Entity>();
                //foreach (var solution in solutions)
                //{
                //    entityCollection.Entities.Add(solution.ToEntity<Entity>());
                //}

                context.OutputParameters["Solutions"] = entityCollection;
                //context.OutputParameters["Solutions"] = new EntityCollection(solutionsQuery.ToList<Entity>()); //failing
            }
            // Only throw an InvalidPluginExecutionException. Please Refer https://go.microsoft.com/fwlink/?linkid=2153829.
            catch (Exception ex)
            {
                tracingService?.Trace("An error occurred executing Plugin SelfContainedSolutionTest.Plugins.FindDuplicatesInUnmanagedSolution : {0}", ex.ToString());
                throw new InvalidPluginExecutionException("An error occurred executing Plugin SelfContainedSolutionTest.Plugins.FindDuplicatesInUnmanagedSolution .", ex);
            }
        }
    }
}