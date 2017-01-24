using System.Collections.Generic;
using System.Linq;
using BackendStarter.Models;

namespace BackendStarter.Repos
{
	public class AuthorRepo : IAuthorRepo
	{
		BackendStarterContext db;

		public AuthorRepo(BackendStarterContext context)
		{
			db = context;
		}

		public Author Add(Author author)
		{
			db.Authors.Add(author);
			db.SaveChanges();
			return author;
		}

		public bool Delete(int id)
		{
			var author = db.Authors.Find(id);

			if (author == null)
			{
				return false;
			}

			db.Authors.Remove(author);
			return db.SaveChanges() > 0;
		}

		public bool DeleteAll()
		{
			db.Authors.RemoveRange(db.Authors);
			return db.SaveChanges() > 0;
		}

		public Author Get(int id)
		{
			return db.Authors.Find(id);
		}

		public IEnumerable<Author> GetAll()
		{
			return db.Authors.ToList();
		}

		public Author Save(Author author)
		{
			db.Authors.Update(author);
			db.SaveChanges();
			return author;
		}
	}
}
