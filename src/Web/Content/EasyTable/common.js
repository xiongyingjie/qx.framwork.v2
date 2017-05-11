$(document).ready(function () {
    $("#search_btn").click(function () {
        var txt = $("#search_txt").val();
        var txt = document.getElementByID("search_txt");
        if (txt == 'lm') {
            location.href = '/Contents/Home2/StartPage';
        }
        else if (txt == 'mb') {
            location.href = '/Contents/Home2/NextPage';
        }
        else if (txt == 'css') {
            location.href = '/Contents/Home2/ThirdPage';
        }
        else if (txt == 'nl') {
            location.href = '/Contents/Home2/TableList';
        }
        else if (txt == 'newt') {
            location.href = '/Contents/Home2/EasyTable';
        }
        else {
            alert('查询无结果');
        }
    });
})