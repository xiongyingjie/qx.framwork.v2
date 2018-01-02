render(function(){
var cfg=[];
cfg.push(
    group([
showInput('人员编号', 'employ-user_id', '', '4'),
input('姓名', 'employ-name', '', '4', {min:1,max:10}),
input('联系电话', 'employ-phone', '', '4', {min:1,max:20}),
select('人员类型', 'employ-type', 'wx.bx.employ_type@items&name=name', '', '4')
],'标题'));
return cfg;
},'wx.bx.employ@update&id='+q.id,'wx.bx.employ@find&id='+q.id,'编辑');