var depart_id = $.random();
render(function () {
var cfg=[];
cfg.push(
    group([
input('部门名', 'asso_depart-department_name', '', '4', {min:1,max:50}),
editor('部门描述', 'asso_depart-describe'),
hide( 'asso_depart-create_time', '#now'),
hide('asso_depart-department_id', depart_id),
hide('asso_depart-association_id', q.association_id),
button('添加', '1:5', Color.green, function () {
    var name=$("#asso_depart-department_name").val();
    submitForm("/twxt2/AssoCRUD/AddAssoDepart?orgnization_id=" + depart_id + "&name=" + name);
    submitForm("ecampus.twxt2.asso_depart@add");
})
],'部门添加'));
return cfg;
}, '', '', '部门添加');