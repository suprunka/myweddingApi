using System;
namespace myweddingApi.Services
{
    public interface IFormService
    {
        bool AddMessage();
    }
    public class FormService :IFormService
    {
        public FormService()
        {
        }

        public bool AddMessage()
        {
            throw new NotImplementedException();
        }
    }
}
