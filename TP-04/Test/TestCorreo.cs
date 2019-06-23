using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Test
{
    [TestClass]
    public class TestCorreo
    {
        [TestMethod]
        public void ListaDeCorreoInstanciada()
        {
            Correo correo = new Correo();

            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void PaquetesConMismoTracking()
        {
            Correo correo = new Correo();
            Paquete p1 = new Paquete("Mitre 700", "123-456-7890");
            Paquete p2 = new Paquete("Pavon 744", "123-456-7890");

            correo += p1;
            correo += p2;
        }
    }
}
