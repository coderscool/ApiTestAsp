using Microsoft.EntityFrameworkCore;
using TestApiPictur.Models;

namespace TestApiPictur.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pictur>().HasData(
                new Pictur() { PicturId = 1, Title = "hello", Leter = "xin chao" }
                );
        }
    }
}
