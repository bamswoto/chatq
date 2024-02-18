using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace chatq
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.register_layout);

            EditText editTextUsername = FindViewById<EditText>(Resource.Id.editTextUsername);
            EditText editTextEmail = FindViewById<EditText>(Resource.Id.editTextEmail);
            EditText editTextPassword = FindViewById<EditText>(Resource.Id.editTextPassword);
            Button buttonRegister = FindViewById<Button>(Resource.Id.buttonRegister);

            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "database.db");
            var db = new DatabaseHelper(dbPath);

            buttonRegister.Click += (sender, e) =>
            {
                var user = new User
                {
                    Username = editTextUsername.Text,
                    Email = editTextEmail.Text,
                    Password = editTextPassword.Text
                };

                int rowsAdded = db.AddUser(user);

                if (rowsAdded > 0)
                {
                    // Pendaftaran berhasil, arahkan ke halaman login
                    Intent intent = new Intent(this, typeof(MainActivity));
                    StartActivity(intent);
                    Finish(); // Tutup halaman pendaftaran
                }
                else
                {
                    // Gagal mendaftarkan pengguna, tampilkan pesan kesalahan
                    Toast.MakeText(this, "Failed to register user", ToastLength.Short).Show();
                }
            };
        }
    }
}