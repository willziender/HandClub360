using HandClub360.core.Models;
using Microsoft.EntityFrameworkCore;

namespace HandClub360.data.Context;

public class ClubDbContext : DbContext
{
    public DbSet<Licencie> Licencies { get; set; }

    public DbSet<Equipe> Equipes { get; set; }

    public DbSet<Arbitre> Arbitres { get; set; }

    public DbSet<Materiel> Materiels { get; set; }

    public DbSet<OrdinateurMatch> OrdinateursMatch { get; set; }

    public DbSet<StockConsommables> StocksConsommables { get; set; }

    public DbSet<TrousseSecours> TroussesSecours { get; set; }

    public DbSet<TuteurLegal> TuteursLegaux { get; set; }

    public DbSet<AffectationEquipe> AffectationsEquipes { get; set; }

    public DbSet<Match> Matchs { get; set; }

    public DbSet<Convocation> Convocations { get; set; }

    public ClubDbContext(DbContextOptions<ClubDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AffectationEquipe>()
            .HasOne(a => a.Licencie)
            .WithMany(l => l.Affectations)
            .HasForeignKey(a => a.LicencieId);

        modelBuilder.Entity<AffectationEquipe>()
            .HasOne(a => a.Equipe)
            .WithMany(e => e.Affectations)
            .HasForeignKey(a => a.EquipeId);

        modelBuilder.Entity<TuteurLegal>()
            .HasOne(t => t.Licencie)
            .WithMany()
            .HasForeignKey(t => t.LicencieId);

        modelBuilder.Entity<Convocation>()
            .HasOne(c => c.Licencie)
            .WithMany(l => l.Convocations)
            .HasForeignKey(c => c.LicencieId);

        modelBuilder.Entity<Convocation>()
            .HasOne(c => c.Match)
            .WithMany(m => m.Convocations)
            .HasForeignKey(c => c.MatchId);
    }
}
