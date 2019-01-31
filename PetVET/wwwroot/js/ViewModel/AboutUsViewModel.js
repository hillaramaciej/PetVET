
function ViewModel() {
    var self = this;

    //FORM 
    self.CompanyName = ko.observable();
    self.CabinetName = ko.observable();
    self.Phone = ko.observable();
    self.Desc = ko.observable();
    self.FB = ko.observable();
    self.Insta = ko.observable();
    self.WWW = ko.observable();
    self.CategoryID = ko.observable();
    self.Category = ko.observable();
    //END FORM 
    self.InfoMessage = ko.observable("");
    self.IsInfoMessage = ko.observable(false);

    self.CategoryOptionData = [
        { id: 1, name: "Kategoria 1" },
        { id: 2, name: "KAT 2" },
        { id: 3, name: "Kategoria 3" },
    ];

    self.SelectedValueCallback = function (value) {
        self.Category(value);
    }


    self.Save = function () {

        var data = {
            companyName: self.CompanyName(),
            cabinetName: self.CabinetName(),
            phone: self.Phone(),
            desc: self.Desc(),
            fB: self.FB(),
            insta: self.Insta(),
            wWW: self.WWW(),
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

        self.CompanyName(undefined);
        self.CabinetName("");
        self.Phone(undefined);
        self.Desc(undefined);
        self.FB(undefined);
        self.Insta(undefined);
        self.WWW(undefined);
        self.CategoryID(undefined);
        self.Category(undefined);
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

        self.CompanyName(jsonData.companyName);
        self.CabinetName(jsonData.cabinetName);
        self.Phone(jsonData.phone);
        self.Desc(jsonData.desc);
        self.FB(jsonData.fB);
        self.Insta(jsonData.insta);
        self.WWW(jsonData.wWW);
        self.CategoryID(jsonData.categoryID);
        self.Category(jsonData.category);
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

var aboutUsViewModel = new ViewModel();
aboutUsViewModel.Utilis = new Utilis();
ko.applyBindings(aboutUsViewModel);

