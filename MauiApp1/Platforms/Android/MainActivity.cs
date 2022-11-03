using Android.App;
using Android.Content.PM;
using Android.Net.Http;
using Android.OS;
using Android.Runtime;
using Android.Webkit;
using Microsoft.Maui.Platform;
using WebView = Android.Webkit.WebView;
using WebViewClient =  Android.Webkit.WebViewClient;

namespace MauiApp1;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    public WebView rbWebView;
    //public WebSettings webSettings;
    /*public WebView rbWebView;*/
    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);
        Android.Webkit.WebView.SetWebContentsDebuggingEnabled(true);
        rbWebView = new WebView(this);
        rbWebView.SetWebViewClient(new myWebViewClient(this));
        //webSettings = rbWebView.Settings;
        //webSettings.DomStorageEnabled = true;
        //webSettings.JavaScriptEnabled = true;
        //webSettings.AllowFileAccess = true;
        //webSettings.AllowContentAccess = true;
        //webSettings.AllowFileAccessFromFileURLs = true;
        //webSettings.AllowUniversalAccessFromFileURLs = true;
        //rbWebView.ClearSslPreferences();
        rbWebView.LoadUrl("https://www.rambase.net");


    }

}

class myWebViewClient : WebViewClient
{
    MainActivity mainActivity;

    public myWebViewClient(MainActivity activity)
    {
        this.mainActivity = activity;
        
    }

    public override void OnReceivedSslError(WebView view, Android.Webkit.SslErrorHandler handler, SslError error)
    {
        //base.OnReceivedSslError(view, handler, error);
        Console.WriteLine("ok",error.Certificate);
        handler.Proceed(); // Ignore SSL certificate errors

    }


}
