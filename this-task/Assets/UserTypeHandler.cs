using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class UserTypeHandler : MonoBehaviour
{
    private string userTypeEndpoint = "http://localhost:3001/user-type"; // Update to your backend URL

    // Method to start fetching the user type from the backend
    public void FetchUserType()
    {
        StartCoroutine(GetUserType());
    }

    // Coroutine to fetch the user type from the backend
    IEnumerator GetUserType()
    {
        UnityWebRequest www = UnityWebRequest.Get(userTypeEndpoint);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"Error: {www.error}");
        }
        else
        {
            string jsonResponse = www.downloadHandler.text;
            Debug.Log($"Received JSON response: {jsonResponse}");

            try
            {
                // Deserialize JSON using JsonUtility
                UserTypeResponse response = JsonUtility.FromJson<UserTypeResponse>(jsonResponse);
                if (response == null)
                {
                    throw new System.ArgumentException("Invalid JSON format");
                }

                Debug.Log($"Received user type: {response.userType}");
                // Do something with the received user type
            }
            catch (System.Exception e)
            {
                Debug.LogError($"JSON parse error: {e.Message}");
            }
        }
    }

    [System.Serializable]
    public class UserTypeResponse
    {
        public string userType;
    }
}
