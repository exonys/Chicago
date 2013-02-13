using System;
using System.Collections.Generic;
using System.IO;

namespace Chicago
{
    internal class JobLoader
    {
        public string Path { get; set; }

        public Job[] Load()
        {
            //TODO: Better check validity check
            if (Path == null)
            {
                throw new Exception("Path is null");
            }

            //TODO: Input format customization
            var lines = new List<string>();
            using (var r = new StreamReader(Path))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            var jobs = new List<Job>();
            foreach (string s in lines) //TODO: Implement yield return
            {
                string[] sp = s.Split(';');

                if (sp.Length != 2)
                {
                    throw new Exception("Check jobs input");
                }

                var j = new Job(sp[0], sp[1]);
                jobs.Add(j);
            }

            return jobs.ToArray();
        }
    }
}