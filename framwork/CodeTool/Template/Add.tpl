/*
js=${model.js}
table_note=${model.table_note}
*/

render([
    group([
       ${model.js}
    ],
        "添加${model.table_note}")
],"*","","添加${model.table_note}");