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

        static void MostrarTodos(List<Persona> pLista)
        {
            foreach (var item in pLista)
            {
                MostrarPersona(item);
            }
            Console.ReadKey();
        }

        static void MostrarTodosTest(CRUDPersonaFacade fachada)
        {
            List<Persona> lista = fachada.GetAll();
            Console.WriteLine("Get all, Resultados");
            Console.ReadKey();
            MostrarTodos(lista);

        }

      
        static void AgregarTest()
        {
            UnitOfWork uow;
            CRUDPersonaFacade fachada;

            uow = new UnitOfWork();
            fachada = new CRUDPersonaFacade(uow);

            Persona mPersona = new Persona
            {
                Nombre = DateTime.Now.ToString(),
                Apellido = "Sánchez",
                Telefonos = new List<Telefono>()
            };

            Telefono mTelefono1 = new Telefono { Numero = DateTime.Now.Ticks.ToString(), Tipo = "Celular" };
            Telefono mTelefono2 = new Telefono { Numero = DateTime.Now.Second.ToString(), Tipo = "Celular" };

            mPersona.Telefonos.Add(mTelefono1);
            mPersona.Telefonos.Add(mTelefono2);

            using (uow)
            {
                fachada.Create(mPersona);

            }

            Console.WriteLine("Agregada");
            Console.ReadKey();
            /*
                        Persona pers = fachada.GetById(1);
                        try
                        {
                            Console.WriteLine("Get by id Nombre: {0}, Cantidad de Telefonos: {1}", pers.Nombre, pers.Telefonos == null ? "null" : pers.Telefonos.Count.ToString());
                        }
                        catch (System.ObjectDisposedException)
                        {
                            Console.WriteLine("Get by id Nombre: {0}, Cantidad de Telefonos: {1}", pers.Nombre, "Context Disposed");
                        }

                        Console.ReadKey();

                       MostrarTodosTest(fachada);*/

        }

        static void MostrarPersona(Persona pPersona)
        {
            Console.WriteLine("\tPersona encontrada Nombre:{0}, Apellido: {1}, IdPersona:{2}",
                           pPersona.Nombre,
                           pPersona.Apellido,
                           pPersona.PersonaId.ToString());
            try
            {
                if (pPersona.Telefonos != null)
                {
                    foreach (var tel in pPersona.Telefonos)
                    {
                        Console.WriteLine("\t\tNumero: {0},Tipo{1}", tel.Numero, tel.Tipo);
                    }
                }
                else
                {
                    Console.WriteLine("\tSin Telefonos");
                }
            }
            catch (System.ObjectDisposedException)
            {
                Console.WriteLine("\tContext Disposed");
            }




        }

        static void ActualizarTest()
        {
            UnitOfWork uow;
            CRUDPersonaFacade fachada;

            uow = new UnitOfWork();
            fachada = new CRUDPersonaFacade(uow);

            Persona mPersona = new Persona
            {
                PersonaId = 40,
                Nombre = "Martin",
                Apellido = "Fijo",
                Telefonos = new List<Telefono>() 
            };

            using (uow)
            {
                mPersona = fachada.GetAll()[5];
                string temp = DateTime.Today.ToString();
                mPersona.Nombre = mPersona.Nombre + temp;

                Console.WriteLine("Nombre viejo: {0}\t Nombre Nuevo: {1}", mPersona.Nombre, mPersona.Nombre + temp);
                Console.ReadKey();

                Telefono mTelefonoNuevo1 = new Telefono { Numero = DateTime.Now.ToString(), Tipo = "Fijo" };
                Telefono mTelefonoNuevo2 = new Telefono { Numero = DateTime.Today.ToString(), Tipo = "CeroOchocientos" };
                mPersona.Telefonos.Add(mTelefonoNuevo1);
                mPersona.Telefonos.Add(mTelefonoNuevo2);

                mPersona.Telefonos[0].Tipo = mPersona.Telefonos[0].Tipo + " Celular";

                //mPersona.Telefonos.RemoveAt(1);
            }
            uow = new UnitOfWork();
            fachada = new CRUDPersonaFacade(uow);

            using (uow)
            {

                fachada.Update(mPersona);

                Console.WriteLine("Actualizada");
                Console.ReadKey();

                Persona pers = fachada.GetAll()[5];
                Console.WriteLine("Get by id Nombre: {0}", pers.Nombre);
                Console.ReadKey();

                MostrarTodosTest(fachada);
            }
        }

        private static void AgregarActualizarPersonaSola()
        {
            UnitOfWork uow;
            CRUDPersonaFacade fachada;

            uow = new UnitOfWork();
            fachada = new CRUDPersonaFacade(uow);

            Persona mPersona = new Persona
            {
                Nombre = DateTime.Now.ToString(),
                Apellido = "Sánchez",
                Telefonos = new List<Telefono>()
            };

            fachada.Create(mPersona);
            Console.WriteLine("Creada ({0})", mPersona.PersonaId);
            Console.ReadKey();

            int id = mPersona.PersonaId;
            mPersona = null;

            mPersona = fachada.GetById(id);

            mPersona.Nombre = "Ramiro"; mPersona.Apellido = "Estuvo aqui";

            Console.WriteLine("Modificada");
            Console.ReadKey();

            fachada.Update(mPersona);

            Console.WriteLine("Actualizada");
            Console.ReadKey();


        }

        private static void EliminarTest()
        {
            UnitOfWork uow;
            CRUDPersonaFacade fachada;

            uow = new UnitOfWork();
            fachada = new CRUDPersonaFacade(uow);

            Persona mPersona;

            using (uow)
            {
                mPersona = fachada.GetAll().First<Persona>();

                Console.WriteLine("Se Eliminara la primer persona, con nombre: '{0}' y ID: {1}", mPersona.Nombre, mPersona.PersonaId);
                Console.ReadKey();

                fachada.Delete(mPersona);

                Console.WriteLine("Eliminada");
                Console.ReadKey();
            }

        }

        static void LeerSinRepo()
        {
            Persona mPersona2;
            List<Persona> pLista = new List<Persona>();
            using (AgendaContext ctx = new AgendaContext())
            {
                DbSet<Persona> dbset = ctx.Set<Persona>();

                mPersona2 = dbset.Find(1);
                pLista = dbset.Include(p => p.Telefonos).ToList<Persona>();
                MostrarPersona(mPersona2);

                // mPersona2.Nombre = "Hola";
            }
            MostrarTodos(pLista);

            Console.ReadKey();


        }

        /* Persona mPersona2;
           using (AgendaContext ctx = new AgendaContext())
           {
               mPersona2 = ctx.Set<Persona>().Find(2);
              // mPersona2.Nombre = "Hola";
           }

           using (AgendaContext ctx = new AgendaContext())
           {
               ctx.Entry(mPersona2).State = EntityState.Modified;
               ctx.SaveChanges();
           }*/


        static void UpdateSinRepo()
        {
            Random lRandom = new Random();
            Persona mPersona2;

            using (AgendaContext ctx = new AgendaContext())
            {
                int cant = ctx.Set<Persona>().Count<Persona>();
                lRandom.Next(0, cant - 1);
                mPersona2 = ctx.Set<Persona>().ToList<Persona>()[lRandom.Next(0, cant - 1)];
            }
            mPersona2.Nombre = "Ramiro estuvo aqui";
            using (AgendaContext ctx = new AgendaContext())
            {
                ctx.Entry(mPersona2).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }


        




        static void Main(string[] args)
        {
            //  LeerSinRepo();

            /* for (int i = 0; i < 10; i++)
             {
                 AgregarTest();
             }*/

            ActualizarTest();
            Console.ReadKey();

           
            //  ActualizarTest();

            /*  AgregarTest();
              Console.ReadKey();*/

            //AgregarActualizarPersonaSola();

            // UpdateSinRepo();

            // EliminarTest();
        }


    }
}
