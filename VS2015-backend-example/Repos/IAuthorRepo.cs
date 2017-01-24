using System.Collections.Generic;
using BackendStarter.Models;

namespace BackendStarter.Repos
{
	public interface IAuthorRepo
	{
		Author Add(Author author);
		bool Delete(int id);
		bool DeleteAll();
		Author Get(int id);
		IEnumerable<Author> GetAll();
		Author Save(Author author);
	}
}
