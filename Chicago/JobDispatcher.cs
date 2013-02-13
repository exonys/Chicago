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
            var job = new Job[25];
            Parallel.ForEach(job, job1 =>
                {
                    //TODO: Handler choose
                    var handler = new Test1 {Job = job1};
                    handler.Process();
                    if (handler.Job.IsSuccess)
                    {
                        Successful++;
                    }
                    else
                    {
                        Bad++;
                    }
                });
        }
    }
}