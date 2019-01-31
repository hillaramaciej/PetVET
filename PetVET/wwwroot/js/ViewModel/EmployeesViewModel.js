
function ViewModel() {
    var self = this;

    //FORM 
    self.Name = ko.observable();
    self.LastName = ko.observable();
    self.Email = ko.observable();
    self.PWZNumber = ko.observable();
    self.Address = ko.observable();
    self.PhoneNumber = ko.observable();
    self.Permit = ko.observable();

    //END FORM 
    self.InfoMessage = ko.observable("");
    self.IsInfoMessage = ko.observable(false);

    self.PermitOptionData = [
        { id: 1, name: "Manager" },
        { id: 2, name: "Weterynarz" },
        { id: 3, name: "Recepcja" },
    ];
    
    self.SelectedValueCallback = function (value) {
        self.Permit(value);
    }

    self.UserAdded = function () {
        // do implementacji
    }

    self.AddUser = function () {
        // do implementacji
    }

    self.Save = function () {

        var data = {
            name: self.Name(),
            lastName: self.LastName(),
            email: self.Email(),
            pWZNumber: self.PWZNumber(),
            address: self.Address(),
            phoneNumber: self.PhoneNumber(),
            permit: self.Permit(),
        }

        self.Utilis.PostApi('api/EmployeesApi', data, self.SaveSuccessfull, SaveFailed)

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
        self.Name(undefined);
        self.LastName("");
        self.Email(undefined);
        self.PWZNumber(undefined);
        self.Address(undefined); 
        self.PhoneNumber(undefined);
        self.Permit("");
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

        self.Name(jsonData.name);
        self.LastName(jsonData.lastName);
        self.Email(jsonData.email);
        self.PWZNumber(jsonData.pWZNumber);
        self.Address(jsonData.address);
        self.PhoneNumber(jsonData.phoneNumber);
        self.Permit(jsonData.permit);
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

var employeesViewModel = new ViewModel();
employeesViewModel.Utilis = new Utilis();
ko.applyBindings(employeesViewModel);

