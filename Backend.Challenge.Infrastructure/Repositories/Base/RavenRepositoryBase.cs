using Raven.Client.Documents;

namespace Backend.Challenge.Infrastructure.Repositories
{
    public class RavenRepositoryBase
    {
        protected readonly DocumentStore _documentStore;
        public RavenRepositoryBase()
        {
            _documentStore = new DocumentStore()
            {
                Urls = new string[] { "http://localhost:8080/" },
                Database = "MainDB"
            };
            _documentStore.Initialize();
        }
    }
}