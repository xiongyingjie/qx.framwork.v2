/*
js=${model.js}
table_note=${model.table_note}
controller_area=${model.controller_area}
controller_name=${model.controller_name}
table_note=${model.table_note}
*/

render(function(){
	return [
		group([
		${model.js}
		],
		"编辑${model.table_note}")
		];
    },"*","/${model.controller_area}/${model.controller_name}/Find","编辑${model.table_note}");