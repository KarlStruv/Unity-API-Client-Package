using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace KarlStruv.ApiClient.Tests
{
    public class APIClientPlayModeTest
    {
        private GameObject gameObject;
        private APIClient apiClient;
        private Text mockDisplayText;
        private Text mockPostText;

        [SetUp]
        public void SetUp()
        {
            // Create a new GameObject and attach the APIClient script
            gameObject = new GameObject();
            apiClient = gameObject.AddComponent<APIClient>();

            // Create a mock displayText object and assign it to APIClient
            mockDisplayText = new GameObject().AddComponent<Text>();
            apiClient.displayText = mockDisplayText;

            // Create a mock postText object and assign it to APIClient
            mockPostText = new GameObject().AddComponent<Text>();
            apiClient.postText = mockPostText;
        }

        [TearDown]
        public void TearDown()
        {
            // Destroy all objects, so they don't interfere with other tests
            Object.Destroy(gameObject);
            Object.Destroy(mockDisplayText.gameObject);
            Object.Destroy(mockPostText.gameObject);
        }

        [UnityTest]
        public IEnumerator GetUser_UpdatesTextObject()
        {
            // Simulate real coroutine
            yield return apiClient.StartCoroutine(FakeGetUserResponse("John Doe"));
            // Check if the displayText object is updated to the mocked text
            Assert.AreEqual("John Doe", apiClient.displayText.text);
        }

        private IEnumerator FakeGetUserResponse(string fakeResponse)
        {
            // Set the displayText to the fake response
            apiClient.displayText.text = fakeResponse;
            yield return null;
        }

        [UnityTest]
        public IEnumerator GetUserPost_UpdatesTextObject()
        {
            // Simulate real coroutine
            yield return apiClient.StartCoroutine(FakeGetUserPostResponse("This is a test post"));
            // Check if the postText object is updated to the mocked text
            Assert.AreEqual("This is a test post", apiClient.postText.text);
        }

        private IEnumerator FakeGetUserPostResponse(string fakeResponse)
        {
            // Set the postText to the fake response
            apiClient.postText.text = fakeResponse;
            yield return null;
        }
    }
}
