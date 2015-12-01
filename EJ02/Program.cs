using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    class Program
    {
        static void MostrarTodosTest(CRUDPersonaFacade fachada)
        {
            List<Persona> lista = fachada.GetAll();
            Console.WriteLine("Get all, Resultados");
            Console.ReadKey();


            foreach (var item in lista)
            {
                Console.WriteLine("\tPersona encontrada Nombre:{0}, Apellido: {1}, IdPersona:{2}",
                            item.Nombre,
                            item.Apellido,
                            item.PersonaId.ToString());
                foreach (var tel in item.Telefonos)
                {
                    Console.WriteLine("\t\tNumero: {0},Tipo{1}", tel.Numero, tel.Tipo);
                }
            }
            Console.ReadKey();

        }



        static void AgregarTest()
        {
            CRUDPersonaFacade fachada = new CRUDPersonaFacade();

            Persona mPersona = new Persona
            {
                Nombre = "Juan",
                Apellido = "Sánchez",
                Telefonos = new List<Telefono>()
            };

            Telefono mTelefono = new Telefono { Numero = "555-123456", Tipo = "Celular" };

            mPersona.Telefonos.Add(mTelefono);

            fachada.Create(mPersona);
            Console.WriteLine("Agregada");
            Console.ReadKey();

            Persona pers = fachada.GetById(1);
            Console.WriteLine("Get by id Nombre: {0}, Cantidad de Telefonos: {1}",pers.Nombre, pers.Telefonos == null ? "null" : pers.Telefonos.Count.ToString());
            Console.ReadKey();

            MostrarTodosTest(fachada);

        }

        static void ActualizarTest()
        {
            CRUDPersonaFacade fachada = new CRUDPersonaFacade();

            Persona mPersona /*= new Persona
            {
                PersonaId = 2,
                Nombre = "Martin",
                Apellido = "Fijo",
                Telefonos = new List<Telefono>() 
            }*/;

            mPersona = fachada.GetById(2);

            Telefono mTelefono = new Telefono { Numero = DateTime.Now.ToString(), Tipo = "Fijo" };
            Telefono mTelefono2 = new Telefono { Numero = DateTime.Today.ToString(), Tipo = "CeroOchocientos" };


            mPersona.Telefonos.Add(mTelefono);
            mPersona.Telefonos.Add(mTelefono2);




            fachada.Update(mPersona);
            Console.WriteLine("Actualizada");
            Console.ReadKey();

            Persona pers = fachada.GetById(2);
            Console.WriteLine("Get by id Nombre: {0}", pers.Nombre);
            Console.ReadKey();

            MostrarTodosTest(fachada);

        }


        static void Main(string[] args)
        {
          /*  Persona mPersona2;
            using (AgendaContext ctx = new AgendaContext())
            {
                mPersona2 = ctx.Set<Persona>().Find(2);
                mPersona2.Nombre = "Hola";
            }

            using (AgendaContext ctx = new AgendaContext())
            {
                ctx.Entry(mPersona2).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            */

            ActualizarTest();


        }
    }
}