(function () {
    var ProjectContactController = function ($scope, $location, projectContactService, projectService, contactService) {
        var projects = function (data) {
            $scope.projects = data;
        };
        var errorDetails = function (serviceResp) {
            $scope.Error = "Something went wrong!!";
        };

        projectService.projects().then(projects, errorDetails);

        var contacts = function (data) {
            $scope.contacts = data;
        };

        contactService.contacts().then(contacts, errorDetails);

        var projectContacts = function (data) {
            $scope.projectContacts = data;
        };

        projectContactService.projectContacts().then(projectContacts, errorDetails);
        $scope.Title = "Project Contact Page";

        $scope.init = function () {

        };

        var projectContact = {
            Id: null,
            ProjectId: null,
            ContactId: null,
            ProjectName: null,
            ContactName: null
        };

        $scope.ProjectContact = projectContact;
        

        $scope.AddProjectContact = function (ProjectContact) {
            projectContactService.addProjectContact(ProjectContact)
                .then(function (data) {
                    console.log(data);
                    $location.path("/ProjectContact");
                });
        };


        var refresh = function () {
            projectContactService.projectContacts()
                .then(projectContacts, errorDetails);
        };

        refresh();

       
    };
    app.controller("ProjectContactController", ["$scope", "$location", "projectContactService", "projectService", "contactService", ProjectContactController]);
}());