using System.Collections.Generic;
using BackendStarter.Models;

namespace BackendStarter.Repos
{
    public interface IAuthorRepo
    {
        int Add(Author newAuthor);
        bool Delete();
        bool Delete(int id);
        Author Get(int id);
        IEnumerable<Author> GetAll();
        bool Save(Author updAuthor);
    }
}