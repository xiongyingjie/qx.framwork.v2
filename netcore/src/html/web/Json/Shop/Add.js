render([
    group([
input('批次编号', 'shop_batch-batch_id', '', '4', {min:1,max:50}),
input('批次名称', 'shop_batch-name', '', '4', {min:1,max:50}),
select('当前生效', 'shop_batch-is_current', [{text:"生效中",value:"1"},{"text":"未生效",value:"0"}],'', '4',false, {int:true})
],'标题')],'wx.ent.xmyxy.shop_batch@add','','添加');