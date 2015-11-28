using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    class Program
    {
        static void Main(string[] args)
        {
            CRUDPersonaFacade fachada = new CRUDPersonaFacade();
            //Console.WriteLine(context.Database.Connection.ConnectionString);
            // Alta
            Persona mPersona = new Persona
            {
                //PersonaId = 1,
                Nombre = "Juan",
                Apellido = "Sánchez",
                Telefonos = new List<Telefono>() 
            };

            Telefono mTelefono = new Telefono { Numero = "555-123456", Tipo = "Celular" };


            mPersona.Telefonos.Add(mTelefono);


          /*  using (AgendaContext context = new AgendaContext())
            {
                context.Personas.Add(mPersona);
                context.Telefonos.Add(mTelefono);
                context.SaveChanges();
            }*/


            fachada.Create(mPersona);
            Console.WriteLine("Holis");
            Console.ReadKey();
            Persona pers = fachada.GetById(1);
            Console.WriteLine(pers.Nombre);
            Console.ReadKey();

            List<Persona> lista = fachada.GetAll();

          /*  using (AgendaContext context = new AgendaContext())
            {
                lista = context.Set<Persona>().ToList<Persona>();
            }*/






            Console.WriteLine("Holis");
            Console.ReadKey();
            // busqueda
            Console.WriteLine("Resultados");

            foreach (var item in lista)
            {
                Console.WriteLine("Persona encontrada Nombre:{0}, Apellido: {1}, IdPersona:{2}",
                            item.Nombre,
                            item.Apellido,
                            item.PersonaId.ToString());
                foreach (var tel in item.Telefonos)
                {
                    Console.WriteLine("Numero: {0},Tipo{1}", tel.Numero, tel.Tipo);
                }
            }
            Console.ReadKey();
        }
    }
}