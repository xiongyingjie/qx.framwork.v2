
function searchReady() {
	$.bindSelect("nj", "zy", "/IEET/CodeApi/GetSpecialty",true);
	$.bindSelect("zy", "bj", "/IEET/CodeApi/GetClass");
}

function tableReady() {
    dealTable(["已上传"], function () {
        return '<img style="width:20px;" src="http://cdn.52xyj.cn/pic/icon1.png"/>';
    });
}