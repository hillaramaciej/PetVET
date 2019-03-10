var ComponentsRegistration = function () {

    ko.components.register("tmpl-ddl", {
        viewModel: function (params) {
            var self = this;
            self.parent = params.$raw;
            self._data = params.data;
            self._name = params.name;
            self.Callback = params.callback;
            self._caption = params.caption;

            self._selectedValue = ko.observable(ko.utils.unwrapObservable(params.selectedValue()));
            self._selectedValue.subscribe(function (newval) {
                self._selectedValue(newval);
                self.Callback(newval);
            });
        },
        template: '<div class="form-group" >\
                  <!-- ko if: _name != null -->\
                 <label data-bind="text:_name">Bład nie ma ddlName!!!!</label>\
                  <!-- /ko -->\
                 <select class="form-control js-example-basic-single" data-bind="options: _data ,optionsText: \'name\', optionsValue: \'id\', value: _selectedValue, optionsCaption: _caption "></select>\
               </div>'
    });
};