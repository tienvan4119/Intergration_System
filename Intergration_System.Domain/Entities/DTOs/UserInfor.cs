using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Domain.DTOs
{
    public interface IUserInfor
    {
        int Id { get; set; }    
        string UserName { get; set; }
        string FullName { get; set; }
        int TenantId { get; set; }
        int? CurrentTenantId { get; set; }
    }

    public class UserInfor: IUserInfor
    {
        public UserInfor()
        {

        }

        
        public int Id { get; set; }
        public int TenantId { get; set; }
        public string UserName { get; set; }
        public int? CurrentTenantId { get; set;}
        public string FullName { get; set; }
    }
}
