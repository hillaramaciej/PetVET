﻿
function ViewModel() {
    var self = this;

    //FORM 
    self.ServiceID = ko.observable();
    self.ServiceName = ko.observable();
    self.ServiceType = ko.observable();
    self.ServiceCost = ko.observable();
    self.ServiceTax = ko.observable();
    self.ServiceDuration = ko.observable();
    //END FORM 
    self.InfoMessage = ko.observable("");
    self.IsInfoMessage = ko.observable(false);


    self.Save = function () {

        var data = {
            serviceId: self.ServiceID(),
            serviceName: self.ServiceName(),
            ServiceType: self.ServiceType(),
            serviceCost: self.ServiceCost(),
            serviceTax: self.ServiceTax(),
            ServiceDuration: self.ServiceDuration(),
        }

        self.Utilis.PostApi('api/ServiceApi', data, self.SaveSuccessfull, SaveFailed)

    };

    SaveSuccessfull = function (response, textStatus, xhr) {
        window.setTimeout(function () {
            if (response.state) {

               

                if (response.message) {
                    //   self.Utils.Form.InfoPanel(response.message, 2000);
                }
            }
            else {
                // self.Utils.Form.HideProgress();
                //self.Utils.Form.ErrorPanel(response.message);
            }
        }, 1);
    };

    SaveFailed = function (response, textStatus, xhr) {
        //self.Utils.Form.HideProgress();
        if (response.message) {
            //self.Utils.Form.ErrorDialog(response.message);
        }
    };

    self.ClearInfoMessage = function () {
        self.InfoMessage = ko.observable("");
        self.IsInfoMessage = ko.observable(false);
    }

    self.AddNew = function () {
        self.ClearInfoMessage();

        self.ServiceID(undefined);
        self.ServiceName("");
        self.ServiceType(undefined);
        self.ServiceCost(undefined);
        self.ServiceTax(undefined);
        self.ServiceDuration(undefined);
    };

    self.MapFromJson = function (jsonData) {
        if (window.console) {
            console.log('MapFromJson>>');
            console.log(jsonData);
        }
        window.setTimeout(function () {
            self.MapFromJsonInternal(jsonData);
        }, 1);
    };

    self.MapFromJsonInternal = function (jsonData) {
        if (window.console)
            console.log('MapFromJsonInternal');

        self.ServiceID(jsonData.serviceId);
        self.ServiceName(jsonData.serviceName);
        self.ServiceType(jsonData.serviceType);
        self.ServiceCost(jsonData.serviceCost);
        self.ServiceTax(jsonData.serviceTax);
        self.ServiceDuration(jsonData.serviceDuration);
    };

}


//ko.components.register("tmpl-ddl", {
//    viewModel: function (params) {
//        var self = this;
//        self.parent = params.$raw;
//        self._data = params.data;
//        self._name = params.name;
//        self.Callback = params.callback;
//        self._caption = params.caption;

//        self._selectedValue = ko.observable(ko.utils.unwrapObservable(params.selectedValue()));
//        self._selectedValue.subscribe(function (newval) {
//            self._selectedValue(newval);
//            self.Callback(newval);
//        });
//    },
//    template: '<div class="form-group">\
//                 <label data-bind="text:_name">Bład nie ma ddlName!!!!</label>\
//                 <select class="form-control" data-bind="options: _data ,optionsText: \'name\', optionsValue: \'id\', value: _selectedValue, optionsCaption: _caption "></select>\
//               </div>'
//});

//ko.validation.configure = {
//    decorateElement: true,
//    registerExtenders: true,
//    messagesOnModified: true,
//    insertMessages: true,
//    parseInputAttributes: true,
//    messageTemplate: null
//};

var components = new ComponentsRegistration();

var serviceViewModel = new ViewModel();
serviceViewModel.Utilis = new Utilis();
ko.applyBindings(serviceViewModel);
