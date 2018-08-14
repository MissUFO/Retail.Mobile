
angular.module('starter.controllers', ['swipe'])

 /*****************
 * MAIN CONTROLLER
 ******************/
.controller('AppCtrl', function ($scope, $state, logService) {

  logService.add(0, 'index.html', 0);

  })
/************************
 * LOGIN FORM CONTROLLER
 ************************/
.controller('LoginCtrl', function($scope,
      $state,
      $ionicPopup,
      $ionicSideMenuDelegate,
      userService,
      logService) {

      $ionicSideMenuDelegate.canDragContent(false);

      $scope.currentUser = userService.getCurrent();
      logService.add($scope.currentUser.Id, 'login.html', 0);
  
      $scope.doLogin = function() {

        userService.login($scope.currentUser.UserName, $scope.currentUser.Password).then(
          function (response) {

            $scope.currentUser = response.data;

              //login
              logService.add($scope.currentUser.Id, 'login.html', 1);

              $state.go('app.browse');
          
          },
          function (response) { // Error callback
            // Handle error state

            //unauthorized
            logService.add($scope.currentUser.Id, 'login.html', 6);

            $ionicPopup.alert({
              title: 'Пользователь не найден',
              template: 'Попробуйте еще раз или обратитесь в службу поддержки.'
            });
          }

          );
        

      };

})

/*************
* Quick tour
*************/
  .controller('QuickTourCtrl', function ($scope, $stateParams, $ionicLoading, $timeout, $state, ticketService, userService, logService) {

    $scope.currentUser = userService.getCurrent();

    $scope.btnClick = function () {

    };

  })

 /*****************
 * QR-codes finder
 *****************/
.controller('BrowseCtrl', function ($scope, $state, $stateParams, $interval, $ionicModal, $ionicPopup, deviceService, userService, logService, appsettingsService, $sce) {

  $scope.currentUser = userService.getCurrent();

  appsettingsService.findByKey(APPSETTINGS_KEY_HELPDESK_PHONE).then(function (list) {
      if (list != undefined && list.length > 0)
        $scope.helpdeskPhone = list[0].Value;
  });

    logService.add($scope.currentUser.Id, 'browse.html', 0);

    $scope.devices = deviceService.getData();
    if ($scope.devices == undefined) {
      $ionicPopup.alert({
        title: 'Не удалось получить данные!',
        template: 'Для работы приложения необходимо подключение к интернет.'
      });
    }

    $scope.scan = function () {

      cordova.plugins.barcodeScanner.scan(
        function(result) {

          //$ionicPopup.alert({
          //  title: 'We got a barcode',
          //  template: "Result: " +
          //    result.text +
          //    "\n" +
          //    "Format: " +
          //    result.format +
          //    "\n" +
          //    "Cancelled: " +
          //    result.cancelled
          //});

          $scope.qrcode = result.text;

          deviceService.findByQRCode($scope.qrcode).then(function(list) {
            if (list != undefined && list.length > 0) {
              $scope.device = list[0];
            
              //$state.go('app.single', ,{'Id':$scope.device.Id});

            } else {
              $scope.device = undefined;

              //$ionicPopup.alert({
              //  title: 'Устройство не найдено',
              //  template: 'Устройство с отсканированным штрих-кодом не найдено'
              //});
              $state.go('app.browse_notfound');
            }
          });

        },
        function(error) {

          //$ionicPopup.alert({
          //  title: 'Устройство не найдено',
          //  template: 'Устройство с отсканированным штрих-кодом не найдено'
          //});
          $state.go('app.browse_notfound');

        }
      );

      logService.add($scope.currentUser.Id, 'browse.html', 5);

    };

    //modal dialog for video
    $scope.modalVideo = null;
    $ionicModal.fromTemplateUrl('templates/popup_video.html',
      {
        scope: $scope
      }).then(function (modal) {
      $scope.modalVideo = modal;
    });
    $scope.closeVideo = function () {
      
      var video = document.getElementById("device_video");
      if (video)
        video.pause();
      
      $scope.modalVideo.hide();
    };
    $scope.showVideo = function (url) {

      logService.add($scope.currentUser.Id, 'popup_video.html', 0);

      $scope.videoUrl = $sce.trustAsResourceUrl(url);
      $scope.modalVideo.show();
    };

    //modal dialog for documents
    $scope.modalDocument = null;
    $ionicModal.fromTemplateUrl('templates/popup_document.html',
      {
        scope: $scope
      }).then(function (modal) {
      $scope.modalDocument = modal;
    });
    $scope.closeDocument = function () {
      $scope.modalDocument.hide();
    };
    $scope.showDocument = function (url) {
      $scope.documentUrl = url;
      $scope.modalDocument.show();

      logService.add($scope.currentUser.Id, 'popup_document.html', 0);
    };

    //slide show
    $scope.slideIndex = 1;
    $scope.plusSlides = function(n) {
      $scope.showSlides($scope.slideIndex = $scope.slideIndex+n);
    };
    $scope.currentSlide = function(n) {
      $scope.showSlides($scope.slideIndex = n+1);
    };
    $scope.showSlides = function(n) {
      var i;
      var slides = document.getElementsByClassName("slides");
      if (slides == undefined || $scope.device == undefined || $scope.device.Images.length < n) {
        $scope.slideIndex = 0;
        return;
      }
      var dots = document.getElementsByClassName("dot");
      //var prevs = document.getElementsByClassName("prev");
      //var nexts = document.getElementsByClassName("next");
      if (n > slides.length) {
        $scope.slideIndex = 1;
      }
      if (n < 1) {
        $scope.slideIndex = slides.length;
      }
      for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
        //prevs[i].style.display = "none";
        //nexts[i].style.display = "none";
      }
      for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
      }
      slides[$scope.slideIndex - 1].style.display = "block";
      //prevs[$scope.slideIndex - 1].style.display = "block";
      //nexts[$scope.slideIndex - 1].style.display = "block";
      dots[$scope.slideIndex - 1].className += " active";
    };

    //$interval(function () { $scope.currentSlide($scope.slideIndex); }, 4000);

    //call
    $scope.call = function () {
      window.open('tel:' + $scope.helpdeskPhone, '_system');
    };

    //send mail
    $scope.sendMail = function () {
      $scope.showEmailForm();
    };
    $scope.modalEmailForm = null;
    $ionicModal.fromTemplateUrl('templates/sendmessage.html',
      {
        scope: $scope
      }).then(function (modal) {
          $scope.modalEmailForm = modal;
    });
    $scope.closeEmailForm = function () {
      $scope.modalEmailForm.hide();
    };
    $scope.showEmailForm = function () {

      logService.add($scope.currentUser.Id, 'sendmessage.html', 0);

      $scope.modalEmailForm.show();
    };


})
  .controller('BrowseNotFoundCtrl', function($scope, $state, userService, logService) {

      $scope.currentUser = userService.getCurrent();
      logService.add($scope.currentUser.Id, 'browse_notfound.html', 0);
      
      $scope.search = function() {
        $state.go('app.search');
      }

  })
/****************
* DEVICES SEARCH
****************/
.controller('SearchCtrl', function ($scope, $state, $ionicPopup, $stateParams, deviceService, userService, logService) {
  
    $scope.currentUser = userService.getCurrent();
    logService.add($scope.currentUser.Id, 'search.html', 0);

    $scope.devices = deviceService.getData();

    $scope.getData = function (str) {

      deviceService.findByName(str).then(function (result) {
        $scope.devices = result;

        logService.add($scope.currentUser.Id, 'search.html', 4);

      });
    };

})
/********************
* DEVICE SINGLE ITEM
*********************/
.controller('ItemCtrl', function ($scope, $stateParams, $interval, $ionicModal, deviceService, userService, logService, appsettingsService, $sce) {

    $scope.currentUser = userService.getCurrent();

    appsettingsService.findByKey(APPSETTINGS_KEY_HELPDESK_PHONE).then(function (list) {
      if (list != undefined && list.length > 0)
        $scope.helpdeskPhone = list[0].Value;
    });

    logService.add($scope.currentUser.Id, 'item.html', 0);

    $scope.Id = $stateParams.Id;
    deviceService.findById($scope.Id).then(function (list) {
        if (list != undefined && list.length > 0)
          $scope.device = list[0];
    });

    //modal dialog for video
    $scope.modalVideo = null;
    $ionicModal.fromTemplateUrl('templates/popup_video.html',
      {
        scope: $scope
      }).then(function (modal) {
      $scope.modalVideo = modal;
    });
    $scope.closeVideo = function () {

      var video = document.getElementById("device_video");
      if (video)
        video.pause();

      $scope.modalVideo.hide();
    };
    $scope.showVideo = function (url) {

      logService.add($scope.currentUser.Id, 'popup_video.html', 0);

      $scope.videoUrl = $sce.trustAsResourceUrl(url);
      $scope.modalVideo.show();
    };

    //modal dialog for documents
    $scope.modalDocument = null;
    $ionicModal.fromTemplateUrl('templates/popup_document.html',
      {
        scope: $scope
      }).then(function (modal) {
      $scope.modalDocument = modal;
    });
    $scope.closeDocument = function () {
      $scope.modalDocument.hide();
    };
    $scope.showDocument = function (url) {

      logService.add($scope.currentUser.Id, 'popup_document.html', 0);

      $scope.documentUrl = url;
      $scope.modalDocument.show();
    };

    //slide show
    $scope.slideIndex = 1;
    $scope.plusSlides = function (n) {
      $scope.showSlides($scope.slideIndex = $scope.slideIndex + n);
    };
    $scope.currentSlide = function (n) {
      $scope.showSlides($scope.slideIndex = n + 1);
    };
    $scope.showSlides = function (n) {
      var i;
      var slides = document.getElementsByClassName("slides");
      if (slides == undefined || $scope.device == undefined || $scope.device.Images.length < n) {
        $scope.slideIndex = 0;
        return;
      }
      var dots = document.getElementsByClassName("dot");
      //var prevs = document.getElementsByClassName("prev");
      //var nexts = document.getElementsByClassName("next");
      if (n > slides.length) {
        $scope.slideIndex = 1;
      }
      if (n < 1) {
        $scope.slideIndex = slides.length;
      }
      for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
        //prevs[i].style.display = "none";
        //nexts[i].style.display = "none";
      }
      for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
      }
      slides[$scope.slideIndex - 1].style.display = "block";
      //prevs[$scope.slideIndex - 1].style.display = "block";
      //nexts[$scope.slideIndex - 1].style.display = "block";
      dots[$scope.slideIndex - 1].className += " active";
    };

   // $interval(function () { $scope.currentSlide($scope.slideIndex); }, 2000);

    //call
    $scope.call = function () {
      window.open('tel:' + $scope.helpdeskPhone, '_system');
    };

    //send mail
    $scope.sendMail = function () {
      $scope.showEmailForm();
    };
    $scope.modalEmailForm = null;
    $ionicModal.fromTemplateUrl('templates/sendmessage.html',
      {
        scope: $scope
      }).then(function (modal) {
      $scope.modalEmailForm = modal;
    });
    $scope.closeEmailForm = function () {
      $scope.modalEmailForm.hide();
    };
    $scope.showEmailForm = function () {

      logService.add($scope.currentUser.Id, 'sendmessage.html', 0);
      
      $scope.modalEmailForm.show();
    };
})

/****************
* PROCESS SEARCH
****************/
  .controller('ProcessListCtrl', function ($scope, $state, $ionicPopup, $stateParams, processService, userService, logService) {

    $scope.currentUser = userService.getCurrent();
    logService.add($scope.currentUser.Id, 'processlist.html', 0);

    $scope.processes = processService.getData();

    $scope.getData = function (str) {

      processService.findByName(str).then(function (result) {
        $scope.processes = result;

        logService.add($scope.currentUser.Id, 'processlist.html', 4);

      });
    };

  })
/********************
* PROCESS SINGLE ITEM
*********************/
  .controller('ProcessItemCtrl', function ($scope, $stateParams, $interval, $ionicModal, processService, userService, logService, $sce) {

    $scope.currentUser = userService.getCurrent();

    logService.add($scope.currentUser.Id, 'processitem.html', 0);

    $scope.Id = $stateParams.Id;
    processService.findById($scope.Id).then(function (list) {
      if (list != undefined && list.length > 0)
        $scope.process = list[0];
    });

    //modal dialog for video
    $scope.modalVideo = null;
    $ionicModal.fromTemplateUrl('templates/popup_video.html',
      {
        scope: $scope
      }).then(function (modal) {
      $scope.modalVideo = modal;
    });
    $scope.closeVideo = function () {

      var video = document.getElementById("device_video");
      if (video)
        video.pause();

      $scope.modalVideo.hide();
    };
    $scope.showVideo = function (url) {

      logService.add($scope.currentUser.Id, 'popup_video.html', 0);

      $scope.videoUrl = $sce.trustAsResourceUrl(url);
      $scope.modalVideo.show();
    };

    //modal dialog for documents
    $scope.modalDocument = null;
    $ionicModal.fromTemplateUrl('templates/popup_document.html',
      {
        scope: $scope
      }).then(function (modal) {
      $scope.modalDocument = modal;
    });
    $scope.closeDocument = function () {
      $scope.modalDocument.hide();
    };
    $scope.showDocument = function (url) {

      logService.add($scope.currentUser.Id, 'popup_document.html', 0);

      $scope.documentUrl = url;
      $scope.modalDocument.show();
    };

    
  })

/*************
* PROFILE
*************/
  .controller('UserProfileCtrl', function (userService, $scope, $stateParams) {

    $scope.currentUser = userService.getCurrent();

  })

/*************
* ABOUT APP
*************/
.controller('AboutCtrl', function (appsettingsService, $scope, $stateParams) {

    appsettingsService.findByKey(APPSETTINGS_KEY_HELPDESK_EMAIL).then(function (list) {
      if (list != undefined && list.length > 0)
        $scope.helpdeskEmail = list[0].Value;
    });

    appsettingsService.findByKey(APPSETTINGS_KEY_HELPDESK_PHONE).then(function (list) {
      if (list != undefined && list.length > 0)
        $scope.helpdeskPhone = list[0].Value;
    });

    appsettingsService.findByKey(APPSETTINGS_KEY_HELPDESK_URL).then(function (list) {
      if (list != undefined && list.length > 0)
        $scope.helpdeskUrl = list[0].Value;
    });

})
/************************************
* SEND MESSAGE AND OPEN ASPIN TICKET
*************************************/
  .controller('SendMessageCtrl', function ($scope, $stateParams, $ionicLoading, $timeout, $state, ticketService, userService, logService, appsettingsService) {

    $scope.currentUser = userService.getCurrent();
    
    $scope.btnClick = function () {

      $scope.device = $scope.$parent.$parent.$parent.device;

      var body = document.getElementById("msg").value;
      var namefrom = document.getElementById("namefrom").value;
      var mailfrom = document.getElementById("mailfrom").value;
      if (body == "" || namefrom == "" || mailfrom == "") {
        $ionicLoading.show({
          template: 'Пожалуйста, заполните форму!', noBackdrop: true, duration: 2000
        });
        return;
      }

      try {

        var msg = 'ФИО сотрудника: ' + $scope.currentUser.FullName + '<br/>';
        if ($scope.device!=undefined)
          msg += 'Устройство: ' + $scope.device.Name + ' (' + $scope.device.Model + ')<br/><br/>';
        msg += 'Комментарий: ' + body + '<br/>';

        var status = ticketService.sendMail(mailfrom, msg);

        logService.add($scope.currentUser.Id, 'sendmessage.html', 3);

        $ionicLoading.show({
          template: 'Данная проблема направлена на обработку. Спасибо, что помогаете нам стать лучше!', noBackdrop: true, duration: 2000
        }).then(function () { $scope.modalEmailForm.hide(); });

      } catch (e) 
      {
        $ionicLoading.show({
          template: 'Сообщение не было отправлено. Пожалуйста, повторите попытку.', noBackdrop: true, duration: 2000
        }).then(function () {  });

      }
    };
  });

