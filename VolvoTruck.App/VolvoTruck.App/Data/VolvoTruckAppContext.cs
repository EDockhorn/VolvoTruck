﻿using Microsoft.EntityFrameworkCore;
using VolvoTruck.App.Models;

public class VolvoTruckAppContext : DbContext
{
    public VolvoTruckAppContext(DbContextOptions<VolvoTruckAppContext> options)
        : base(options)
    {
    }

    public DbSet<Truck> Trucks { get; set; }
}
