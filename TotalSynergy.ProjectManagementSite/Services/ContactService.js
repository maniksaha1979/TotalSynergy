(function () {
    var contactService = function ($http, $q, $log) {
        var cachedcontacts;

        var contacts = function () {
            if (cachedcontacts)
                return $q.when(cachedcontacts);

            return $http.get(String.format("{0}api/Contact/All", DataApiPath()))
                .then(function (serviceResp) {
                    cachedcontacts = serviceResp.data;
                    return serviceResp.data;
                });
        };

        var addcontact = function (contact) {
            return $http.post(String.format("{0}api/Contact/Create", DataApiPath()), contact)
                .then(function (result) {
                    $log.info("Insert Successful");
                    cachedcontacts = result.data;
                    return result;
                });
        };

        return {
            contacts: contacts,
            addcontact: addcontact
        };
    };

    var module = angular.module("TotalSynergyTestModule");

    module.factory("contactService", ["$http", "$q", "$log", contactService]);
}());