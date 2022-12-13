using Microsoft.EntityFrameworkCore;
using TrainingAppAPI.DataModel.Entities;

namespace TrainingAppAPI.DataModel.Context
{
  public class TrainingAppAPIContext:DbContext
  {
    public TrainingAppAPIContext(DbContextOptions<TrainingAppAPIContext> options) : base(options)
    {

    }

    public virtual DbSet<CardItem> CardItem { get; set; }

  }
}
