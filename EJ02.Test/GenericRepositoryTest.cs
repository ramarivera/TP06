using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            //var mockSetNonGeneric = new Mock<DbSet>();
            var mockSet = new Mock<DbSet<Persona>>();
            var mockContext = new Mock<AgendaContext>();
            var mockRepository = new Mock<GenericRepository<Persona>>(mockContext.Object);

            mockContext.Setup(m => m.Personas).Returns(mockSet.Object);
            mockContext.Setup(m => m.Set<Persona>()).Returns(mockSet.Object);
            
            //mockContext.Setup(c => c.Set(typeof(Persona))).Returns(mockSetNonGeneric.Object);

            var repositorio = mockRepository.Object;

            // Act
            repositorio.GetByID(1);

            // Assert
            mockContext.Verify(ctx => ctx.dbset, Times.Exactly(1));
            mockSet.Verify(set => set.Find(It.IsAny<Object>()), Times.Once);

            //mockSet.Verify(m => m.Add(It.IsAny<Blog>()), Times.Once());
           // mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
