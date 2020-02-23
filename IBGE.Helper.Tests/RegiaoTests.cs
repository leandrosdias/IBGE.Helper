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
    public class RegiaoTests
    {
        [Test]
        public async Task GetAllRegioesTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeClient();
            var result = await client.GetRegioesAsync();

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }

        [Test]
        public async Task GetAllRegioesByIdTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeClient();
            var result = await client.GetRegioesByIdAsync(new List<int> { 1 });

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }
    }
}
