head.load(["js/jquery.event.drag-1.5.min.js", "js/jquery.touchSlider.js"])

function init_banner() {
    $(".main_visual").hover(function () {
        $("#btn_prev,#btn_next").fadeIn()
    }, function () {
        $("#btn_prev,#btn_next").fadeOut()
    });

    $dragBln = false;

    $(".main_image").touchSlider({
        flexible: true,
        speed: 200,
        btn_prev: $("#btn_prev"),
        btn_next: $("#btn_next"),
        paging: $(".flicking_con a"),
        counter: function (e) {
            $(".flicking_con a").removeClass("on").eq(e.current - 1).addClass("on");
        }
    });

    $(".main_image").bind("mousedown", function () {
        $dragBln = false;
    });

    $(".main_image").bind("dragstart", function () {
        $dragBln = true;
    });

    $(".main_image a").click(function () {
        if ($dragBln) {
            return false;
        }
    });

    timer = setInterval(function () {
        $("#btn_next").click();
    }, 3000);

    $(".main_visual").hover(function () {
        clearInterval(timer);
    }, function () {
        timer = setInterval(function () {
            $("#btn_next").click();
        }, 3000);
    });

    $(".main_image").bind("touchstart", function () {
        clearInterval(timer);
    }).bind("touchend", function () {
        timer = setInterval(function () {
            $("#btn_next").click();
        }, 3000);
    });
}

$.bindPage("sys.app.panda_site_clothes_site@list".eq("site_id",$.appid()), [],
    function (data) {
        
        $.each(data["index_banners"].split(';'), function (i, o) {
            $("#container-icon").append('<a href="###">' + (i + 1) + '</a>');
            $("#container-pic").append(' <li><span style="background: url(' + $.url(o) + ') center top no-repeat;background-size: cover;"  ></span></li>');
        });
        init_banner();
        return data;
    }
);