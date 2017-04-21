Ext.data.MyStore = function(_cfg) {
    Ext.data.MyStore.superclass.constructor.call(this, _cfg);
    Ext.apply(this, _cfg);
};

Ext.extend(Ext.data.MyStore, Ext.data.Store, {
    Added: [],
    Removed: [],
    getAddRecords: function() {
        return this.Added;
    },
    getRemoveRecords: function() {
        return this.Removed;
    },
    getChangeJSON: function() {
        var strJsonRecord = "[";
        for (var i = 0; i < this.Added.length; i++) {
            strJsonRecord += "{ \"state\":\"Add\",\"Table\":\"User\",\"Key\":\"UserID\"," + Ext.util.JSON.encode(this.Added[i].data).replace("{", "");
        };
        for (var i = 0; i < this.Removed.length; i++) {
            strJsonRecord += "{ \"state\":\"Remove\",\"Table\":\"User\",\"Key\":\"UserID\"," + Ext.util.JSON.encode(this.Removed[i].data).replace("{", "");
        };
        for (var i = 0; i < this.modified.length; i++) {
            if (this.Added.indexOf(this.modified[i]) < 0) {
                strJsonRecord += "{\"state\":\"Modify\",\"Table\":\"User\",\"Key\":\"UserID\"," + Ext.util.JSON.encode(this.modified[i].data).replace("{", "");
            }
        };
        strJsonRecord += "]";

        return strJsonRecord;
    },
    remove: function(record) {
        var index = this.data.indexOf(record);
        this.data.removeAt(index);
        if (this.pruneModifiedRecords) {
            this.modified.remove(record);
        }
        if (this.snapshot) {
            this.snapshot.remove(record);
        }
        if (this.Added.indexOf(record) > -1) {
            this.Added.remove(record);
        } else {
            this.Removed.push(record);
        };
        this.fireEvent("remove", this, record, index);
    },
    removeAll: function() {
        for (var i = 0; i < this.getCount(); i++) {
            this.Removed.push(this.getAt(i));
        };
        this.Added = [];
        this.data.clear();
        if (this.snapshot) {
            this.snapshot.clear();
        }
        if (this.pruneModifiedRecords) {
            this.modified = [];
        }

        this.fireEvent("clear", this);
    },
    insert: function(index, records) {
        records = [].concat(records);
        for (var i = 0, len = records.length; i < len; i++) {
            this.data.insert(index, records[i]);
            records[i].join(this);
        }
        for (var i = 0; i < records.length; i++) {
            this.Added.push(records[i]);
        };
        this.fireEvent("afterMyAdd", this, records, index);
        this.fireEvent("add", this, records, index);
    },
    add: function(records) {
        for (var i = 0; i < records.length; i++) {
            this.Added.push(records[i]);
        };

        records = [].concat(records);
        if (records.length < 1) {
            return;
        }
        for (var i = 0, len = records.length; i < len; i++) {
            records[i].join(this);
        }
        var index = this.data.length;
        this.data.addAll(records);
        if (this.snapshot) {
            this.snapshot.addAll(records);
        }
        this.fireEvent("add", this, records, index);
    },
    commitChanges: function() {
        var m = this.modified.slice(0);
        this.modified = [];
        this.Added = [];//自定义数组,存放Add
        this.Removed = []; //自定义数组,存放Remove
        for (var i = 0, len = m.length; i < len; i++) {
            m[i].commit();
        }

    }
});
		   