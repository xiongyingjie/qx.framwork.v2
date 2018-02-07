$.bindPage("sys.app.panda_site_clothes_goods@list".eq("site_id", $.appid()), [
    "list_goods", function () {
        /*
            <div class="products1">
                <a href="{url}"><img src="{pic}"></a>
                <a href="{url}" title="{title}">{title}<br/><span>¥{price}</span><i>详  情</i></a>
            </div>
        */
    }
],
    function (data) {
        $.each(data, function (i, o) {
        });
        return data;
    }
);