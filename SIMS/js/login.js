$(document).ready(function () {
    ApplyValidationLoginForm();
});

//Apply validation on Sign in 
function ApplyValidationLoginForm() {
    $("#frmLogin").validate({
        // Rules for form validation
        rules: {
            ctl00$cpContent$txtUserName: {
                required: true
            },
            ctl00$cpContent$txtPassword: {
                required: true
            }
        },

        // Messages for form validation
        messages: {
            ctl00$cpContent$txtUserName: {
                required: 'required',
            },
            ctl00$cpContent$txtPassword: {
                required: 'required',
            }
        },

        // Do not change code below
        errorPlacement: function (error, element) {
            error.insertBefore(element);
        },

        submitHandler: function (form) {
            //loginOverLayShow();
            javascript: __doPostBack('ctl00$cpContent$btnValueLogin', '');
            return false;
        }
    });
}

//Set Message from string
function CodeBehindMessage(msg, type) {
    SmallNotification(msg, type);
}

//Hide the ProgressBar
function loginOverLayHide() {
    $('.loginOverLay').hide();
}