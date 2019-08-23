var app = angular.module('TotalSynergyTestModule', ['ngRoute', 'ui.bootstrap']);
app.config(function ($routeProvider) {
    $routeProvider
        .when("/Home", {
            templateUrl: "/Home.html",
            controller: "HomeController"
        })
        .when("/Project", {
            templateUrl: "Project/Projects.html",
            controller: "ProjectController"
        })
        .when("/AddProject", {
            templateUrl: "Project/AddProject.html",
            controller: "AddProjectController"
        })
        .when("/Contact", {
            templateUrl: "Contact/Contacts.html",
            controller: "ContactController"
        })
        .when("/AddContact", {
            templateUrl: "Contact/AddContact.html",
            controller: "ContactController"
        })
        .when("/ProjectContact", {
            templateUrl: "ProjectContact/ProjectContactList.html",
            controller: "ProjectContactController"
        })
        .when("/AddProjectContact", {
            templateUrl: "ProjectContact/AddProjectContact.html",
            controller: "ProjectContactController"
        })


        .otherwise({ redirectTo: "/Home" });
});
