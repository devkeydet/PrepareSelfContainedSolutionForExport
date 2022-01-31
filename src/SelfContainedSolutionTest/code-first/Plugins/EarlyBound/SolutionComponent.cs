namespace SelfContainedSolutionTest.Plugins.EarlyBound
{
    [System.Runtime.Serialization.DataContract()]
    [Microsoft.Xrm.Sdk.Client.EntityLogicalName("solutioncomponent")]
    [System.CodeDom.Compiler.GeneratedCode("CrmSvcUtil", "9.1.0.95")]
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
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        private void OnPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("componenttype")]
        public Microsoft.Xrm.Sdk.OptionSetValue ComponentType
        {
            get
            {
                return GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("componenttype");
            }
            set
            {
                SetAttributeValue("componenttype", value);
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("createdby")]
        public Microsoft.Xrm.Sdk.EntityReference CreatedBy
        {
            get
            {
                return GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("createdon")]
        public System.DateTime? CreatedOn
        {
            get
            {
                return GetAttributeValue<System.DateTime?>("createdon");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("createdonbehalfby")]
        public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
        {
            get
            {
                return GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("ismetadata")]
        public bool? IsMetadata
        {
            get
            {
                return GetAttributeValue<bool?>("ismetadata");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("modifiedby")]
        public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
        {
            get
            {
                return GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("modifiedon")]
        public System.DateTime? ModifiedOn
        {
            get
            {
                return GetAttributeValue<System.DateTime?>("modifiedon");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("modifiedonbehalfby")]
        public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
        {
            get
            {
                return GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("objectid")]
        public System.Guid? ObjectId
        {
            get
            {
                return GetAttributeValue<System.Guid?>("objectid");
            }
            set
            {
                SetAttributeValue("objectid", value);
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("rootcomponentbehavior")]
        public Microsoft.Xrm.Sdk.OptionSetValue RootComponentBehavior
        {
            get
            {
                return GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("rootcomponentbehavior");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("rootsolutioncomponentid")]
        public System.Guid? RootSolutionComponentId
        {
            get
            {
                return GetAttributeValue<System.Guid?>("rootsolutioncomponentid");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("solutioncomponentid")]
        public System.Guid? SolutionComponentId
        {
            get
            {
                return GetAttributeValue<System.Guid?>("solutioncomponentid");
            }
            set
            {
                SetAttributeValue("solutioncomponentid", value);
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("solutioncomponentid")]
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

        [Microsoft.Xrm.Sdk.AttributeLogicalName("solutionid")]
        public Microsoft.Xrm.Sdk.EntityReference SolutionId
        {
            get
            {
                return GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("solutionid");
            }
            set
            {
                SetAttributeValue("solutionid", value);
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("versionnumber")]
        public long? VersionNumber
        {
            get
            {
                return GetAttributeValue<long?>("versionnumber");
            }
        }

        [Microsoft.Xrm.Sdk.RelationshipSchemaName("solutioncomponent_parent_solutioncomponent", Microsoft.Xrm.Sdk.EntityRole.Referenced)]
        public System.Collections.Generic.IEnumerable<SolutionComponent> Referencedsolutioncomponent_parent_solutioncomponent
        {
            get
            {
                return GetRelatedEntities<SolutionComponent>("solutioncomponent_parent_solutioncomponent", Microsoft.Xrm.Sdk.EntityRole.Referenced);
            }
            set
            {
                OnPropertyChanging("Referencedsolutioncomponent_parent_solutioncomponent");
                SetRelatedEntities("solutioncomponent_parent_solutioncomponent", Microsoft.Xrm.Sdk.EntityRole.Referenced, value);
                OnPropertyChanged("Referencedsolutioncomponent_parent_solutioncomponent");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("rootsolutioncomponentid")]
        [Microsoft.Xrm.Sdk.RelationshipSchemaName("solutioncomponent_parent_solutioncomponent", Microsoft.Xrm.Sdk.EntityRole.Referencing)]
        public SolutionComponent Referencingsolutioncomponent_parent_solutioncomponent
        {
            get
            {
                return GetRelatedEntity<SolutionComponent>("solutioncomponent_parent_solutioncomponent", Microsoft.Xrm.Sdk.EntityRole.Referencing);
            }
        }
    }
}