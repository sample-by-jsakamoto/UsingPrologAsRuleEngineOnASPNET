var UsingPrologAsRuleEngineOnASPNET;
(function (UsingPrologAsRuleEngineOnASPNET) {
    var MainController = (function () {
        function MainController($http) {
            var _this = this;
            this.$http = $http;
            this.man_spec = {
                annual_income: 1000,
                height: 170,
                class_curve: 65,
                wealthy_parent: false
            };
            this.result = null;
            $http.get('/default_rule.pl')
                .then(function (res) {
                _this.rule = res.data;
                setTimeout(function () { $('#rule').trigger('autoresize'); }, 0);
            });
        }
        MainController.prototype.judge = function () {
            var _this = this;
            this.result = null;
            this.$http
                .post('/api/can_marriage', {
                man_spec: this.man_spec,
                rule: this.rule
            })
                .then(function (res) { return _this.result = res.data; });
        };
        return MainController;
    })();
    UsingPrologAsRuleEngineOnASPNET.MainController = MainController;
    angular
        .module('app', [])
        .controller('mainController', MainController);
})(UsingPrologAsRuleEngineOnASPNET || (UsingPrologAsRuleEngineOnASPNET = {}));
