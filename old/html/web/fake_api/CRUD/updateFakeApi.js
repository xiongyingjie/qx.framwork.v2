render([
input("编号", "id"),
input("访问地址", "api"),
input("请求参数", "request_param"),
input("所属子系统", "sub_system"),
input("正式环境url", "real_api"),
input("调用次数", "count"),
date("最后调用时间", "last_call"),
area("备注", "note"),
area("返回值", "response_json", "{}", 4, "必须为标准json格式"),
input("区域", "area"),
input("控制器", "controller"),
input("动作", "action"),
input("状态", "state")
], "ecampus.twxt.fake_api@update", "ecampus.twxt.fake_api@find");