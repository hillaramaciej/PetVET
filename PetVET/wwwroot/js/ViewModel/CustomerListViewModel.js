

function ViewModel() {
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

    self.Init = function () {
        debugger;
        var data = {
            //firstName: self.FirstName(),
            //phonNumber: self.PhonNumber(),
            //lastName: self.LastName(),
            //mail: self.Mail(),
            page: self.Page(),
            step: self.Step(),
            search: self.QuickSearch(),
        };

        self.CustomerList([]);
        self.Utilis.PostApi('api/customerApi/search', data, self.SearchSuccess, self.SearchFaild);
    };

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

       // if (self.QuickSearch() !== "") {
            self.Page(1);
            //self.Step(5);

            var data = {
                //firstName: self.FirstName(),
                //phonNumber: self.PhonNumber(),
                //lastName: self.LastName(),
                //mail: self.Mail(),
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
            c.LastName(response.result[i].lastName);
            c.FirstName(response.result[i].firstName);
            c.PhonNumber(response.result[i].phonNumber);
            c.Mail(response.result[i].mail);
            c.UserID(response.result[i].userId);
            c.City(response.result[i].city);

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
        self.UserID("");
        self.FirstName("")
        self.PhonNumber("")
        self.LastName("")
        self.Mail("")
        self.IsNewCustomer("")
        self.QuickSearch("")
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

