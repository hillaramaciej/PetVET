ko.bindingHandlers['modal'] = {
  init: function(element, valueAccessor, allBindingsAccessor) {
    var allBindings = allBindingsAccessor();
    var $element = $(element);
    $element.addClass('hide modal');
    
    if (allBindings.modalOptions && allBindings.modalOptions.beforeClose) {
      $element.on('hide', function() {
        var value = ko.utils.unwrapObservable(valueAccessor());
        return allBindings.modalOptions.beforeClose(value);
      });
    }
  },
  update: function(element, valueAccessor) {
    var value = ko.utils.unwrapObservable(valueAccessor());
    if (value) {
      $(element).removeClass('hide').modal('show');
    } else {
      $(element).modal('hide');
    }
  }
};

/* ViewModel for the individual records in our collection. */
var User = function(name, age) {
  var self = this;
  self.Name = ko.observable(ko.utils.unwrapObservable(name));
  self.Age = ko.observable(ko.utils.unwrapObservable(age));
}

/* The page's main ViewModel. */
var ViewModel = function() {
  var self = this;
  self.Users = ko.observableArray();
  
  self.ValidationErrors = ko.observableArray([]);
  
  // Logic to ensure that user being edited is in a valid state
  self.ValidateUser = function(user) {
    if (!user) {
      return false;
    }
    
    var currentUser = ko.utils.unwrapObservable(user);
    var currentName = ko.utils.unwrapObservable(currentUser.Name);
    var currentAge = ko.utils.unwrapObservable(currentUser.Age);
    
    self.ValidationErrors.removeAll(); // Clear out any previous errors
    
    if (!currentName)
      self.ValidationErrors.push("The user's name is required.");
    
    if (!currentAge) {
      self.ValidationErrors.push("Please enter the user's age.");
    } else { // Just some arbitrary checks here...
      if (Number(currentAge) == currentAge && currentAge % 1 === 0) { // is a whole number
        if (currentAge < 2) {
          self.ValidationErrors.push("The user's age must be 2 or greater.");
        } else if (currentAge > 99) {
          self.ValidationErrors.push("The user's age must be 99 or less.");
        }
      } else {
        self.ValidationErrors.push("Please enter a valid whole number for the user's age.");
      }
    }
    
    return self.ValidationErrors().length <= 0;
  };
  
  // The instance of the user currently being edited.
  self.UserBeingEdited = ko.observable();
  
  // Used to keep a reference back to the original user record being edited
  self.OriginalUserInstance = ko.observable();
  
  self.AddNewUser = function() {
    // Load up a new user instance to be edited
    self.UserBeingEdited(new User());
    self.OriginalUserInstance(undefined);
  };
  
  self.EditUser = function(user) {
    // Keep a copy of the original instance so we don't modify it's values in the editor
    self.OriginalUserInstance(user);
    
    // Copy the user data into a new instance for editing
    self.UserBeingEdited(new User(user.Name, user.Age));
  };
  
  // Save the changes back to the original instance in the collection.
  self.SaveUser = function() {
    var updatedUser = ko.utils.unwrapObservable(self.UserBeingEdited);
    
    if (!self.ValidateUser(updatedUser)) {
      // Don't allow users to save users that aren't valid
      return false;
    }
    
    var userName = ko.utils.unwrapObservable(updatedUser.Name);
    var userAge = ko.utils.unwrapObservable(updatedUser.Age);
    
    if (self.OriginalUserInstance() === undefined) {
      // Adding a new user
      self.Users.push(new User(userName, userAge));
    } else {
      // Updating an existing user
      self.OriginalUserInstance().Name(userName);
      self.OriginalUserInstance().Age(userAge);
    }
    
    // Clear out any reference to a user being edited
    self.UserBeingEdited(undefined);
    self.OriginalUserInstance(undefined);
  }
  
  // Remove the selected user from the collection
  self.DeleteUser = function(user) {
    if (!user) {
      return false;
    }
    
    var userName = ko.utils.unwrapObservable(ko.utils.unwrapObservable(user).Name);
    
    // We could use another modal here to display a prettier dialog, but for the
    // sake of simplicity, we're just using the browser's built-in functionality.
    if (confirm('Are you sure that you want to delete ' + userName + '?')) {
      // Find the index of the current user and remove them from the array
      var index = self.Users.indexOf(user);
      if (index > -1) {
        self.Users.splice(index, 1);
      }
    }
  };
}

var viewModel = new ViewModel();

// Populate the ViewModel with some dummy data
for (var i = 1; i <= 10; i++) {
  var letter = String.fromCharCode(i + 64);
  var userName = 'User ' + letter;
  var userAge = i * 2;
  viewModel.Users.push(new User(userName, userAge));
}

// Let Knockout do its magic!
ko.applyBindings(viewModel);