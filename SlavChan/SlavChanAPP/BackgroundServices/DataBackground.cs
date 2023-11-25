

using SlavChanAPP.Repositories;

namespace SlavChanAPP.BackgroundServices
{
    public class DataBackground : BackgroundService
    {

        private readonly IServiceScopeFactory _scopeFactory;

        public DataBackground(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // temporary fix for updating time for specific records 
                using (var scope = _scopeFactory.CreateScope())
                {
                    var subjectRepository = scope.ServiceProvider.GetRequiredService<ISubjectRepository>();
                    subjectRepository.UpdateAllTime();
                    subjectRepository.Delete();
                }

                await Task.Delay(60000, stoppingToken);
            }
        }
    }
}