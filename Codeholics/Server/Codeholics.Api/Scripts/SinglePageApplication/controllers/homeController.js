var controllers = controllers || {};
(function (scope) {

    var isLogged = data.users.loginManager();

    //if (isLogged) {
    //    document.redirect('#/myhome');
    //}

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

    function addProject(context) {
        var title = $('#title'),
            description = $('#description'),
            startDate = $('#startDate'),
            deadline = $('#deadline'),
            creator = $('#creator');

        data.projects.add(title,description,startDate,deadline,creator)
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
        homeProjects: homeProjects,
        addProject: addProject
    };
}(controllers));
