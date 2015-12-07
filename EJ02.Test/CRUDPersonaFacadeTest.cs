using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EJ02.Test
{

    [TestClass]
    public class CRUDPersonaFacadeTest
    {
        public void Create(Persona pPersona)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.PersonaRepository.Insert(pPersona);
                /*foreach (var item in pPersona.Telefonos)
                {
                    uow.TelefonoRepository.Insert(item);
                }*/
                uow.Save();
            }

        }

        [TestMethod]
        public void Create()
        {
            var mockSetPersonas = new Mock<DbSet<Persona>>();
            var mockSetTelefonos = new Mock<DbSet<Persona>>();
            var mockContext = new Mock<AgendaContext>();
            var mockRepositoryPersonas = new Mock<GenericRepository<Persona>>(mockContext.Object);
            var mockRepositoryTelefonos = new Mock<GenericRepository<Telefono>>(mockContext.Object);
            var mockUnitOfWork = new Mock<UnitOfWork>();
            var mockFacade = new Mock<CRUDPersonaFacade>();

            mockUnitOfWork.Setup(uow => uow.PersonaRepository).Returns(mockRepositoryPersonas.Object);
            mockUnitOfWork.Setup(uow => uow.TelefonoRepository).Returns(mockRepositoryTelefonos.Object);
            mockUnitOfWork.Setup(uow => uow.UnitOfWork)

            Persona lPersona = new Persona()
            {
                Nombre = "Ramiro",
                Apellido = "Rivera",
                Telefonos = new List<Telefono>()
                    {
                        new Telefono() { Tipo = "Celular", Numero="03447-15409832" }
                    }
            };


            mockFacade.Object.Create(lPersona);

            mockRepositoryPersonas.Verify(per => per.Insert(It.Is<Persona>(p => p == lPersona)), Times.Once);
            mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
            mockUnitOfWork.Verify(uow => uow.Dispose(), Times.Once);

        }
    }
}
