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
    public class MesoregiaoTests
    {
        [Test]
        public async Task GetAllMesoregiaoTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeClient();
            var result = await client.GetMesoregiaoAsync();

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }

        [Test]
        public async Task GetMesoregiaoByUfTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeClient();
            var result = await client.GetMesoregiaoByUfAsync(new List<int> { 33, 35 });

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }

        [Test]
        public async Task GetMesoregiaoByIdTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeClient();
            var result = await client.GetMesoregiaoByIdAsync(new List<int> { 3302, 3509 });

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }

        [Test]
        public async Task GetMesoregiaoByMacroregiaoTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeClient();
            var result = await client.GetMesoregiaoByMacroregiaoAsync(new List<int> { 3,4 });

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }
    }
}
