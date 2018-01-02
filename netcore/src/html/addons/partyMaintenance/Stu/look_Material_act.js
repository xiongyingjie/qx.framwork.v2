render(function () {

    var cfg = [
        group([
            //数据库读取
            //从数据库中的stu_info查出显示学号，姓名，班级
            showInput('学号', 'cultivation_object_info-UserId', '', '1'),//来源于表stu_info-uid，提交的时候存到cultivation_object_info.stu_Id
            showInput('姓名', 'cultivation_object_info-name', '', '1'),//来源于表stu_info.name
            showinput("所在班级", "cultivation_object_info-Class", '', '1'),//来源表league_branch.Name，stu_info.unitid=league_branch.unitid
            //申请转入状态，申请时间，审核状态
              showInput('申请转入状态', 'cultivation_state-name', '', '1'),
            showinput("审核状态", "cultivation_object_info-move_in_state", '', '1', ''),

        ], '积极分子转入申请查看')];


    return cfg;

},
 '', 'ecampus.join_party.cultivation_object_info@list'
    .jn('cultivation_state.cultivation_object_stateId', 'cultivation_object_info.cultivation_object_stateId')
     .eq('cultivation_object_info.UserId', '10018888')
    , '');
//'ecampus.join_party.cultivation_object_info@update-' + '_uid'
function formReady() {
    var old = $("#cultivation_object_info-move_in_state");
    //转换代码
    if (old.val() == 0) {
        debugger
        //cultivation_state-move_in_state
        old.val("待审核");
    } else if (old.val() == 1) {
        old.val("已批准");
    }
    else {
        old.val("该生为内部培养");
    }
}