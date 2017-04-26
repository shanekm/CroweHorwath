using System;
using System.Web.Http;
using Contracts.Abstract;

namespace RestfulService.Controllers
{
    public class MessageController : ApiController
    {
        private readonly IStoreReader _reader;
        private readonly IStoreWriter _writer;

        public MessageController(IStoreReader reader, IStoreWriter writer)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            _reader = reader;
            _writer = writer;
        }

        public string Get()
        {
            return _reader.Read();
        }

        public void Post([FromBody] string value)
        {
            _writer.Write(value);
        }
    }
}