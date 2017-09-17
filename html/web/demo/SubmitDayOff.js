render([
    group([
        hide("userid", $.uid()),
        input("请假天数", "day", "1", 1),
        area("请假理由", "reason")
    ],
        "填写请假申请单")
],"*","","填写请假申请单");