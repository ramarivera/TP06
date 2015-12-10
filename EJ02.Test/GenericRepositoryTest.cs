using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using EJ02;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EJ02.Test
{
    /*
    [TestClass]
    public class GenericRepositoryTest
    {

        [TestMethod]
        public void GetByID()
        {
            // Arrange 
            var mockSetPersonas = new Mock<DbSet<Persona>>();
            var mockContext = new Mock<AgendaContext>();
            var mockRepository = new Mock<GenericRepository<Persona>>(mockContext.Object);

            mockContext.Setup(m => m.Set<Persona>()).Returns(mockSetPersonas.Object);

            var repositorio = mockRepository.Object;

            // Act
            repositorio.GetByID(1);

            // Assert
            mockSetPersonas.Verify(set => set.Find(It.IsAny<Object>()), Times.Once);
        }


        [TestMethod]
        public void Insert()
        {
            // Arrange 
            var mockSetPersonas = new Mock<DbSet<Persona>>();
            var mockContext = new Mock<AgendaContext>();
            var mockRepository = new Mock<GenericRepository<Persona>>(mockContext.Object);

            mockContext.Setup(m => m.Set<Persona>()).Returns(mockSetPersonas.Object);

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

            // Act
            repositorio.Insert(lPersona);

            // Assert
            mockSetPersonas.Verify(set => set.Add(It.Is<Persona>(per => per == lPersona)), Times.Once);
        }



        [TestMethod]
        public void Update()
        {
            // Arrange 
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

            mockContext.Setup(m => m.Set<Persona>()).Returns(mockSetPersonas.Object);
           //mockContext.Setup(ctx => ctx.Entry(It.Is<Persona>(p => p == lPersona))).Returns(mockEntry.Object);

            // Act
            repositorio.Update(lPersona);
            // context.Entry(entityToUpdate).State = EntityState.Modified;

            // Assert
            //mockContext.Verify(ctx => ctx.Entry(It.Is<Persona>(p => p == lPersona)), Times.Once);
           mockEntry.VerifySet(entry => entry.State = EntityState.Modified);
        }
    } */
}
