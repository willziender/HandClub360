using Microsoft.EntityFrameworkCore;

namespace HandClub360.data.Context;

public static class ClubDbContextFactory
{
    public static ClubDbContext Create()
    {
        var options =
            new DbContextOptionsBuilder<ClubDbContext>()
                .UseSqlite("Data Source=club.db")
                .Options;

        return new ClubDbContext(options);
    }
}