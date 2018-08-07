
function ViewModel() {
    var self = this;

    //FORM 
    self.PetID = ko.observable();
    self.Name = ko.observable();
    self.PetType1 = ko.observable();
    self.PetType2 = ko.observable();
    self.Sex = ko.observable();
    self.ChipNo = ko.observable();
    //END FORM 
    self.InfoMessage = ko.observable("");
    self.IsInfoMessage = ko.observable(false);

    self.SexOptionData = [
        { id: 1, name: "Obojniak" },
        { id: 2, name: "Samiec" },
        { id: 3, name: "Samica" },
    ];
    
    self.SelectedValueCallback = function (value) {
        self.Sex(value);
    }

    self.Save = function () {

        var data = {
            petId: self.PetID(),
            name: self.Name(),
            petType1: self.PetType1(),
            petType2: self.PetType2(),
            sex: self.Sex(),
            chipNo: self.ChipNo(),
        }

        self.Utilis.PostApi('api/PetApi', data, self.SaveSuccessfull, SaveFailed)

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

        self.PetID(undefined);
        self.Name("");
        self.PetType1(undefined);
        self.PetType2(undefined);
        self.Sex(undefined);
        self.ChipNo("");
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

        self.PetID(jsonData.petId)
        self.Name(jsonData.name);
        self.PetType1(jsonData.petType1);
        self.PetType2(jsonData.petType2);
        self.Sex(jsonData.sex);
        self.ChipNo(jsonData.chipNo);
    };

}

//ko.validation.configure = {
//    decorateElement: true,
//    registerExtenders: true,
//    messagesOnModified: true,
//    insertMessages: true,
//    parseInputAttributes: true,
//    messageTemplate: null
//};

var components = new ComponentsRegistration();

var petViewModel = new ViewModel();
petViewModel.Utilis = new Utilis();
ko.applyBindings(petViewModel);

