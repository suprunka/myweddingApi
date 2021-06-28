using System;
using MongoDB.Driver;
using myweddingApi.Configuration;
using myweddingApi.Database;

namespace myweddingApi.Repositories
{
    public interface IMessageRepository
    {
        Message Create(Message book);
    }
    public class MessageRepository : IMessageRepository
    {
        private readonly IMongoCollection<Message> _messages;

        public MessageRepository(IDatabaseConfiguration settings)
        {
            var client = new MongoClient(Environment.GetEnvironmentVariable("DATABASE_URL"));
            var database = client.GetDatabase(settings.DatabaseName);

            _messages = database.GetCollection<Message>(settings.MessagesCollectionName);
        }
        public Message Create(Message book)
        {
            book.CreatedAt = DateTime.UtcNow;
            _messages.InsertOne(book);
            return book;
        }
    }
}
