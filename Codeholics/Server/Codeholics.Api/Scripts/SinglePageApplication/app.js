(function() {
    console.log("Ind pow");
  var sammyApp = Sammy('#content', function() {

    this.get('#/', function(context) {
      context.redirect('#/home');
    });

    this.get('#/home', controllers.homeController.home);
   //this.get('#/home/add', controllers.home.add);

    //this.get('#/my-cookie', controllers.myCookie.all);

    this.get('#/register', controllers.usersController.register);

    this.get('#/login', controllers.usersController.login);
    //this.get('#/users/register', function (context) {
    //    console.log(    "Sing up madafaka" );
    //  context.redirect('#/sign-up');
    //});
    //this.get('#/sign-up', controllers.users.register);
    this.get('#/logout', controllers.usersController.logout);
  });

  $(function() {
    sammyApp.run('#/');

    if (data.users.hasUser()) {
      $('#container-sign-in').hide();
    } else {
      $('#container-sign-out').hide();
    }
  });
}());
