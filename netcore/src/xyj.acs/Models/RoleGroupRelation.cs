using System;
using xyj.acs.Entity;
using xyj.core.Extensions;

namespace xyj.acs.Models
{

    public class RoleGroupRelation
    {

        public role_group_relation ToEntity()
        {
            return new role_group_relation()
            {

                role_group_relation_id = role_group_relation_id.CheckValue(),

                role_group_id = role_group_id,

                role_id = role_id,

                role_name = role_name,

                create_userid = create_userid.CheckValue("admin"),

                create_username = create_username.CheckValue("admin"),

                create_Date = create_Date.CheckValue(DateTime.Now.ToTimeStr()),

            };
        }

        public static RoleGroupRelation ToModel(role_group_relation model)
        {
            return new RoleGroupRelation()
            {

                role_group_relation_id = model.role_group_relation_id,

                role_group_id = model.role_group_id,

                role_id = model.role_id,

                role_name = model.role_name,

                create_userid = model.create_userid,

                create_username = model.create_username,

                create_Date = model.create_Date,

            };
        }


        public string role_group_relation_id { get; set; }

        public string role_group_id { get; set; }

        public string role_id { get; set; }

        public string role_name { get; set; }

        public string create_userid { get; set; }

        public string create_username { get; set; }

        public string create_Date { get; set; }


    }
}
