(function () {
    var ContactController = function ($scope, ContactService, $log, $routeParams, $location) {
        var Contacts = function (data) {
            $scope.Contacts = data;
            $log.info(data);
        };

        $scope.init = function () {

        };

        var Contact = {
            Id: null,
            Name: null,
            Details: null 
        };

        $scope.Contact = Contact;

        var errorDetails = function (serviceResp) {
            $scope.Error = "Something went wrong ??";
        };

        $scope.AddContact = function (Contact) {
            ContactService.addContact(Contact)
                .then(function (data) {
                    console.log(data);
                    $location.path("/Contact");
                });
        };


        var refresh = function () {
            ContactService.contacts()
                .then(Contacts, errorDetails);
        };

        refresh();
        $scope.Title = "Contact Details Page";
    };
    app.controller("ContactController", ["$scope", "ContactService", "$log", "$routeParams", "$location", ContactController]);
}());