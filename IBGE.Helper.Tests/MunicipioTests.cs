using IBGE.Helper.Tests.Utils;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBGE.Helper.Tests
{
    [TestFixture]
    public class MunicipioTests
    {
        [Test]
        public async Task GetAllMunicipioTestAsync()
        {
            if(!InternetAvailability.IsInternetAvailable())
            {
                Assert.Inconclusive();
                return;
            }

            var client = new IbgeClient();
            var result = await client.GetMunicipiosAsync();

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.ToList().Count, 1);
        }

    }
}
