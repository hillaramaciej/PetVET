
function ViewModel() {
    var self = this;

    //FORM 
    self.Rowid = ko.observable();
    self.ServicName = ko.observable();
    self.ServicTypeid = ko.observable();
    self.ServicCost = ko.observable();
    self.ServicTaxid = ko.observable();
    self.ServicDuration = ko.observable();
    self.ServicOfficeid = ko.observable();
    //END FORM 
    self.InfoMessage = ko.observable("");
    self.IsInfoMessage = ko.observable(false);


    self.Save = function () {

        var data = {
            rowid: self.Rowid(),
            servicName: self.ServicName(),
            servicTypeid: self.ServicTypeid(),
            servicCost: self.ServicCost(),
            servicTaxid: self.ServicTaxid(),
            servicDuration: self.ServicDuration(),
            servicOfficeid: self.ServicOfficeid(),
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

        self.Rowid(undefined);
        self.ServicName("");
        self.ServicTypeid(undefined);
        self.ServicCost(undefined);
        self.ServicTaxid(undefined);
        self.ServicDuration(undefined);
        self.ServicOfficeid(undefined);
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

        self.Rowid(jsonData.rowid);
        self.ServicName(jsonData.servicName);
        self.ServicTypeid(jsonData.servicTypeid);
        self.ServicCost(jsonData.servicCost);
        self.ServicTaxid(jsonData.servicTaxid);
        self.ServicDuration(jsonData.servicDuration);
        self.ServicOfficeid(jsonData.servicOfficeid);
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

