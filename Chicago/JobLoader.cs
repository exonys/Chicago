using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Chicago
{
    internal class JobLoader
    {
        public string Path { get; set; }

        public IEnumerable<Job> Load()
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

            foreach (string[] sp in lines.Select(s => s.Split(';')))
            {
                if (sp.Length != 2)
                {
                    throw new Exception("Check jobs input");
                }

                yield return new Job(sp[0], sp[1]);
            }
        }
    }
}