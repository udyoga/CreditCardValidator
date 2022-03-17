var cardApp = angular.module('cardApp',[]);

cardApp.controller("indexController", function ($scope, $location, $http) {

    var $API_URL = '';

    $scope.init = function () {
        $API_URL = `${$location.protocol()}://` + `${$location.host()}:` + `${$location.port()}/api/`;
        $scope.SaveIncident();
    };

    $scope.SubmitForm = function () {
        return $http.post($API_URL + "CardValidateAPI/CheckCard", { "CardNumber": $scope.cardNo}).then(function (response) {
            return response;
        }, function errorCallback(response) {
            return response.data.ExceptionMessage;
        });
    };
});