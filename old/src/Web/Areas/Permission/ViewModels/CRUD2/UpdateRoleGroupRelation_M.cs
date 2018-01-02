using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using qx.permmision.v2.Models;
using System.Web.Mvc;
namespace Web.Areas.Permission.ViewModels.CRUD2
{

    public class UpdateRoleGroupRelation_M
    {

        public RoleGroupRelation ToModel()
        {
            return new RoleGroupRelation()
            {

                role_group_relation_id = role_group_relation_id,

                role_group_id = role_group_id,

                role_id = role_id,

                role_name = role_name,

                create_userid = create_userid,

                create_username = create_username,

                create_Date = create_Date,

            };
        }

        public static UpdateRoleGroupRelation_M ToViewModel(RoleGroupRelation model, List<SelectListItem> roleListItems)
        {
            return new UpdateRoleGroupRelation_M()
            {

                _RoleListItems= roleListItems,
                role_group_relation_id = model.role_group_relation_id,

                role_group_id = model.role_group_id,

                role_id = model.role_id,

                role_name = model.role_name,

                create_userid = model.create_userid,

                create_username = model.create_username,

                create_Date = model.create_Date,

            };
        }


        [Display(Name = "角色组关系ID")]

        public string role_group_relation_id { get; set; }


        [Display(Name = "角色组ID")]

        public string role_group_id { get; set; }


        [Display(Name = "角色ID")]

        public string role_id { get; set; }


        [Display(Name = "角色别名")]

        public string role_name { get; set; }


        [Display(Name = "创建者ID")]

        public string create_userid { get; set; }


        [Display(Name = "创建者姓名")]

        public string create_username { get; set; }


        [Display(Name = "创建时间")]

        public string create_Date { get; set; }

        public List<SelectListItem> _RoleListItems { get; set; }
    }
}