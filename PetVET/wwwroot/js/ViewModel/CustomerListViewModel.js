

function ViewModel () {
        var self = this;

       //FORM 
        self.UserID = ko.observable();
        self.FirstName = ko.observable("").extend({ required: true }).extend({ minLength: 3 });
        self.PhonNumber = ko.observable("");
        self.LastName = ko.observable("");
        self.Mail = ko.observable("");
        self.IsNewCustomer = ko.observable(true);
        self.SearchType = ko.observable("Wyszukiwanie zaawansowane");
        self.QuickSearch = ko.observable("");
       //END FORM 


        self.InfoMessage = ko.observable("");
        self.IsInfoMessage = ko.observable(false);

        self.CustomerList = ko.observableArray([]);

        self.Customer = function () {
            var selfC = this;

            selfC.UserID = ko.observable();
            selfC.FirstName = ko.observable("")
            selfC.PhonNumber = ko.observable("");
            selfC.LastName = ko.observable("");
            selfC.Mail = ko.observable("");
            selfC.City = ko.observable("");

            selfC.FullName = ko.computed(function () {
                return selfC.FirstName() + " " + selfC.LastName();
            }, selfC);
        }
        

        //SUBSCRIBE

        ko.computed(function () {

            quickSearchObject = {
                //FirstName : ko.observable(self.FirstName),
                //LastName: ko.observable(self.LastName),
                //PhonNumber: ko.observable(self.PhonNumber),
                //Mail: ko.observable(self.Mail),
                QuickSearch: ko.observable(self.QuickSearch),
            }

            return ko.toJSON(quickSearchObject);
        }).subscribe(function () {

            if (self.QuickSearch() !== "") {
                var data = {
                    //firstName: self.FirstName(),
                    //phonNumber: self.PhonNumber(),
                    //lastName: self.LastName(),
                    //mail: self.Mail(),
                    search: self.QuickSearch(),
                };

                self.CustomerList([]);
                self.Utilis.PostApi('api/customerApi/search', data, SearchSuccess, SearchFaild);
            } else {
                self.CustomerList([]);
            }
            });



        var SearchSuccess = function (result) {
            for (var i = 0; i < result.length; i++) {

                var c = new self.Customer();
                c.LastName(result[i].lastName); 
                c.FirstName(result[i].firstName); 
                c.PhonNumber(result[i].phonNumber); 
                c.Mail(result[i].mail); 
                c.UserID(result[i].userID); 
                c.City(result[i].city); 
                
                self.CustomerList.push(c);
            }            
        };
        var SearchFaild = function (result) {
            let t = result;
        };

        //END SUBSCRIBE

        self.ClearSearch = function () {
            self.UserID("");
            self.FirstName("")
            self.PhonNumber("")
            self.LastName("")
            self.Mail("")
            self.IsNewCustomer("")
            self.QuickSearch("")
        }

        self.CustomerListVisible = ko.computed(function () {

            if (self.CustomerList().length > 0)
                return true;
            else
                return false;

        });

        self.optionData = [
            { id: 1, name: "red" },
            { id: 2, name: "green" },
            { id: 3, name: "blue" },
        ];

        self.SelectedValue = ko.observable();    
        self.SelectedValueCallback = function (value) {
            self.SelectedValue(value);
        } 

        self.ClearInfoMessage = function () {
            self.InfoMessage = ko.observable("");
            self.IsInfoMessage = ko.observable(false);
        }
    

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
        };

        self.CollapseSearch = function () {
            self.CustomerList([]);

            self.ClearSearch();

            $('#quickSearch').collapse('toggle');
            $('#fullSearch').collapse('toggle');
            if (self.SearchType() == "Wyszukiwanie zaawansowane")
                self.SearchType("Wszukiwanie szybkie");
            else
                self.SearchType("Wyszukiwanie zaawansowane");
        }
        self.QuickSearchCall = function (data, event) {

            if (event.which == 13) {                
                return false;
            }




            return true;
        }

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

var customerListViewModel = new ViewModel();
customerListViewModel.Utilis = new Utilis();
ko.applyBindings(customerListViewModel);

