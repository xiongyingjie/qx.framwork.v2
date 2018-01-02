function searchReady() {
    //操作页面的元素
}
function uptoSchool(unit_id, batchinstanceid) {
    try {
        submitChecked("/QxJzxt/CRUD/UptoSchool", "上报到学校", {
            unit_id: unit_id,
        batchinstanceid:batchinstanceid
    });
    } catch (e) {
        $.alert(e.message);
    }
}