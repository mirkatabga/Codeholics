var jsonRequester = (function () {

    function send(method, url, options, contentType) {
        options = options || {};
        //contentType = contentType || 'application/json';

        var headers = options.headers || {},
          data = options.data || undefined;
        var promise = {};

        if (contentType) {
            promise = new Promise(function (resolve, reject) {
                $.ajax({
                    url: url,
                    method: method,
                    contentType: contentType,
                    headers: headers,
                    data: data,//JSON.stringify(data),
                    success: function (res) {
                        resolve(res);
                    },
                    error: function (err) {
                        reject(err);
                    }
                });
            });
        } else {
            promise = new Promise(function (resolve, reject) {
                $.ajax({
                    url: url,
                    method: method,
                    contentType: 'application/json',
                    headers: headers,
                    data: JSON.stringify(data),
                    success: function (res) {
                        resolve(res);
                    },
                    error: function (err) {
                        reject(err);
                    }
                });
            });
        }

        return promise;
    }

    function get(url, options, contentType) {
        return send('GET', url, options);
    }

    function post(url, options, contentType) {
        return send('POST', url, options, contentType);
    }

    function put(url, options, contentType) {
        return send('PUT', url, options);
    }

    function del(url, options, contentType) {
        return send('POST', url, options);
    }

    return {
        send: send,
        get: get,
        post: post,
        put: put,
        delete: del
    };
}());
