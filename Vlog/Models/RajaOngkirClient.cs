using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Text;


namespace Vlog.Models
{
  public class RajaOngkirClient
  {
    private string BaseUrl { get; set; }
    private string ApiKey { get; set; }
    private string Mode { get; set; }
    public string DefaultCourier { get; private set; }
    public string DefaultService { get; private set; }
    public RajaOngkirClient(IConfiguration configuration)
    {
      ApiKey = configuration["RajaOngkir:ApiKey"];
      BaseUrl = configuration["RajaOngkir:Url"];
      Mode = configuration["RajaOngkir:Mode"];
      DefaultCourier = configuration["RajaOngkir:DefaultCourier"];
      DefaultService = configuration["RajaOngkir:DefaultService"];
    }

    public JObject GetPrice(string originId, string destinationId, int weight, string courier = null)
    {
      if (courier == null)
        courier = DefaultCourier;

      var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{BaseUrl}/{Mode}/cost");
      httpWebRequest.Method = "POST";
      httpWebRequest.Headers.Add("key", ApiKey);
      
      var postData = $"origin={originId}";
      postData += $"&destination={destinationId}";
      postData += $"&weight={weight}";
      postData += $"&courier={courier}";
      var data = Encoding.ASCII.GetBytes(postData);

      httpWebRequest.ContentType = "application/x-www-form-urlencoded";
      httpWebRequest.ContentLength = data.Length;

      using (var stream = httpWebRequest.GetRequestStream())
      {
        stream.Write(data, 0, data.Length);
      }

      var response = (HttpWebResponse)httpWebRequest.GetResponse();
      var jsonString = new StreamReader(response.GetResponseStream()).ReadToEnd();
      
      return JObject.Parse(jsonString);
    }

    public JObject GetCities(string provinceId = null)
    {
      var url = $"{BaseUrl}/{Mode}/city";

      if (provinceId != null)
        url += $"?province={provinceId}";

      var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
      httpWebRequest.Method = "GET";
      httpWebRequest.Headers.Add("key", ApiKey);

      var response = (HttpWebResponse)httpWebRequest.GetResponse();
      var jsonString = new StreamReader(response.GetResponseStream()).ReadToEnd();

      return JObject.Parse(jsonString);
    }

    public JObject GetCity(string provinceId, string cityId)
    {
      var url = $"{BaseUrl}/{Mode}/city?province={provinceId}&id={cityId}";

      var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
      httpWebRequest.Method = "GET";
      httpWebRequest.Headers.Add("key", ApiKey);

      var response = (HttpWebResponse)httpWebRequest.GetResponse();
      var jsonString = new StreamReader(response.GetResponseStream()).ReadToEnd();

      return JObject.Parse(jsonString);
    }

    public JObject GetProvincies()
    {
      var url = $"{BaseUrl}/{Mode}/province";

      var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
      httpWebRequest.Method = "GET";
      httpWebRequest.Headers.Add("key", ApiKey);

      var response = (HttpWebResponse)httpWebRequest.GetResponse();
      var jsonString = new StreamReader(response.GetResponseStream()).ReadToEnd();

      return JObject.Parse(jsonString);
    }

    public JObject GetProvince(string provinceId)
    {
      var url = $"{BaseUrl}/{Mode}/province?id={provinceId}";

      var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
      httpWebRequest.Method = "GET";
      httpWebRequest.Headers.Add("key", ApiKey);

      var response = (HttpWebResponse)httpWebRequest.GetResponse();
      var jsonString = new StreamReader(response.GetResponseStream()).ReadToEnd();

      return JObject.Parse(jsonString);
    }
  }
}
