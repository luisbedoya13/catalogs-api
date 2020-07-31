using Catalog.Domain.Entities;
using Catalog.Domain.Responses.Item;

namespace Catalog.Domain.Mappers {
  public interface IGenreMapper {
    GenreResponse Map(Genre genre);
  }
}
