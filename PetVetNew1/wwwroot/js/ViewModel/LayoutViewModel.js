

function ViewModel () {
        var self = this;

       //FORM 
        
        data = {}
  
        self.Logout = function () {


            var sentDate = JSON.stringify({});

            $.ajax({
                type: "POST",
                url: new URL('Account/Logout', "https://" + window.location.host),

               // data: JSON.stringify(data),
                contentType: "application/json",                
            });


            //self.Utilis.PostApi('Account/Logout', data, null, null);
        };
    }

var layoutViewModel = new ViewModel();
//layoutViewModel.Utilis = new Utilis();
ko.applyBindings(layoutViewModel);

