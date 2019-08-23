(function () {
    var ProjectContactController = function ($scope, projectContactService, projectService, contactService, $log, $routeParams, $location,) {

        var availableProjects = function (data) {
            $scope.allAvailableprojects = data;
        };
        var errorDetails = function (serviceResp) {
            $scope.Error = "Something went wrong!!";
        };

        var refreshProjects = function () {
            projectService.Getprojects().then(availableProjects, errorDetails);
        };

        var availablecontacts = function (data) {
            $scope.allAvailablecontacts = data;
        };

        var refreshContacts = function () {
            contactService.Getcontacts().then(availablecontacts, errorDetails);
        };

        var projectContacts = function (data) {
            $scope.projectContacts = data;
        };

        
        $scope.ProjectContactTitle = "Project Contact Page";

        $scope.init = function () {

        };

        var projectContact = {
            Id: null,
            ProjectId: null,
            ContactId: null,
            ProjectName: null,
            ContactName: null
        };


        $scope.singleProjectContact = projectContact;

       var getProjectContacts = function (data) {
            $scope.allProjectContacts = data;
        };
        

        $scope.AddProjectContact = function (ProjectContact) {
            projectContactService.CreateProjectContact(ProjectContact)
                .then(function (data) {
                    console.log(data);
                    $location.path("/ProjectContact");
                });
        };

        $scope.ProjectContactRefresh = function () {
            projectContactService.GetprojectContacts()
                .then(getProjectContacts, errorDetails);
        };

        var refresh = function () {
            projectContactService.GetprojectContacts()
                .then(getProjectContacts, errorDetails);
        };

        refreshProjects();
        refreshContacts();
        refresh();
       
    };
    app.controller("ProjectContactController", ["$scope", "projectContactService", "projectService", "contactService",  "$log", "$routeParams", "$location", ProjectContactController]);
}());