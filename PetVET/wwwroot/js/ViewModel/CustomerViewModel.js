function ViewModel() {
    var self = this;
      
    //FORM 

    self.UserID = ko.observable();
    self.FirstName = ko.observable();//.extend({ required: true }).extend({ minLength: 3 });
    self.PhonNumber = ko.observable();
    self.LastName = ko.observable();
    self.Mail = ko.observable();
    self.City = ko.observable();
    self.IsNewCustomer = ko.observable();
    self.Street = ko.observable();
    self.HouseNumber = ko.observable();
    self.FlatNumber = ko.observable();
    self.CityCode = ko.observable();
    self.DateOfBirth = ko.observable();

    self.SelectedValue = ko.observable();
    //END FORM 

    //Search Trigger
    self.SerchTrigger = false;
    self.ClearSearch = function () {
        if (self.SerchTrigger === false)
            self.SerchTrigger = true;
        else {
            self.SerchTrigger = false;
            self.UserID = ko.observable(undefined);
            self.FirstName = ko.observable(undefined)
            self.PhonNumber = ko.observable(undefined);
            self.LastName = ko.observable(undefined);
            self.Mail = ko.observable(undefined);
            self.City = ko.observable(undefined);
            self.Street = ko.observable(undefined);
            self.HouseNumber = ko.observable(undefined);
            self.FlatNumber = ko.observable(undefined);
            self.CityCode = ko.observable(undefined);
            self.DateOfBirth = ko.observable(undefined);
        }
    };
    //END Search Trigger

    self.optionData = [
        { id: 1, name: "red" },
        { id: 2, name: "green" },
        { id: 3, name: "blue" },
    ];


    self.SelectedValueCallback = function (value) {
        self.SelectedValue(value);
    }

    self.Save = function () {

        var data = {
            userId: self.UserID(),
            firstName: self.FirstName(),
            phonNumber: self.PhonNumber(),
            lastName: self.LastName(),
            mail: self.Mail(),
            isNewCustomer: self.IsNewCustomer() === 1 ? true : false,
            street: self.Street(),
            houseNumber: self.HouseNumber(),
            flatNumber: self.FlatNumber(),
            cityCode: self.CityCode(),
            dateOfBirth: self.DateOfBirth(),
        }

        self.Utilis.PostApi('api/CustomerApi', data, self.SaveSuccessfull, SaveFailed)

    };

    SaveSuccessfull = function (response, textStatus, xhr) {
        window.setTimeout(function () {
            if (response.state) {

                var tt = self.UserID();

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
    };

    self.AddPet = function () {

    };

    self.AddNew = function () {
        var ttt = self.SelectedValue()
        self.ClearInfoMessage();

        self.UserID(undefined);
        self.FirstName("");
        self.PhonNumber(null);
        self.LastName("");
        self.Mail("");
        self.IsNewCustomer(false);
        self.Street("");
        self.HouseNumber(null);
        self.FlatNumber(null);
        self.CityCode(null);
        self.DateOfBirth(null);
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

        self.UserID(jsonData.userID)
        self.FirstName(jsonData.firstName);
        self.PhonNumber(jsonData.phonNumber);
        self.LastName(jsonData.lastName);
        self.Mail(jsonData.mail);
        self.IsNewCustomer(jsonData.isNewCustomer);
        self.Street(jsonData.street);
        self.HouseNumber(jsonData.houseNumber);
        self.FlatNumber(jsonData.flatNumber);
        self.CityCode(jsonData.cityCode);
        self.DateOfBirth(jsonData.dateOfBirth);
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

ko.validation.configure = {
    decorateElement: true,
    registerExtenders: true,
    messagesOnModified: true,
    insertMessages: true,
    parseInputAttributes: true,
    messageTemplate: null
};

var components = new ComponentsRegistration();

var customerViewModel = new ViewModel();
customerViewModel.Utilis = new Utilis();
ko.applyBindings(customerViewModel);
