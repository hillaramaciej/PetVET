var my = my || {}; // namespace

my.CalendarApi = (function (my) {
    "use strict";

    var params = {
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        events: [
            {
                id: 1,
                title: 'Business Lunch',
                start: '2016-12-03T13:00:00',
                end: '2016-12-03T14:00:00',
                constraint: 'businessHours',
            },
            {
                id: 2,
                title: 'Meeting',
                start: '2016-12-13T11:00:00',
                constraint: 'availableForMeeting', // defined below
                color: '#68081d'
            },
            {
                id: 3,
                title: 'Conference',
                start: '2016-12-18T13:00:00',
                end: '2016-12-20T11:00:00',
                color: '#68081d'
            },
            {
                id: 4,
                title: 'Party',
                start: '2016-12-29T20:00:00'
            },
            // // areas where "Meeting" must be dropped
            // {
            //     id: 'availableForMeeting',
            //     start: '2016-12-11T10:00:00',
            //     end: '2016-12-11T16:00:00',
            //     rendering: 'background'
            // },
            // {
            //     id: 'availableForMeeting',
            //     start: '2016-12-13T10:00:00',
            //     end: '2016-12-13T16:00:00',
            //     rendering: 'background'
            // },
            // red areas where no events can be dropped
            {

                start: '2016-12-24',
                end: '2016-12-28',
                overlap: false,
                rendering: 'background',
                color: '#ff9f89'
            },
            {
                start: '2016-12-06',
                end: '2016-12-08',
                overlap: false,
                rendering: 'background',
                color: '#ff9f89'
            }
        ],
        viewDate: '2016-12-12',
        minTime: '06:00:00',
        maxTime: '23:00:00',
        startDate: '2016-12-12',

    };
    var ReservationUsers = {
        users: [
            {
                eventId: 1,
                UserId: 11,
                FirstName: "Maciej",
                LastName: "Hillar",
            },
            {
                eventId: 2,
                UserId: 22,
                FirstName: "Marcin",
                LastName: "Mikka",
            }

        ],
    };

    var UsersList = {
        users: [
            {
                UserId: 11,
                FirstName: "Maciej",
                LastName: "Hillar",
            },
            {
                UserId: 22,
                FirstName: "Marcin",
                LastName: "Mikka",
            },
            {
                UserId: 33,
                FirstName: "Michał",
                LastName: "Mirek",
            }

        ],
    };

    return {
        params: params,

        GetRezervationUser: function (id) {
            var self = this;



            var user = ReservationUsers.users.find(x => x.eventId === id || x.eventId == id + 1)

            if (user) {
                return new my.User(user.FirstName, user.LastName,user.UserId);
                //return user;
            }
            else {
               // return undefined;
                               return new my.User("","","");
            }
        },

        GetUserList: function (user) {

            var result = $.map(UsersList.users, function (i, e) {
                // removes all items > 5
                if (i.FirstName.indexOf(user.FirstName()) > -1 && (i.LastName.indexOf(user.LastName()) > -1))
                    return i;
                return null;
            });

            return result;
        },


    }

})(my);


my.Utilis = (function (my) {
    "use strict";

    return {       

        ConvertArrayToUserList: function (array) {
            var self = this;
            let userArray = [];
            $(array).each(function(index, value){
                userArray.push(new my.User(value.FirstName, value.LastName));
            });
            return userArray;

          }
    }
})(my);