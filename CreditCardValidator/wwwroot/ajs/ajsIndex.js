var cardApp = angular.module('cardApp',[]);

cardApp.controller("indexController", function ($scope, $location, $http) {

    var $API_URL = '';
    $scope.result = null;
    $scope.errors = null;

    $scope.init = function () {
        $API_URL = `${$location.protocol()}://` + `${$location.host()}:` + `${$location.port()}/api/`;        
    };

    $scope.SubmitForm = function () {
        $scope.result = null;
        $scope.errors = null;
        return $http.post($API_URL + "CardValidateAPI/CheckCard", { "CardNumber": $scope.cardNo }).then(function (response) {
            $scope.result = response.data;           
        }, function errorCallback(error) {
            $scope.errors = error.data.errors.CardNumber;            
        });
    };

    $scope.clearMessages = function () {
        $scope.result = null;
        $scope.errors = null;
    };
});