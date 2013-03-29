using System.Threading.Tasks;
using Chicago.JobHandlers;
using NLog;

namespace Chicago
{
    internal class JobDispatcher
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     Represents successful jobs count
        /// </summary>
        public int Successful { get; private set; }

        /// <summary>
        ///     Represents failed jobs count
        /// </summary>
        public int Bad { get; private set; }

        /// <summary>
        ///     This is handler class
        /// </summary>
        public object Handler { private get; set; }

        public void Execute()
        {
            //TODO: Real Job Loader?
            _logger.Trace("Loading jobs");
            var jobLoader = new JobLoader {Path = "test_job.txt"}; //It should get path from UI

            //TODO: ThreadPool?
            //This multi-threading method is CPU efficient, but it's limited to logical processors count
            _logger.Trace("Doing jobs");
            var d = jobLoader.Load();
            Parallel.ForEach(jobLoader.Load(), Check); 
        }

        private void Check(Job job)
        {
            //TODO: Handler choose
            var handler = (Test1) Handler;
            handler.Job = job;
            handler.Process();
            if (handler.Job.IsSuccessful)
            {
                Successful++;
            }
            else
            {
                Bad++;
            }
        }
    }
}