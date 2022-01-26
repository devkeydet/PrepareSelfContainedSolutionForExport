
//// <copyright file="PreValidationAccountCreate.cs" company="">
//// Copyright (c) 2022 All Rights Reserved
//// </copyright>
//// <author></author>
//// <date>1/24/2022 10:38:39 AM</date>
//// <summary>Implements the PreValidationAccountCreate Plugin.</summary>
//// <auto-generated>
////     This code was generated by a tool.
////     Runtime Version:4.0.30319.1
//// </auto-generated>

//using System;
//using Microsoft.Xrm.Sdk;

//namespace SelfContainedSolutionTest.Plugins.TablePlugins
//{

//    /// <summary>
//    /// PreValidationAccountCreate Plugin.
//    /// </summary>    
//    public class PreValidationAccountCreate: PluginBase
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PreValidationAccountCreate"/> class.
//        /// </summary>
//        /// <param name="unsecure">Contains public (unsecured) configuration information.</param>
//        /// <param name="secure">Contains non-public (secured) configuration information. 
//        /// When using Microsoft Dynamics 365 for Outlook with Offline Access, 
//        /// the secure string is not passed to a plug-in that executes while the client is offline.</param>
//        public PreValidationAccountCreate(string unsecure, string secure)
//            : base(typeof(PreValidationAccountCreate))
//        {
            
//           // TODO: Implement your custom configuration handling.
//        }


//        /// <summary>
//        /// Main entry point for he business logic that the plug-in is to execute.
//        /// </summary>
//        /// <param name="localContext">The <see cref="LocalPluginContext"/> which contains the
//        /// <see cref="IPluginExecutionContext"/>,
//        /// <see cref="IOrganizationService"/>
//        /// and <see cref="ITracingService"/>
//        /// </param>
//        /// <remarks>
//        /// For improved performance, Microsoft Dynamics 365 caches plug-in instances.
//        /// The plug-in's Execute method should be written to be stateless as the constructor
//        /// is not called for every invocation of the plug-in. Also, multiple system threads
//        /// could execute the plug-in at the same time. All per invocation state information
//        /// is stored in the context. This means that you should not use global variables in plug-ins.
//        /// </remarks>
//        protected override void ExecuteDataversePlugin(ILocalPluginContext localContext)
//        {
//            if (localContext == null)
//            {
//                throw new InvalidPluginExecutionException(nameof(localContext));
//            }           
//            // Obtain the tracing service
//            ITracingService tracingService = localContext.TracingService;

//            try
//            { 
//                // Obtain the execution context from the service provider.  
//                IPluginExecutionContext context = (IPluginExecutionContext)localContext.PluginExecutionContext;

//                // Obtain the organization service reference for web service calls.  
//                IOrganizationService currentUserService = localContext.CurrentUserService;

//                // TODO: Implement your custom Plug-in business logic.

                
//            }	
//            // Only throw an InvalidPluginExecutionException. Please Refer https://go.microsoft.com/fwlink/?linkid=2153829.
//            catch (Exception ex)
//            {
//                tracingService?.Trace("An error occurred executing Plugin SelfContainedSolutionTest.Plugins.PreValidationAccountCreate : {0}", ex.ToString());
//                throw new InvalidPluginExecutionException("An error occurred executing Plugin SelfContainedSolutionTest.Plugins.PreValidationAccountCreate .", ex);
//            }	
//        }
//    }
//}
