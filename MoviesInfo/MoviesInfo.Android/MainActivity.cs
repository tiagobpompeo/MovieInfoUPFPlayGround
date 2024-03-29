﻿using System;
using Plugin.Permissions;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms.Droid;
using MoviesInfo.Droid.Helpers;
using Acr.UserDialogs;
using Android.Net;
using Android.Content;

namespace MoviesInfo.Droid
{
    [Activity(Label = "MoviesInfo", Icon = "@mipmap/iclauncher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
            //Verificando Informacoes de Rede em Android
            ConnectivityManager conn = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            bool isConnected = conn.ActiveNetworkInfo != null && conn.ActiveNetworkInfo.IsConnected;
                                   //acesso a pasta do nosso aplicativo criando a base de dados com seu respectivo nome
            string dbPath = FileAccessHelper.GetLocalFilePath("lista.db3");
            UserDialogs.Init(this);
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App(dbPath));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}