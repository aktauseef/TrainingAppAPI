using TrainingAppAPI.DataModel.Interfaces;
using TrainingAppAPI.DataModel.Repositories;

namespace TrainingAppAPI.Extensions
{
  public static class DependencyExtension
  {
    public static void ConfigureDomainServices(this IServiceCollection services)
    {
      services.AddTransient<IPaymentRepository, PaymentRepository>();
    }
  }
}
