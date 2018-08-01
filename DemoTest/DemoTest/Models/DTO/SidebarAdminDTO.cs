using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace DemoTest.Models.DTO
{
    public class SidebarAdminDTO
    {
        public SidebarAdminDTO(int id,string name,string img)
        {
            this.Id = id;
            this.Name = name;
        }

        public SidebarAdminDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.Name = row["Name"].ToString();
            this.Img = row["Img"].ToString();
        }


        private int id;
        [Required(ErrorMessage = "This is a required field.")]
        private string name;
        private string img;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Img { get => img; set => img = value; }
    }
}