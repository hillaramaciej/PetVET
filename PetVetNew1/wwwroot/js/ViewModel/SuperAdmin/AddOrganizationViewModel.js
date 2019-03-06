

function ViewModel() {
    var self = this;

    //FORM 

    self.Mail = ko.observable("");
    self.LicenseCount = ko.observable(0);//.extend({ required: true }).extend({ minLength: 3 });

    //END FORM 

    self.Save = function () {

        var data = {
            mail: self.Mail(),
            licenseCount: self.LicenseCount()
        }

        self.Utilis.PostApi('api/superAdminApi', data, SaveSuccessfull, SaveFailed)

    };

    var SaveSuccessfull = function (response, textStatus, xhr) {
        debugger;
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

    var SaveFailed = function (response, textStatus, xhr) {
        debugger;
        //self.Utils.Form.HideProgress();
        if (response.message) {
            //self.Utils.Form.ErrorDialog(response.message);
        }
    };

    self.ClearInfoMessage = function () {
        self.InfoMessage = ko.observable("");
        self.IsInfoMessage = ko.observable(false);
    };

    self.AddNew = function () {
        self.ClearInfoMessage();

        self.Mail("");
        self.LicenseCount(0);

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

var addOrganizationViewModel = new ViewModel();
addOrganizationViewModel.Utilis = new Utilis();
ko.applyBindings(addOrganizationViewModel);

