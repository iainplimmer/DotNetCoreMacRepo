(function () {
    angular.module('ngIainPlimmerApi')
    .controller('TestController', function (svcblog) {

        var vm = this;
        vm.BlogPostCount = 0;
        vm.BlogPosts = [];
        
        //  Use the services defined to return the data from the API
        this.$onInit = function () {
            
            svcblog.GetCount()
                .then(function (response) {
                    vm.BlogPostCount = response.data;
                })
                .catch(function (err) {
                    console.log(response);
                });

            svcblog.GetAll()
                .then(function (response) {
                    vm.BlogPosts = response.data;
                })
                .catch(function (err) {
                    console.log(err);
                });
        };
    });
})();

