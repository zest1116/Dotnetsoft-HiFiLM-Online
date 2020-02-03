using Dotnetsoft.HiFiLM.Graph.Extensions;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dotnetsoft.HiFiLM.Graph.Services
{
    public class AdminService : BaseService
    {
        public AdminService(GraphServiceClient client) : base(client)
        {

        }

        public async Task CreateExtensions()
        {
            var schemaExtension = new SchemaExtension
            {
                Id = "GroupExtensionProperties",
                Description = "Dotnetsoft Graph Extension Properties",
                TargetTypes = new List<String>()
                {
                    "Group"
                },
                Properties = new List<ExtensionSchemaProperty>()
                {
                    new ExtensionSchemaProperty
                    {
                        Name = "DeptId",
                        Type = "String"
                    },
                    new ExtensionSchemaProperty
                    {
                        Name = "ParentDeptId",
                        Type = "String"
                    }
                }
            };

            SchemaExtension schema = await graphClient.SchemaExtensions.Request().AddAsync(schemaExtension);
        }

        public async Task UpdateGroupExtensions()
        {
            //var updateSchemaExtension = new SchemaExtension
            //{
            //    Status = "Available"
            //};

            //var schemaExtension = graphClient.SchemaExtensions["ext9ouc00qu_GroupExtensionProperties"].Request().UpdateAsync(updateSchemaExtension);

            var groupExtension = new GroupExtension
            {
                DeptId = "deptId006",
                ParentDeptId = "parentDeptId001"
            };

            IDictionary<string, object> extensionInstance = new Dictionary<string, object>();
            extensionInstance.Add("ext9ouc00qu_GroupExtensionProperties", groupExtension);
            Group updateGroup = new Group()
            {
                AdditionalData = extensionInstance
            };

            var extension = await graphClient.Groups["42bb5eb5-d95d-4447-81e3-ce8d21429a02"].Request().UpdateAsync(updateGroup);
        }
    }
}
