using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Auth;
using Xamarin.Forms;

namespace Capstone
{
    public class App : Application
    {
        public App()
        {

        }

        protected override void OnStart()
        {
            Auth auth = new Auth();
            auth.LoginWithGoogle();

            // The root page of your application
            var content = new ContentPage
            {
                Title = "GeoMessage - Leave your mark",
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Children = {
                        new Label {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = auth.testText
                        }
                    }
                }
            };

            MainPage = new NavigationPage(content);
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
