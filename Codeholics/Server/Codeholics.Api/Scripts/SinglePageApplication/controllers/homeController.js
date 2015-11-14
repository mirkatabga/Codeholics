var controllers = controllers || {};
(function (scope) {

    data.users.loginManager();

    function home(context) {
        templates.get('home')
          .then(function (template) {
              context.$element().html(template());
          });
    }

    function homeProjects(context) {

        data.projects.all()
            .then(function (res) {
                templates.get("home-projects")
                    .then(function (template) {
                        context.$element().html(template({ projects: res }));
          })
            },
            function (err) {
                console.log(err);
            })


    }

    scope.homeController = {
        home: home,
        homeProjects: homeProjects
    };
}(controllers));
