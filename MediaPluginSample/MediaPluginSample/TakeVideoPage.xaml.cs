using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MediaPluginSample
{
    public partial class TakeVideoPage : ContentPage
    {
        public TakeVideoPage()
        {
            InitializeComponent();
            takeVideo.Clicked += async (sender, args) =>
            {
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakeVideoSupported)
                {
                    await DisplayAlert("No Video support", "Cant capture video", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
                {
                    Directory = "Sample"
                });

                if (file == null) return;

                await DisplayAlert("File Location", file.Path, "OK");

                video.Source = file.Path;
            };
        }
    }
}
