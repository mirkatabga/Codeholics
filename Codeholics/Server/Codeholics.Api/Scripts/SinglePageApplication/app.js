(function() {
    console.log("Ind pow");
  var sammyApp = Sammy('#content', function() {

    this.get('#/', function(context) {
      context.redirect('#/home');
    });

    this.get('#/home', controllers.homeController.home);
    this.get('#/homeGosho', controllers.homeController.homeProjects);

    this.get('#/add-project', controllers.homeController.addProject);

   //this.get('#/home/add', controllers.home.add);

    //this.get('#/my-cookie', controllers.myCookie.all);

    this.get('#/register', controllers.usersController.register);

    this.get('#/login', controllers.usersController.login);

    this.get('#/logout', controllers.usersController.logout);

    this.get('#/aboutUs', controllers.aboutUsController.about);

    this.get('#/projects', controllers.homeController.homeProjects);
  });

  $(function() {
    sammyApp.run('#/');

    if (data.users.hasUser()) {
        //setTimeout(function () {
        //    $('#container-sign-in').fadeOut(-100, function () {
        //        //console.log('Here!');
        //        $('#container-sign-out').fadeIn(500);
        //    });
        //}, 1000);
      $('#container-sign-in').hide();
    } else {
        //setTimeout(function () {
        //    $('#container-sign-out').fadeOut(-100, function () {
        //        //console.log('Here!');
        //        $('#container-sign-in').fadeIn(500);
        //    });
        //}, 1000);
      $('#container-sign-out').hide();
    }
  });
}());
