(function () {
    var ContactController = function ($scope, contactService, $log, $routeParams, $location) {
        var getContacts = function (data) {
            $scope.AllContacts = data;
            $log.info(data);
        };

        $scope.ContactTitle = "Contact Details Page";

        $scope.init = function () {

        };

        var Contact = {
            Id: null,
            Name: null,
            Details: null 
        };

        $scope.SingleContact = Contact;

        var errorDetails = function (serviceResp) {
            $scope.Error = "Something went wrong ??";
        };

        $scope.AddContact = function (Contact) {
            contactService.CreateContact(Contact)
                .then(function (data) {
                    console.log(data);
                    $location.path("/Contact");
                });
        };


        $scope.ContactRefresh = function () {
            contactService.Getcontacts()
                .then(getContacts, errorDetails);
        };

        $scope.ContactRefresh();
       
    };
    app.controller("ContactController", ["$scope", "contactService", "$log", "$routeParams", "$location", ContactController]);
}());