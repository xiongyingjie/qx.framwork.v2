render([
    hide("curr_schedule_id"),
    showinput("试卷名称：", "test_paper_name"),
    showinput("课程：", "course_name"),
    showinput("出题人：", "test_author"),
    showinput("提交时间：", "test_submit_time"),
    showfile("试卷文件", "test_paper_file"),
     showfile("试卷标准答案", "test_paper_answer_file"),
      showfile("试卷分析文件", "test_analysis_file")

 
], "","/IEET/Test/FindTest_Paper","查看试卷");