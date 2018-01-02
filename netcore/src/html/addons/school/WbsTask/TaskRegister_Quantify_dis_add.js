render([

input("人员id", "UserId", "", 4, "请输入人员id", "^[0-9]*$"),
input("人员名称", "UserName", "", 4, "请输入人员名称", ""),
date("完成时间", "CompleteDate", "2010-2-11", 4, "请输入时间"),
select("计分标准","ScoreStand","[{\"text\":\"计分标准测试一\",\"value\":\"1\"},{\"text\":\"计分标准测试二\",\"value\":\"2\"}]","请选择计分标准",4),
editor({
  label:"佐证材料",
  name:"note",
  value:"今天我很开心",
  num:"1",
  height:"350"
}),
input("备注", "Remark", "", 4, "请输备注", "")
]);