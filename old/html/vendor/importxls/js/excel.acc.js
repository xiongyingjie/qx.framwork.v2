// 依赖于shim.js、xls.js  
//   
  
var X = XLS;  
  
function to_json(workbook) {  
    var result = {};  
    workbook.SheetNames.forEach(function (sheetName) {  
        var roa = XLS.utils.sheet_to_row_object_array(workbook.Sheets[sheetName]);  
        if (roa.length > 0) {  
            result[sheetName] = roa;  
        }  
    });  
    return result;  
}  
  
function fixdata(data) {  
    var o = "", l = 0, w = 10240;  
    for (; l < data.byteLength / w; ++l) o += String.fromCharCode.apply(null, new Uint8Array(data.slice(l * w, l * w + w)));  
    o += String.fromCharCode.apply(null, new Uint8Array(data.slice(l * w)));  
    return o;  
}  
  
function process_wb(wb,type) {  
    var output = "";  
    switch (type) {  
        case "json":  
            output = JSON.stringify(to_json(wb), 2, 2);  
            break;  
        case "form":  
            output = to_formulae(wb);  
            break;  
        default:  
            output = to_csv(wb);  
    }  
    //if (out.innerText === undefined) out.textContent = output;  
    //else out.innerText = output;  
    return output;  
}   
  
function ReadExcel(out) {  
  
    //如果只要json 可以不用转换  
    var exlData = JSON.parse(out);  
  
    // Page1 其实是表格页标签名字,具体示实际名称  
    // if (exlData.Page1 == null || exlData.Page1 == undefined) {  
    //     msgErro("未查询到Excel文件中的数据！");  
    //     //saveLoading('hide');  
    //     return;  
    // }  
     
    //传出外面  
    UploadExcel(exlData, out);
}  
  
//绑定 Input Change 事件  
function handleFile(e) {      
  
    if (e.target.files[0].name.indexOf(".xls") < 0) {  
       // msgErro("请选择.xls格式文件！");  
        return;  
    }  
    //saveLoading('show');  
     
    var files = e.target.files;  
    var output = "";  
    var f = files[0];  
    {  
        var reader = new FileReader();  
        var name = f.name;  
        reader.onload = function (e) {  
            

            try {
                var data = e.target.result;

                var arr = fixdata(data);
                var wb = X.read(btoa(arr), { type: 'base64' });

                output = process_wb(wb, "json");

                ReadExcel(output);
            } catch (ex) {
                $.alert("导入失败，不支持该格式的模板文件：" + ex.message);
            }
           
        };  
  
        reader.readAsArrayBuffer(f);  
    }  
}  