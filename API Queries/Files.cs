using System;
using System.Collections.Generic;
using System.Text;

namespace API_Queries
{
    public class Files
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Content { get; set; }

        public Files(string path)
        {
            Path = path;
        }
    }
}
