namespace EJ02.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Martin092 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("TDP.Telefono", "Persona", "TDP.Persona");
            DropPrimaryKey("TDP.Persona");
            DropPrimaryKey("TDP.Telefono");
            AlterColumn("TDP.Persona", "PersonaId", c => c.Int(nullable: false));
            AlterColumn("TDP.Telefono", "TelefonoId", c => c.Int(nullable: false));
            AddPrimaryKey("TDP.Persona", "PersonaId");
            AddPrimaryKey("TDP.Telefono", "TelefonoId");
            AddForeignKey("TDP.Telefono", "Persona", "TDP.Persona", "PersonaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("TDP.Telefono", "Persona", "TDP.Persona");
            DropPrimaryKey("TDP.Telefono");
            DropPrimaryKey("TDP.Persona");
            AlterColumn("TDP.Telefono", "TelefonoId", c => c.Int(nullable: false, identity: true));
            AlterColumn("TDP.Persona", "PersonaId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("TDP.Telefono", "TelefonoId");
            AddPrimaryKey("TDP.Persona", "PersonaId");
            AddForeignKey("TDP.Telefono", "Persona", "TDP.Persona", "PersonaId", cascadeDelete: true);
        }
    }
}
