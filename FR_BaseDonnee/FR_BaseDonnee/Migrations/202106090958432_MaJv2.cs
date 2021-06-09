namespace FR_BaseDonnee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaJv2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quizzs", "Niveau", c => c.String());
            AlterColumn("dbo.Questions", "Libre", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "Libre", c => c.Int(nullable: false));
            DropColumn("dbo.Quizzs", "Niveau");
        }
    }
}
