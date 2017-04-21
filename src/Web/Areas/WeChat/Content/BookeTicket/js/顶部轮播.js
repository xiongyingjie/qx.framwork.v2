// JavaScript Document
//变量声明
{
	var play=null,
		mainBanIndex=0;
}


function autoPlay()
{
	Play=setInterval(function(){
		$(".main-banner ol li").eq(mainBanIndex).css({'background':'red'}).siblings().css({'background':'white'});
		$(".main-banner .main-bannerBox a").eq(mainBanIndex).fadeIn().siblings().hide();
		mainBanIndex++;
		if(mainBanIndex>3){mainBanIndex=0;}
	},2000);
}

autoPlay();

$(".main-banner ol li").each(function(){
		$(this)[0].addEventListener('touchend',function(){
		mainBanIndex=$(this).index(".main-banner ol li");
		$(this).css({'background':'red'}).siblings().css({'background':'white'});
		$(".main-banner .main-bannerBox a").eq(mainBanIndex).fadeIn().siblings().hide();
	})
})
