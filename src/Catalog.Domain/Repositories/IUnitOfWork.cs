using System;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Domain.Repositories {
  public interface IUnitOfWork : IDisposable {
    Task<int> SaveChangesAsync (CancellationToken cancelationToken = default(CancellationToken));
    Task<bool> SaveEntitiesAsync (CancellationToken cancellation = default(CancellationToken));
  }
}