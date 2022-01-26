namespace SelfContainedSolutionTest.Plugins.Models
{
    [System.Runtime.Serialization.DataContractAttribute()]
	[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("solutioncomponent")]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.1.0.95")]
	public partial class SolutionComponent : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{

		public SolutionComponent() :
				base(EntityLogicalName)
		{
		}

		public const string EntityLogicalName = "solutioncomponent";

		public const string EntityLogicalCollectionName = "solutioncomponentss";

		public const string EntitySetName = "solutioncomponents";

		public const int EntityTypeCode = 7103;

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

		private void OnPropertyChanged(string propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		private void OnPropertyChanging(string propertyName)
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
			}
		}

		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("componenttype")]
		public Microsoft.Xrm.Sdk.OptionSetValue ComponentType
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("componenttype");
			}
			set
			{
				this.SetAttributeValue("componenttype", value);
			}
		}

		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
		public Microsoft.Xrm.Sdk.EntityReference CreatedBy
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
			}
		}

		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
		public System.Nullable<System.DateTime> CreatedOn
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
			}
		}

		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
		public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
			}
		}

		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ismetadata")]
		public System.Nullable<bool> IsMetadata
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("ismetadata");
			}
		}

		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
		public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
			}
		}

		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
		public System.Nullable<System.DateTime> ModifiedOn
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
			}
		}

		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
		public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
			}
		}

		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("objectid")]
		public System.Nullable<System.Guid> ObjectId
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("objectid");
			}
			set
			{
				this.SetAttributeValue("objectid", value);
			}
		}

		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("rootcomponentbehavior")]
		public Microsoft.Xrm.Sdk.OptionSetValue RootComponentBehavior
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("rootcomponentbehavior");
			}
		}

		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("rootsolutioncomponentid")]
		public System.Nullable<System.Guid> RootSolutionComponentId
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("rootsolutioncomponentid");
			}
		}

		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("solutioncomponentid")]
		public System.Nullable<System.Guid> SolutionComponentId
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("solutioncomponentid");
			}
			set
			{
				this.SetAttributeValue("solutioncomponentid", value);
			}
		}

		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("solutioncomponentid")]
		public override System.Guid Id
		{
			get
			{
				return base.Id;
			}
			set
			{
				base.Id = value;
			}
		}

		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("solutionid")]
		public Microsoft.Xrm.Sdk.EntityReference SolutionId
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("solutionid");
			}
			set
			{
				this.SetAttributeValue("solutionid", value);
			}
		}

		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
		public System.Nullable<long> VersionNumber
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
			}
		}

		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("solutioncomponent_parent_solutioncomponent", Microsoft.Xrm.Sdk.EntityRole.Referenced)]
		public System.Collections.Generic.IEnumerable<SolutionComponent> Referencedsolutioncomponent_parent_solutioncomponent
		{
			get
			{
				return this.GetRelatedEntities<SolutionComponent>("solutioncomponent_parent_solutioncomponent", Microsoft.Xrm.Sdk.EntityRole.Referenced);
			}
			set
			{
				this.OnPropertyChanging("Referencedsolutioncomponent_parent_solutioncomponent");
				this.SetRelatedEntities<SolutionComponent>("solutioncomponent_parent_solutioncomponent", Microsoft.Xrm.Sdk.EntityRole.Referenced, value);
				this.OnPropertyChanged("Referencedsolutioncomponent_parent_solutioncomponent");
			}
		}

		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("rootsolutioncomponentid")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("solutioncomponent_parent_solutioncomponent", Microsoft.Xrm.Sdk.EntityRole.Referencing)]
		public SolutionComponent Referencingsolutioncomponent_parent_solutioncomponent
		{
			get
			{
				return this.GetRelatedEntity<SolutionComponent>("solutioncomponent_parent_solutioncomponent", Microsoft.Xrm.Sdk.EntityRole.Referencing);
			}
		}
	}
}
