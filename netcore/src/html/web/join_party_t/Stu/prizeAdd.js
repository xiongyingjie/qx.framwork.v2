render([
    group([

	       input("获奖描述", "get_prize-describe", '', 4),   //用到的只是describe 

			 hide("获奖名称", "get_prize-prize_name"),
			 file("证明附件", "get_prize-attachment", 3, "/UserFile/join_party/get_prize_file/"),
			 hide('get_prize-get_prize_id', '#id'),
              hide('get_prize-UserId', '#uid'),
             hide('get_prize-upload_time', '#now')

],'上传获奖情况及材料')],'ecampus.join_party.get_prize@add','','添加');








