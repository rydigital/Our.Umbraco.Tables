function tableGeneratorOverlayController($scope, tinyMceService)
{
	console.log("Table Overlay", $scope.model);
}

angular.module("umbraco").controller("Our.Umbraco.TableGenerator.BackOffice.TableGenerator.Overlay.Controller", tableGeneratorOverlayController);