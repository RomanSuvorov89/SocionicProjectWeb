var myAngular = angular.module("AngularSocionic", []);
myAngular.run(function ($rootScope) {
	$rootScope.firstValue = firstValue;
	$rootScope.secondValue = secondValue;
	$rootScope.Style = Style;
	console.log($rootScope);
});