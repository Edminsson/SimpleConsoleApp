using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleTests.Models;
using System.Security.Cryptography;
using System.Text;

namespace SimpleTests
{
    [TestClass]
    public class FirstTest
    {
        [TestMethod]
        public void GenerateHashKeyForPlayer()
        {
            Player player = new Player();
            player.Id = 9;
            player.Name = "Zlatan";
            player.Country = "Sweden";
            var hashcode = player.GetHashCode();
            Player player2 = new Player();
            player2.Id = 9;
            player2.Name = "Zlatan";
            player2.Country = "Sweden";
            var hashcode2 = player2.GetHashCode();
            //Två "identiska" objekt får ändå olika hashkod som default
            Assert.AreNotEqual(hashcode, hashcode2);
        }
        [TestMethod]
        public void GenerateHashKeyForString()
        {
            var player = "Zlatan";
            var hashcode = player.GetHashCode();
            var player2 = "Zlatan";
            var hashcode2 = player2.GetHashCode();
            Assert.AreEqual(hashcode, hashcode2);
            var player3 = "zlatan";
            var hashcode3 = player3.GetHashCode();
            Assert.AreNotEqual(hashcode, hashcode3);
        }
        [TestMethod]
        public void CacheGenerationFromPluralSight()
        {
            string cacheKey = "Zlatan";
            byte[] hashBytes;
            using (var provider = new MD5CryptoServiceProvider())
            {
                var inputBytes = Encoding.Default.GetBytes(cacheKey);
                hashBytes = provider.ComputeHash(inputBytes);
            }
            string slutligHash = new Guid(hashBytes).ToString();
        }
        [TestMethod]
        public void  StringTest()
        {
            string strang = "hola";
            string strang2 = strang;
            strang = "mira";
        }

    }
}
