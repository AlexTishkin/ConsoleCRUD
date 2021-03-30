using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class DbInitializer
    {
        private IDbFactory _dbFactory;

        public DbInitializer(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public void Initialize()
        {
            var itGenre = new Genre(Guid.Parse("66F5D6DB-9CF8-49CD-AFF9-019D2051EBE0"), "ИТ");
            var psychoGenre = new Genre(Guid.Parse("416F9C2B-D828-4FC0-BF65-7BA02021743D"), "Психология");
            var genres = new List<Genre> { itGenre, psychoGenre };

            var shildt = new Author(Guid.Parse("1198DB46-C393-4C33-83E1-CD3001DCAEDB"), "Шилдт");
            var richter = new Author(Guid.Parse("E82801A5-D111-4544-91F1-023DF254FD0B"), "Рихтер");
            var skit = new Author(Guid.Parse("06E9DC4B-199E-4D42-ACD6-4036A09A5BD5"), "Скит");
            var authors = new List<Author> { shildt, richter, skit };

            using (var db = _dbFactory.CreateDb())
            {
                var isEmptyDatabase = db.Genres.Count() == 0;
                if (!isEmptyDatabase) return;

                db.Genres.AddRange(genres);
                db.Authors.AddRange(authors);
                db.SaveChanges();
            }
        }
    }
}
