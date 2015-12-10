using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AgendaContext())
            {
                // Alta
                Telefono mTelefono = new Telefono
                {
                   // TelefonoId = 1,
                    Numero = DateTime.Now.ToString(),
                    Tipo = "Celular"
                };
                Persona mPersona = new Persona
                {
                    PersonaId = 1,
                    Nombre = "Juan",
                    Apellido = "Sánchez",
                    Telefonos = new List<Telefono>{ mTelefono }
                };
                db.Personas.Add(mPersona);
                db.Telefonos.Add(mTelefono);
                Console.WriteLine("Cambios por guardarse");
                Console.ReadKey();
                db.SaveChanges();
                // busqueda
                foreach (var item in db.Personas)
                {
                    Console.WriteLine("Persona encontrada Nombre:{0}, Apellido: {1}, IdPersona:{2}",
                                item.Nombre,
                                item.Apellido,
                                item.PersonaId.ToString());
                    if (item.Telefonos != null)
                    {
                        foreach (var tel in item.Telefonos)
                        {
                            Console.WriteLine("\tNumero: {0},Tipo{1}", tel.Numero, tel.Tipo);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\tTelefonos Null");
                    }
                    
                }
                Console.ReadKey();
            }
        }
    }
}
