using Android.App;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

// Internet Connectivity //
[assembly: UsesPermission(Android.Manifest.Permission.AccessNetworkState)]
