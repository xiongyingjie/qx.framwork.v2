function searchReady() {
    //操作页面的元素
}
function uptoList() {
    try {
        submitChecked("/QxJzxt/CRUD/AddToUptoListBathch","添加到上报名单");
    } catch (e) {
        $.alert(e.message);
    }
}