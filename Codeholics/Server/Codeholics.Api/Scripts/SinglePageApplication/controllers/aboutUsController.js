var controllers = controllers || {};
(function (scope) {

    data.users.loginManager();

    function about(context) {
        templates.get('about-us')
          .then(function (template) {
              context.$element().html(template());
          });
    }

    scope.aboutUsController = {
        about: about
    };
}(controllers));
