namespace BlogWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        Titre = c.String(),
                        content = c.String(),
                        date_de_parution = c.DateTime(nullable: false),
                        Writer_Key = c.Int(),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("dbo.Users", t => t.Writer_Key)
                .Index(t => t.Writer_Key);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        Pseudo = c.String(),
                        password = c.String(),
                        droit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Key);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "Writer_Key", "dbo.Users");
            DropIndex("dbo.Articles", new[] { "Writer_Key" });
            DropTable("dbo.Users");
            DropTable("dbo.Articles");
        }
    }
}
