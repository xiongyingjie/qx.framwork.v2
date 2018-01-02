var da;
function Init() {
    var container = da;
    $.bindPage([], ["remind", function () {
        /*
               <li>
               <a class="acolor">
                     <div class="item-content">
                          <div class="item-inner">
                            <div class="item-title">{table22222-title}</div>
                            <div class="item-after ">{table22222-allday}</div>
                          </div>
                    </div>
                    </a>
                   </li>
                 
        */
    }, function (data) {
        var obj = [
           { "table22222-data": "Fri Sep 08 2017 00:00:00 GMT+0800 (中国标准时间)", "table22222-title": "搬家", "table22222-where": "b2-202", "table22222-allday": "1", "table22222-starttime": "2", "table22222-endtime": "1525121004" },
           { "table22222-data": "Wed Sep 06 2017 00:00:00 GMT+0800 (中国标准时间)", "table22222-title": "开会", "table22222-where": "b2-202", "table22222-allday": "0", "table22222-starttime": "2", "table22222-endtime": "1525121004" }
        ];
        return obj;
    }]);
}

var myApp = new Framework7();
var $$ = Dom7;
$$('.open-login').on('click', function () {
    myApp.loginScreen();
});
var monthNames = ['1月', '2月', '3月', '4月', '5月', '6月', '7月', '8月', '9月', '10月', '11月', '12月'];

var calendarInline = myApp.calendar({
    container: '#calendar-inline-container',
    //  value: [new Date()],
    dateFormat: 'yyyy-mm-dd',
    weekHeader: false,
    toolbarTemplate:
        '<div class="toolbar calendar-custom-toolbar">' +
            '<div class="toolbar-inner">' +
                '<div class="left">' +
                    '<a href="#" class="link icon-only"><i class="icon icon-back"></i></a>' +
                '</div>' +
                '<div class="center"></div>' +
                '<div class="right">' +
                    '<a href="#" class="link icon-only"><i class="icon icon-forward"></i></a>' +
                '</div>' +
            '</div>' +
        '</div>',

    onDayClick: function (p, dayContainer, year, month, day) {
        var year = year;
        var month =parseInt(month) + 1;
        var day = day;
        da = year + "-" + (month < 10 ? "0" + month : month) + "-" + (day < 10 ? "0" + day : day);
        Init();
    },
    onOpen: function (p) {
        $$('.calendar-custom-toolbar .center').text(monthNames[p.currentMonth] + ', ' + p.currentYear);
        $$('.calendar-custom-toolbar .left .link').on('click', function () {
            calendarInline.prevMonth();
        });
        $$('.calendar-custom-toolbar .right .link').on('click', function () {
            calendarInline.nextMonth();
        });
    },
    onMonthYearChangeStart: function (p) {
        $$('.calendar-custom-toolbar .center').text(monthNames[p.currentMonth] + ', ' + p.currentYear);
    }
});

