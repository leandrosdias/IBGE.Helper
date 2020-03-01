using IBGE.Helper.Tests.Utils;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBGE.Helper.Tests
{
    [TestFixture]
    class SubDistritoTests
    {
        [Test]
        public async Task GetAllSubDistritosTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeClient();
            var result = await client.GetSubDistritosAsync();

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }

        [Test]
        public async Task GetAllSubDistritosByIdTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeClient();
            var result = await client.GetSubDistritosByIdAsync(new List<ulong> { 53001080517 });

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }

        [Test]
        public async Task GetAllSubDistritosByUfsTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeClient();
            var result = await client.GetSubDistritosByUfsAsync(new List<int> { 33 });

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }

        [Test]
        public async Task GetAllSubDistritosByMesorregiaoTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeClient();
            var result = await client.GetSubDistritosByMesorregiaoAsync(new List<int> { 4305 });

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }

        [Test]
        public async Task GetAllSubDistritosByMicrorregiaoTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeClient();
            var result = await client.GetSubDistritosByMicrorregiaoAsync(new List<int> { 11001 });

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }

        [Test]
        public async Task GetAllSubDistritosByMunicipioTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeClient();
            var result = await client.GetSubDistritosByMunicipiosAsync(new List<int> { 3304557 });

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }

        [Test]
        public async Task GetAllSubDistritosByRegiaoTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeClient();
            var result = await client.GetSubDistritosByRegioesAsync(new List<int> { 3 });

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }
    }
}
