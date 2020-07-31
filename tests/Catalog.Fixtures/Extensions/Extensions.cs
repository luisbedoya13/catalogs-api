using System.IO;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Catalog.Fixtures.Extensions {
  public static class Extensions {
    public static ModelBuilder Seed<T> (
      this ModelBuilder modelBuilder,
      string file
    ) where T : class {
      using var reader = new StreamReader(file);
      var json = reader.ReadToEnd();
      var data = JsonConvert.DeserializeObject<T[]>(json);
      modelBuilder.Entity<T>().HasData(data);
      return modelBuilder;
    }
  }
}