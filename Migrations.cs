using System;
using Orchard.ContentManagement.MetaData;
using Orchard.Data.Migration;

namespace CodeSanook.Comment
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable("CommentPartRecord", config =>
            config.ContentPartRecord()
            .Column<string>("CommentBody")
            .Column<DateTime>("CreatedUtcDate")
            .Column<DateTime>("LastUpdatedUtcDate"));

            ContentDefinitionManager.AlterTypeDefinition("BlogPost", cfg =>
                cfg.WithPart("CommentContainerPart")
            );



            return 1;
        }


        public int UpdateFrom1()
        {
            //create Comment type
            ContentDefinitionManager.AlterTypeDefinition("Comment",
                cfg => cfg
                .WithPart("CommentPart")
                .WithPart("CommonPart")
                .RemovePart("IdentityPart")
                );
            return 2;
        }
    }

}