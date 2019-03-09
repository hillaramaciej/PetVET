ko.bindingHandlers['modal'] = {
    init: function (element, valueAccessor, allBindingsAccessor) {

        var allBindings = allBindingsAccessor();
        var $element = $(element);
        // $element.addClass('hide modal');

        if (allBindings.modal) {

            debugger;
            $('#modalSave').on('click', function () {
                // modalSave $('#holidayModal').on('hidden.bs.modal', function () {
                debugger;
                var value = ko.utils.unwrapObservable(valueAccessor());


                let obj = {
                    Id: 1,
                    HolidayName: "Test",
                    DateFrom: '1985-02-04',
                    DateTo: '1985-02-04'
                };

                value.self.Utilis.PostApi('api/EmployeesHoldayApi', obj,
                    function (x, y, z) {
                        debugger;
                    },
                    function (x, y, z) {
                        debugger;
                    });

                return null; //allBindings.modal.beforeClose(value);
            });
        }
    },
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());

        if (value) {
            // $(#holidayModal).addClass('in');
            $('#holidayModal').modal('show');
        } else {
            //  $(element).removeClass('in');
            $("#holidayModal").modal('hide');
        }
    }
};



function tableRow(odTime, doTime, scope) {
    this.odTime = ko.observable(odTime);
    this.doTime = ko.observable(doTime);

}

function HolidayRow(id, eventName, startDate, endDate, scope) {
    this.self = scope;
    this.Id = id;
    this.HolidayName = ko.observable(ko.utils.unwrapObservable(eventName));
    this.DateFrom = ko.observable(ko.utils.unwrapObservable(startDate));
    this.DateTo = ko.observable(ko.utils.unwrapObservable(endDate));
}


function ViewModel() {
    var self = this;

    self.InfoMessage = ko.observable("");
    self.IsInfoMessage = ko.observable(false);

    self.Test = ko.observable("dupa");


    self.HolidayList = ko.observableArray([]);
    self.HolidayBeingEdited = ko.observable();


    self.EditHoliday = function (id) {

        var match = ko.utils.arrayFirst(self.HolidayList(), function (item) {
            return item.Id === id;
        });

        if (match !== null) {
            self.HolidayBeingEdited(match);
        }


    };
    self.RemoveHoliday = function (id) {

    };
    self.AddHoliday = function () {

    };

    self.SaveHoliday = function () {
        debugger;
    };


    self.OnMonthClick = function (month) {

        for (var i = 0; i < self.items.length; i++) {
            self.items[i].isActive(false);
        }

        self.items[month - 1].isActive(true);

        self.HolidayList([]);

        self.HolidayList.push(new HolidayRow(1, "Swięto", "2013-01-08", "2013-01-08", self));
        self.HolidayList.push(new HolidayRow(2, "Swięto1", "2013-01-08", "2013-01-08", self));
        self.HolidayList.push(new HolidayRow(3, "Swięto12", "2013-01-08", "2013-01-08", self));
    };



    self.items = [
        { isActive: ko.observable(false) },
        { isActive: ko.observable(false) },
        { isActive: ko.observable(false) },
        { isActive: ko.observable(false) },
        { isActive: ko.observable(false) },
        { isActive: ko.observable(false) },
        { isActive: ko.observable(false) },
        { isActive: ko.observable(false) },
        { isActive: ko.observable(false) },
        { isActive: ko.observable(false) },
        { isActive: ko.observable(false) },
        { isActive: ko.observable(false) }
    ];

    //holidays


    //END holidays

    //hours
    self.PN = ko.observableArray([]);
    self.WT = ko.observableArray([]);
    self.SR = ko.observableArray([]);
    self.CZ = ko.observableArray([]);
    self.PT = ko.observableArray([]);
    self.SO = ko.observableArray([]);
    self.ND = ko.observableArray([]);

    self.Add = function (day) {

        self[day].push(new tableRow("00:00", "00:00", self));
    };

    self.Remove = function (day) {
        self[day].pop();
    };


    self.PNCheck = ko.observable(false);
    self.PNCheck.subscribe(function (newValue) {
        if (newValue === false) {
            self.PN([]);
        }

    });

    self.Reset = function () {

    };

    self.Save = function () {
        console.log("doimpementacji !!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

        //var data = {
        //    openHoursId: self.OpenHoursID(),
        //    openHoursName: self.OpenHoursName(),
        //    openHoursType: self.OpenHoursType(),
        //};
        debugger;
        let obj = {
            Id: 1,
            HolidayName: "Test",
            DateFrom: '12-12-1985',
            DateTo: '12-12-1985'
        };

        self.Utilis.PostApi('api/EmployeesHoldayApi', obj,
            function (x, y, z) {
                debugger;
            },
            function (x, y, z) {
                debugger;
            });

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
    //End hours


    self.ClearInfoMessage = function () {
        self.InfoMessage = ko.observable("");
        self.IsInfoMessage = ko.observable(false);
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

        console.log("doimpementacji !!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
    };

    self.OnMonthClick(1);

}


var components = new ComponentsRegistration();

var openHoursViewModel = new ViewModel();
openHoursViewModel.Utilis = new Utilis();
ko.applyBindings(openHoursViewModel);

