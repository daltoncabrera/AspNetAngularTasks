app.controller("tasksController", function ($scope, $http) {
    var serviceBase = location.protocol + '//' + location.host + '/'; // 'http://localhost:26264/';
    $scope.selected = null;
    $scope.showModal = false;
    $scope.model = {
        selected: null,
        list: {
            "toDo": { listName: "ToDo", items: [], dragging: false },
            "doing": { listName: "Doing", items: [], dragging: false },
            "test": { listName: "Test", items: [], dragging: false },
            "done": { listName: "Done", items: [], dragging: false }
        }
    };

    $scope.mapStatus = {
        "ToDo": 0,
        "Doing": 1,
        "Test": 2,
        "Done": 3
    }

    $scope.updateModel = function () {
        $http.get(serviceBase + 'api/tasks/').success(function (results) {
            $scope.model.list["toDo"].items = results.toDo;
            $scope.model.list["doing"].items = results.doing;
            $scope.model.list["test"].items = results.test;
            $scope.model.list["done"].items = results.done;
        });
    };

    $scope.toggleModal = function () {
        $scope.showModal = !$scope.showModal;
    };

    $scope.addTask = function (vm) {
        vm.status = $scope.mapStatus["ToDo"];
        $http.post(serviceBase + 'api/Tasks/', vm).success(function (results) {
            var list = $scope.model.list["toDo"];
            list.items = list.items.slice(0, 0)
                .concat(vm)
                .concat(list.items.slice(0));
            toastr.success('Task added!');
            $scope.showModal = false;
        }).error(function (error) {
            toastr.error('Error adding Task, please reload page');

        });
    };

    $scope.onDragstart = function (list, event) {
        list.dragging = true;
        if (event.dataTransfer.setDragImage) {
            var img = new Image();
            img.src = 'Content/images/ic_content_copy_black_24dp_2x.png';
            event.dataTransfer.setDragImage(img, 0, 0);
        }
    };

    $scope.onDrop = function (list, item, index) {

        item.status = $scope.mapStatus[list.listName];
        $http.put(serviceBase + 'api/Tasks/?id=' + item.id, item).success(function (results) {
            list.items = list.items.slice(0, index)
                 .concat(item)
                 .concat(list.items.slice(index));
            toastr.success('Task updated!');

        }).error(function (error) {
            toastr.error('Error updating Task, please reload page');

        });

        return true;
    }

    $scope.onMoved = function (list, index) {
        list.items.splice(index, 1);
    };

    $scope.updateModel();
});
