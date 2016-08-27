using System;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.Threading.Tasks;
namespace XF_CognitiveServiceSample.Services
{
    public class ImageService
    {
        readonly IMedia _currentInstance = CrossMedia.Current;

        public async Task<MediaFile> TakePhotoAsync()
        {
            if (_currentInstance.IsCameraAvailable && _currentInstance.IsTakePhotoSupported)
            {
                // Supply media options for saving our photo after it's taken.
                var mediaOptions = new StoreCameraMediaOptions
                {
                    Directory = "Receipts",
                    Name = $"{DateTime.UtcNow}.jpg",
                    DefaultCamera = CameraDevice.Front,
                    SaveToAlbum = false
                };

                // Take a photo of the business receipt.
                return await CrossMedia.Current.TakePhotoAsync(mediaOptions);
            }
            return null;
        }

        public async Task<MediaFile> PickPhotoAsync()
        {
            // Select a photo. 
            if (_currentInstance.IsPickPhotoSupported)
            {
                return await CrossMedia.Current.PickPhotoAsync();
            }
            return null;
        }
    }
}

