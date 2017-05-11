using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using qx.permmision.v2.Models;

namespace Web.Areas.Permission.ViewModels.CRUD2
{

    public class UpdateUserGroup_M
    {

        public UserGroup ToModel()
        {
            return new UserGroup()
            {

                user_group_id = user_group_id,

                user_group_name = user_group_name,

                father_id = father_id,

            };
        }

        public static UpdateUserGroup_M ToViewModel(UserGroup model)
        {
            return new UpdateUserGroup_M()
            {

                user_group_id = model.user_group_id,

                user_group_name = model.user_group_name,

                father_id = model.father_id,

            };
        }


        [Display(Name = "用户组ID")]

        public string user_group_id { get; set; }


        [Display(Name = "用户组名称")]

        public string user_group_name { get; set; }


        [Display(Name = "父亲ID")]

        public string father_id { get; set; }


    }
}