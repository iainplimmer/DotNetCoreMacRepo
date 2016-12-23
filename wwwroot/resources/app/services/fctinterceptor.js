(function () {
    angular.module('ngIainPlimmerApi')
    .factory('headerInjector', function () {
        var headerInjector = {
            request: function (config) {
                config.headers['auth-key'] = 'q1w2-e3r4-t5y6-u7i8-o9p0';
                return config;
            }
        };
        return headerInjector;
    });
})();    