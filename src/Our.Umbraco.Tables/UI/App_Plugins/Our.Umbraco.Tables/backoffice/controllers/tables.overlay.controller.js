function tablesOverlayController($scope, tinyMceService)
{
	console.log("Table Overlay", $scope.model);
}

angular.module("umbraco").controller("Our.Umbraco.Tables.BackOffice.Overlay.Controller", tablesOverlayController);