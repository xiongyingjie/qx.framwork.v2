/**
 * Created by 学妹 on 2016/11/10.
 */
window.onload = function () {


    function animate(offset) {
        var containter = document.getElementById('containter');
        var list = document.getElementById('list');
        var prev = document.getElementById('prev');
        var next = document.getElementById('next');

        var num=document.getElementById('list').children.length;
        var temp=Math.floor(num/3);
        var widthSet=temp*355;

        /*console.log("oldleft:"+list.style.left);*/
        var newleft = parseInt(list.style.left) + offset;
        if (newleft > -355) {
            list.style.left =-widthSet + 'px';
            newleft=0;
        }
        if (newleft <=-widthSet) {
            newleft=-widthSet;
        }
        list.style.left = newleft + 'px';

    }
    next.onclick = function () {
        animate(-355);


    }
    prev.onclick = function () {
        animate(+355);
    }




}