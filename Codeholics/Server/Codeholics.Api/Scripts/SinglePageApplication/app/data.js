var data = (function() {
  const USERNAME_LOCAL_STORAGE_KEY = 'userName',
    AUTH_KEY_LOCAL_STORAGE_KEY = 'Authorization',
    USER_ID = "userId";

  const USERNAME_CHARS = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890_@.",
    USERNAME_MIN_LENGTH = 6,
    USERNAME_MAX_LENGTH = 30;

  const COOKIE_TEXT_MIN_LENGTH = 6,
    COOKIE_TEXT_MAX_LENGTH = 30,
    COOKIE_CATEGORY_MIN_LENGTH = 6,
    COOKIE_CATEGORY_MAX_LENGTH = 30;

  /* Users */

  function register(user) {
    var error = validator.validateString(user.firstName, USERNAME_MIN_LENGTH, USERNAME_MAX_LENGTH, USERNAME_CHARS);

    if (error) {
      return Promise.reject(error.message);
    }

    var reqUser = {
        firstName: user.firstName,
        lastName: user.lastName,
        email: user.email,
        password: user.password,
        confirmPassword: user.confirmPassword
    };
    console.log('---');
    console.log(reqUser);
    return jsonRequester.post('api/Account/Register', {
        data: reqUser
      })
      .then(function(resp) {
        return {
          username: resp
        };
      });
  }

  function signIn(user) {
    var error = validator.validateString(user.username, USERNAME_MIN_LENGTH, USERNAME_MAX_LENGTH, USERNAME_CHARS);

    if (error) {
      return Promise.reject(error.message);
    }

    var reqUser = {
        username: user.username,
        password: user.password
      //passHash: CryptoJS.SHA1(user.username + user.password).toString()
    };   
    
    var parameters = "username=" + reqUser.username + "&password=" + reqUser.password + "&grant_type=password";
    var options = {
        data: parameters
    };

    return jsonRequester.post('/token', options, "application/x-www-form-urlencoded")
      .then(function(resp) {
        var username = resp.userName;
        localStorage.setItem(USERNAME_LOCAL_STORAGE_KEY, username);
        localStorage.setItem(AUTH_KEY_LOCAL_STORAGE_KEY, resp.token_type + ' ' + resp.access_token);
          jsonRequester.post('api/Users', {
              data: { "username" : localStorage.getItem(USERNAME_LOCAL_STORAGE_KEY) }
          })
          .then(function (response) {
              var id = response;
              localStorage.setItem(USER_ID, id);
          });
        console.log(localStorage);
        return user;
      });
  }

  function signOut() {
    var promise = new Promise(function(resolve, reject) {
      //localStorage.removeItem(USERNAME_LOCAL_STORAGE_KEY);
      //localStorage.removeItem(AUTH_KEY_LOCAL_STORAGE_KEY);
        //localStorage.removeItem(USER_ID);
        localStorage.clear();
      resolve();
    });
    return promise;
  }

  function hasUser() {
    return !!localStorage.getItem(USERNAME_LOCAL_STORAGE_KEY) &&
      !!localStorage.getItem(AUTH_KEY_LOCAL_STORAGE_KEY);
  }

  function loginManager() {
      if (data.users.hasUser()) {
          $('#userName').html(localStorage.getItem(USERNAME_LOCAL_STORAGE_KEY));
          $('#container-sign-in').hide();
      } else {
          $('#container-sign-out').hide();
      }

      $(".header-login").css('display', 'inline-block');
  }

  function getCurrentUserInfo() {
      if (localStorage.getItem(USER_ID) !== null) {
          return jsonRequester.get('/api/Users/' + localStorage.getItem(USER_ID))
            .then(function (resp) {
                return user = resp;
            });
      }
  }

  return {
    users: {
      register: register,
      signIn: signIn,
      signOut: signOut,
      hasUser: hasUser,
      loginManager: loginManager,
      currentUser: getCurrentUserInfo
    }
  };

}());
