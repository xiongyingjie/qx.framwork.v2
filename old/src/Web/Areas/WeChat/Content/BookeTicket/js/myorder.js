// JavaScript Document
var index=0;
var Play=null;

$("#unfinish").click(function(){
	$(".unfinishmore").show();
	$(this).addClass('Hover');
	$("#finish").removeClass('Hover');
	$('.finishmore').hide();
});
$("#finish").click(function(){
	$(".finishmore").show();
	$(this).addClass('Hover');
	$("#unfinish").removeClass('Hover');
	$('.unfinishmore').hide();
})


