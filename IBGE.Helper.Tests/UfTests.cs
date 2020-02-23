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
    public class UfTests
    {
        [Test]
        public async Task GetAllUfsTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeClient();
            var result = await client.GetUfsAsync();

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }

        [Test]
        public async Task GetAllUfsByIdTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeClient();
            var result = await client.GetUfsByIdAsync(new List<int> { 33 });

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }

        [Test]
        public async Task GetAllUfsByRegionTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeClient();
            var result = await client.GetUfsByRegionAsync(new List<int> { 3 });

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }
    }
}
