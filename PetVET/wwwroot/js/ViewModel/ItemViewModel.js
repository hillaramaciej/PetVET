
function ViewModel() {
    var self = this;

    //FORM 
    self.ItemID = ko.observable();
    self.ItemName = ko.observable();
    self.ItemCost = ko.observable();
    self.ItemPrice = ko.observable();
    self.ItemExpirationDate = ko.observable();
    self.ItemPurchaseDate = ko.observable();
    self.ItemKind = ko.observable();
    //END FORM 
    self.InfoMessage = ko.observable("");
    self.IsInfoMessage = ko.observable(false);

    self.ItemKindOptionData = [
        { id: 1, name: "Lek" },
        { id: 2, name: "Karma" },
        { id: 3, name: "Inne" },
    ];
    
    self.SelectedValueCallback = function (value) {
        self.ItemKind(value);
    }

    self.Save = function () {

        var data = {
            itemID: self.ItemID(),
            itemName: self.ItemName(),
            itemCost: self.ItemCost(),
            itemPrice: self.ItemPrice(),
            itemExpirationDate: self.ItemExpirationDate(),
            itemPurchaseDate: self.ItemPurchaseDate(),
            itemKind: self.ItemKind(),
        }

        self.Utilis.PostApi('api/ItemApi', data, self.SaveSuccessfull, SaveFailed)

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

        self.ItemID(undefined);
        self.ItemName("");
        self.ItemCost(undefined);
        self.ItemPrice(undefined);
        self.ItemExpirationDate(undefined);
        self.ItemPurchaseDate("");
        self.ItemKind("");
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

        self.ItemID(jsonData.itemID)
        self.ItemName(jsonData.itemName);
        self.ItemCost(jsonData.itemCost);
        self.ItemPrice(jsonData.itemPrice);
        self.ItemExpirationDate(jsonData.itemExpirationDate);
        self.ItemPurchaseDate(jsonData.itemPurchaseDate);
        self.ItemKind(jsonData.itemKind);
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

var itemViewModel = new ViewModel();
itemViewModel.Utilis = new Utilis();
ko.applyBindings(itemViewModel);

