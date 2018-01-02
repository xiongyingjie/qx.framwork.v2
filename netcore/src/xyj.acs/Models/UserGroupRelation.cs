using System;
using xyj.acs.Entity;
using xyj.core.Extensions;

namespace xyj.acs.Models
{

    public class UserGroupRelation
    {

        public user_group_relation ToEntity()
        {
            return new user_group_relation()
            {

                user_group_relation_id = user_group_relation_id.CheckValue(),

                user_id = user_id,

                nick_name = nick_name,

                user_group_id = user_group_id,

                create_user_id = create_user_id.CheckValue("Admin"),

                create_user_name = create_user_name.CheckValue("Admin"),

                create_date = create_date.CheckValue(DateTime.Now.ToStr()),

            };
        }

        public static UserGroupRelation ToModel(user_group_relation model)
        {
            return new UserGroupRelation()
            {

                user_group_relation_id = model.user_group_relation_id,

                user_id = model.user_id,

                nick_name = model.nick_name,

                user_group_id = model.user_group_id,

                create_user_id = model.create_user_id,

                create_user_name = model.create_user_name,

                create_date = model.create_date,

            };
        }


        public string user_group_relation_id { get; set; }

        public string user_id { get; set; }

        public string nick_name { get; set; }

        public string user_group_id { get; set; }

        public string create_user_id { get; set; }

        public string create_user_name { get; set; }

        public string create_date { get; set; }


    }
}
