using Catalog.Domain.Entities;
using Catalog.Domain.Responses.Item;

namespace Catalog.Domain.Mappers {
  public class ArtistMapper: IArtistMapper {
    public ArtistResponse Map(Artist artist) {
      if (artist == null) {
        return null;
      }

      return new ArtistResponse {
        ArtistId = artist.ArtistId,
        ArtistName = artist.ArtistName,
      };
    }
  }
}
