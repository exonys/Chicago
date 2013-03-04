using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog;

namespace Chicago
{
    internal class JobLoader
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public string Path { get; set; }

        public IEnumerable<Job> Load()
        {
            var lines = new List<string>();
            _logger.Trace("Reading");
            try
            {
                //TODO: Input format customization
                using (var r = new StreamReader(Path))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                _logger.Error("Reading failed: {0}", e.Message);
            }

            _logger.Trace("Parsing");
            foreach (var sp in lines.Select(s => s.Split(';')))
            {
                if (sp.Length != 2)
                {
                    _logger.Error("Job file is invalid!");
                    continue;
                }

                yield return new Job(sp[0], sp[1]);
            }
        }
    }
}