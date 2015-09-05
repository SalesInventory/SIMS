//<%--Facebook - Start--%>

function DownloadSocialMediaProfileImage(profileImageUrl) {
    var params = new Object();
    params.profileImageUrl = profileImageUrl;
    $.ajax({
        type: "POST",
        async: false,
        url: BaseURL + 'services/appraiser.asmx/DownloadSocialMediaProfileImage',
        data: JSON.stringify(params),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d) {
                ShowProfileImageChangePopup();
                setTimeout(function () {
                    options.imgSrc = "data:image/png;base64," + response.d;
                    cropper = $('.imageBox').cropbox(options);
                }, 500);
            } else {
                SmallNotification('Unable to proceed, please try later.', -1);
            }
        },
        failure: function (xhr, status, error) {
            AjaxErrorHandling(status);
        },
        error: function (xhr, status, error) {
            AjaxErrorHandling(status);
        }
    });
}

// This is called with the results from from FB.getLoginStatus().
function facebookLoginCallback(response) {
    // The response object is returned with a status field that lets the
    // app know the current login status of the person.
    // Full docs on the response object can be found in the documentation
    // for FB.getLoginStatus().
    if (response.status === 'connected') {
        // Logged into your app and Facebook.
        loadFacebookProfileUrl(response);
    } else if (response.status === 'not_authorized') {
        //The person is logged into Facebook, but not your app.
        //document.getElementById('status').innerHTML = 'Please log into this app.';
        //alert('Please log into this app.');
        //SmallNotification('Please log into this app.', 2);
        FB.login(function (res) {
            if (res.authResponse) {
                loadFacebookProfileUrl(res);
            } else {
                //document.getElementById('status').innerHTML = 'User cancelled login.';
                //alert('User cancelled login.');
                SmallNotification('User cancelled login.', 2);
            }
        });
    } else {
        // The person is not logged into Facebook, so we're not sure if
        // they are logged into this app or not.
        //document.getElementById('status').innerHTML = 'Please log into Facebook.';
        FB.login(function (res) {
            if (res.authResponse) {
                loadFacebookProfileUrl(res);
            } else {
                //document.getElementById('status').innerHTML = 'User cancelled login.';
                //alert('User cancelled login.');
                SmallNotification('User cancelled login.', 2);
            }
        });
    }
}

//window.fbAsyncInit = function () {
//    FB.init({
//        appId: '1485330861757039',
//        cookie: true,  // enable cookies to allow the server to access the session
//        xfbml: true,  // parse social plugins on this page
//        version: 'v2.3' // use version 2.2
//    });
//};

// Load the SDK asynchronously
(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_US/sdk.js";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));

function loadFacebookProfileUrl(res) {

    if (!res) {
        //alert('Error occurred.');
        SmallNotification('Error occurred.', -1);
    } else if (res.error) {
        //alert('Error: ' + res.error.message);
        SmallNotification('Error occurred.', -1);
    } else {
        FB.api("/" + res.authResponse.userID + "/picture?type=large",
            function (response) {

                if (!response) {
                    //alert('Error occurred.');
                    SmallNotification('Error occurred.', -1);
                } else if (response.error) {
                    if (response.error.code == 190 || response.error.error_subcode == 467) {
                        doFacebookLogin()
                    } else {
                        // alert('Error: ' + response.error.message);
                        SmallNotification('Error occurred.', -1);
                    }
                } else {
                    //console.log(response);
                    //document.getElementById('status').innerHTML += "<img src='" + response.data.url + "' />";
                    DownloadSocialMediaProfileImage(response.data.url);
                }
            }
        );
    }
}

function doFacebookLogin() {
    FB.getLoginStatus(function (response) {
        facebookLoginCallback(response);
    }/*, { scope: 'public_profile,email' }*/);
}

//<%--Facebook - End--%>

//<%--LinkedIn - Start--%>
// Setup an event listener to make an API call once auth is complete
function onLinkedInLoad() {
    //IN.Event.on(IN, "auth", getProfileData);
}

// Handle the successful return from the API call
function onLinkedInSuccess(data) {
    var url;
    if (data.pictureUrls && data.pictureUrls != null && typeof (data.pictureUrls) != 'undefined') {
        //document.getElementById('status').innerHTML += "<img src='" + data.pictureUrls.values[0] + "' />";
        if (typeof (data.pictureUrls.values) != 'undefined')
            url = data.pictureUrls.values[0];
        else
            SmallNotification('Your linkedin profile doesn\'t contain any profie picture.', 0);
    }
    else if (data.pictureUrl && data.pictureUrl != null && typeof (data.pictureUrl) != 'undefined') {
        //document.getElementById('status').innerHTML += "<img src='" + data.pictureUrl + "' />";
        url = data.pictureUrl;
    } else
        SmallNotification('Your linkedin profile doesn\'t contain any profie picture.', 0);

    if (url)
        DownloadSocialMediaProfileImage(url);
}

// Handle an error response from the API call
function onLinkedInError(error) {
    //alert(error);
    SmallNotification('Error occurred.', -1);
}

// Use the API call wrapper to request the member's basic profile data
function getProfileData() {
    IN.API.Raw("/people/~:(id,first-name,last-name,picture-url,picture-urls::(original))").result(onLinkedInSuccess).error(onLinkedInError);
}

function doLinkedInLogin() {
    IN.User.authorize(function () {
        getProfileData();
    });
}

//<%--LinkedIn - End--%>