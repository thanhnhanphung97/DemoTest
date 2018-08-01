using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoTest.Areas.Admin.Models
{
    public class SidebarModel
    {
        public int id;
        public string name;
        public string img;
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Img { get => img; set => img = value; }
    }
}