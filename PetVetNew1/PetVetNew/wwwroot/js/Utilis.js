
var Utilis = function () {
    var self = this;

    self.PostApi = function (url, data, success, faild) {

       // debugger;
        let __RequestVerificationToken = $("input[name='__RequestVerificationToken']").val()
        data.__RequestVerificationToken = __RequestVerificationToken;

        var sentDate = JSON.stringify(data);

        $.ajax({
            type: "POST",
            url: new URL(url, "https://" + window.location.host),
            headers: {
                //'Authorization': "Bearer " + "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoibWFjaWVrLmhpbHVAd3AucGwiLCJleHAiOjE1NDkyMjQ5MzIsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NDQzNDMvIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo0NDM0My8ifQ.gKIBnt_GxRAHCL9iFvbzZmSCau2pjkWgDLVcTjsLJc4",
                'RequestVerificationToken': __RequestVerificationToken
            },            
            data: JSON.stringify(data),
            contentType: "application/json, application/x-www-form-urlencoded",
            success: success,
            error: faild === null ? self.Faild : faild
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
            error: faild,
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

    self.Faild = function (response, textStatus, xhr) {
        //self.Utils.Form.HideProgress();       
      


    };


    return {
        PostApi: self.PostApi,
        GetApi: self.GetApi
    }

};
