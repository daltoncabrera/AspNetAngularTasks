var app = angular.module('tasksapp', ['ngRoute', 'dndLists', 'angular-loading-bar', 'ngAnimate', 'tasksapp.directives']);
app.config(['$routeProvider', function ($routeProvider) {

    $routeProvider
    .when('/tasks',
    {
        templateUrl: 'app/tasks/tasks.html',
        controller: 'tasksController',
    })
    .otherwise({
        redirectTo: '/tasks'
    });

}]);