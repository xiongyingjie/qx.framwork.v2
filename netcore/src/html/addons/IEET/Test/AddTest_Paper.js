
render(function () {
    return [
        group([
            hide("curr_schedule_id", q.id),
            input("试卷名称", "test_paper_name","",2, {max:40,min:2},"请输入试卷名称"),
			input("出题人：", "test_author","",4, {max:20,min:2},"请输入出题人"),
            file("试卷文件上传", "test_paper_file", 1, "/UserFile/IEET/test_paper_file/"),
            file("试卷标准答案上传", "test_paper_answer_file", 1, "/UserFile/IEET/test_paper_answer_file/"),
            file("试卷分析文件上传", "test_analysis_file", 1, "/UserFile/IEET/test_analysis_file/")
		
        ], "试卷上传", 1)
    ];
}, "/IEET/Test/AddTest_Paper","","试卷上传");

