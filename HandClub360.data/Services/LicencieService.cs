using HandClub360.core.Models;
using HandClub360.data.Context;
using Microsoft.EntityFrameworkCore;

namespace HandClub360.data.Services;

public class LicencieService
{
    public async Task<List<Licencie>> GetAllAsync()
    {
        using var db = ClubDbContextFactory.Create();

        return await db.Licencies.ToListAsync();
    }

    public async Task AjouterAsync(
        Licencie licencie)
    {
        using var db = ClubDbContextFactory.Create();

        db.Licencies.Add(licencie);

        await db.SaveChangesAsync();
    }

    public async Task SupprimerAsync(
        Guid id)
    {
        using var db = ClubDbContextFactory.Create();

        var licencie =
            await db.Licencies.FindAsync(id);

        if (licencie != null)
        {
            db.Remove(licencie);

            await db.SaveChangesAsync();
        }
    }
}