namespace UsingPrologAsRuleEngineOnASPNET {
    export class MainController {
        public man_spec = {
            annual_income: 1000,
            height: 170,
            class_curve: 65,
            wealthy_parent: false
        };

        public rule: string;

        public result: boolean = null;

        constructor(private $http: ng.IHttpService) {
            $http.get<string>('/default_rule.pl')
                .then(res => {
                    this.rule = res.data;
                    setTimeout(() => { $('#rule').trigger('autoresize'); }, 0);
                });
        }

        public judge(): void {
            this.result = null;
            this.$http
                .post<boolean>('/api/can_marriage', {
                    man_spec: this.man_spec,
                    rule: this.rule
                })
                .then(res => this.result = res.data);
        }
    }

    angular
        .module('app', [])
        .controller('mainController', MainController);
}