using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNS.Common
{
    public static class Common
    {
        public static List<Role> GetRoles
        {
            get {
                return new List<Role>()
                {
                    new Role() { Id = 1, RoleName = "Administator" },
                    new Role() { Id = 2, RoleName = "Nhân Viên" },
                    new Role() { Id = 3, RoleName = "Người Phát Triển" },
                    new Role() { Id = 4, RoleName = "Quản Lý" },
                };
            }
        }
        public static List<Status> GetStatuses
        {
            get
            {
                return new List<Status>()
                {
                    new Status() { StatusId = 0, StatusName = "Không Hoạt động" },
                    new Status() { StatusId = 1, StatusName = "Hoạt động" }
                };
            }
        }
    }
}