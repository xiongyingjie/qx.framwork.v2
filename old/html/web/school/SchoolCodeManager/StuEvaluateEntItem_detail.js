﻿render([

input("批次编号", "PracticeNo", "", 4, "2017-2018学年酒店管理", ""),
input("条目次序（两位数）", "EntryNo", "", 4, "例如01（两位数字）", "^[0-9]*$"),

input("条目编号", "Entry_No", "", 4, "根据批次名称和条目次序自动生成", "^[0-9]*$"),

input("条目名称", "EntryName", "", 4, "例如：企业文化", ""),

input("条目所占权重", "EntryWeight", "", 4, "请输入班级名称", "")


]);