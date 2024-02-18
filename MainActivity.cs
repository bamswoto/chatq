using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Android.Content;
using System.IO;


namespace chatq
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            EditText editTextUsername = FindViewById<EditText>(Resource.Id.editTextUsername);
            EditText editTextPassword = FindViewById<EditText>(Resource.Id.editTextPassword);
            Button buttonLogin = FindViewById<Button>(Resource.Id.buttonLogin);
            Button buttonRegister = FindViewById<Button>(Resource.Id.buttonRegister);

            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "database.db");
            var db = new DatabaseHelper(dbPath);

            buttonLogin.Click += (sender, e) =>
            {
                string username = editTextUsername.Text;
                string password = editTextPassword.Text;

                var user = db.GetUserByUsernameAndPassword(username, password);
                


                if (user != null)
                {
                    // Login berhasil, arahkan ke halaman berikutnya
                    Intent intent = new Intent(this, typeof(ChatActivity));
                    StartActivity(intent);
                    Finish(); // Tutup halaman login
                }
                else
                {
                    // Login gagal, tampilkan pesan kesalahan kepada pengguna
                    Toast.MakeText(this, "Username or password is incorrect", ToastLength.Short).Show();
                }
            };

            buttonRegister.Click += (sender, e) =>
            {
                // Tambahkan kode untuk berpindah ke halaman registrasi di sini
                // Contoh:
                Intent intent = new Intent(this, typeof(RegisterActivity));
                StartActivity(intent);
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}