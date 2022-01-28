namespace SelfContainedSolutionTest.Plugins.EarlyBound
{
    [System.Runtime.Serialization.DataContract()]
    [Microsoft.Xrm.Sdk.Client.EntityLogicalName("solution")]
    [System.CodeDom.Compiler.GeneratedCode("CrmSvcUtil", "9.1.0.95")]
    public partial class Solution : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {
        public Solution() :
                base(EntityLogicalName)
        {
        }

        public const string EntityLogicalName = "solution";

        public const string EntityLogicalCollectionName = "solutions";

        public const string EntitySetName = "solutions";

        public const int EntityTypeCode = 7100;

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

        [Microsoft.Xrm.Sdk.AttributeLogicalName("configurationpageid")]
        public Microsoft.Xrm.Sdk.EntityReference ConfigurationPageId
        {
            get
            {
                return GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("configurationpageid");
            }
            set
            {
                OnPropertyChanging("ConfigurationPageId");
                SetAttributeValue("configurationpageid", value);
                OnPropertyChanged("ConfigurationPageId");
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

        [Microsoft.Xrm.Sdk.AttributeLogicalName("description")]
        public string Description
        {
            get
            {
                return GetAttributeValue<string>("description");
            }
            set
            {
                OnPropertyChanging("Description");
                SetAttributeValue("description", value);
                OnPropertyChanged("Description");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("friendlyname")]
        public string FriendlyName
        {
            get
            {
                return GetAttributeValue<string>("friendlyname");
            }
            set
            {
                OnPropertyChanging("FriendlyName");
                SetAttributeValue("friendlyname", value);
                OnPropertyChanged("FriendlyName");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("installedon")]
        public System.DateTime? InstalledOn
        {
            get
            {
                return GetAttributeValue<System.DateTime?>("installedon");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("isapimanaged")]
        public bool? IsApiManaged
        {
            get
            {
                return GetAttributeValue<bool?>("isapimanaged");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("ismanaged")]
        public bool? IsManaged
        {
            get
            {
                return GetAttributeValue<bool?>("ismanaged");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("isvisible")]
        public bool? IsVisible
        {
            get
            {
                return GetAttributeValue<bool?>("isvisible");
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

        [Microsoft.Xrm.Sdk.AttributeLogicalName("organizationid")]
        public Microsoft.Xrm.Sdk.EntityReference OrganizationId
        {
            get
            {
                return GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("organizationid");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("parentsolutionid")]
        public Microsoft.Xrm.Sdk.EntityReference ParentSolutionId
        {
            get
            {
                return GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("parentsolutionid");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("pinpointassetid")]
        public string PinpointAssetId
        {
            get
            {
                return GetAttributeValue<string>("pinpointassetid");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("pinpointpublisherid")]
        public long? PinpointPublisherId
        {
            get
            {
                return GetAttributeValue<long?>("pinpointpublisherid");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("pinpointsolutiondefaultlocale")]
        public string PinpointSolutionDefaultLocale
        {
            get
            {
                return GetAttributeValue<string>("pinpointsolutiondefaultlocale");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("pinpointsolutionid")]
        public long? PinpointSolutionId
        {
            get
            {
                return GetAttributeValue<long?>("pinpointsolutionid");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("publisherid")]
        public Microsoft.Xrm.Sdk.EntityReference PublisherId
        {
            get
            {
                return GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("publisherid");
            }
            set
            {
                OnPropertyChanging("PublisherId");
                SetAttributeValue("publisherid", value);
                OnPropertyChanged("PublisherId");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("solutionid")]
        public System.Guid? SolutionId
        {
            get
            {
                return GetAttributeValue<System.Guid?>("solutionid");
            }
            set
            {
                OnPropertyChanging("SolutionId");
                SetAttributeValue("solutionid", value);
                if (value.HasValue)
                {
                    base.Id = value.Value;
                }
                else
                {
                    base.Id = System.Guid.Empty;
                }
                OnPropertyChanged("SolutionId");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("solutionid")]
        public override System.Guid Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                SolutionId = value;
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("solutionpackageversion")]
        public string SolutionPackageVersion
        {
            get
            {
                return GetAttributeValue<string>("solutionpackageversion");
            }
            set
            {
                OnPropertyChanging("SolutionPackageVersion");
                SetAttributeValue("solutionpackageversion", value);
                OnPropertyChanged("SolutionPackageVersion");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("solutiontype")]
        public Microsoft.Xrm.Sdk.OptionSetValue SolutionType
        {
            get
            {
                return GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("solutiontype");
            }
            set
            {
                OnPropertyChanging("SolutionType");
                SetAttributeValue("solutiontype", value);
                OnPropertyChanged("SolutionType");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("templatesuffix")]
        public string TemplateSuffix
        {
            get
            {
                return GetAttributeValue<string>("templatesuffix");
            }
            set
            {
                OnPropertyChanging("TemplateSuffix");
                SetAttributeValue("templatesuffix", value);
                OnPropertyChanged("TemplateSuffix");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("thumbprint")]
        public string Thumbprint
        {
            get
            {
                return GetAttributeValue<string>("thumbprint");
            }
            set
            {
                OnPropertyChanging("Thumbprint");
                SetAttributeValue("thumbprint", value);
                OnPropertyChanged("Thumbprint");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("uniquename")]
        public string UniqueName
        {
            get
            {
                return GetAttributeValue<string>("uniquename");
            }
            set
            {
                OnPropertyChanging("UniqueName");
                SetAttributeValue("uniquename", value);
                OnPropertyChanged("UniqueName");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("updatedon")]
        public System.DateTime? UpdatedOn
        {
            get
            {
                return GetAttributeValue<System.DateTime?>("updatedon");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("upgradeinfo")]
        public string UpgradeInfo
        {
            get
            {
                return GetAttributeValue<string>("upgradeinfo");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("version")]
        public string Version
        {
            get
            {
                return GetAttributeValue<string>("version");
            }
            set
            {
                OnPropertyChanging("Version");
                SetAttributeValue("version", value);
                OnPropertyChanged("Version");
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

        [Microsoft.Xrm.Sdk.RelationshipSchemaName("solution_parent_solution", Microsoft.Xrm.Sdk.EntityRole.Referenced)]
        public System.Collections.Generic.IEnumerable<Solution> Referencedsolution_parent_solution
        {
            get
            {
                return GetRelatedEntities<Solution>("solution_parent_solution", Microsoft.Xrm.Sdk.EntityRole.Referenced);
            }
            set
            {
                OnPropertyChanging("Referencedsolution_parent_solution");
                SetRelatedEntities("solution_parent_solution", Microsoft.Xrm.Sdk.EntityRole.Referenced, value);
                OnPropertyChanged("Referencedsolution_parent_solution");
            }
        }

        [Microsoft.Xrm.Sdk.AttributeLogicalName("parentsolutionid")]
        [Microsoft.Xrm.Sdk.RelationshipSchemaName("solution_parent_solution", Microsoft.Xrm.Sdk.EntityRole.Referencing)]
        public Solution Referencingsolution_parent_solution
        {
            get
            {
                return GetRelatedEntity<Solution>("solution_parent_solution", Microsoft.Xrm.Sdk.EntityRole.Referencing);
            }
        }
    }
}