render([





    select({
        label: "选择企业",
        name: "SelectCompany",
        option: "[{\"text\":\"华大酒店\",\"value\":\"1\"},{\"text\":\"华大可浓餐厅\",\"value\":\"2\"},{\"text\":\"泰国曼谷猜犹披亚公园酒店\",\"value\":\"3\"},{\"text\":\"美国塞班悦泰度假村酒店\",\"value\":\"4\"},{\"text\":\"美国关岛悦泰酒店\",\"value\":\"5\"},{\"text\":\"法国实习企业\",\"value\":\"6\"},{\"text\":\"晋江爱乐国际酒店\",\"value\":\"7\"},{\"text\":\"美国塞班卡诺亚度假村\",\"value\":\"8\"}]",
        value: "1",
        num: 1
    }),



   select({
       label: "",
       name: "Choice",
       option: "[{\"text\":\"第一志愿\",\"value\":\"1\"},{\"text\":\"第二志愿\",\"value\":\"2\"}]",
       value: "1",
       num: 2
   }),//selectCompany Choice Number




   select({
       label: "",
       name: "Number",
       option: "[{\"text\":\"1\",\"value\":\"1\"},{\"text\":\"2\",\"value\":\"2\"},{\"text\":\"3\",\"value\":\"3\"},{\"text\":\"4\",\"value\":\"4\"}]",
       value: "1",
       num: 2
   }),











], "*");