using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

namespace KarlStruv.ApiClient
{
    public class APIClient : MonoBehaviour
    {

        public Text displayText; // For user data
        public Text postText;    // For post data

        private const string BASE_URL = "http://localhost:8000"; //API local URL

        public void OnButtonClick()
        {
            GetUser();
            GetUserPost();
        }

        // Fetches User data from the "/user" endpoint
        private void GetUser()
        {
            StartCoroutine(GetUserRequest($"{BASE_URL}/user"));
        }

        // Fetches User Post data from the "/user/{id}/post" endpoint - {id} is hardcoded as nor users, nor posts are tied to any id due to no CRUD endpoints(unnecessary functionality for the task) 
        private void GetUserPost()
        {
            StartCoroutine(GetPostRequest($"{BASE_URL}/user/1/post")); 
        }

        // Coroutine to handle API request for User data
        private IEnumerator GetUserRequest(string url)
        {
            using UnityWebRequest request = UnityWebRequest.Get(url);
            {
                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    // Display user data
                    if (displayText != null)
                    {
                        displayText.text = request.downloadHandler.text;
                    }
                    else
                    {
                        Debug.LogError("displayText is not assigned!");
                    }
                }
                else
                {
                    Debug.LogError($"Error fetching user data: {request.error}");
                    if (displayText != null)
                    {
                        displayText.text = "Failed to load user data!";
                    }
                }
            }
        }

        // Coroutine to handle API request for User Post data
        private IEnumerator GetPostRequest(string url)
        {
            using UnityWebRequest request = UnityWebRequest.Get(url);
            {
                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    // Display post data
                    if (postText != null)
                    {
                        postText.text = request.downloadHandler.text;
                    }
                    else
                    {
                        Debug.LogError("postText is not assigned!");
                    }
                }
                else
                {
                    Debug.LogError($"Error fetching post data: {request.error}");
                    if (postText != null)
                    {
                        postText.text = "Failed to load post data!";
                    }
                }
            }
        }
    }
}
