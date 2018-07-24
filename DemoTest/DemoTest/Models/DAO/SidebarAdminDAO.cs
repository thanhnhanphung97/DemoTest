using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DemoTest.Models.DTO;
namespace DemoTest.Models.DAO
{
    public class SidebarAdminDAO
    {
        private static SidebarAdminDAO instance;

        public static SidebarAdminDAO Instance { get { if (instance == null) instance = new SidebarAdminDAO(); return SidebarAdminDAO.instance; }; private set => instance = value; }

        private SidebarAdminDAO() { }

        public List<SidebarAdminDTO> GetListSidebarAdmin()
        {
            List<SidebarAdminDTO> list = new List<SidebarAdminDTO>();
            string query = "USP_GetAll_Sidebar";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                SidebarAdminDTO sidebar = new SidebarAdminDTO(item);
                list.Add(sidebar);
            }

            return list;
        }

        public bool InsertSidebar(string name)
        {
            string query = "USP_Add_Sidebar @name";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name });
            return result > 0;
        }

        public bool EditSidebar(int id, string name)
        {
            string query = "USP_Edit_Sidebar @id , @name";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, name });
            return result > 0;
        }

        public bool DeleteSidebar(int id)
        {
            string query = "USP_Delete_Sidebar @id";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
            return result > 0;
        }
    }
}