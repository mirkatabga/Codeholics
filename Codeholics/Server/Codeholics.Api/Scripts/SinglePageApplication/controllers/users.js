var controllers = controllers || {};
(function (scope) {

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

    scope.users = {
        register: register
    };
}(controllers));
