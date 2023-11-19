using SlavChanAPP.Repositories;

namespace SlavChanAPP.BackgroundServices
{
    public class DataBackground : BackgroundService
    {
        private readonly ISubjectRepository _subjectRepository;
        public DataBackground(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _subjectRepository.UpdateTime();
                _subjectRepository.Delete();
                Console.WriteLine("Dupa");
                await Task.Delay(10, stoppingToken);
            }
        }
    }
}
