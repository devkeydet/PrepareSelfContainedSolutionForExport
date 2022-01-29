using SelfContainedSolutionTest.Plugins.EarlyBound;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SelfContainedSolutionTest.Plugins.TableControllers
{
    internal static class SolutionComponentController
    {
        internal static List<SolutionComponent> GetSolutionComponents(IEarlyBoundContext ctx, Guid solutionId)
        {
            var query =
                from sc in ctx.SolutionComponentSet
                where sc.SolutionId.Id == solutionId
                select new SolutionComponent
                {
                    ComponentType = sc.ComponentType,
                    ObjectId = sc.ObjectId,
                    Id = sc.Id,
                    SolutionId = sc.SolutionId
                };

            return query.ToList();
        }
    }
}