render([
    group([


	input("绩点", "point_table-grade_point", '', 4, {float:true}),
			 select("选择学年", "point_table-grade", 
			       [{ text: '大一学年', value: '大一学年' },
                   { text: '大二学年', value: '大二学年' },
                   { text: '大三学年', value: '大三学年' },
                   { text: '大四学年', value: '大四学年' }], "", 3),
            file('绩点证明材料', 'point_table-point_attachmebt',3, "/UserFile/join_party/point_file/"),

hide('point_table-point_table_id', '#id'),
hide('point_table-UserId','#uid')

],'上传绩点及材料')],'ecampus.join_party.point_table@add','','添加');

