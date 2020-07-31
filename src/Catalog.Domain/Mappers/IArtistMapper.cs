using Catalog.Domain.Entities;
using Catalog.Domain.Responses.Item;

namespace Catalog.Domain.Mappers {
  public interface IArtistMapper {
    ArtistResponse Map(Artist artist);
  }
}
