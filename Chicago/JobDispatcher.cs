using System.Threading.Tasks;
using Chicago.JobHandlers;

namespace Chicago
{
    internal class JobDispatcher
    {
        /// <summary>
        ///     Represents successful jobs count
        /// </summary>
        public int Successful { get; private set; }

        /// <summary>
        ///     Represents not successful jobs count
        /// </summary>
        public int Bad { get; private set; }

        public void Execute()
        {
            //TODO: Job Loader?
            var jobLoader = new JobLoader {Path = "test_job.txt"};

            Parallel.ForEach(jobLoader.Load(), CheckThread);
        }

        private void CheckThread(Job job)
        {
            //TODO: Handler choose
            var handler = new Test1 {Job = job};
            handler.Process();
            if (handler.Job.IsSuccess)
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