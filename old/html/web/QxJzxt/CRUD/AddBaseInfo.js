render([
        group([
        input('信息项名称', 'infoname', '', '3', '','请输入信息项名称'),
        select("类型", "infodatatype", "/QxJzxt/CRUD/BaseInfoTypeSelect", "", 4)],
        "基本信息项",
        1)],
        "/QxJzxt/CRUD/AddBaseInfo",
        "",
       '*');

