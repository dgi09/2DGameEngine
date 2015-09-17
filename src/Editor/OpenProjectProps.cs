using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public enum OpenType
    {
        New,
        Existing
    }
    public class OpenProjectProps
    {
        public OpenType Type { get; set; }
        public string ProjectFolder { get; set; }
        public string ProjectFile { get; set; }
        public string ProjectName { get; set; }
    }
}
