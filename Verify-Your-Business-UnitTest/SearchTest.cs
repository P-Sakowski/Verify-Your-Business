using Microsoft.VisualStudio.TestTools.UnitTesting;
using Verify_Your_Business_Library;

namespace Verify_Your_Business_UnitTest
{
    [TestClass]
    public class SearchTest
    {

        [DataTestMethod]
        [DataRow("5252344078")]
        [DataRow("5252530705")]
        [DataRow("5260250995")]
        public void NipSearchSuccess(string textSearch)
        {
            ApiClient apiClient = new ApiClient(textSearch, "1");
            Assert.IsNotNull(apiClient.content);
        }

        [DataTestMethod]
        [DataRow("525234407")]
        [DataRow("52525307")]
        [DataRow("52602509955")]
        public void NipSearchFailure(string textSearch)
        {
            ApiClient apiClient = new ApiClient(textSearch, "1");
            Assert.IsNull(apiClient.content);
        }

        [DataTestMethod]
        [DataRow("146108856")]
        [DataRow("012100784")]
        [DataRow("140182840")]
        public void RegonSearchSuccess(string textSearch)
        {
            ApiClient apiClient = new ApiClient(textSearch, "2");
            Assert.IsNotNull(apiClient.content);
        }

        [DataTestMethod]
        [DataRow("14610885")]
        [DataRow("0121007")]
        [DataRow("1401828400")]
        public void RegonSearchFailure(string textSearch)
        {
            ApiClient apiClient = new ApiClient(textSearch, "2");
            Assert.IsNull(apiClient.content);
        }
    }
}
