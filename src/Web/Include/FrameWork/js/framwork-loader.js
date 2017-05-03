var framwork_Dubug = false;
//触发事件
  var active = {
    setTop: function(){
        var that = $(this);
        var url = that.data('url');
        if (url.indexOf("http") > -1) {
            if (framwork_Dubug) {
                 console.log("remote requesting to " + url);
            }
            //url = "/F2/grap?dist_url=" + url;
        } else {
            if (framwork_Dubug) {
                console.log("local requesting to " + url);
            }
        }
        //----计算弹窗数据
        var topHeight = 50;
        var leftWidth = 250;
        var formWidth = ($(window).width() - leftWidth)+"px";
        var formHeight = ($(window).height() - topHeight-45)+"px";
        var formPositionX = topHeight;
        var formPositionY = leftWidth+1 ;
        //----计算弹窗数据

      //多窗口模式，层叠置顶
      layer.open({
        type: 2 //2 =>iframe
        , title: that.data('title') ? that.data('title') : '未命名'
        , area: [formWidth, formHeight]//  area: ['85%', '85%']
        ,shade: 0
        ,maxmin: true
        ,offset: [
        formPositionX// Math.random()*($(window).height()-300)
          , formPositionY//Math.random()*($(window).width()-390)
        ]
        , content: url//'http://www.baidu.com'
        , btn: ['复制窗口', '关闭当前',  '关闭所有']
        ,yes: function(){
          $(that).click();
        }
        ,btn2: function(){
          layer.close();
        },
        btn3: function () {
            layer.closeAll();
        }
        ,zIndex: layer.zIndex //重点1
        , success: function (layero) {
            if (framwork_Dubug) {
                console.log(layero);
            }
          layer.setTop(layero); //重点2
        }
      });
    }}
        // $('#wrapper .layui-btn')
  $('#wrapper .qx-menu').on('click', function () {
      var othis = $(this), method = 'setTop';//othis.data('method');
    active[method] ? active[method].call(this, othis) : '';
  });

  $(".back").click(function() {
      history.go(-1);
  });