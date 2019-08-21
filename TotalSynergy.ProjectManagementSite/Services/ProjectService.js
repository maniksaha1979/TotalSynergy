(function () {
    var projectService = function ($http, $q, $log) {
        var cachedProjects;

        var projects = function () {
            if (cachedProjects)
                return $q.when(cachedProjects);

            return $http.get(String.format("{0}api/Project/All", DataApiPath()))
                .then(function (serviceResp) {
                    cachedProjects = serviceResp.data;
                    return serviceResp.data;
                });
        };

        var addProject = function (project) {
            return $http.post(String.format("{0}api/Project/Create", DataApiPath()), project)
                .then(function (result) {
                    $log.info("Insert Successful");
                    cachedProjects = result.data;
                    return result;
                });
        };

        return {
            projects: projects,
            addProject: addProject
        };
    };

    var module = angular.module("TotalSynergyTestModule");

    module.factory("projectService", ["$http", "$q", "$log", projectService]);
}());