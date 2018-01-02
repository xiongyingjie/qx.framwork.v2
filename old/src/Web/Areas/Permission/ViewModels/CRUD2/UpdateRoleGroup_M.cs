using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using qx.permmision.v2.Models;
namespace Web.Areas.Permission.ViewModels.CRUD2
{

    public class UpdateRoleGroup_M
    {

        public RoleGroup ToModel()
        {
            return new RoleGroup()
            {

                role_group_id = role_group_id,

                role_group_name = role_group_name,

                father_id = father_id,

            };
        }

        public static UpdateRoleGroup_M ToViewModel(RoleGroup model)
        {
            return new UpdateRoleGroup_M()
            {

                role_group_id = model.role_group_id,

                role_group_name = model.role_group_name,

                father_id = model.father_id,

            };
        }


        [Display(Name = "角色组ID")]

        public string role_group_id { get; set; }


        [Display(Name = "角色组名称")]

        public string role_group_name { get; set; }


        [Display(Name = "父亲ID")]

        public string father_id { get; set; }


    }
}