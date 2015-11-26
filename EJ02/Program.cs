﻿using System;
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
            using (var db = new AgendaContext())
            {
                // Alta
                Persona mPersona = new Persona
                {
                    PersonaId = 1,
                    Nombre = "Juan",
                    Apellido = "Sánchez",
                    Telefonos = new List<Telefono>{ new Telefono{ TelefonoId = 1,
                                                                  Numero = "555-123456",
                                                                  Tipo = "Celular"} }
                };
                fachada.Create(mPersona);
                Console.WriteLine("Holis");
                Console.ReadKey();
                Persona pers = fachada.GetById(1);
                Console.WriteLine(pers.Nombre);
                Console.ReadKey();
                /*List<Persona> lista = fachada.GetAll();
                Console.WriteLine("Holis");
                Console.ReadKey();
                // busqueda
                foreach (var item in lista)
                {
                    Console.WriteLine("Persona encontrada Nombre:{0}, Apellido: {1}, IdPersona:{2}",
                                item.Nombre,
                                item.Apellido,
                                item.PersonaId.ToString());
                    foreach (var tel in item.Telefonos)
                    {
                        Console.WriteLine("Numero: {0},Tipo{1}",tel.Numero,tel.Tipo);
                    }
                }
                Console.ReadKey();*/
            }
        }
    }
}