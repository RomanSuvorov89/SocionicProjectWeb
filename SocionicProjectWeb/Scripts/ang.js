angular.module("AngularSocionic", [])
    .controller("TestCtrl", function ($scope) {
        $scope.firstValue = [
            "систематический", "структура ", "план", "решение", "систематичность", "организованный", "подготовка",
            "решительный", "твердый", "склонный к критике", "преимущество", "голова", "мысли", "анализировать ",
            "фактический", "применение на практике", "опыт", "рассудительный", "практик", "реалист", "реальность",
            "шумный", "оживленный ", "общительность", "расходование энергии", "ориентированный во внешний мир", "высказываться вслух", "отважный"
        ];
        $scope.secondValue = [
            "спонтанный", "течение ", "импровизация", "импульс", "случайность", "импульсивный", "экспромт",
            "преданный", "мягкосердечный ", "доброжелательный", "удача", "сердце", "чувства", "симпатизировать",
            "теоретический", "поиск скрытого смысла", "теории", "удивительный", "фантазер", "мечтатель", "перспективность",
            "тихий", "спокойный ", "сосредоточенность", "сохранение энергии", "ориентированный внутрь себя", "переживать в себе", "хладнокровный"
        ];
        $scope.Style = ["btn-primary", "btn-info", "btn-success", "btn-warning"];
        $scope.arrayAnswers = [0, 0, 0, 0];
        $scope.Answers = [];
        $scope.numberQuest = 0;
        $scope.numberAnswers = 0;

        $scope.checkAnswer = function (buttonInput) {
            $scope.Answers[$scope.numberQuest] = buttonInput;
            $scope.arrayAnswers[$scope.numberAnswers] += buttonInput;
            $scope.numberQuest++;
            if (($scope.numberQuest % 7) === 0) {
                $scope.Style.splice(0, 1);
                $scope.numberAnswers++;
            }
            if ($scope.numberQuest === 28) {
                document.getElementById("Quests").remove();
                testResult($scope.arrayAnswers, $scope.Answers);
            }
        }

    });


function testResult(arrayAnswers, Answers) {
    dateObj = new Date();
    $.ajax({
        type: 'POST',
        url: '/Home/Result',
        data: { arrayAnswers, Answers, dateObj },
        dataType: 'json',
        success:function () { alert(); }
    });

}