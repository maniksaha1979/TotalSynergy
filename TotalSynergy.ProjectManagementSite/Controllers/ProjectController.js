(function () {
    var ProjectController = function ($scope, projectService, $log, $routeParams, $location) {

        var getProjects = function (data) {
            $log.log(data);
            $scope.AllProjects = data;
            $log.log(data);
            $log.log($scope.AllProjects);
        };

        $scope.ProjectTitle = "Project Details Page";

        $scope.init = function () {
            
        };

        var project = {
            Id: null,
            Name: null
        };

        $scope.Project = project;

        var errorDetails = function (serviceResp) {
            $scope.Error = "Something went wrong ??";
        };

        $scope.AddProject = function (project) {
            projectService.addProject(project)
                .then(function (data) {
                    $location.path("/AddProject");
                });
        };

        
        $scope.ProjectRefresh = function () {
            projectService.Getprojects()
                .then(getProjects, errorDetails);
        };

        $scope.ProjectRefresh();
        
    };
    app.controller("ProjectController", ["$scope", "projectService", "$log", "$routeParams", "$location", ProjectController]);
}());