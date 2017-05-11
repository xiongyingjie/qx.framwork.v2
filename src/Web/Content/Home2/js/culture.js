$(document).ready(function () {
	$('#prev').hover(function(){
		$('#prev').css("opacity",'0.9');
	},function(){
		$('#prev').css("opacity","0.2");
		
	});
	
	$('#next').hover(function(){
		$('#next').css("opacity",'0.9');
	},function(){
		$('#next').css("opacity","0.2");
		
	});
	
	$('#prev').mousedown(function(){
		var i=0;
		var len=$('.images li').length;
		while(!($('.images li').eq(i).hasClass('showWhat')))
			i++;
		if(i==0){
			$('.images li').eq(0).removeClass('showWhat');
			$('.images li').eq(len-1).addClass('showWhat');
		}			
		else $('.images li').eq(i).removeClass('showWhat').prev().addClass('showWhat');
		
	});
	
	$('#next').mousedown(function(){
		var i=0;
		var len=$('.images li').length;
		while(!($('.images li').eq(i).hasClass('showWhat')))
			i++;
		if(i==len-1){
			$('.images li').eq(i).removeClass('showWhat');
			
			$('.images li').eq(0).addClass('showWhat');
		}
		else $('.images li').eq(i).removeClass('showWhat').next().addClass('showWhat');
		
	});
});


