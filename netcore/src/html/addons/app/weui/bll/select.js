render([
    group([
                 
          popupradio('职业', 'summerfriut3', ["法官", "医生", "猎人", "学生", "记者", "其他"]),
           popupradio('水果', 'summerfri4234', ["法官", "医生", "猎人", "学生", "记者", "其他"]),
          popupcheckbox('职业2', 'summerfriut4', '[{title: "画画", value: 1,description: "额外的数据1" },{title: "打球", value: 2,description: "额外的数据2" }]'),
          popupcheckbox('水果2', 'summerfr21312', '[{title: "画画", value: 1,description: "额外的数据1" },{title: "打球", value: 2,description: "额外的数据2" }]')
    ], '')]);


//   $('#' + id).val(); //popupradio取值
//   $('#' + id).val("值"); //popupradio取值

//   $('#' + id).val(); //popupcheckbox取值
//   $('#' + id).val("值,值"); //popupcheckbox取值