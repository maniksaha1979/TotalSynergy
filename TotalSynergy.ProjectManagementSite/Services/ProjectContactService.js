(function () {
    var projectContactService = function ($http) {
        var projectContacts = function () {
            return $http.get(String.format("{0}api/ProjectContact/All", DataApiPath()))
                .then(function (serviceResp) {
                    return serviceResp.data;
                });
        };

        var addProjectContact = function (newData) {
            return $http.post(String.format("{0}api/ProjectContact/Create", DataApiPath()), newData)
                .then(function (response) {
                    return response.data;
                });
        };

        return {
            GetprojectContacts: projectContacts,
            CreateProjectContact: addProjectContact
        };
    };
    var module = angular.module("TotalSynergyTestModule");
    module.factory("projectContactService", ["$http", projectContactService]);
}());