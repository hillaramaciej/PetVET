
function ViewModel() {
    var self = this;

    //FORM 
    self.PetID = ko.observable();
    self.Name = ko.observable();
    self.Species = ko.observable();
    self.Race = ko.observable();
    self.Age = ko.observable();
    self.ChipNumber = ko.observable();
    self.Weight = ko.observable();
    self.Coat = ko.observable();
    self.Sex = ko.observable();
    self.Castrated = ko.observable();

    //END FORM 
    self.InfoMessage = ko.observable("");
    self.IsInfoMessage = ko.observable(false);

    //self.SexOptionData = [
    //    { id: 1, name: "Obojniak" },
    //    { id: 2, name: "Samiec" },
    //    { id: 3, name: "Samica" },
    //];
    
    self.SelectedValueCallback = function (value) {
        self.Sex(value);
    }

    self.Save = function () {

        var data = {
            petId: self.PetID(),
            name: self.Name(),
            species: self.Species(),
            race: self.Race(),
            age: self.Age(),
            chipNumber: self.ChipNumber(),
            weight: self.Weight(),
            coat: self.Coat(),
            sex: self.Sex(),
            castrated: self.Castrated(),
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
        self.Species(undefined);
        self.Race(undefined);
        self.Age(null);
        self.ChipNumber(null);
        self.Weight(null);
        self.Coat(undefined);
        self.Sex(undefined);
        self.Castrated(null);
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
        self.Species(jsonData.species);
        self.Race(jsonData.race);
        self.Age(jsonData.age);
        self.ChipNumber(jsonData.chipNumber);
        self.Weight(jsonData.weight);
        self.Coat(jsonData.coat);
        self.Sex(jsonData.sex);
        self.Castrated(jsonData.castrated);
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

