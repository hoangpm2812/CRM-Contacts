/**
 * @author a.demeshko
 * created on 12/16/15
 */
(function () {
  'use strict';


  angular.module('BlurAdmin.pages.sourceTeam.contactOne')
    .controller('ContactOneCtrl', ContactOneCtrl);

  // ContactOneCtrl.$inject = ["$scope", "$http", "$timeout"];

  /** @ngInject */
  function ContactOneCtrl($scope, $http, $timeout, toastr) {
    var vm = this;

    vm.allFields = [
      { label: 'Họ tên', value: 'name' },
      { label: 'Số điện thoại', value: 'phoneNumber' },
      { label: 'Email', value: 'email' },
      { label: 'Link CV', value: 'linkCV' },
      { label: 'Thuộc đơn hàng', value: 'order' },
      { label: 'Nguồn', value: 'source' },
      { label: 'Ngày nhập liệu', value: 'createAt' },
      { label: 'Ai tìm', value: 'founder' },
      { label: 'Người giới thiệu', value: 'recommender' },
    ];
    vm.fieldsPicker = vm.allFields

    vm.hideFields = {
      name: false,
      phoneNumber: false,
      email: false,
      linkCV: false,
      order: false,
      source: false,
      createAt: false,
      founder: false,
      recommender: false,
    }

    // combo box of Orders
    vm.withSearchOrder = {};
    vm.selectWithSearchOrders = [];

    // Tick to show field 
    vm.showFieldsPicker = function () {
      console.log(vm.fieldsPicker)
      angular.forEach(vm.hideFields, function (value, key) {
        vm.hideFields[key] = true;
      });
      angular.forEach(vm.fieldsPicker, function (value, key) {
        vm.hideFields[value.value] = false;
      })
    }

    // get data of Orders
    $http.get("http://localhost:65332/api/order")
      .then(function (response) {
        angular.forEach(response.data, function (value, key) {
          var data = { label: value.name + " - " + value.description, value: value.id }
          vm.selectWithSearchOrders.push(data)
        })
      }, function (response) {
        alert("Failed to get data");
      })


    //phone number change event (check duplicate)
    vm.phoneChange = function () {
      if (vm.frm.phoneNumber.$error.minlength == true || vm.frm.phoneNumber.$error.parse == true) {
        vm.loadingPhoneNumber = false;
        vm.loadingPhoneNumberOK = false;
        vm.loadingPhoneNumberError = false;
      }
      else {
        vm.loadingPhoneNumber = true;
        $http({
          headers: { 'Content-Type': 'application/json' },
          method: "POST",
          url: "http://localhost:65332/api/contact/checkDuplicatePhone",
          data: vm.phoneNumber
        }).then(function (response) {
          if (response.data.data == false) {
            vm.loadingPhoneNumber = false;
            vm.loadingPhoneNumberOK = true;
            vm.loadingPhoneNumberError = false;
          }
          else {
            vm.loadingPhoneNumber = false;
            vm.loadingPhoneNumberError = true;
            vm.loadingPhoneNumberOK = false;
          }
        }, function (response) {
          vm.loadingPhoneNumber = false;
          vm.loadingPhoneNumberError = true;
          vm.loadingPhoneNumberOK = false;
        });
      }

    }

    // email change event (check duplicate)
    vm.emailChange = function () {
      if (vm.frm.email.$error.email == true || vm.frm.email.$error.required == true) {
        vm.loadingEmail = false;
        vm.loadingEmailOK = false;
        vm.loadingEmailError = false;
      }
      else {
        var email = vm.email;
        vm.loadingEmail = true;
        $http({
          headers: { 'Content-Type': 'application/json' },
          method: "POST",
          url: "http://localhost:65332/api/contact/checkDuplicateEmail",
          data: '"' + email + '"'
        }).then(function (response) {
          if (response.data.data == false) {
            vm.loadingEmail = false;
            vm.loadingEmailOK = true;
            vm.loadingEmailError = false;
          }
          else {
            vm.loadingEmail = false;
            vm.loadingEmailError = true;
            vm.loadingEmailOK = false;
          }
        }, function (response) {
          vm.loadingEmail = false;
          vm.loadingEmailError = true;
          vm.loadingEmailOK = false;
        });
      }

    }

    // reset fields when create a contact successfully
    vm.resetFields = function () {
      vm.loadingPhoneNumber = false;
      vm.loadingPhoneNumberError = false;
      vm.loadingPhoneNumberOK = false;
      vm.loadingEmail = false;
      vm.loadingEmailError = false;
      vm.loadingEmailOK = false;
      vm.name = ""
      vm.phoneNumber = ""
      vm.email = ""
      vm.linkCV = ""
    }

    //function to create a contact
    vm.submitFunc = function () {

      if (vm.loadingEmailOK == false || vm.loadingPhoneNumberOK == false) {
        toastr.error('Phone number or Email address is DUPLICATED !', 'Error', {
          "autoDismiss": false,
          "positionClass": "toast-top-right",
          "type": "error",
          "timeOut": "5000",
          "extendedTimeOut": "2000",
          "allowHtml": false,
          "closeButton": false,
          "tapToDismiss": true,
          "progressBar": false,
          "newestOnTop": true,
          "maxOpened": 0,
          "preventDuplicates": false,
          "preventOpenDuplicates": false
        })
        return;
      }
      else {
        var orderSelected = 0;
        if (vm.withSearchOrder.selected != null) {
          orderSelected = vm.withSearchOrder.selected.value;
        }
        var data = {
          Name: vm.name,
          PhoneNumber: vm.phoneNumber,
          Email: vm.email,
          LinkCV: vm.linkCV,
          OrderId: orderSelected,
          Source: vm.source,
          CreateAt: vm.createAt,
          Founder: vm.founder,
          Recommender: vm.recommender
        };
        console.log(data);
        $.LoadingOverlay("show");
        $http({
          headers: { 'Content-Type': 'application/json' },
          method: "POST",
          url: "http://localhost:65332/api/contact",
          data: data
        }).then(function (response) {
          $.LoadingOverlay("hide");
          alert(response.data.message);
          vm.resetFields();
        }, function (response) {
          $.LoadingOverlay("hide");
          alert(response.data.message);
        });
      }

    };

  }
})();