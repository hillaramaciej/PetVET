
function ViewModel() {
    var self = this;

    //FORM 
    self.OpenHoursID = ko.observable();
    self.OpenHoursName = ko.observable();
    self.OpenHoursType = ko.observable();
    self.MonStart = ko.observable();
    self.MonEnd = ko.observable();
    self.TuStart = ko.observable();
    self.TuEnd = ko.observable();
    self.WenStart = ko.observable();
    self.WenEnd = ko.observable();
    self.ThStart = ko.observable();
    self.ThEnd = ko.observable();
    self.FriStart = ko.observable();
    self.FriEnd = ko.observable();
    self.SatStart = ko.observable();
    self.SatEnd = ko.observable();
    self.SunStart = ko.observable();
    self.SunEnd = ko.observable();


    //END FORM 
    self.InfoMessage = ko.observable("");
    self.IsInfoMessage = ko.observable(false);


    self.Save = function () {

        var data = {
            openHoursId: self.OpenHoursID(),
            openHoursName: self.OpenHoursName(),
            openHoursType: self.OpenHoursType(),
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

        self.OpenHoursID(undefined);
        self.OpenHoursName("");
        self.OpenHoursType(undefined);
        self.MonStart(undefined);
        self.MonEnd(undefined);
        self.TuStart(undefined);
        self.TuEnd(undefined);
        self.WenStart(undefined);
        self.WenEnd(undefined);
        self.ThStart(undefined);
        self.ThEnd(undefined);
        self.FriStart(undefined);
        self.FriEnd(undefined);
        self.SatStart(undefined);
        self.SatEnd(undefined);
        self.SunStart(undefined);
        self.SunEnd(undefined);
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

        self.OpenHoursID(jsonData.openHoursId);
        self.OpenHoursName(jsonData.openHoursName);
        self.OpenHoursType(jsonData.openHoursType);
        self.MonStart(jsonData.monStart);
        self.MonEnd(jsonData.monEnd);
        self.TuStart(jsonData.tuStart);
        self.TuEnd(jsonData.tuEnd);
        self.WenStart(jsonData.wenStart);
        self.WenEnd(jsonData.wenEnd);
        self.ThStart(jsonData.thStart);
        self.ThEnd(jsonData.thEnd);
        self.FriStart(jsonData.friStart);
        self.FriEnd(jsonData.friEnd);
        self.SatStart(jsonData.satStart);
        self.SatEnd(jsonData.satEnd);
        self.SunStart(jsonData.sunStart);
        self.SunEnd(jsonData.sunEnd);
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

var openHoursViewModel = new ViewModel();
openHoursViewModel.Utilis = new Utilis();
ko.applyBindings(openHoursViewModel);

