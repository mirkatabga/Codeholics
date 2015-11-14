var controllers = controllers || {};
(function (scope) {

    data.users.loginManager();

    function home(context) {
        templates.get('home')
          .then(function (template) {
              context.$element().html(template());
          });
    }

    scope.homeController = {
        home: home
    };
}(controllers));
