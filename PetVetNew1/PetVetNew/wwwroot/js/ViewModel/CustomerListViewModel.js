

function ViewModel() {
    var self = this;

    //FORM 
    self.Rowid = ko.observable();
    self.CustFirstname = ko.observable("").extend({ required: true }).extend({ minLength: 3 });
    self.CustPhone = ko.observable("");
    self.CustLastname = ko.observable("");
    self.CustMail = ko.observable("");
    self.CustNotused = ko.observable(true);
    self.SearchType = ko.observable("Wyszukiwanie zaawansowane");
    self.QuickSearch = ko.observable("");
    //END FORM

    self.InfoMessage = ko.observable("");
    self.IsInfoMessage = ko.observable(false);


    //Paggination


    //self.PaginnationArray = ko.observableArray([]);
    //self.Page = ko.observable(1);
    //self.Step = ko.observable(2);
    //self.AllPages = ko.observable(0);

    //self.Next = function () {

    //    self.Page(self.Page() + 1);
    //    var data = {
    //        //firstName: self.FirstName(),
    //        //phonNumber: self.PhonNumber(),
    //        //lastName: self.LastName(),
    //        //mail: self.Mail(),
    //        page: self.Page(),
    //        step: self.Step(),
    //        search: self.QuickSearch(),
    //    };

    //    self.CustomerList([]);
    //    self.Utilis.PostApi('api/customerApi/search', data, SearchSuccess, SearchFaild);
    //};

    //self.Previous = function () {

    //    self.Page(self.Page() - 1);
    //    var data = {
    //        //firstName: self.FirstName(),
    //        //phonNumber: self.PhonNumber(),
    //        //lastName: self.LastName(),
    //        //mail: self.Mail(),
    //        page: self.Page(),
    //        step: self.Step(),
    //        search: self.QuickSearch(),
    //    };

    //    self.CustomerList([]);
    //    self.Utilis.PostApi('api/customerApi/search', data, SearchSuccess, SearchFaild);
    //};

    //self.NextBy = function (param) {

    //    self.Page(param());


    //    console.log(self.Page());

    //    var data = {
    //        //firstName: self.FirstName(),
    //        //phonNumber: self.PhonNumber(),
    //        //lastName: self.LastName(),
    //        //mail: self.Mail(),
    //        page: self.Page(),
    //        step: self.Step(),
    //        search: self.QuickSearch(),
    //    };

    //    self.CustomerList([]);
    //    self.Utilis.PostApi('api/customerApi/search', data, SearchSuccess, SearchFaild);
    //};

    //End Paggination

    self.CustomerList = ko.observableArray([]);

    self.Customer = function () {
        var selfC = this;

        selfC.Rowid = ko.observable();
        selfC.CustFirstname = ko.observable("")
        selfC.CustPhone = ko.observable("");
        selfC.CustLastname = ko.observable("");
        selfC.CustMail = ko.observable("");
        selfC.CustCity = ko.observable("");

        selfC.FullName = ko.computed(function () {
            return selfC.CustFirstname() + " " + selfC.CustLastname();
        }, selfC);
    }

    //SUBSCRIBE

    self.Init = function () {
        var data = {
            //custFirstname: self.CustFirstname(),
            //custPhone: self.CustPhone(),
            //custLastname: self.CustLastname(),
            //custMail: self.CustMail(),
            page: self.Page(),
            step: self.Step(),
            search: self.QuickSearch(),
        };

        self.CustomerList([]);
        self.Utilis.PostApi('api/customerApi/search', data, self.SearchSuccess, self.SearchFaild);
    };

    ko.computed(function () {

        quickSearchObject = {
            //CustFirstname : ko.observable(self.CustFirstname),
            //CustLastname: ko.observable(self.CustLastname),
            //CustPhone: ko.observable(self.CustPhone),
            //CustMail: ko.observable(self.CustMail),

            QuickSearch: ko.observable(self.QuickSearch),
        };

        return ko.toJSON(quickSearchObject);
    }).subscribe(function () {

       // if (self.QuickSearch() !== "") {
            self.Page(1);
            //self.Step(5);

            var data = {
                //custFirstname: self.CustFirstname(),
                //custPhone: self.CustPhone(),
                //custLastname: self.CustLastname(),
                //custMail: self.CustMail(),
                page: self.Page(),
                step: self.Step(),
                search: self.QuickSearch(),
            };

            self.CustomerList([]);
            self.Utilis.PostApi('api/customerApi/search', data, self.SearchSuccess, self.SearchFaild);
       // } else {
       //     self.CustomerList([]);
       // }
    });

    self.SearchSuccess = function (response) {
       
        self.AllPages(response.pagesNumber);
        self.PaginnationUtilis.SetPaginnation(self.PaginnationArray, self.Page(), self.Step(), response.count, self.AllPages());      

        for (var i = 0; i < response.result.length; i++) {

            var c = new self.Customer();
            c.CustLastname(response.result[i].custLastname);
            c.CustFirstname(response.result[i].custFirstname);
            c.CustPhone(response.result[i].custPhone);
            c.CustMail(response.result[i].custMail);
            c.Rowid(response.result[i].rowid);
            c.CustCity(response.result[i].custCity);

            self.CustomerList.push(c);
        }
    };


    self.SearchFaild = function (response) {

    };
    //END SUBSCRIBE

    self.GotoProfile = function (element, id) {

        return window.location.origin + "//" + element.getAttribute('data-url').replace('id=0', id());
    };

    self.ClearSearch = function () {
        self.Rowid("");
        self.CustFirstname("");
        self.CustPhone("");
        self.CustLastname("");
        self.CustMail("");
        self.CustNotused("");
        self.QuickSearch("");
    };

    self.CustomerListVisible = ko.computed(function () {

        if (self.CustomerList().length > 0)
            return true;
        else
            return false;

    });

    self.optionData = [
        { id: 1, name: "red" },
        { id: 2, name: "green" },
        { id: 3, name: "blue" }
    ];

    self.SelectedValue = ko.observable();
    self.SelectedValueCallback = function (value) {
        self.SelectedValue(value);
    };

    self.ClearInfoMessage = function () {
        self.InfoMessage = ko.observable("");
        self.IsInfoMessage = ko.observable(false);
    };

    self.CollapseSearch = function () {
        self.CustomerList([]);

        self.ClearSearch();

        $('#quickSearch').collapse('toggle');
        $('#fullSearch').collapse('toggle');
        if (self.SearchType() === "Wyszukiwanie zaawansowane")
            self.SearchType("Wszukiwanie szybkie");
        else
            self.SearchType("Wyszukiwanie zaawansowane");
    };
}

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
customerListViewModel.PaginnationUtilis = new PaginationUtilis();
customerListViewModel.PaginnationUtilis.InitPaginnation(customerListViewModel, 10);
customerListViewModel.Init();
ko.applyBindings(customerListViewModel);

