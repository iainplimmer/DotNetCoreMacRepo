(function () {
    angular.module('ngIainPlimmerApi')
        .service('svcblog', function ($http) {
            return {
                GetAll : _getAllBlogPosts,
                GetCount : _getCountOfBlogPosts
            }

            function _getAllBlogPosts () {
                return $http.get('/api/blogs/GetBlogPosts');
            }

            function _getCountOfBlogPosts () {
                return $http.get('/api/blogs/GetBlogCount');
            }
        });

   
})();