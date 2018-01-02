render([
    dropdown("我的作业",
    [
        { text: "登陆", value: "*f/demo/login" },
        { text: "注册", value: "*f/demo/regist" },
        { text: "修改密码", value: "*f/demo/changePsw" },
        { text: "删除账号", value: "*f/demo/delete" },
        { text: "绑定数据", value: "*f/demo/bind?id=123" },
        { text: "用户管理", value: "*r/Home/Userlist" }
       ],
        3, Color.black),


//------------------------------------------------------------------------
         dropdown("个人账户管理",
    [
        { text: "登录密码修改", value: "*f/ent/peraccount/ChgPsw" },
        { text: "学生信息维护", value: "*f/ent/peraccount/MaintainMsg" }
    ],
        3, Color.red),

//------------------------------------------------------------------------

         dropdown("分散实习管理",
    [
        { text: "企业入驻申请", value: "*f/school/DecentPractice/EnterPriseApply" },
        { text: "申请分散实习", value: "*f/school/DecentPractice/EnterPriseApplyList" },
        { text: "实习成绩查询", value: "*f/school/DecentPractice/QueryPracticescore" },//----js文件名自己创的
        { text: "我的实习成绩", value: "*f/school/DecentPractice/Practicescore" },//----js文件名自己创的
    ],
        3, Color.green),

//------------------------------------------------------------------------

         dropdown("实习报名管理",
    [
        { text: "了解企业", value: "*f/ent/PracticeApply/UnderstandCompany" },
        { text: "我要报名", value: "*f/ent/PracticeApply/Apply" },
        { text: "录取确认", value: "*f/ent/PracticeApply/Admissionconfirmation" },
    ],
        3, Color.blue),











]);



