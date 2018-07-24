﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace DemoTest.Models.DTO
{
    public class SidebarAdminDTO
    {
        public SidebarAdminDTO(int id,string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public SidebarAdminDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.Name = row["Name"].ToString();
        }


        private int id;
        [Required(ErrorMessage = "This is a required field.")]
        private string name;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}