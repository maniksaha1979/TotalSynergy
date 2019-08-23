(function () {
    var projectService = function ($http, $q, $log) {
        

        var projects = function () {
            $log.log("In projects in service");
            //var geturl = String.format("{0}api/Project/All", DataApiPath()) + "?callback==JSON_CALLBACK";
            //return $http.jsonp(geturl)
            //    .then(function (serviceResp) {
            //        $log.debug(serviceResp);
            //        $log.log(serviceResp.found);
            //        return serviceResp.found;
            //    });

            return $http.get(String.format("{0}api/Project/All", DataApiPath()))
                .then(function (serviceResp) {
                    return serviceResp.data;
                });
        };

        var addProject = function (project) {
            return $http.post(String.format("{0}api/Project/Create", DataApiPath()), project)
                .then(function (result) {
                    $log.log("Add Project");
                    $log.info("Insert Successful");
                    return result;
                });
        };

        return {
            Getprojects: projects,
            CreateProject: addProject
        };
    };

    var module = angular.module("TotalSynergyTestModule");

    module.factory("projectService", ["$http", "$q", "$log", projectService]);
}());