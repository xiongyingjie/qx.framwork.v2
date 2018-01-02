using xyj.acs.Entity;

namespace xyj.acs.Models
{

    public class RoleGroup
    {

        public role_group ToEntity()
        {
            return new role_group()
            {

                role_group_id = role_group_id,

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
