namespace EJ02.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion02 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "TDP.Persona", newName: "Personas");
            RenameTable(name: "TDP.Telefono", newName: "Telefonoes");
            MoveTable(name: "TDP.Personas", newSchema: "dbo");
            MoveTable(name: "TDP.Telefonoes", newSchema: "dbo");
            DropForeignKey("TDP.Telefono", "Persona", "TDP.Persona");
            DropIndex("dbo.Telefonoes", new[] { "Persona" });
            RenameColumn(table: "dbo.Telefonoes", name: "Persona", newName: "Persona_PersonaId");
            AlterColumn("dbo.Telefonoes", "Persona_PersonaId", c => c.Int());
            CreateIndex("dbo.Telefonoes", "Persona_PersonaId");
            AddForeignKey("dbo.Telefonoes", "Persona_PersonaId", "dbo.Personas", "PersonaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telefonoes", "Persona_PersonaId", "dbo.Personas");
            DropIndex("dbo.Telefonoes", new[] { "Persona_PersonaId" });
            AlterColumn("dbo.Telefonoes", "Persona_PersonaId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Telefonoes", name: "Persona_PersonaId", newName: "Persona");
            CreateIndex("dbo.Telefonoes", "Persona");
            AddForeignKey("TDP.Telefono", "Persona", "TDP.Persona", "PersonaId", cascadeDelete: true);
            MoveTable(name: "dbo.Telefonoes", newSchema: "TDP");
            MoveTable(name: "dbo.Personas", newSchema: "TDP");
            RenameTable(name: "TDP.Telefonoes", newName: "Telefono");
            RenameTable(name: "TDP.Personas", newName: "Persona");
        }
    }
}
