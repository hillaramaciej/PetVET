

function ViewModel () {
        var self = this;

       //FORM 
        
    self.Rowid = ko.observable();
    self.CustFirstname = ko.observable();//.extend({ required: true }).extend({ minLength: 3 });
    self.CustLastname = ko.observable();
    self.CustPhone = ko.observable();
    self.CustMail = ko.observable();
    self.CustNotused = ko.observable();
    self.CustStreet = ko.observable();
    self.CustHouse = ko.observable();
    self.CustFlat = ko.observable();
    self.CustCity = ko.observable();
    self.CustCitycode = ko.observable();
    self.CustBirthdate = ko.observable();
    self.CustNotused = ko.observable();
    self.CustAgree1 = ko.observable();
    self.CustAgree2 = ko.observable();
    self.CustAgree3 = ko.observable();

        self.SelectedValue = ko.observable(); 
        //END FORM 

        //Search Trigger
        self.SerchTrigger = false;
        self.ClearSearch = function () {
            if (self.SerchTrigger === false)
                self.SerchTrigger = true;
            else {
                self.SerchTrigger = false;
                self.Rowid = ko.observable(undefined);
                self.CustFirstname = ko.observable(undefined)
                self.CustLastname = ko.observable(undefined);
                self.CustPhone = ko.observable(undefined);
                self.CustMail = ko.observable(undefined);
                self.CustStreet = ko.observable(undefined);
                self.CustHouse = ko.observable(undefined);
                self.CustFlat = ko.observable(undefined);
                self.CustCity = ko.observable(undefined);
                self.CustCitycode = ko.observable(undefined);
                self.CustBirthdate = ko.observable(undefined);
                self.CustNotused = ko.observable(undefined);
                self.CustAgree1 = ko.observable(undefined);
                self.CustAgree2 = ko.observable(undefined);
                self.CustAgree3 = ko.observable(undefined);
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

    self.Print = function () { }
  
        self.Save = function () {

            var data = {
                rowid: self.Rowid(),
                custFirstname: self.CustFirstname(),
                custLastname: self.CustLastname(),
                custPhone: self.CustPhone(),
                custMail: self.CustMail(),
                custStreet: self.CustStreet(),
                custHouse: self.CustHouse(),
                custFlat: self.CustFlat(),
                custCity: self.CustCity(),
                custCitycode: self.CustCitycode(),
                custBirthdate: self.CustBirthdate(),
                custNotused: self.CustNotused() === 1 ? true : false,
                custAgree1: self.CustAgree1() === 1 ? true : false,
                custAgree2: self.CustAgree2() === 1 ? true : false,
                custAgree3: self.CustAgree3() === 1 ? true : false,
            }

            self.Utilis.PostApi('api/CustomerApi', data, self.SaveSuccessfull, self.SaveFailed)

        };

        self.SaveSuccessfull = function (response, textStatus, xhr) {
            window.setTimeout(function () {
                if (response.state) {

                  var tt =   self.UserID();

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

        self.SaveFailed = function (response, textStatus, xhr) {
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

            self.Rowid(undefined);
            self.CustFirstname("");
            self.CustLastname("");
            self.CustPhone(null);
            self.CustMail("");
            self.CustStreet("");
            self.CustHouse(null);
            self.CustFlat(null);
            self.CustCity(null);
            self.CustCitycode(null);
            self.CustBirthdate(null);
            self.CustNotused(false);
            self.CustAgree1(false);
            self.CustAgree2(false);
            self.CustAgree3(false);
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

            self.Rowid(jsonData.rowid)
            self.CustFirstname(jsonData.custFirstname);
            self.CustLastname(jsonData.custLastname);
            self.CustPhone(jsonData.custPhone);
            self.CustMail(jsonData.custMail);
            self.CustStreet(jsonData.custStreet);
            self.CustHouse(jsonData.custHouse);
            self.CustFlat(jsonData.custFlat);
            self.CustCity(jsonData.custCity);
            self.CustCitycode(jsonData.custCitycode);
            self.CustBirthdate(jsonData.custBirthdate);
            self.CustNotused(jsonData.custNotused);
            self.CustAgree1(jsonData.custAgree1);
            self.CustAgree2(jsonData.custAgree2);
            self.CustAgree3(jsonData.custAgree3);
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

