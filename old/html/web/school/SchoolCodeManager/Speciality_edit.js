﻿render([

input("学校名称", "SchoolName", "", 4, "请输入计分标准名称", ""),
input("年级", "Grade", "", 4, "例如：2013（4个数字）", "^[0-9]*$"),

input("专业编号", "SpecialityNo", "", 4, "例如：120901（6个数字）", "^[0-9]*$"),

input("专业名称", "SpecialityName", "", 4, "例如：对外汉语专业", "")

]);