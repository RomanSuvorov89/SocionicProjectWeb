
myAngular.controller("TestingController", function ($scope) {
	$scope.groupOfAnswers = [0, 0, 0, 0];
	$scope.arrayAnswers = [];
	$scope.numberQuest = 0;
	$scope.numberGroup = 0;
	$scope.numberStyle = 0;

	$scope.checkAnswer = function (buttonInput) {
		$scope.arrayAnswers[$scope.numberQuest] = buttonInput;
		$scope.groupOfAnswers[$scope.numberGroup] += buttonInput;
		$scope.numberQuest++;
		if ($scope.numberQuest % 7 === 0) {
			$scope.numberStyle++;
			$scope.numberGroup++;
		}

		if ($scope.numberQuest === 28) {
			document.getElementById("Quests").remove();
			testResult($scope.groupOfAnswers, $scope.arrayAnswers);
		}
	};

});



function testResult(groupOfAnswers, arrayAnswers) {
	$("#Quests").hide();
	$("#resultload").show();
	var currentTime = new Date();
	var userInfo = navigator.appVersion;
	var device;
	if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|BB|PlayBook|IEMobile|Windows Phone|Kindle|Silk|Opera Mini/i
		.test(navigator.userAgent)) {
		device = "Mobile";
	} else {
		device = "PC";
	}
	var objectResult = {
		GroupOfAnswers: groupOfAnswers,
		ArrayAnswers: arrayAnswers,
		CurrentTime: currentTime,
		UserInfo: userInfo,
		Device: device
	};
	$.ajax({
		type: "POST",
		url: "/Home/Result",
		data: { objectResult },
		success: function (data) {
			console.log(data.newurl);
			window.location = data.newurl;
		}
	});

}