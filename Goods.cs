using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExportApp
{

        public class Goods
        {
            private String _id;
            private String _name;
            private String _price;


            public string id { get => _id; set => _id = value; }
            public string name { get => _name; set => _name = value; }
            public string price { get => _price; set => _price = value; }
        }
    
}
