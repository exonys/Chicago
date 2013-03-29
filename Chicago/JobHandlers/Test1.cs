using System;
using System.Windows.Forms;

namespace Chicago.JobHandlers
{
    internal sealed class Test1
    {
        /// <summary>
        ///     Job to be done by JobHandler
        /// </summary>
        public Job Job;

        /// <summary>
        ///     Runs checking process
        /// </summary>
        public void Process()
        {
            //Run some checks before check
            if (Job == null)
            {
                throw new Exception("Job is null. Check JobDispatcher.cs");
            }
            Job.IsSuccessful = Check();
        }

        /// <summary>
        ///     Runs given job
        /// </summary>
        /// <returns></returns>
        private static bool Check()
        {
            MessageBox.Show("DB");
            //Checking code should be here
            return true;
        }
    }
}