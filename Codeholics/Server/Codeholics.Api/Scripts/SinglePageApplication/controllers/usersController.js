var controllers = controllers || {};
(function (scope) {

    data.users.loginManager();

    function register(context) {
        templates.get('register')
          .then(function (template) {
              context.$element().html(template());

              $('#btn-register').on('click', function () {
                  var user = {
                      firstName: $('#tb-reg-firstname').val(),
                      lastName: $('#tb-reg-lastname').val(),
                      email: $('#tb-reg-email').val(),
                      password: $('#tb-reg-password').val(),
                      confirmPassword: $('#tb-reg-confirmPassword').val()
                  };
                  console.log(user);
                  /*
                  "firstName": "ganchoPopa",
          "lastName": "ganchoPopa",
          "email": "some123email@gmail.com",
          "password": "123456",
          "confirmPassword": "123456"
                  */
                  data.users.register(user)
                    .then(function () {
                        toastr.success('User registered!');
                        setTimeout(function () {
                            context.redirect('#/');
                            document.location.reload(true);
                        }, 1000);
                    }, function (err) {
                        console.log("eerr");
                        toastr.error(err);
                    });
              });
          });
    }

    function login(context) {
        templates.get('sign-in')
          .then(function (template) {
              context.$element().html(template());

              $('#btn-sign-in').on('click', function (e) {
                  var user = {
                      username: $('#tb-username').val(),
                      password: $('#tb-password').val()
                  };
                  console.log("USER BEE");
                  console.log(user);
                  data.users.signIn(user)
                    .then(function (user) {
                        toastr.success('User signed in!');
                        //document.location = '#/register';
                        context.redirect('#/home');
                        document.location.reload(true);
                        //setTimeout(function () {
                        //    $('#container-sign-in').fadeOut(100, function () {
                        //        console.log('Here!');
                        //        $('#container-sign-out').fadeIn(500);
                        //    });
                        //}, 1000);
                    }, function (err) {
                        toastr.error(err.responseText);
                    });
              });
          });
    }

    function logout(context) {
        data.users.signOut()
          .then(function () {
              toastr.success('User signed out!');
              //document.location = '#/register';
              context.redirect('#/home');
              document.location.reload(true);
              //setTimeout(function () {
              //    $('#container-sign-out').fadeOut(100, function () {
              //        console.log('Here!');
              //        $('#container-sign-in').fadeIn(500);
              //    });
              //}, 1000);
          });
    }

    scope.usersController = {
        register: register,
        login: login,
        logout: logout
    };
}(controllers));
