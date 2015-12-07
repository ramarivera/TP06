using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using EJ02;
using System.Data.Entity;

namespace EJ02.Test
{

    [TestClass]
    public class GenericRepositoryTest
    {

        [TestMethod]
        public void GetByID()
        {
            // Arrange 
            var mockSet = new Mock<DbSet<Persona>>();
            var mockContext = new Mock<AgendaContext>();
            var mockRepository = new Mock<GenericRepository<Persona>>(mockContext.Object);

            mockContext.Setup(m => m.Set<Persona>()).Returns(mockSet.Object);

            var repositorio = mockRepository.Object;

            // Act
            repositorio.GetByID(1);

            // Assert
            
            mockSet.Verify(set => set.Find(It.IsAny<Object>()), Times.Once);
        }


        [TestMethod]
        public void Insert()
        {
            // Arrange 
            var mockSet = new Mock<DbSet<Persona>>();
            var mockContext = new Mock<AgendaContext>();
            var mockRepository = new Mock<GenericRepository<Persona>>(mockContext.Object);

            mockContext.Setup(m => m.Set<Persona>()).Returns(mockSet.Object);

            var repositorio = mockRepository.Object;

            Persona lPersona = new Persona()
            {
                Nombre = "Ramiro",
                Apellido = "Rivera",
                PersonaId = 5,
                Telefonos = new List<Telefono>()
                    {
                        new Telefono() {TelefonoId = 2, Tipo = "Celular", Numero="03447-15409832" }
                    }
            };

            // Act
            repositorio.Insert(lPersona);

            // Assert

            mockSet.Verify(set => set.Add(It.Is<Persona>(per => per == lPersona)), Times.Once);
        }
    }
}
