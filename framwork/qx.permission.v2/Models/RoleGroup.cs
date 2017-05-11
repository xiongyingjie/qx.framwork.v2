using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using qx.permmision.v2.Entity;
using Qx.Tools.CommonExtendMethods;

namespace qx.permmision.v2.Models
{

    public class RoleGroup
    {

        public role_group ToEntity()
        {
            return new role_group()
            {

                role_group_id = role_group_id.CheckValue(),

                role_group_name = role_group_name,

                father_id = father_id,

            };
        }

        public static RoleGroup ToModel(role_group model)
        {
            return new RoleGroup()
            {

                role_group_id = model.role_group_id,

                role_group_name = model.role_group_name,

                father_id = model.father_id,

            };
        }


        public string role_group_id { get; set; }

        public string role_group_name { get; set; }

        public string father_id { get; set; }


    }
}
