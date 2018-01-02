var motionBoxClass="motion-box";
	var isIE=navigator.userAgent.indexOf("MSIE")>-1;
	function show(obj,id,html,width,height){
		if(document.getElementById(id)==null)
		{
			var motionBox;
			motionBox=document.createElement("div");
			motionBox.className=motionBoxClass;
			motionBox.id=id;
			motionBox.innerHTML=html;
			obj.appendChild(motionBox);
			motionBox.style.width=width?width="px":"auto";            motionBox.style.height=height?height="px":"auto";
			if(!width&&isIE){
				motionBox.style.width=motionBox.offsetWidth;
			}
			motionBox.style.position="absolute";
			motionBox.style.display="block";
			var left=obj.offsetLeft+47;
			var top=obj.offsetTop-50;
			
			motionBox.style.left=left+"px";
			motionBox.style.top=top+"px";
		
			obj.onmouseleave=function(){
				setTimeout(function(){
					
			document.getElementById(id).style.display="none";
				},300);
			}
		}
		else{
			document.getElementById(id).style.display="block";
			}
		}
		var t1=document.getElementById("motion1");
		var t2=document.getElementById("motion2");
		var t3=document.getElementById("motion3");
		var t4=document.getElementById("motion4");
		
		t1.onmouseenter=function(){
			   var _html1='<div id="wu"><img src="img/A景点1.png" alt=""/><p>位于江西省东北.东西分别毗邻衢州市、景德镇市，南隔铜都德兴市与“江南第一仙山”——三清山相望，北枕国家级旅游胜地黄山市。</p></div>';
			show(this,"t1",_html1,300);
			};
		t2.onmouseenter=function(){
        var _html2='<div id="wu"><img src="img/A景点1.png" alt=""/><p>篁岭的十大看点：晒秋人家、天街古巷、五桂香堂、奇异怪屋、冒险森林、极速溜索、红豆杉群、垒心栈桥、梯田花海、爱在心田。</p></div>';
			show(this,"t2",_html2,300);
			};
			t3.onmouseenter=function(){
		 var _html3='<div id="wu"><img src="img/A景点1.png" alt=""/><p>卧龙谷荟萃了九寨的水、雁荡的瀑、黄山的岩、版纳的树，是一处金庸笔下的人间美景、世外桃源,是夏季戏水纳凉的绝佳去处。</p></div>';
			show(this,"t3",_html3,300);
			};
			t4.onmouseenter=function(){
				var _html4='<div id="zhu"><p>婺源住宿建议：</p><p>婺源的美是美在乡村，由于旅游开发的力度大,婺源的吃穿住行都很方便,你可以在婺源入住各类型及酒店以及经济型酒店,建议在婺源住宿可以住在这些离风景最近的地方。在婺源游玩的时候不为住宿担忧。但如果对住宿要求条件高，也可以去高端民宿，如思溪延村景区内的保鉴山房</p></div>'
			show(this,"t4",_html4,200);
			};
	