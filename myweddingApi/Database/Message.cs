using System;
namespace myweddingApi.Database
{
    public class Message
    {
        public Message(string name, string contact, string text)
        {
            Name = name;
            Contact = contact;
            Text = text;
        }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Text { get; set; }
    }
}
