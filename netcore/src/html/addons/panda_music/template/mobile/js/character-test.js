
	//此数组用来保存答案
var Qnum=15,  //问题数量
	Anwsers=new Array(),
	// Anwsers="1-a;2-a;3-a;4-a;5-a;6-a;7-a;8-a;9-a;10-a;11-a;12-a;13-a;14-a;15-a"
    ClickFlag=false,
	timer=null,
	userName=null;
 
var mySwiper = new Swiper('.swiper-container', {
    pagination: '.swiper-pagination',
    paginationClickable: true,
    // spaceBetween: 30,
    nextButton: '.swiper-button-next',
    prevButton: '.swiper-button-prev',
    grabCursor:true, //鼠标变手型
    parallax:true,
    shortSwipes:false, //进行快速短距离的拖动无法触发Swiper
    paginationBulletRender: function (index, className) {
      return '<span class="' + className + '">' + (index + 1) + '</span>';
    },
    //当点击模块的时候判断是否有选择或者改变答案，若是，自动切换到下一题
    onTouchEnd:function(){
    	setTimeout(function(){
    		//等待500ms，确保label绑定的事件执行
    		var activeIndex=mySwiper.activeIndex+1;
    		if(ClickFlag){
	    		ClickFlag=false;
	    			//本题已答
	    		console.log(activeIndex);
    			if(IsAnwsered(activeIndex+1)||activeIndex===Qnum){
    				// 下题已答就找出未答的最小题号
    				var questions=[];
					for(var i=1;i<=Qnum;i++){
						if(!IsAnwsered(i)){
							questions.push(i);
						}
					}
					if(questions.length){
						mySwiper.slideTo(questions[0]-1, 1000, false);
					}else{
						//全部答完
						console.log("全部答完");
						finished();
					}

    			}else{
    				mySwiper.slideNext();
    			}
    		}
    		
    	},1000);
    }
});

$(document).ready(function(){
	$("label").on("click",function(){
		var acIndex=mySwiper.activeIndex+1;
		anwser="";
		if(ClickFlag){
			return;
		}
		$(this).find("input[type='radio']").attr("checked","checked");
		if(IsAnwsered(acIndex)){
			ClickFlag=true;
			anwser=$(this).find("input[type='radio']:checked").val();
			$(this).parent(".tabs-"+acIndex).addClass("active").siblings().removeClass("active");
			ArrayInsert(acIndex,anwser);
			PaginationChange(acIndex);
		}
	});

});
//添加数组元素到指定索引处
function ArrayInsert(index,item){
	var str=index+"-";
	var result=false;
	if(Anwsers.length==0){
		Anwsers.splice(index-1,0,str+item);
	}else{
		for(var i=0;i<Anwsers.length;i++){
			if(isContains(Anwsers[i], str)){
				Anwsers[i]=str+item;
				result=true;
				break;
			}
		}
		if(!result){
			Anwsers.splice(index-1,0,str+item);
		}
	}
}

function isContains(str, substr) {
    return new RegExp(substr).test(str);
}

function PaginationChange(index){
	$(".swiper-pagination-bullet").each(function(){
		if($(this).html()==index){
			$(this).addClass("pagination-checkyet");
		}
	});
}
//判断索引题目是否已答
function IsAnwsered(index){
	var qname="q"+(index);
		anwser=$("input[name="+qname+"]:checked").val();
	if(anwser!=undefined){
		return true;
	}else{
		return false;
	}
}
//检查是否回答完
function finished(){
	var questions=[];
	if(Anwsers.length==Qnum){
		//显示提交按钮
		$(".remind-content").find("h3").html("已回答完所有问题，点击提交即可查看结果");
		ShowRemind(1);
	}
}
function ShowRemind(data) {
    //1--答题已完成 2--提交成功 3--显示错误信息
    var btn1, btn2,html;
    if (data == 1) {
        btn1 = "提交";
        btn2 = "再看看";
        html = "<button class=\"defult-btn btn-1\" onclick=\"Submit();\">" + btn1 +
            "</button><button class=\"defult-btn btn-2\" onclick=\"CloseRemind();\">" + btn2 + "</button>";
    } else if(data==2) {
        btn1 = "看答案";
        // btn2 = "寻找有缘人";
        html = "<button class=\"defult-btn btn-1\" onclick=\"ShowAnwser();\">" + btn1 +"</button>";
            // "</button><button class=\"defult-btn btn-2\" onclick=\"GoToRecommend()\">" + btn2 + "</button>";
    }else{
    	html = "<button class=\"defult-btn btn-1\" onclick=\"CloseRemind();\">确定</button>"
    }
    $(".btn-bg").append(html);
    //调整位置,改变窗口可视大小的时候，会重复触发
    $(".remind-bg").css("display","block");
    var top=$(window).height()-$(".remind-content").height()
    $(".remind-content").css("margin-top",top/2+"px");
}
//关闭提示窗
function CloseRemind(){
	$(".remind-bg").css("display","none");
	$(".btn-bg").children().remove();
}
//提交答案
function Submit(){
	//提交之前先判断一下答题情况
	if(Anwsers.length==15){
		console.log("提交成功");
	  	$(".remind-bg").css("display","none");
		$(".btn-bg").children().remove();
		$(".remind-content").find("h3").html("提交成功");
		ShowRemind(2);
	}else{
		$(".remind-content").find("h3").html("提交失败");
        ShowRemind(3);
	}
}
//看答案
function ShowAnwser(){
	$(".remind-bg").css("display","none");
	$(".btn-bg").children().remove();
	$("label").unbind("click");
	AnwserInit();
	mySwiper.slideTo(0, 1500, false);
}
//显示答案选项
function AnwserInit(){
	$("input[type='radio']").attr("disabled","disabled");
	//所有答案输入选项禁用
	for(var i=1;i<=Qnum;i++){
		$("h5").css("display","block");
		$(".answer-"+Anwsers[i-1]).css("display","block");
		var anwser=Anwsers[i-1].substr($.trim(Anwsers[i-1]).length-1,1);
		$(".tabs-"+i).find("label").each(function(){
			if($(this).find("input").val().trim()==anwser){
				// console.log($(this).find("input").val());
				$(this).parent(".tabs-"+i).addClass("active").siblings().removeClass("active");
			}
		});
	}
}
