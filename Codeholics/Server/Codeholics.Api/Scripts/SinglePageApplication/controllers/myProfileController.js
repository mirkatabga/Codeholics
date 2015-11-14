var controllers = controllers || {};
(function (scope) {

    data.users.loginManager();
    function getMyProfile (context) {
        var myProfile;
        data.users.currentUser()
            .then(function myProfile(user) {
                myProfile = user;
                console.log('user moimds');
                console.log(myProfile);
                return templates.get('my-profile');
            }).then(function (template) {
                console.log(myProfile);
                context.$element().html(template(myProfile));
            });
    }

    scope.myProfileController = {
        myProfile: getMyProfile
    };
}(controllers));
