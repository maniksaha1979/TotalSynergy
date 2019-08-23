(function () {
    var AddProjectController = function ($scope, projectService, $log, $routeParams, $location) {


        $scope.init = function () {
            
        };

        var project = {
            Id: null,
            Name: null
        };

        $scope.SingleProject = project;

        var errorDetails = function (serviceResp) {
            $scope.Error = "Something went wrong ??";
        };

        $scope.AddProject = function (project) {
            $log.log(project.Name);
            projectService.CreateProject(project)
                .then(function (data) {
                    $location.path("/AddProject");
                });
        };

        
    };
    app.controller("AddProjectController", ["$scope", "projectService", "$log", "$routeParams", "$location", AddProjectController]);
}());