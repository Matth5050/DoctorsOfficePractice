using Microsoft.EntityFrameworkCore;

namespace DocOffice.Models
{
  public class DocOfficeContext : DbContext
  {
    public DbSet<Spec> Specs { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<SpecDoctor> SpecDoctor { get; set; }

    public DocOfficeContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}