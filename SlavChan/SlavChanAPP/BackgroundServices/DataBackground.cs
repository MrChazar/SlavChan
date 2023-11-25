using SlavChanAPP.Repositories;

namespace SlavChanAPP.BackgroundServices
{
    public class DataBackground : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        public DataBackground(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var subjectRepository = scope.ServiceProvider.GetRequiredService<ISubjectRepository>();
            while (!stoppingToken.IsCancellationRequested)
            {
                subjectRepository.UpdateTime();
                subjectRepository.Delete();
                await Task.Delay(60000, stoppingToken);
            }
        }
    }
}
