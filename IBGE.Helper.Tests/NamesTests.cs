using IBGE.Helper.Models.Nomes;
using IBGE.Helper.Tests.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBGE.Helper.Tests
{
    [TestFixture]
    public class NamesTests
    {
        [Test]
        public async Task GetAllNamesTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeNomeClient();
            var result = await client.GetNamesAsync(new List<string> { "Leandro", "Pâmela"});

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }

        [Test]
        public async Task GetAllNamesFrequencyTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeNomeClient();
            var names = await client.GetNamesAsync(new List<string> { "Leandro" });

            var result = UtilsNames.GetNameFrequencies(names.FirstOrDefault());

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }
    }
}
