using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using qx.permmision.v2.Entity;
using Qx.Tools.CommonExtendMethods;

namespace qx.permmision.v2.Models
{

    public class UserGroup
    {

        public user_group ToEntity()
        {
            return new user_group()
            {

                user_group_id = user_group_id.CheckValue(),

                user_group_name = user_group_name,

                father_id = father_id,

            };
        }

        public static UserGroup ToModel(user_group model)
        {
            return new UserGroup()
            {

                user_group_id = model.user_group_id.CheckValue(),

                user_group_name = model.user_group_name,

                father_id = model.father_id,

            };
        }


        public string user_group_id { get; set; }

        public string user_group_name { get; set; }

        public string father_id { get; set; }


    }
}
