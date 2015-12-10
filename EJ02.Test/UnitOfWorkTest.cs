using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using EJ02;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EJ02.Test
{
    
    [TestClass]
    public class UnitOfWorkTest
    {

        [TestMethod]
        public void TestMethod1()
        {
            var mockSetPersonas = new Mock<DbSet<Persona>>();
            var mockSetTelefonos = new Mock<DbSet<Persona>>();
            var mockContext = new Mock<AgendaContext>();
            var mockEntry = new Mock<DbEntityEntry<Persona>>();
            var mockRepository = new Mock<GenericRepository<Persona>>(mockContext.Object);
            var repositorio = mockRepository.Object;

            Persona lPersona = new Persona()
            {
                Nombre = "Ramiro",
                Apellido = "Rivera",
                Telefonos = new List<Telefono>()
                    {
                        new Telefono() { Tipo = "Celular", Numero="03447-15409832" }
                    }
            };
        }
    }

   
}
