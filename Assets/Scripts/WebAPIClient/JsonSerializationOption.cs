using Newtonsoft.Json;
using System;
using UnityEngine;

public class JsonSerializationOption : ISerializationOption
{
    public string ContentType => "application/json";

    public T Deserialize<T>(string text)
    {
        try
        {
            var result = JsonConvert.DeserializeObject<T>(text);

            return result;
        }
        catch (Exception ex)
        {
            Debug.Log($"Could not parse response {text}. {ex.Message}");

            return default;
        }
    }
}
