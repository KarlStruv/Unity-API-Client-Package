using NUnit.Framework;
using UnityEngine;

namespace KarlStruv.ApiClient.Tests
{
    public class APIClientTest
    {
        private GameObject gameObject;
        private APIClient apiClient;

        [SetUp]
        public void SetUp()
        {
            // Create a new GameObject and attach the APIClient script
            gameObject = new GameObject();
            apiClient = gameObject.AddComponent<APIClient>();
        }

        [Test]
        public void TestAPIClientInitialization()
        {
            // Check if the APIClient script is attached to the GameObject
            Assert.NotNull(apiClient);
        }

        [Test]
        public void TestOnButtonClick()
        {
            // Simulate the OnButtonClick action
            Assert.DoesNotThrow(() => apiClient.OnButtonClick());
        }
    }
}
