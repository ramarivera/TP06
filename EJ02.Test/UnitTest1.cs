using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EJ02.Test
{

    class Hola :IDisposable
    {

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            this.disposed = true;
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool Test()
        {
            return true;
        }
    }


    [TestClass]
    public class UnitTest1
    {
        Hola iHola;

        [TestMethod]
        public void TestMethod1()
        {
            using (this.iHola = new Hola())
            {
                
            }

            Assert.IsTrue(this.iHola.Test());

        }
    }
}
