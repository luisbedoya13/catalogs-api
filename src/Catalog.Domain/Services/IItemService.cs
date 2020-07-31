using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Domain.Requests.Item;
using Catalog.Domain.Responses.Item;

namespace Catalog.Domain.Services {
  public interface IItemService {
    Task<IEnumerable<ItemResponse>> GetItemsAsync ();
    Task<ItemResponse> GetItemAsync (GetItemRequest request);
    Task<ItemResponse> AddItemAsync (AddItemRequest request);
    Task<ItemResponse> EditItemAsync (EditItemRequest request);
    // Task<ItemResponse> DeleteItemAsync (DeleteItemRequest request);
  }
}