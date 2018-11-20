using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using RestSharp;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using Xamarin.Forms;

namespace VirtualLib
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
           
            InitializeComponent();
            takePhoto.Clicked += async (sender, args) =>
            {

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                    return;
                }

                 var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front,
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    Directory = "Sample",
                    Name = "test.jpg"
                });
                

                if (file == null)
                    return;

                await DisplayAlert("File Location", file.Path, "OK");
                
                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
                byte[] imageBytes=FindFile(file.Path);
                SendFace(imageBytes, false);
                File.Delete(file.Path);
                
            };
            
        }
        public byte[] FindFile(string path)
        {
           return File.ReadAllBytes(path);
        }
        public void SendFace(byte[] imageBytes, bool isForSave)
        {
            string apiUrl = "http://192.168.0.102:45455/api";

            string image64String = Convert.ToBase64String(imageBytes);
            RestClient client = new RestClient(apiUrl);
            //RestRequest request = new RestRequest("Values/{id}",Method.POST);
            //request.AddFile("face",path);
            //request.AddParameter("value", "String1");
            //request.AddUrlSegment("id", 0);
            var request = new RestRequest("/Values", Method.POST) { RequestFormat = DataFormat.Json };
            //request.AddFile("faceImage", path);
            //request.AddParameter("imageIsForSaving",false);
            //request.AddFile("face",path);
            
            request.AddBody(new { image64String, isForSave });
          
            
            var response = client.Execute(request);
            if (response.Content == "true")
            { 
                Debug.WriteLine(response.StatusCode);
                Debug.WriteLine(response.Content);
            }
            else 
            {
                Debug.WriteLine(response.StatusCode);
                Debug.WriteLine(response.Content);
            }
                    

            // var request2 = new RestRequest("Values/0", Method.GET) { RequestFormat = DataFormat.Json };
            //client.ExecuteAsync(request,response => )






        }
        
    }
}
