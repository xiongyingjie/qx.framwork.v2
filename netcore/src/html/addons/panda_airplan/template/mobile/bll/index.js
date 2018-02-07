head.load(["launcher/egret_require.js", "launcher/egret_loader.js", "launcher/game-min.js"], function () {
    window.shareData = {
        'title': '同城飞机大战',
        'link': 'http://i.52xyj.cn/',
        'imgurl': 'icon.png'
    };
    window.shareFriendData = {
        'title': '同城飞机大战',
        'content': '更多好玩的游戏等着你。',
        'link': 'http://i.52xyj.cn/',
        'imgurl': 'icon.png'
    };
    //updateShare(0);
    var support = [].map && document.createElement("canvas").getContext;
    if (support) {
        egret_h5.startGame();
    }
    else {
        alert("Egret 不支持您当前的浏览器")
    }
});

function submit_score(e) {
 //$.submitPage("")
   
 //   $.msg("正在提交分数");
 //   "/open/ipinfo".submit(function (data) {
 //     //  $.alert(data.Country);
 //   })

}

function tapShare(e) {
    //$.clearPage();
    //$.loading();
    //$.msg("正在打开排行榜");
    //"/open/ipinfo".query(function (data) {
    //    $.alert(data.Country);
    //})
}
function update_score(e) {
    //$.msg(e);
    //window.score = e;
    ////updateShare(window.score);
    ////Play68.setRankingScoreDesc(window.score);
    //var mescore = e;
    //var mefont = "分";
    //var melevel = "";

}