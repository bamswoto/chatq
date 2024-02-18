using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chatq
{
    public class ChatAdapter : BaseAdapter<string>
    {
        private List<string> messages;
        private Activity context;

        public ChatAdapter(Activity context)
        {
            this.context = context;
            messages = new List<string>();
        }

        public override string this[int position]
        {
            get { return messages[position]; }
        }

        public override int Count
        {
            get { return messages.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            }

            TextView textView = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            textView.Text = messages[position];

            return view;
        }

        public void AddMessage(string message)
        {
            messages.Add(message);
            NotifyDataSetChanged();
        }
    }
}