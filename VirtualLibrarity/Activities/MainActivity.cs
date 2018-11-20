﻿using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Android.Views;
using Android.Content;
using Android.Support.Animation;
using System.Threading;

namespace VirtualLibrarity
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private SpringAnimation _springAnim;
        private bool _LoginPressed = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            View loginButton = FindViewById<Button>(Resource.Id.loginButton);
            View registerButton = FindViewById<Button>(Resource.Id.registerButton);


            loginButton.Click += (o, e) =>
            {
                _LoginPressed = true;
                _springAnim = new SpringAnimation(loginButton, DynamicAnimation.TranslationY, 0);
                _springAnim.Spring.SetStiffness(SpringForce.StiffnessVeryLow);
                _springAnim.Spring.SetDampingRatio(SpringForce.DampingRatioLowBouncy);
                _springAnim.SetStartVelocity(-300);
                _springAnim.Start();

                ThreadStart start = new ThreadStart(StartNewActivity);
                Thread thread = new Thread(start);
                thread.Start();
            };

            registerButton.Click += delegate
            {
                _springAnim = new SpringAnimation(registerButton, DynamicAnimation.TranslationY, 0);
                _springAnim.Spring.SetStiffness(SpringForce.StiffnessVeryLow);
                _springAnim.Spring.SetDampingRatio(SpringForce.DampingRatioLowBouncy);
                _springAnim.SetStartVelocity(300);
                _springAnim.Start();

                ThreadStart start = new ThreadStart(StartNewActivity);
                Thread thread = new Thread(start);
                thread.Start();
            };
        }

        private void StartNewActivity()
        {
            Intent intent;
            while (_springAnim.IsRunning)
            {
                Thread.Sleep(50);
            }
            if (_LoginPressed)
                intent = new Intent(this, typeof(LoginActivity));
            else
                intent = new Intent(this, typeof(RegisterActivity));
            StartActivity(intent);
        }
    }
}