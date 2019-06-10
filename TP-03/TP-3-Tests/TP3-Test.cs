using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using Excepciones;

namespace TP_3_Tests
{
    [TestClass]
    public class ClasesAbtractasTest
    {
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void NacionalidadIncorrectaArgentino()
        {
            string dni = "92022111";
            Alumno alumno = new Alumno(1, "Juan", "Perez", dni, EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniConCaracteresIncorrecto()
        {
            string dniIncorrecto = "37011abc";
            Profesor profesor = new Profesor(2, "Marcelo", "Fasso", dniIncorrecto, EntidadesAbstractas.Persona.ENacionalidad.Argentino);
        }

        [TestMethod]
        public void NombreInvalidoNoCarga()
        {
            string nombre = "p3dr0";
            string apellido = "4l0nz0";
            Alumno alumno = new Alumno(1, nombre, apellido, "98123456", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);

            Assert.AreEqual("", alumno.Nombre);
            Assert.AreEqual("", alumno.Apellido);
        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void NacionalidadIncorrectaExtranjero()
        {
            string dni = "30022111";
            Alumno alumno = new Alumno(1, "Juan", "Perez", dni, EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
        }

        [TestMethod]
        public void ValorNoNuloProfesor()
        {
            Profesor profesor = new Profesor(4, "Mariana", "Maciel", "12555666", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            Assert.IsNotNull(profesor.Nombre);
            Assert.IsNotNull(profesor.Apellido);
            Assert.IsNotNull(profesor.DNI);
            Assert.IsNotNull(profesor.Nacionalidad);
        }

        [TestMethod]
        public void ValorNoNuloJornada()
        {
            Profesor profesor = new Profesor(2, "Leonardo", "Maffia", "97555666", EntidadesAbstractas.Persona.ENacionalidad.Extranjero);
            Jornada jornada = new Jornada(Universidad.EClases.Legislacion, profesor);

            Assert.IsNotNull(profesor.DNI);
            Assert.IsNotNull(profesor.Nombre);
            Assert.IsNotNull(profesor.Apellido);
            Assert.IsNotNull(profesor.Nacionalidad);
            Assert.IsNotNull(jornada.Alumnos);
            Assert.IsNotNull(jornada.Clase);
            Assert.IsNotNull(jornada.Instructor);
        }

    }
}
