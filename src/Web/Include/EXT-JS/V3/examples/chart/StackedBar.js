Ext.require('Ext.chart.*');
Ext.require('Ext.layout.container.Fit');

Ext.onReady(function () {
    var store = new Ext.data.JsonStore({
        fields: ['year', 'comedy', 'action', 'drama', 'thriller'],
        data: [
                {year: 2005, comedy: 34000000, action: 23890000, drama: 18450000, thriller: 20060000},
                {year: 2006, comedy: 56703000, action: 38900000, drama: 12650000, thriller: 21000000},
                {year: 2007, comedy: 42100000, action: 50410000, drama: 25780000, thriller: 23040000},
                {year: 2008, comedy: 38910000, action: 56070000, drama: 24810000, thriller: 26940000},
				 {year: 2009, comedy: 34000000, action: 23890000, drama: 18450000, thriller: 20060000},
                {year: 2010, comedy: 56703000, action: 38900000, drama: 12650000, thriller: 21000000},
                {year: 2011, comedy: 42100000, action: 50410000, drama: 25780000, thriller: 23040000},
                {year: 2012, comedy: 38910000, action: 56070000, drama: 24810000, thriller: 26940000},
				 {year: 2014, comedy: 34000000, action: 23890000, drama: 18450000, thriller: 20060000},
                {year: 2016, comedy: 56703000, action: 38900000, drama: 12650000, thriller: 21000000},
                {year: 2017, comedy: 42100000, action: 50410000, drama: 25780000, thriller: 23040000},
                {year: 2018, comedy: 38910000, action: 56070000, drama: 24810000, thriller: 26940000},
				   {year: 2035, comedy: 34000000, action: 23890000, drama: 18450000, thriller: 20060000},
                {year: 2036, comedy: 56703000, action: 38900000, drama: 12650000, thriller: 21000000},
                {year: 2037, comedy: 42100000, action: 50410000, drama: 25780000, thriller: 23040000},
                {year: 2038, comedy: 38910000, action: 56070000, drama: 24810000, thriller: 26940000},
				 {year: 2029, comedy: 34000000, action: 23890000, drama: 18450000, thriller: 20060000},
                {year: 2020, comedy: 56703000, action: 38900000, drama: 12650000, thriller: 21000000},
                {year: 2021, comedy: 42100000, action: 50410000, drama: 25780000, thriller: 23040000},
                {year: 2022, comedy: 38910000, action: 56070000, drama: 24810000, thriller: 26940000},
				 {year: 2024, comedy: 34000000, action: 23890000, drama: 18450000, thriller: 20060000},
                {year: 2026, comedy: 56703000, action: 38900000, drama: 12650000, thriller: 21000000},
                {year: 2027, comedy: 42100000, action: 50410000, drama: 25780000, thriller: 23040000},
                {year: 2028, comedy: 38910000, action: 56070000, drama: 24810000, thriller: 26940000}
              ]
    });
    
    var panel1 = Ext.create('widget.panel', {
        width: 800,
        height: 400,
        title: 'Stacked Bar Chart - Movie Takings by Genre',
        renderTo: Ext.getBody(),
        layout: 'fit',
        items: {
            xtype: 'chart',
            animate: true,
            shadow: true,
            store: store,
            legend: {
                position: 'right'
            },
            axes: [{
                type: 'Numeric',
                position: 'bottom',
                fields: ['comedy', 'action', 'drama', 'thriller'],
                title: false,
                grid: true,
                label: {
                    renderer: function(v) {
                        return String(v).replace(/000000$/, 'M');
                    }
                }
            }, {
                type: 'Category',
                position: 'left',
                fields: ['year'],
                title: false
            }],
            series: [{
                type: 'bar',
                axis: 'bottom',
                gutter: 80,
                xField: 'year',
                yField: ['comedy', 'action', 'drama', 'thriller'],
                stacked: true,
                tips: {
                    trackMouse: true,
                    width: 65,
                    height: 28,
                    renderer: function(storeItem, item) {
                        this.setTitle(String(item.value[1] / 1000000) + 'M');
                    }
                }
            }]
        }
    });
});
