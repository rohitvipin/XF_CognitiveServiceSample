using System;
using Xamarin.Forms;
using XF_CognitiveServiceSample.Services;
using System.Linq;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;

namespace XF_CognitiveServiceSample
{
    public partial class XF_CognitiveServiceSamplePage : ContentPage
    {
        readonly CognitiveService _cognitiveService = new CognitiveService();
        readonly ImageService _imageService = new ImageService();
        readonly DialogService _dialogService = new DialogService();


        public XF_CognitiveServiceSamplePage()
        {
            InitializeComponent();
            titleLabel.Text = "Select Image";
        }

        async Task GetImageDetailsAsync(MediaFile image)
        {
            try
            {
                IsBusy = true;

                _dialogService.ShowLoading("Analysing Image...");
                selectedImage.Source = ImageSource.FromFile(image.Path);
                var analysis = await _cognitiveService.GetImageDetailsAsync(image.GetStream());
                titleLabel.Text = string.Join(Environment.NewLine, analysis.Description.Captions.Select(x => x.Text));
                descLabel.Text = string.Join(", ", analysis.Tags.Select(x => x.Name));
                _dialogService.HideLoading();
            }
            finally
            {
                IsBusy = false;
                _dialogService.HideLoading();
            }
        }

        async void PickPhotoButton_Clicked(object sender, EventArgs e)
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                using (var image = await _imageService.PickPhotoAsync())
                {
                    await GetImageDetailsAsync(image);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        async void ClickPhotoButton_Clicked(object sender, EventArgs e)
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                using (var image = await _imageService.TakePhotoAsync())
                {
                    await GetImageDetailsAsync(image);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }
    }
}

