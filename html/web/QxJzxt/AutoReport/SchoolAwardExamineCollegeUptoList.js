function searchReady() {
    //操作页面的元素
}
function schoolExamine() {
    try {
        submitChecked("/QxJzxt/CRUD/schoolExaminePass", "批准通过");
    } catch (e) {
        $.alert(e.message);
    }
}