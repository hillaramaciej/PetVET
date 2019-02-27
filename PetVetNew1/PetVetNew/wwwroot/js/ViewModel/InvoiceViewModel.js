
function ViewModel() {
    var self = this;

    //FORM 
    self.InvoiceID = ko.observable();
    self.InvoiceTyp = ko.observable();
    self.Service = ko.observable();
    self.Item = ko.observable();
    //END FORM 
    self.InfoMessage = ko.observable("");
    self.IsInfoMessage = ko.observable(false);


    self.ServiceOptionData = ko.observableArray([]);
    
    self.SelectedValueCallback = function (value) {
        self.Service(value);
    }

    self.ItemOptionData = [
        { id: 1, name: "Lek 1" },
        { id: 2, name: "Treba podłączyć z bazy leki" },
        { id: 3, name: "Lek 3" },
    ];

    self.SelectedValueCallback = function (value) {
        self.Item(value);
    }

    self.Print = function () {
        // do implementacji
    }

    self.Agreement1 = function () {
        // do implementacji
    }

    self.Agreement2 = function () {
        // do implementacji
    }

    self.Agreement3 = function () {
        // do implementacji
    }

    self.CustomerList = function () {
        // do implementacji
    }

    self.Save = function () {

        var data = {
            invoiceID: self.InvoiceID(),
            invoiceTyp: self.InvoiceTyp(),
            // invoiceTyp: self.Service(),
            itemTyp: self.Item(),

        };

        self.Utilis.PostApi('api/InvoiceApi', data, self.SaveSuccessfull, SaveFailed)

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

        self.InvoiceID(undefined);
        self.InvoiceTyp("");
        self.Service("");
        self.Item("");
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

        self.InvoiceID(jsonData.invoiceID);
        self.InvoiceTyp(jsonData.invoiceTyp);
        self.Service(jsonData.service);
        self.Item(jsonData.item);
    };


    self.Init = function () {  

        var data = null;
        self.Utilis.GetApi('api/serviceApi/', data, function (response) {
        
            for (var i = 0; i < response.length; i++) {
                self.ServiceOptionData.push({ id : response[i].id, name : response[i].name});
            }


        }, self.SearchFaild);
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

var invoiceViewModel = new ViewModel();
invoiceViewModel.Utilis = new Utilis();
invoiceViewModel.Init();
ko.applyBindings(invoiceViewModel);
