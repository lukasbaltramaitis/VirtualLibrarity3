using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using RestSharp;

namespace VirtualLibrarity
{
    class RequestSender
    {
        public async Task<int> SendFaceAsync(string image64String, bool isForSave)
        {
            string apiUrl = "http://192.168.0.102:45455/api";

            RestClient client = new RestClient(apiUrl);
            var request = new RestRequest("/faces", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddBody(new { image64String, isForSave});


            var responseTask = client.ExecuteTaskAsync(request);
            var response = await responseTask;
            try
            {
                Console.Write(response.Content);
                Console.Write(response.StatusCode);
                return int.Parse(response.Content);
            }
            catch(Exception ex)
            {
                Console.Write(ex.Data);////
                return 0;
            }
        }
        public byte[] ConvertToByteArray(Bitmap bitmap)
        {
            MemoryStream stream = new MemoryStream();
            bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
            return stream.ToArray();
        }
    }
}