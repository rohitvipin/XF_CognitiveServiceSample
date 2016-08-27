using Acr.UserDialogs;
using Xamarin.Forms;
namespace XF_CognitiveServiceSample.Services
{
    public class DialogService
    {
        readonly IUserDialogs _userDialog = UserDialogs.Instance;

        public void ShowLoading(string title)
        {
            _userDialog.Loading(title, null, null, true, MaskType.Clear);
        }

        public void HideLoading()
        {
            _userDialog.HideLoading();
        }
    }
}

