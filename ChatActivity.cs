using Android.App;
using Android.OS;
using Android.Widget;

namespace chatq
{
    [Activity(Label = "ChatActivity")]
    public class ChatActivity : Activity
    {
        ListView listViewMessages;
        EditText editTextMessage;
        Button buttonSend;
        ChatAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.chat_layout);

            // Inisialisasi komponen UI
            listViewMessages = FindViewById<ListView>(Resource.Id.listViewMessages);
            editTextMessage = FindViewById<EditText>(Resource.Id.editTextMessage);
            buttonSend = FindViewById<Button>(Resource.Id.buttonSend);

            // Inisialisasi adapter untuk daftar pesan
            adapter = new ChatAdapter(this);
            listViewMessages.Adapter = adapter;

            // Handler saat tombol kirim diklik
            buttonSend.Click += ButtonSend_Click;
        }

        private void ButtonSend_Click(object sender, System.EventArgs e)
        {
            // Ambil pesan dari input field
            string message = editTextMessage.Text;

            // Kirim pesan ke adapter untuk ditampilkan
            adapter.AddMessage(message);

            // Bersihkan input field
            editTextMessage.Text = "";
        }
    }
}