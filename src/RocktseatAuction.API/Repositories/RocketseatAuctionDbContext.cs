using Microsoft.EntityFrameworkCore;
using RocktseatAuction.API.Entities;

namespace RocktseatAuction.API.Repositories;

public class RocketseatAuctionDbContext : DbContext
{
    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=C:\Users\henri\Desktop\RocketseatAuction\leilaoDbNLW.db");
    }
}
