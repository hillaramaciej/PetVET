﻿
var Utilis = function () {
    var self = this;

    self.PostApi = function (url, data, success, faild) {

        var sentDate = JSON.stringify(data);

        $.ajax({
            type: "POST",
            url: url,
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