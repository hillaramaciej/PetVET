
var Utilis = function () {
    var self = this;

    self.PostApi = function (url, data, success, faild) {

        var sentDate = JSON.stringify(data);

        $.ajax({
            type: "POST",
            url: new URL(url, "https://" + window.location.host),

            data: JSON.stringify(data),
            contentType: "application/json",
            success: success,
            failed: faild,
        });
    };

    self.GetApi = function (url, data, success, faild) {

        var sentDate = JSON.stringify(data);

        $.ajax({
            type: "Get",
            url: new URL(url, "https://" + window.location.host),
            data: JSON.stringify(data),
            contentType: "application/json",
            success: success,
            failed: faild,
        });
    };

    self.SearchApi = function (url, data, success, faild) {

        var sentDate = JSON.stringify(data);

        $.ajax({
            type: "Get",
            url: new URL(url, "https://" + window.location.host),
            data: JSON.stringify(data),
            contentType: "application/json",
            success: success,
            failed: faild,
        });
    };

    return {
        PostApi: self.PostApi,
    }

};
