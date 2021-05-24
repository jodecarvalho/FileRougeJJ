namespace FR_BaseDonnee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        AgentId = c.Long(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 30),
                        Prenom = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.AgentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Agents");
        }
    }
}
