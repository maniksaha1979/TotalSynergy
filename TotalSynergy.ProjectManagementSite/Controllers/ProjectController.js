(function () {
    var ProjectController = function ($scope, projectService, $log, $routeParams, $location) {
        var projects = function (data) {
            $scope.Projects = data;
            $log.info(data);
        };

        $scope.init = function () {
            
        };

        var project = {
            Id: null,
            Name: null
        };

        $scope.project = project;

        var errorDetails = function (serviceResp) {
            $scope.Error = "Something went wrong ??";
        };

        $scope.AddProject = function (project) {
            projectService.addProject(project)
                .then(function (data) {
                    console.log(data);
                    $location.path("/Project");
                });
        };

        
        var refresh = function () {
            projectService.projects()
                .then(projects, errorDetails);
        };

        refresh();
        $scope.Title = "Project Details Page";
    };
    app.controller("ProjectController", ["$scope", "projectService", "$log", "$routeParams", "$location", ProjectController]);
}());