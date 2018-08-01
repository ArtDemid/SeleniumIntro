using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverIntro
{
    public class Test
    {
        private string name;
        private int iD;
        private List<object> data;

        public int id { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public List<object> Data { get => data; set => data = value; }

        public Test(int id, string name, List<object> data)
        {
            this.id = id;
            this.Name = name;
            this.Data = data;
        }
    }
}
