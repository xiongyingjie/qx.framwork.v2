
//变量声明
{
	var play=null,
		mainBanIndex=0;
		deviceWidth=window.screen.width;
		
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




{
	var mainRecoNum=$('.main-reco-box').find('a').length,
		roundmRN=Math.ceil(mainRecoNum/3);
	$('.main-reco-box').width(roundmRN*100+'%');
	$('.main-reco-box').find('a').width(100/(roundmRN*3)+'%');

	
$('.reco-right-icon').click(function(){
	var $box=$('.main-reco-box'),
		$boxWidth=$box.width();
		if(parseInt($box.css('left'))>1-(roundmRN-1)*$('.main-reco-c').width())
			$box.animate({'left':'-='+100+'%'});

})

$('.reco-left-icon').click(function(){
	var $box=$('.main-reco-box'),
		$boxWidth=$box.width();
		if(parseInt($box.css('left'))!=0)
			$box.animate({'left':'+='+100+'%'});
})
	
}





