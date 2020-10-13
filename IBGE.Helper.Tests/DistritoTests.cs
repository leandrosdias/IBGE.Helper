using IBGE.Helper.Tests.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBGE.Helper.Tests
{
    [TestFixture]
    class DistritoTests
    {
        [Test]
        public async Task GetAllDistritosTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeLocalidadeClient();
            var result = await client.GetDistritosAsync();

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }

        [Test]
        public async Task GetAllDistritosByIdTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeLocalidadeClient();
            var result = await client.GetDistritosByIdAsync(new List<int> { 160030312 });

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }

        [Test]
        public async Task GetAllDistritosByUfsTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeLocalidadeClient();
            var result = await client.GetDistritosByUfsAsync(new List<int> { 33 });

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }

        [Test]
        public async Task GetAllDistritosByMesorregiaoTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeLocalidadeClient();
            var result = await client.GetDistritosByMesorregiaoAsync(new List<int> { 1602 });

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }

        [Test]
        public async Task GetAllDistritosByMicrorregiaoTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeLocalidadeClient();
            var result = await client.GetDistritosByMicrorregiaoAsync(new List<int> { 16003 });

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }

        [Test]
        public async Task GetAllDistritosByMunicipioTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeLocalidadeClient();
            var result = await client.GetDistritosByMunicipiosAsync(new List<int> { 3550308 });

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }

        [Test]
        public async Task GetAllDistritosByRegiaoTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeLocalidadeClient();
            var result = await client.GetDistritosByRegioesAsync(new List<int> { 3 });

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }
    }
}
