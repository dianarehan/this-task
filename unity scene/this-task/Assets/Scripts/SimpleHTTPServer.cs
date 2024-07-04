using System;
using System.Net;
using System.Text;
using UnityEngine;

public class SimpleHTTPServer : MonoBehaviour
{
    private HttpListener _httpListener;
    void Start()
    {
        try
        {
            _httpListener = new HttpListener();
            _httpListener.Prefixes.Add("http://*:3001/");
            _httpListener.Start();
            _httpListener.BeginGetContext(OnRequest, _httpListener);
            Debug.Log("Server started and listening on http://*:3001/");
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to start server: " + e.Message);
        }
    }

    private void OnRequest(IAsyncResult result)
    {
        var context = _httpListener.EndGetContext(result);
        var request = context.Request;
        var response = context.Response;

        Debug.Log("Received a request: " + request.HttpMethod);

        if (request.HttpMethod == "OPTIONS")
        {
            response.AddHeader("Access-Control-Allow-Origin", "*");
            response.AddHeader("Access-Control-Allow-Methods", "POST, GET, OPTIONS");
            response.AddHeader("Access-Control-Allow-Headers", "Content-Type");
            response.StatusCode = (int)HttpStatusCode.OK;
            response.Close();
        }
        else if (request.HttpMethod == "POST")
        {
            using (var reader = new System.IO.StreamReader(request.InputStream, request.ContentEncoding))
            {
                string requestData = reader.ReadToEnd();
                Debug.Log("Received data: " + requestData);

                var json = JsonUtility.FromJson<ReceivedData>(requestData);
                Debug.Log("User type: " + json.userType);
                DragObject.setTheUserType((string)json.userType);
            }

            string responseString = "Data received";
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            var responseOutput = response.OutputStream;
            responseOutput.Write(buffer, 0, buffer.Length);
            responseOutput.Close();
        }

        _httpListener.BeginGetContext(OnRequest, _httpListener);
    }

    void OnApplicationQuit()
    {
        if (_httpListener != null && _httpListener.IsListening)
        {
            _httpListener.Stop();
            _httpListener.Close();
        }
    }

    [Serializable]
    private class ReceivedData
    {
        public string userType;
    }
}
