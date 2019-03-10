ko.bindingHandlers['modal'] = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        var allBindings = allBindingsAccessor();
        var $element = $(element);
        // $element.addClass('hide modal');
       
        if (allBindings.modal) {
            

            $('#modalAlert').hide();
            $('#modalSave').on('click', function () {
                // modalSave $('#holidayModal').on('hidden.bs.modal', function () {
                var value = ko.utils.unwrapObservable(valueAccessor());
                let obj = {};
                for (property in value) {
                    if (value.hasOwnProperty(property) && property !== "self") {

                        if (typeof value[property] === "function")
                            obj[property] = value[property]();
                        else
                            obj[property] = value[property];
                    }
                }

                value.self.Utilis.PostApi('api/EmployeesHoldayApi', obj,
                    function (x, y, z) {
                        

                        var match = ko.utils.arrayFirst(this.scope.HolidayList(), function (item) {
                            return item.Id() === x['id'];
                        });
                        if (match) {
                            for (property in x) {
                                for (prop in match) {
                                    if (prop.toLowerCase() === property.toLowerCase()) {
                                        match[prop](x[property]);
                                    }
                                }
                            }
                        }
                        else {
                            var _new = new HolidayRow(x['id'], x['holidayName'], x['dateFrom'], x['dateTo'], value.self);
                            value.self.HolidayList.push(_new);
                        }
                 
                        this.scope.HolidayBeingEdited(undefined);
                    },
                    function (x, y, z) {
                        $('#modalAlert').text(x.responseText);
                        $('#modalAlert').show();
                    }, value.self);

                // allBindings.modal.beforeClose(value);
            });

            $('#holidayModal').on('click', function () {
               
                $('#modalAlert').hide();
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

ko.bindingHandlers['modalDelete'] = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        var allBindings = allBindingsAccessor();
        var $element = $(element);
        // $element.addClass('hide modal');
        
        if (allBindings.modalDelete) {
            

            $('#modalAlertDelete').hide();
            $('#modalDelete').on('click', function () {
                // modalSave $('#holidayModal').on('hidden.bs.modal', function () {
                var value = ko.utils.unwrapObservable(valueAccessor());
          

                value.self.Utilis.DeleteApi('api/EmployeesHoldayApi/' + value.Id(),
                    function (x, y, z) {

                        var _new = [];

                        for (var i = 0; i < value.self.HolidayList().length; i++) {
                            if (value.self.HolidayList()[i].Id() !== x) {
                                _new.push(value.self.HolidayList()[i]);
                            }
                        }

                        value.self.HolidayList([]);

                        for (var j = 0; j < _new.length; j++) {
                            value.self.HolidayList.push(_new[j]);
                        }

                      //  value.self.RemoveHoliday(x);

                        value.self.HolidayBeingDelete(undefined);
                    },
                    function (x, y, z) {
                        $('#modalAlertDelete').text(x.responseText);
                        $('#modalAlertDelete').show();
                    });

                // allBindings.modal.beforeClose(value);
            });

            $('#holidayModalDelete').on('click', function () {

                $('#modalAlertDelete').hide();
            });

        }
    },
    update: function (element, valueAccessor) {

        var value = ko.utils.unwrapObservable(valueAccessor());

        if (value) {
            // $(#holidayModal).addClass('in');
            $('#holidayModalDelete').modal('show');
        } else {
            //  $(element).removeClass('in');
            $("#holidayModalDelete").modal('hide');
        }
    }
};


function tableRow(odTime, doTime, scope) {
    this.odTime = ko.observable(odTime);
    this.doTime = ko.observable(doTime);

}

function HolidayRow(id, eventName, startDate, endDate, scope) {
    this.self = scope;
    this.Id = ko.observable(ko.utils.unwrapObservable(id));
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
    self.HolidayBeingDelete = ko.observable();
    self.SelectedMonth = null;

    self.EditHoliday = function (id) {
        var match = ko.utils.arrayFirst(self.HolidayList(), function (item) {
            return item.Id() === id;
        });

        var _new = new HolidayRow(match.Id(), match.HolidayName(), match.DateFrom, match.DateTo, self);

        if (match !== null) {
            //  self.HolidayBeingEdited(ko.utils.unwrapObservable(match));
            self.HolidayBeingEdited(ko.utils.unwrapObservable(_new));
        }


    };


    self.AddHoliday = function () {      
        debugger;
        var _new = new HolidayRow(0, "", "2019-01-01", "2019-01-01", self);

        
            //  self.HolidayBeingEdited(ko.utils.unwrapObservable(match));
            self.HolidayBeingEdited(ko.utils.unwrapObservable(_new));
        


    };


    self.HolidayDelete = function (id) {
        
        var match = ko.utils.arrayFirst(self.HolidayList(), function (item) {
            return item.Id() === id;
        });

        var _new = new HolidayRow(match.Id(), match.HolidayName(), match.DateFrom, match.DateTo, self);

        if (match !== null) {
            //  self.HolidayBeingEdited(ko.utils.unwrapObservable(match));
            self.HolidayBeingDelete(ko.utils.unwrapObservable(_new));
        }
    };

    self.RemoveHoliday = function (id) {
        var match = ko.utils.arrayFirst(self.HolidayList(), function (item) {
            return item.Id() === id;
        });
        ko.utils.arrayRemoveItem(self.HolidayList(), match);
        self.HolidayList([]);
    };
 
    self.OnMonthClick = function (month) {
        self.SelectedMonth = month;
        for (var i = 0; i < self.items.length; i++) {
            self.items[i].isActive(false);
        }
        self.items[month - 1].isActive(true);

        self.HolidayList([]);
        self.Utilis.GetApi('api/EmployeesHoldayApi/' + month, null,
            function (x, y, z) {
                

                for (var i = 0; i < x.length; i++) {
                    self.HolidayList.push(new HolidayRow(x[i].id, x[i].holidayName,x[i].dateFrom ,x[i].dateTo, self));
                }               
            },
            function (x, y, z) {
                

            });

        //self.HolidayList([]);

        //self.HolidayList.push(new HolidayRow(1, "Swięto", "2013-01-08", "2013-01-08", self));
        //self.HolidayList.push(new HolidayRow(2, "Swięto1", "2013-01-08", "2013-01-08", self));
        //self.HolidayList.push(new HolidayRow(3, "Swięto12", "2013-01-08", "2013-01-08", self));
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
        console.log("do impementacji !!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

        //var data = {
        //    openHoursId: self.OpenHoursID(),
        //    openHoursName: self.OpenHoursName(),
        //    openHoursType: self.OpenHoursType(),
        //};
        
        let obj = {
            Id: 1,
            HolidayName: "Test",
            DateFrom: '12-12-1985',
            DateTo: '12-12-1985'
        };

        self.Utilis.PostApi('api/EmployeesHoldayApi', obj,
            function (x, y, z) {
                
            },
            function (x, y, z) {
                
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

    self.Init = function (month) {
        self.OnMonthClick(1);
    };
    

}


var components = new ComponentsRegistration();

var openHoursViewModel = new ViewModel();
openHoursViewModel.Utilis = new Utilis();
openHoursViewModel.Init(1);
ko.applyBindings(openHoursViewModel);

