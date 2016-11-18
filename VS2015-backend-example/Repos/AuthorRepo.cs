using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendStarter.Models;

namespace BackendStarter.Repos
{
    public class AuthorRepo : IAuthorRepo
    {
        private List<Author> _allAuthors;
        public AuthorRepo()
        {
            _allAuthors = new List<Author>()
            {
                new Author() {
                    Id = 0,
                    FirstName = "Cory",
                    LastName = "House"
                },
                new Author() {
                    Id = 1,
                    FirstName = "Scott",
                    LastName = "Allen"
                },
                new Author() {
                    Id = 2,
                    FirstName = "Dan",
                    LastName = "Wahlin"
                }
            };
        }

        public IEnumerable<Author> GetAll()
        {
            return _allAuthors.OrderBy(a => a.LastName);
        }

        public Author Get(int id)
        {
            return _allAuthors.Where(a => a.Id == id).FirstOrDefault();
        }

        public int Add(Author newAuthor)
        {
            int newId = _allAuthors.OrderByDescending(a => a.Id).Select(a => a.Id).FirstOrDefault() + 1;
            newAuthor.Id = newId;
            _allAuthors.Add(newAuthor);

            return newId;
        }

        public bool Save(Author updAuthor)
        {
            var currAuthor = _allAuthors.Where(a => a.Id == updAuthor.Id).FirstOrDefault();
            if (currAuthor != null)
            {
                currAuthor.FirstName = updAuthor.FirstName;
                currAuthor.LastName = updAuthor.LastName;
                return true;
            }

            return false;
        }

        public bool Delete()
        {
            _allAuthors.Clear();

            return true;
        }

        public bool Delete(int id)
        {
            var delAuthor = _allAuthors.Where(a => a.Id == id).FirstOrDefault();
            if (delAuthor != null)
            {
                _allAuthors.Remove(delAuthor);
                return true;
            }

            return false;
        }

    }
}
