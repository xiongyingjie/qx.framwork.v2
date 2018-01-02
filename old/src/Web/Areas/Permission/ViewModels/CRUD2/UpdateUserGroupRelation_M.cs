using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using qx.permmision.v2.Models;
using System.Web.Mvc;
namespace Web.Areas.Permission.ViewModels.CRUD2
{

    public class UpdateUserGroupRelation_M
    {

        public UserGroupRelation ToModel()
        {
            return new UserGroupRelation()
            {

                user_group_relation_id = user_group_relation_id,

                user_id = user_id,

                nick_name = nick_name,

                user_group_id = user_group_id,

                create_user_id = create_user_id,

                create_user_name = create_user_name,

                create_date = create_date,

            };
        }

        public static UpdateUserGroupRelation_M ToViewModel(UserGroupRelation model, List<SelectListItem> userListItems)
        {
            return new UpdateUserGroupRelation_M()
            {
                _UserListItems= userListItems,
                user_group_relation_id = model.user_group_relation_id,

                user_id = model.user_id,

                nick_name = model.nick_name,

                user_group_id = model.user_group_id,

                create_user_id = model.create_user_id,

                create_user_name = model.create_user_name,

                create_date = model.create_date,

            };
        }


        [Display(Name = "用户组关系ID")]

        public string user_group_relation_id { get; set; }


        [Display(Name = "用户ID")]

        public string user_id { get; set; }


        [Display(Name = "成员别名")]

        public string nick_name { get; set; }


        [Display(Name = "用户组ID")]

        public string user_group_id { get; set; }


        [Display(Name = "创建者ID")]

        public string create_user_id { get; set; }


        [Display(Name = "创建者姓名")]

        public string create_user_name { get; set; }


        [Display(Name = "创建日期")]

        public string create_date { get; set; }

        public List<SelectListItem> _UserListItems { get; set; }
    }
}