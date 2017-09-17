
{
		var orderNum=$('.order li ').length,
			erweimaVis=new Array([orderNum]);
		for(var i=0;i<orderNum;i++)
			erweimaVis[i]=false;
}

$('.order li ').each(function(){
	$(this).find(".middle h4").click(function(){
		
		var index=$(this).closest('li').index();
		if(erweimaVis[index]) erweimaVis[index]=false;
		else erweimaVis[index]=true;
		
		if(erweimaVis[index]) $(this).siblings('.erweima').show();
		else $(this).siblings('.erweima').hide();
	})
})
