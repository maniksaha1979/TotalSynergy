(function () {
    var contactService = function ($http, $q, $log) {
        
        var contacts = function () {
            return $http.get(String.format("{0}api/Contact/All", DataApiPath()))
                .then(function (serviceResp) {
                    return serviceResp.data;
                });
        };

        var addcontact = function (contact) {
            return $http.post(String.format("{0}api/Contact/Create", DataApiPath()), contact)
                .then(function (result) {
                    $log.info("Insert Successful");
                    return result;
                });
        };

        return {
            Getcontacts: contacts,
            CreateContact: addcontact
        };
    };

    var module = angular.module("TotalSynergyTestModule");

    module.factory("contactService", ["$http", "$q", "$log", contactService]);
}());