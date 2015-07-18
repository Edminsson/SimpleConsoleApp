using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleTests.Models;
using System.Security.Cryptography;
using System.Text;
using SimpleClassLibrary.Interfaces;
using Moq;
using System.Collections.Generic;

namespace SimpleTests
{
    [TestClass]
    public class MoqTests
    {
        [TestMethod]
        public void ITrabajoTest()
        {
            var trabajo = new Mock<ITrabajo>();
            trabajo.Setup(t => t.GetFavoriteNumbers(2, "aa")).Returns(new List<int> { 10, 53, 23, 44 });
            trabajo.Setup(t => t.GetFavoriteNumbers(It.IsAny<int>(), It.IsAny<string>())).Returns(new List<int> { 5, 25 });
            trabajo.Setup(t => t.GetFavoriteNumbers(1, "qwerty")).Returns(new List<int> { 1, 3, 23 });
            var jobb = trabajo.Object;

            var mock = new Mock<ITrabajo>();
            mock.Setup(ms => ms.GetFavoriteNumbers(It.Is<int>(u => u == 4), It.Is<string>(p => p == "g")))
                .Returns(new List<int>());



            var lista1 = jobb.GetFavoriteNumbers(2, "rr");
            var lista2 = jobb.GetFavoriteNumbers(1, "qwerty");
            var lista3 = jobb.GetFavoriteNumbers(2, "aa");
        }

    }
}
