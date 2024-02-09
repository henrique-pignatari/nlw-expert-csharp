using Microsoft.EntityFrameworkCore;
using RocktseatAuction.API.Entities;

namespace RocktseatAuction.API.Repositories;

public class RocketseatAuctionDbContext : DbContext
{
    public RocketseatAuctionDbContext(DbContextOptions options): base(options)
    {
        
    }

    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; }
}
