using AspireCMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspireCMS.ApiService.Contexts
{
    public class CMSContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Page> Pages => Set<Page>();
        public DbSet<Media> Media => Set<Media>();
        public DbSet<ContentBlock> ContentBlocks => Set<ContentBlock>();
    }
}
