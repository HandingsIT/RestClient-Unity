using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class WebAPIClient
{
    protected readonly ISerializationOption _serializationOption;

    public WebAPIClient(ISerializationOption serializationOption)
    {
        _serializationOption = serializationOption;
    }

    #region Get Methods
    //--------------------------------------- GET ------------------------------------------------
    // HTTP GET Async
    [ContextMenu("Test Get")]
    public async Task<TResultType> GetAsync<TResultType>(string url)
    {
        try
        {
            using var request = UnityWebRequest.Get(url);

            request.SetRequestHeader("Content-Type", _serializationOption.ContentType);

            var sendRequest = request.SendWebRequest();

            while (!sendRequest.isDone)
            {
                await Task.Yield();
            }

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log($"Request Result : {request.result}, Error Code : {request.responseCode}, Error Message : {request.error}");
                return default;
            }

            var result = _serializationOption.Deserialize<TResultType>(request.downloadHandler.text);
            return result;
        }
        catch (Exception ex)
        {
            Debug.Log($"[{nameof(GetAsync)}] Failed : {ex.Message}");
            return default;
        }
    }

    #endregion

    #region Post Methods
    //--------------------------------------- POST ------------------------------------------------
    public async Task<TResultType> PostAsync<TResultType, TRequestValue>(string url, TRequestValue requestValue)
    {
        try
        {
            var json = JsonConvert.SerializeObject(requestValue);

            using (var request = UnityWebRequest.PostWwwForm(url, json))
            {
                byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
                request.uploadHandler = new UploadHandlerRaw(jsonToSend);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", _serializationOption.ContentType);


                var sendRequest = request.SendWebRequest();

                while (!sendRequest.isDone)
                {
                    await Task.Yield();
                }


                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log($"Request Result : {request.result}, Error Code : {request.responseCode}, Error Message : {request.error}");

                    return default;
                }

                var result = _serializationOption.Deserialize<TResultType>(request.downloadHandler.text);
                return result;
            }

        }
        catch (Exception ex)
        {
            Debug.Log($"[{nameof(PostAsync)}] Failed : {ex.Message}");
            return default;
        }
    }

    #endregion

    #region Put Methos
    //--------------------------------------- PUT ------------------------------------------------
    //To Do : HTTP Put Async
    public async Task<TResultType> PutAsync<TResultType, TRequestValue>(string url, TRequestValue requestValue)
    {
        try
        {
            var json = JsonConvert.SerializeObject(requestValue);

            using (var request = UnityWebRequest.Put(url, json))
            {
                byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
                request.uploadHandler = new UploadHandlerRaw(jsonToSend);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", _serializationOption.ContentType);

                var sendRequest = request.SendWebRequest();

                while (!sendRequest.isDone)
                {
                    await Task.Yield();
                }

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log($"Request Result : {request.result}, Error Code : {request.responseCode}, Error Message : {request.error}");

                    return default;
                }

                var result = _serializationOption.Deserialize<TResultType>(request.downloadHandler.text);
                return result;
            }

        }
        catch (Exception ex)
        {
            Debug.Log($"[{nameof(PostAsync)}] Failed : {ex.Message}");
            return default;
        }
    }

    #endregion

    #region Delete Method
    //--------------------------------------- Delete ------------------------------------------------
    // HTTP Delete Async
    [ContextMenu("Test Delete")]
    public async Task<TResultType> DeleteAsync<TResultType>(string url, int id)
    {
        try
        {
            using var request = UnityWebRequest.Delete(url + $"/{id}");

            // Delete Method is not contain downloadHandler
            request.downloadHandler = new DownloadHandlerBuffer();

            request.SetRequestHeader("Content-Type", _serializationOption.ContentType);

            var sendRequest = request.SendWebRequest();

            while (!sendRequest.isDone)
            {
                await Task.Yield();
            }

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log($"Request Result : {request.result}, Error Code : {request.responseCode}, Error Message : {request.error}");
                return default;
            }

            var result = _serializationOption.Deserialize<TResultType>(request.downloadHandler.text);
            return result;

        }
        catch (Exception ex)
        {
            Debug.Log($"[{nameof(DeleteAsync)}] Failed : {ex.Message}");
            return default;
        }
    }

    #endregion

}
