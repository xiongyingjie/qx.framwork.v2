using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;
using xyj.core.Models.Db;


namespace Web.Controllers
{
    public class DbController : BaseController
    {
        // 加密算法可以公开  
        //string encrypt(string plainText, int key)
        //{
        //    return plainText ^ key;
        //}

        //// 解密算法也可以公开  
        //string decrypt(string cipherText, int key)
        //{
        //    return cipherText ^ key;
        //}
        // GET: DataBase
        public IActionResult Index()
        {
            //DataContext.CurrentTable = "base_activity";
            //var t=DataContext["base_activity_id"];
            //DataContext["base_activity_id"] = "2";
             return Json();
            //return Json(State.SuccessConfirmClose, _db.Get(Table.course).Add(new course() {course_id = "dsfa"}));
            //return Json(State.SuccessConfirmClose, _db.Get(Table.course).Update(new course() {course_id = "dsfa"}));
            //return Json(State.SuccessConfirmClose, _db.Get(Table.course).ToSelectItems("course_name"));
            //return Json(State.SuccessConfirmClose, _db.Get(Table.course).Find("241001"));
            //return Json(State.SuccessConfirmClose, _db.Get(Table.course).All());
            //return Json(State.SuccessConfirmClose, _db.Get(Table.course).All("course_id='251001'"));
            // return Json(State.SuccessConfirmClose, _db.Get(Table.course).All(new { course_id = "241001", course_name = "3DMax" }));
        }

        public IActionResult Test()
        {

        
            //DataContext.CurrentTable = "base_activity";
            var t = DataContext["user_id"];
          
            DataContext.Push();
            DataContext["user_id"] = 4;
            DataContext["_id"] = DataContext["user_id"];
            DataContext.Push(Operate.Delete);
           // DataContext["id"] = 5;
            //DataContext.Push(Operate.Delete);
            // DataContext["user_id"] = 5;
            //DataContext["base_activity_id"] = "2";
            return Json();
        }
    }
}