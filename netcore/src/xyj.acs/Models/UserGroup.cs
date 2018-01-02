using xyj.acs.Entity;
using xyj.core.Extensions;

namespace xyj.acs.Models
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
