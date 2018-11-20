using Android.App;
using Android.Content;
using Android.Database;
using Android.Database.Sqlite;
using Android.OS;
using Android.Widget;
using VirtualLibrarity.Database;

namespace VirtualLibrarity
{
    [Activity(Label = "Login")]
    public class LoginActivity : Activity
    {
        DbHelper _dbHelper;
        SQLiteDatabase _database;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);

            Button loginManualyButton = FindViewById<Button>(Resource.Id.ManualLoginButton);

            loginManualyButton.Click += delegate
            {
                EditText email = FindViewById<EditText>(Resource.Id.EmailET);
                EditText password = FindViewById<EditText>(Resource.Id.PasswordET);
                _dbHelper = new DbHelper(this);
                _database = _dbHelper.WritableDatabase;

                ICursor selectData = _database.RawQuery("select * from User where Email = '"
                    + email.Text + "' AND Password = '" + password.Text + "'", new string[] { });

                if (selectData.Count > 0)
                {
                    selectData.MoveToFirst();
                    Intent intent = new Intent(this, typeof(LoggedInActivity));
                    intent.PutExtra("userID", selectData.GetInt(selectData.GetColumnIndex("Id")).ToString());
                    StartActivity(intent);
                }
                else
                {
                    Toast.MakeText(this, "No user found", ToastLength.Long).Show();
                }
            };
        }
    }
}