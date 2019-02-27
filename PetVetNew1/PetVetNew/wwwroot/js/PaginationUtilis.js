
var PaginationUtilis = function () {
    var self = this;


    var stepViewModel = function (stepObject) {
        var self = this;
        this.Page = ko.observable(stepObject.Page);
        this.Visable = ko.observable(stepObject.Visable);
        this.Selected = ko.observable(false);
    };


    self.InitPaginnation = function (parent,pagginationStep) {

        parent.PaginnationArray = ko.observableArray([]);
        parent.Page = ko.observable(1);
        parent.Step = ko.observable(pagginationStep);
        parent.AllPages = ko.observable(0);

        parent.Next = function () {

            parent.Page(parent.Page() + 1);
            var data = {
                //firstName: self.FirstName(),
                //phonNumber: self.PhonNumber(),
                //lastName: self.LastName(),
                //mail: self.Mail(),
                page: parent.Page(),
                step: parent.Step(),
                search: parent.QuickSearch(),
            };
            parent.CustomerList([]);
            parent.Utilis.PostApi('api/customerApi/search', data, parent.SearchSuccess, parent.SearchFaild);
        };

        parent.Previous = function () {

            parent.Page(parent.Page() - 1);
            var data = {
                //firstName: self.FirstName(),
                //phonNumber: self.PhonNumber(),
                //lastName: self.LastName(),
                //mail: self.Mail(),
                page: parent.Page(),
                step: parent.Step(),
                search: parent.QuickSearch(),
            };

            parent.CustomerList([]);
            parent.Utilis.PostApi('api/customerApi/search', data, parent.SearchSuccess, parent.SearchFaild);
        };

        parent.NextBy = function (param) {

            parent.Page(param());


            console.log(parent.Page());

            var data = {
                //firstName: self.FirstName(),
                //phonNumber: self.PhonNumber(),
                //lastName: self.LastName(),
                //mail: self.Mail(),
                page: parent.Page(),
                step: parent.Step(),
                search: parent.QuickSearch(),
            };

            parent.CustomerList([]);
            parent.Utilis.PostApi('api/customerApi/search', data, parent.SearchSuccess, parent.SearchFaild);
        };
    };


    var SetSelected = function (array, page) {
        debugger;
        var match = ko.utils.arrayFirst(array(), function (item) {
            return item.Page() == page;
        });

        if (match) {
            match.Selected(true);
        }
    };

    self.SetPaginnation = function (array, page, step, max, allPages) {
        console.log(page);
        array([]);
        //dodać zaokroglenie w górę bo nie bedzie widoczna czasem ostatnia strona
     
        if (allPages == 1) {
            array.push(
                new stepViewModel({ Page: 'Prevouse', Visable: false }),
                new stepViewModel({ Page: 1, Visable: true }),
                new stepViewModel({ Page: 2, Visable: false }),
                new stepViewModel({ Page: 3, Visable: false }),
                new stepViewModel({ Page: 4, Visable: false }),
                new stepViewModel({ Page: 5, Visable: false }),
                new stepViewModel({ Page: 'Next', Visable: false })
            );
        } else if (allPages == 2) {
            array.push(
                new stepViewModel({ Page: 'Prevouse', Visable: false }),
                new stepViewModel({ Page: 1, Visable: true }),
                new stepViewModel({ Page: 2, Visable: true }),
                new stepViewModel({ Page: 3, Visable: false }),
                new stepViewModel({ Page: 4, Visable: false }),
                new stepViewModel({ Page: 5, Visable: false }),
                new stepViewModel({ Page: 'Next', Visable: false })
            );
        }
        else if (allPages == 3) {
            array.push(
                new stepViewModel({ Page: 'Prevouse', Visable: false }),
                new stepViewModel({ Page: 1, Visable: true }),
                new stepViewModel({ Page: 2, Visable: true }),
                new stepViewModel({ Page: 3, Visable: true }),
                new stepViewModel({ Page: 4, Visable: false }),
                new stepViewModel({ Page: 5, Visable: false }),
                new stepViewModel({ Page: 'Next', Visable: false })
            );
        }

        else if (allPages == 4) {
            array.push(
                new stepViewModel({ Page: 'Prevouse', Visable: false }),
                new stepViewModel({ Page: 1, Visable: true }),
                new stepViewModel({ Page: 2, Visable: true }),
                new stepViewModel({ Page: 3, Visable: true }),
                new stepViewModel({ Page: 4, Visable: true }),
                new stepViewModel({ Page: 5, Visable: false }),
                new stepViewModel({ Page: 'Next', Visable: false })
            );
        }
        else if (page == allPages) {
            array.push(
                new stepViewModel({ Page: 'Prevouse', Visable: true }),
                new stepViewModel({ Page: 1, Visable: true }),
                new stepViewModel({ Page: allPages - 2, Visable: true }),
                new stepViewModel({ Page: allPages - 1, Visable: true }),
                new stepViewModel({ Page: allPages, Visable: true }),
                new stepViewModel({ Page: allPages, Visable: false }),
                new stepViewModel({ Page: 'Next', Visable: false })
            )
        }
        else {

            if (page == 1)
                array.push(
                    new stepViewModel({ Page: 'Prevouse', Visable: false }),
                    new stepViewModel({ Page: 1, Visable: true }),
                    new stepViewModel({ Page: 2, Visable: true }),
                    new stepViewModel({ Page: 3, Visable: true }),
                    new stepViewModel({ Page: 4, Visable: true }),
                    new stepViewModel({ Page: allPages, Visable: true }),
                    new stepViewModel({ Page: 'Next', Visable: true })
                )
            else if (page == allPages) {
                array.push(
                    new stepViewModel({ Page: 'Prevouse', Visable: true }),
                    new stepViewModel({ Page: 1, Visable: true }),
                    new stepViewModel({ Page: 2, Visable: true }),
                    new stepViewModel({ Page: 3, Visable: true }),
                    new stepViewModel({ Page: 4, Visable: false }),
                    new stepViewModel({ Page: allPages, Visable: true }),
                    new stepViewModel({ Page: 'Next', Visable: false })
                );
            }

            else if (page > 1) {
                array.push(
                    new stepViewModel({ Page: 'Prevouse', Visable: true }),
                    new stepViewModel({ Page: 1, Visable: true }),
                    new stepViewModel({ Page: 2, Visable: true }),
                    new stepViewModel({ Page: 3, Visable: true }),
                    new stepViewModel({ Page: 4, Visable: true }),
                    new stepViewModel({ Page: allPages, Visable: page + 1 != allPages && page != allPages }),
                    new stepViewModel({ Page: 'Next', Visable: page + 1 != allPages && page != allPages })
                );

                if (page >= 4) {  

                    array()[2].Page(page - 1);
                    array()[3].Page(page);
                    array()[4].Page(page + 1)
                }
            }
        }


        debugger;
        SetSelected(array, page);
    };    

    return {
        SetPaginnation: self.SetPaginnation,
        InitPaginnation: self.InitPaginnation
    }

};
