using IBGE.Helper.Tests.Utils;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBGE.Helper.Tests
{
    [TestFixture]
    class MicrorregiaoTests
    {
        [Test]
        public async Task GetAllMicroregiaoTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeLocalidadeClient();
            var result = await client.GetMicrorregiaoAsync();

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }

        [Test]
        public async Task GetMicrorregiaoByUfTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeLocalidadeClient();
            var result = await client.GetMicrorregiaoByUfAsync(new List<int> { 33, 35 });

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);

            var microsNotInUf = result.Where(x => x.Mesorregiao.Uf.Id != 33 && x.Mesorregiao.Uf.Id != 35).ToList();

            Assert.Zero(microsNotInUf.Count);
        }

        [Test]
        public async Task GetMicrorregiaoByMesorregiaoTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeLocalidadeClient();
            var result = await client.GetMicrorregiaoByMesorregiaoAsync(new List<int> { 3303, 3304 });

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);

            var microsNotInMeso = result.Where(x => x.Mesorregiao.Id != 3303 && x.Mesorregiao.Id != 3304).ToList();

            Assert.Zero(microsNotInMeso.Count);
        }

        [Test]
        public async Task GetMicrorregiaoByIdTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeLocalidadeClient();
            var result = await client.GetMicroregiaoByIdAsync(new List<int> { 33007, 31007 });

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);

            result = await client.GetMicroregiaoByIdAsync(new List<int> { 33007 });
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ToList().Count, 1);
        }

        [Test]
        public async Task GetMicrorregiaoByMacroTestAsync()
        {
            if (!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeLocalidadeClient();
            var result = await client.GetMicroregiaoByMacrorregiaoAsync(new List<int> { 3, 4 });

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);

        }
    }
}
