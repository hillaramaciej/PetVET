(function () {


  ko.bindingHandlers.enterKey = {
    init: function (element, valueAccessor, allBindings, data, context) {
      var wrapper = function (data, event) {
        if (event.keyCode === 13) {
          valueAccessor().call(this, data, event);
        }
      };
      ko.applyBindingsToNode(element, { event: { keyup: wrapper } }, context);
    }
  };

  ko.bindingHandlers.fullCalendar = {
    update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
      ko.unwrap(valueAccessor());
      this.vm = viewModel;

      $(element).fullCalendar('destroy');
      $(element).fullCalendar({
        eventLimit: true,
        events: ko.utils.unwrapObservable(viewModel.events),
        header: viewModel.header,
        navLinks: true, // can click day/week names to navigate views
        businessHours: true, // display business hours
        editable: true,
        selectable: true,
        defaultDate: viewModel.startDate,
        minTime: viewModel.minTime,
        maxTime: viewModel.maxTime,
        firstDay: 1,
        contentHeight: 900,
        eventRender: function (event, element) {
          var originalClass = element[0].className;
          element[0].className = originalClass + ' hasmenu';
        },
        dayRender: function (day, cell) {
          var originalClass = cell[0].className;
          cell[0].className = originalClass + ' hasmenu';
        },
        dayClick: function (date, jsEvent, view) {

          var t = vm.events().find(x => {
            if (x.rendering !== undefined) {
              return moment.utc(x.start) < moment.utc(date._i)
                && moment.utc(x.end) < moment.utc(date._i)
            }
          })
        },
        select: function (start, end) {
          var t = start;
        },
        eventClick: function (calEvent, jsEvent, view) {
          selectedEvent = calEvent;
          if (Number.isInteger(selectedEvent.id))
            vm.isAutoComplete(true);
          else
            vm.isAutoComplete(false);
            vm.VisableUserList(false);
            vm.UsersList([]);
          var user = my.CalendarApi.GetRezervationUser(selectedEvent.id);
          vm.OrginalRezervation = ko.utils.unwrapObservable(new my.Rezervation(ko.observable(selectedEvent), ko.observable(user)));
          vm.ReservationBeginEdited(ko.utils.unwrapObservable(new my.Rezervation(ko.observable(selectedEvent), ko.observable(new my.User(user.FirstName, user.LastName,user.UserId)))));


          // $('#addEvent').modal('show');
          // vm.removeEvent(selectedEvent.id)
        },
        defaultView: viewModel.selectedView,
        droppable: true, // this allows things to be dropped onto the calendar
        eventRender: function( event, element, view ){
            var t =event;
        },
        eventReceive: function (event) {
          let e = vm.events().find(x => x.id === event.id);

          if (event.id == "Nowa rezerwacja") {
            event.color = 'red';
          }
          else if (event.id == "Dzień Wolny") {
            event.overlap = false;
            event.rendering = 'background';
            event.color = '#ff9f89';

          }
          else if (event.id == "Przerwa") {
            event.color = 'green';

          }
          vm.events.push(event);
        }

      });
      $(element).fullCalendar('gotoDate', viewModel.viewDate);
      $('div.fc-button-group > button').on('click', function () {
        if ($(this).hasClass('fc-state-active')) {
          var res = vm.ViewObjectArray.find(x => x.view === $(this)[0].innerText).type;
          vm.selectedView = res;
        }
      });

      var calndr = $('#external-events .fc-event');

      $(calndr).each(function () {
  //      store data so the calendar knows to render an event upon drop
        $(this).data('event', {
          title: $.trim($(this).text()),
          id: $.trim($(this).text()), // use the element's text as the event title
          stick: true // maintain when user navigates (see docs on the renderEvent method)
        });

   //     make the event draggable using jQuery UI
        $(this).draggable({
          zIndex: 999,
          revert: true, // will cause the event to go back to its
          revertDuration: 0  //  original position after the drag
        });

      });
    }
  };
  

  ko.bindingHandlers['modal'] = {
    init: function (element, valueAccessor, allBindingsAccessor) {
      var allBindings = allBindingsAccessor();
      var $element = $(element);
      $element.addClass('hide modal');
      $element.modal('hide');

      if (allBindings.modalOptions && allBindings.modalOptions.beforeClose) {
        $element.on('hide', function () {
          var value = ko.utils.unwrapObservable(valueAccessor());
          return allBindings.modalOptions.beforeClose(value);
        });
      }
    },
    update: function (element, valueAccessor) {
      var value = ko.utils.unwrapObservable(valueAccessor());
      if (value) {
        $(element).removeClass('hide').modal('show');
      } else {
        $(element).modal('hide');
      }
    }
  };


  my.OrginalRezervation = ko.observable(undefined);
  /* ViewModel for the modal*/
  my.Rezervation = function (event, user , pets) {
    var self = this;
    self.RezervationEvent = ko.observable(ko.utils.unwrapObservable(event));
    self.User = ko.observable(ko.utils.unwrapObservable(user));
    self.Test = ko.observable(ko.utils.unwrapObservable("mm"));
    //self.Pets = ko.observableArray(pets);   
  }

  /* ViewModel for the individual records in our collection. */
  my.User = function (name, lastName,id) {
    var self = this;
    self.UserId = ko.observable(ko.utils.unwrapObservable(id));
    self.FirstName = ko.observable(ko.utils.unwrapObservable(name));
    self.LastName = ko.observable(ko.utils.unwrapObservable(lastName));

    self.FullName = ko.computed(function(){
      return self.FirstName() +', ' + self.LastName();
    });
  }

  /* The page's main ViewModel. */
  my.ViewModel = function (config) {
    var self = this;

    self.isAutoComplete = ko.observable(false);
    self.VisableUserList = ko.observable(false);
    self.UsersList = ko.observableArray([]);
    self.ValidationErrors = ko.observableArray([]);
    self.IsNewUser = ko.observable(false);

    //!!!!!!!!!!!! Trzeba dorobić walidacje czy jest to liczba czy string i dodać szukanie po telefonie;
    self.AutoComplete = function (f, data, event) {
      console.log(event.key);

      f(f() + event.key);
      let users = my.CalendarApi.GetUserList(self.ReservationBeginEdited().User());

      if(users.length > 1){
      self.VisableUserList(true);
      self.UsersList(my.Utilis.ConvertArrayToUserList(users));
      }else if(users.length == 1){
        self.ReservationBeginEdited().User(new my.User(users[0].FirstName,users[0].LastName));
        self.VisableUserList(false);
      }
      else{
        self.VisableUserList(false);        
      }

    };

   // Logic to ensure that user being edited is in a valid state
    self.ValidateUser = function (user) {
      if (!user) {
        return false;
      }

      var currentUser = ko.utils.unwrapObservable(user);
      var currentName = ko.utils.unwrapObservable(currentUser.Name);
      var currentAge = ko.utils.unwrapObservable(currentUser.LastName);

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

    //The instance of the user currently being edited.
    self.ReservationBeginEdited = ko.observable();

   // Used to keep a reference back to the original user record being edited
    self.OriginalReservationInstance = ko.observable();

    self.DeleteEvent = function () {
      var reservation = ko.utils.unwrapObservable(self.ReservationBeginEdited);
       vm.removeEvent(reservation.RezervationEvent().id);
       vm.ReservationBeginEdited(undefined);




       
        $('#ReservationModal').modal('hide');
    //  Load up a new user instance to be edited
      self.ReservationBeginEdited(new my.User());
      self.OriginalReservationInstance(undefined);
    };

    self.Edit = function (user) {
      var updatedUser = ko.utils.unwrapObservable(self.ReservationBeginEdited);
      updatedUser.User().FirstName("tyeryery");

     // Keep a copy of the original instance so we don't modify it's values in the editor
      self.OriginalReservationInstance(user);

      // Copy the user data into a new instance for editing
      self.ReservationBeginEdited(new my.User(user.Name, user.LastName));
    };

   // Save the changes back to the original instance in the collection.
    self.SaveUser = function () {
      var updatedUser = ko.utils.unwrapObservable(self.ReservationBeginEdited);
var dddd = ko.utils.unwrapObservable(vm.OrginalRezervation);

      var name = ko.utils.unwrapObservable(ko.utils.unwrapObservable(updatedUser.User()).FirstName)
      var id = ko.utils.unwrapObservable(ko.utils.unwrapObservable(updatedUser.User()).UserId)
      var lastName = ko.utils.unwrapObservable(ko.utils.unwrapObservable(updatedUser.User()).LastName)

      $('#ReservationModal').modal('hide');
      if (!self.ValidateUser(updatedUser)) {
        // Don't allow users to save users that aren't valid
        return false;
      }

      var userName = ko.utils.unwrapObservable(updatedUser.Name);
      var userAge = ko.utils.unwrapObservable(updatedUser.LastName);

      if (self.OriginalReservationInstance() === undefined) {
        // Adding a new user
        self.Users.push(new my.User(userName, userAge));
      } else {
        // Updating an existing user
        self.OriginalReservationInstance().Name(userName);
        self.OriginalReservationInstance().LastName(userAge);
      }

      // Clear out any reference to a user being edited
      self.ReservationBeginEdited(undefined);
      self.OriginalReservationInstance(undefined);
    }

    //Remove the selected user from the collection
    self.DeleteUser = function (user) {
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



    /* ----------------- END Modal ----------------*/
    /* -----------------  Full Calendar ----------------*/
    self.selectedEvent = ko.observable(null);
    self.header = config.params.header;
    self.events = ko.observableArray(config.params.events);
    self.minTime = config.params.minTime;
    self.maxTime = config.params.maxTime;
    self.viewDate = config.params.viewDate;
    self.selectedView = 'month';
    self.name = ko.observable("Maciej"),
      self.removeEvent = function (id) {
        self.events.remove(function (event) {
          self.name = "asdasd";
          return event.id == id;
        });

      };
    self.ViewObjectArray = [
      { view: "week", type: "agendaWeek" },
      { view: "month", type: "month" },
      { view: "day", type: "agendaDay" },
    ];

    this.notes = ko.observableArray();
  }
  /* -----------------  End Calendar ----------------*/


})();



var calendarViewModel = new my.ViewModel(my.CalendarApi);

calendarViewModel.ReservationBeginEdited.subscribe(function(newValue){
  if(calendarViewModel.isAutoComplete())
  {

  }

});


// Populate the ViewModel with some dummy data
// for (var i = 1; i <= 10; i++) {
//   var letter = String.fromCharCode(i + 64);
//   var userName = 'User ' + letter;
//   var userAge = i * 2;
//   calendarViewModel.Users.push(new my.User(userName, userAge));
// }  
// //Let Knockout do its magic!

ko.applyBindings(calendarViewModel);






 ////var calendarViewModel = new ko.fullCalendar.viewModel(params);
//ko.applyBindings(calendarViewModel);






