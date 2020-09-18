function tablesOverlayController($scope)
{
	$scope.save = function() {
        $scope.$broadcast("formSubmitting", { scope: $scope });
        $scope.model.submit($scope.model);
    }
}

angular.module("umbraco").controller("Our.Umbraco.Tables.BackOffice.Overlay.Controller", tablesOverlayController);