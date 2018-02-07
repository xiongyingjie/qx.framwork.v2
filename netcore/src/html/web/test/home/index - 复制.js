var data = {
    model: {
        id: 1,
        name: "John Doe",
        password: "J0hnD03!x4",
        skills: ["Javascript", "VueJS"],
        email: "john.doe@gmail.com",
        status: true
    },

    fields: [
    {
        type: "input",
        label: "input测试",
        name: "inpu-01",
        value: "123",
        num: 4,
        tip:"输入数字",
        validators: { int:true}
    },{
        type: "showinput",
        label: "showinput测试",
        name: "showinput-01",
        value: "123",
        num: 4
    },{
        type: "time",
        label: "time测试",
        name: "time-01",
        value: "2017-12-18 14:30:25",
        num: 4,
        tip: "输入时间",
    },{
        type: "showTime",
        label: "showTime测试",
        name: "showTime-01",
        value: "2017-03-18 14:30:25",
        num: 4
    },{
        type: "date",
        label: "date测试",
        name: "date-01",
        value: "2017-11-18",
        num: 4,
        tip: "输入日期",
    }, {
        type: "showDate",
        label: "showDate测试",
        name: "showDate-01",
        value: "2017-11-18",
        num: 4
    },
     {
         type: "select",
         label: "select测试",
         name: "select-01",
         option:[{text:"男",value:"1"}, {text:"女",value:"2"}],
         value: "1",
         num: 4,
         readonly:false
     }, {
         type: "showSelect",
         label: "showSelect测试",
         name: "showSelect-01",
         option: [{ text: "男", value: "1" }, { text: "女", value: "2" }],
         value: "2",
         num: 4
     },
     {
         type: "radio",
         label: "radio测试",
         name: "radio-01",
         items: [{ text: "男", value: "1" }, { text: "女", value: "2" }],
         value: "2",
         vertical:true,
         num: 4
     },
     {
         type: "showRadio",
         label: "showRadio测试",
         name: "showRadio-01",
         items: [{ text: "男", value: "1" }, { text: "女", value: "2" }],
         value: "2",
         vertical: true,
         num: 4
     }, {
         type: "editor",
         label: "editor测试",
         name: "editor-01",
         num:1,
         value: "假装有一串文字表情",
         height:200
     }, {
         type: "showEditor",
         label: "showEditor测试",
         name: "showEditor-01",
         num: 1,
         value: "假装有一串文字表情",
         height: 200
     }, {
         type: "checkbox",
         label: "checkbox测试",
         name: "checkbox-01",
         items: [{ text: "苹果", value: "1" }, { text: "西瓜", value: "2" }, { text: "榴莲", value: "3" }, { text: "香蕉", value: "4" }],
         valueArray: [1, 3],
         vertical: true,
         num: 4
     }, {
         type: "showCheckbox",
         label: "showCheckbox测试",
         name: "showCheckbox-01",
         items: [{ text: "苹果", value: "1" }, { text: "西瓜", value: "2" }, { text: "榴莲", value: "3" }, { text: "香蕉", value: "4" }],
         valueArray: [1, 3],
         vertical: true,
         num: 4
     }, {
         type: "_switch",
         label: "_switch测试",
         name: "_switch-01",
         onText: "开",
         offText:"关",
         num: 4,
         value: 1
     }, {
         type: "showSwitch",
         label: "showSwitch测试",
         name: "showSwitch-01",
         onText: "开",
         offText: "关",
         num: 4,
         value: 1
     }, {
         type: "area",
         label: "area测试",
         name: "area-01",
         num: 2,
         value: "假装有一段很长的文字",
         height: 200,
         validators: { max: 10, min: 3 },
         tip:"请输入文字"
     }, {
         type: "showArea",
         label: "showArea测试",
         name: "showArea-01",
         num: 2,
         value: "假装有一段很长的文字",
         height: 300,
         validators: { max: 10, min: 3 },
         tip: "请输入文字"
     }, {
         type: "file",
         label: "file测试",
         name: "file-01",
         num: 4
     },
     //{
     //    type: "showFile",
     //    label: "showFile测试",
     //    name: "showFile-01",
     //    num: 4
     //},
     {
         type: "image",
         imType: "circle",
         num: 4,
         value: "http://www.runoob.com/wp-content/uploads/2014/06/download.png",
         tip: "我是圆的"
     },
     //{
     //    type: "button",
     //    label: "button测试",
     //    num:4,
     //    color: "Color.red",
     //    onclick: ""
     //}
      {
          type: "tab",
          contents: [
     {
         title: "标题1",
         content: [input("姓名1", "name1"), input("性别1", "sex1")]
     },
     {
         title: "标题2",
         content: [input("姓名2", "name2"), input("姓名2", "sex2")]
     }
          ],
          num: 1
      }, {
          type: "hide",
          name: "hide1",
          value:"001"
      }, {
          type: "hides",
          nameArray: ['hides1', 'hides2', 'hides3'],
          valueArray: [1,2,3]
      }, {
          type: "hideTime",
          name: "hideTime",
          value: "001"
      }, {
          type: "hideTimes",
          nameArray: ['hideTimes1', 'hideTimes2', 'hideTimes3'],
          valueArray: [1, 2, 3]
      }
    ],
    option: {
        title:"",
        source: "",
        target: "",
        overWrite: false

    }
}


qx.form.render2(data);