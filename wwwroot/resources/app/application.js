(function () {
    angular.module('ngIainPlimmerApi', [])
    .config(function($httpProvider) {  
        $httpProvider.interceptors.push('headerInjector');
    })    
})();


