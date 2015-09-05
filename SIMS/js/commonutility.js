function PageSetUpS() {
    $.ajaxSetup({
        timeout: 120000, //Time in milliseconds 1000 = 1sec
    });
    $('.datepicker').datepickernoConflict({ dateFormat: 'mm/dd/yy' });//.on('changeDate', function (ev) {
    //console.log(ev);//this.hide();
    //$('.datepicker').hide();datepicker
    //});

    if (typeof ShowJobTypes != 'function') {
        //This function should not be used in login page.
        ShowActiveLinkInHeader();
        ShowUserData();
        ShowUserWiseLinks();
        $('.timepicker').timepicki();
    }

}

function preload(arrayOfImages) {
    $(arrayOfImages).each(function () {
        $('<img/>')[0].src = this;
        // Alternatively you could use:
        // (new Image()).src = this;
    });
}
function AjaxErrorHandling(status) {
    if (status == 'timeout') {
        SmallNotification('Could not connect to server.', -1);
    } else if (status != 'Not Found') {
        SmallNotification('Unable to proceed, please try later.', -1);
    }
}
// Usage:


function InitializeMasking() {
    $.mask.placeholder = 'X';
    $('input').each(function () {
        if ($(this).attr('data-mask')) {
            $(this).mask($(this).attr('data-mask'));
        }
    });
}
preload([
    '../img/scheduler.png',
    '../img/scheduler-sel.png',
    '../img/appraisals-sel.png',
    '../img/appraisals.png',
    '../img/users.png',
    '../img/users-sel.png',
    '../img/job-types.png',
    '../img/job-types-sel.png',
    '../img/coverage.png',
    '../img/coverage-sel.png',
    '../img/invitation.png',
    '../img/invitation-sel.png',
    '../img/myteam.png',
    '../img/myteam-sel.png',
    '../img/settings.png',
    '../img/settings-sel.png',
    '../img/help-center.png',
    '../img/help-center-sel.png',
    '../img/companydetail.png',
    '../img/companydetail-sel.png',
    '../img/companydetail.png',
    '../img/companydetail-sel.png',
]);
//Small Notification - Top-Right
//Type 1 = Success, 0 = warning, -1 = Unsuccess,  2 = info
function SmallNotification(content, type, oncompeted) {
    //console.log(typeof oncompeted);
    var color = '#FCFEF9'; //success type = 1
    var title = 'SUCCESS';
    if (type == 0) { color = '#FEFFFA'; title = 'WARNING'; } //warning
    else if (type == -1) { color = '#FFFCFD'; title = 'ERROR'; } //unsuccess
    else if (type == 2) { color = '#F9FDFF'; title = 'INFORMATION'; } // info
    try {
        $.smallBox({
            title: '<div style="font-weight: bold;">' + title + '</div>',
            content: "<div style='font-size: 12px !important;margin-left: 37px !important;'>" + content + "</div>",
            color: color,
            iconSmall: "spancloseicons fadeInRight animated",
            timeout: 5000,
            oncomplete: oncompeted
        });

        var obj = $(".SmallBox").last();
        var div = $("<div>");
        $(div).addClass("contentNotification");
        $(div).html(obj.html());
        obj.html('');
        obj.append($(div));

        if (typeof (oncompeted) == 'function') {
            $(obj).find('.textoFull').click(function () { oncompeted() });
            $(obj).find('.miniIcono').click(function () { oncompeted() });
        }

        if (type == 1) { $(".contentNotification").last().addClass('smalboxsuccess'); $(".SmallBox").last().css("border-color", "#53C128"); }//success
        else if (type == 0) { $(".contentNotification").last().addClass('smalboxwarning'); $(".SmallBox").last().css("border-color", "#CDB213"); }//warning
        else if (type == -1) { $(".contentNotification").last().addClass('smalboxunsuccess'); $(".SmallBox").last().css("border-color", "#F07B6C"); }//unsuccess
        else if (type == 2) { $(".contentNotification").last().addClass('smalboxinfo'); $(".SmallBox").last().css("border-color", "#17A3E2"); }//info

    } catch (err) { }

}
//Type 1 = Success, 0 = warning, -1 = Unsuccess,  2 = info
function SmallNotificationNoTimeout(content, type, title, callback) {
    var color = '#FCFEF9'; //success type = 1            
    if (type == 1) { if (!title) title = 'SUCCESS'; }
    else if (type == 0) { color = '#FEFFFA'; if (!title) title = 'WARNING'; } //warning
    else if (type == -1) { color = '#FFFCFD'; if (!title) title = 'ERROR'; } //unsuccess
    else if (type == 2) { color = '#F9FDFF'; if (!title) title = 'INFORMATION'; } // info
    try {
        $.smallBox({
            title: '<div style="font-weight: bold;">' + title + '</div>',
            content: "<div style='font-size: 12px !important;margin-left: 37px !important;'>" + content + "</div>",
            color: color,
            iconSmall: "spancloseicons fadeInRight animated",
            //timeout: 5000
        });

        var obj = $(".SmallBox").last();
        var div = $("<div>");
        $(div).addClass("contentNotification");
        $(div).html(obj.html());
        obj.html('');
        obj.append($(div));
        if (typeof (callback) == 'function')
            $(obj).find('.textoFull').click(function () { callback() });

        if (type == 1) { $(".contentNotification").last().addClass('smalboxsuccess'); $(".SmallBox").last().css("border-color", "#53C128"); }//success
        else if (type == 0) { $(".contentNotification").last().addClass('smalboxwarning'); $(".SmallBox").last().css("border-color", "#CDB213"); }//warning
        else if (type == -1) { $(".contentNotification").last().addClass('smalboxunsuccess'); $(".SmallBox").last().css("border-color", "#F07B6C"); }//unsuccess
        else if (type == 2) { $(".contentNotification").last().addClass('smalboxinfo'); $(".SmallBox").last().css("border-color", "#17A3E2"); }//info

    } catch (err) { }

}
//With TImeOut in milisecond
function SmallNotificationTimeOut(content, type, tout) {
    var color = '#739E73'; //success
    if (type == 0) { color = '#C79121'; } //warning
    else if (type == -1) { color = '#C46A69'; } //unsuccess
    else if (type == 2) { color = '#3276B1'; } // info
    try {
        $.smallBox({
            title: 'Valuepad Team',
            content: "<i class='fa fa-clock-o'></i> <i>" + content + "</i>",
            color: color,
            iconSmall: "fa fa-check fa-2x fadeInRight animated",
            timeout: tout
        });
    } catch (err) { }
}
//Big Notification - Bottom-Right
//Type 1 = Success, 0 = warning, -1 = Unsuccess, 2 = info
function BigNotification(msg, content, type) {
    var color = '#739E73'; //success
    if (type == 0) { color = '#C79121'; } //warning
    else if (type == -1) { color = '#C46A69'; } //unsuccess
    else if (type == 2) { color = '#3276B1'; } // info.
    try {
        $.bigBox({
            title: msg,
            content: content,
            color: color,
            //timeout: 8000,
            icon: "fa fa-bell swing animated",
            number: "Valuepad Team"
        });
    } catch (err) { }
}

function JQgridStyles() {
    // remove classes
    $(".ui-jqgrid").removeClass("ui-widget ui-widget-content");
    $(".ui-jqgrid-view").children().removeClass("ui-widget-header ui-state-default");
    $(".ui-jqgrid-labels, .ui-search-toolbar").children().removeClass("ui-state-default ui-th-column ui-th-ltr");
    $(".ui-jqgrid-pager").removeClass("ui-state-default");
    $(".ui-jqgrid").removeClass("ui-widget-content");

    // add classes
    $(".ui-jqgrid-htable").addClass("table table-bordered table-hover");
    $(".ui-jqgrid-btable").addClass("table table-bordered table-striped");

    $(".ui-pg-div").removeClass().addClass("btn btn-sm btn-primary");
    $(".ui-icon.ui-icon-plus").removeClass().addClass("fa fa-plus");
    $(".ui-icon.ui-icon-pencil").removeClass().addClass("fa fa-pencil");
    $(".ui-icon.ui-icon-trash").removeClass().addClass("fa fa-trash-o");
    $(".ui-icon.ui-icon-search").removeClass().addClass("fa fa-search");
    $(".ui-icon.ui-icon-refresh").removeClass().addClass("fa fa-refresh");
    $(".ui-icon.ui-icon-disk").removeClass().addClass("fa fa-save").parent(".btn-primary").removeClass("btn-primary").addClass("btn-success");
    $(".ui-icon.ui-icon-cancel").removeClass().addClass("fa fa-times").parent(".btn-primary").removeClass("btn-primary").addClass("btn-danger");

    $(".ui-icon.ui-icon-seek-prev").wrap("<div class='btn btn-sm btn-default'></div>");
    $(".ui-icon.ui-icon-seek-prev").removeClass().addClass("fa fa-backward");

    $(".ui-icon.ui-icon-seek-first").wrap("<div class='btn btn-sm btn-default'></div>");
    $(".ui-icon.ui-icon-seek-first").removeClass().addClass("fa fa-fast-backward");

    $(".ui-icon.ui-icon-seek-next").wrap("<div class='btn btn-sm btn-default'></div>");
    $(".ui-icon.ui-icon-seek-next").removeClass().addClass("fa fa-forward");

    $(".ui-icon.ui-icon-seek-end").wrap("<div class='btn btn-sm btn-default'></div>");
    $(".ui-icon.ui-icon-seek-end").removeClass().addClass("fa fa-fast-forward");
}

String.format = function () {
    var s = arguments[0];
    for (var i = 0; i <= 16; i++) {
        var reg = new RegExp("\\{" + i + "\\}", "gm");
        if (arguments.length - 1 <= i)
            s = s.replace(reg, '');
        else
            s = s.replace(reg, arguments[i + 1]);
    }
    return s;
}

//For Dialogue box view in different browsers.
function BrowserDetection() {


    if (navigator.userAgent.search("Chrome") >= 0) {
        //alert("Browser is Chrome");
    }
        //Check if browser is Firefox or not
    else if (navigator.userAgent.search("Firefox") >= 0) {
        //alert("Browser is FireFox");
        $("html").addClass("browsercss");
        $("body").addClass("browsercss");
    }
        //Check if browser is Safari or not
    else if (navigator.userAgent.search("Safari") >= 0 && navigator.userAgent.search("Chrome") < 0) {
        //alert("Browser is Safari");
    }
        //Check if browser is Opera or not
    else if (navigator.userAgent.search("Opera") >= 0) {
        //alert("Browser is Opera");
    }
        //Check if browser is IE or not
    else if (navigator.userAgent.indexOf('Trident/')) {
        // alert("Browser is InternetExplorer");
        $("html").addClass("browsercss");
        $("body").addClass("browsercss");
    }
    //Check if browser is Chrome or not
}

function get12Time(currentTime) {
    var hours = currentTime.getHours();
    var minutes = currentTime.getMinutes();

    if (minutes < 10)
        minutes = "0" + minutes;

    var suffix = "AM";
    if (hours >= 12) {
        suffix = "PM";
        hours = hours - 12;
    }
    if (hours == 0) {
        hours = 12;
    }
    var current_time = hours + ":" + minutes + " " + suffix;
    //console.log(current_time);
    return current_time;
}

function printDiv(printid) {
    //functionality of print a div.

    if (printid == 'ViewInstruction') {
        var DocumentContainer = document.getElementById('divViewInstruction');
        var client = document.getElementById('divClientInsruction');
        var Dc = document.getElementById('divClientInsruction');


        if (Dc.innerHTML != "") {
            var innerDc = document.getElementById('childdivClientInsruction');
            if (innerDc.innerHTML == "") {
                Dc.innerHTML = "";
            }
        }
        var WindowObject = window.open('', 'PrintWindow', 'width=750,height=650,top=50,left=50,toolbars=no,scrollbars=yes,status=no,resizable=yes');
        var strHtml = "<html>\n<head>\n <link rel='stylesheet' type='text/css' media='screen' href='../css/font-awesome.min.css' /> " +
                        "<link rel='stylesheet' type='text/css' media='screen' href='../css/auth.css' />" +
                       "<link rel='stylesheet' type='text/css' media='screen' href='../css/base.css' />" +
                        "<link rel='stylesheet' type='text/css' media='screen' href='../css/valuepad.css' />" +
                            " <style> " +
                            ".btn-link, .btn-link:active, .btn-link:focus, .btn-link:hover {border-color: transparent;border-top-color: transparent;border-right-color-value: transparent;border-bottom-color: transparent;border-left-color-value: transparent;border-left-color-ltr-source: physical;border-left-color-rtl-source: physical;border-right-color-ltr-source: physical;border-right-color-rtl-source: physical;}" +
                            ".btn-link, .btn-link:active, .btn-link[disabled], fieldset[disabled] .btn-link {background-color: transparent;box-shadow: none;} .btn-link {color: #333;;font-weight: 400; cursor: pointer;border-radius: 0px;}" +
                            "th{text-align: left;} b, strong {font-weight: 700;}  .well{background: none repeat scroll 0 0 #d6dde7;bordor-bottom:1px solid black;min-height: 50px;box-sizing: border-box;margin-bottom: 10px !important;}</style>\n</head>" +
                            "<body style='color: #333; font-family:Open Sans,Arial,Helvetica,sans-serif;font-size:12px;line-height: 1.42857;'>" +
                            "<div> " +
                            //"<i id='iprint' class='fa fa-print' style='cursor:pointer; font-size: 20px !important; padding-top: 7px; margin-bottom:20px' onclick='window.print();' rel='tooltip' title='' data-placement='bottom' data-original-title='Print' style='display: block;'></i>" +
                            '<button type="button" onclick="window.print();" rel="tooltip" title="" data-placement="bottom" data-original-title="print" class="btn-action padding-15 btn-print" ></button>' +
                            //"<input id='btnprintOfNewPage' style='float:right;margin-bottom:20px;' type='button' value='Print' onclick='window.print();' />" +
                            "</div><div style=\"testStyle\">\n"
                        + DocumentContainer.innerHTML + Dc.innerHTML + "\n</div>\n</body>\n</html>";
        WindowObject.document.writeln(strHtml);
        WindowObject.document.close();
        WindowObject.focus();

    }
    else if (printid == 'printdivBasicDetails') {
        GetInstructionByOrderID();
        var BasicDetailContainer = document.getElementById('printdivBasicDetails');
        var DocumentContainer = document.getElementById('divViewInstruction');
        var client = document.getElementById('divClientInsruction');
        var Dc = document.getElementById('divClientInsruction');
        var doc = DocumentContainer.innerHTML.trim();
        if (doc != "") {
            $('#spanInstructionPrint').show();
        }

        if (Dc.innerHTML != "") {
            var innerDc = document.getElementById('childdivClientInsruction');
            if (innerDc.innerHTML == "") {
                Dc.innerHTML = "";
            } else {
                $('#spanInstructionPrint').show();
            }
        }
        var WindowObject = window.open('', 'PrintWindow', 'width=750,height=650,top=50,left=50,toolbars=no,scrollbars=yes,status=no,resizable=yes');
        var strHtml = "<html>\n<head>\n <link rel='stylesheet' type='text/css' media='screen' href='../css/font-awesome.min.css' /> " +
                        //"<link rel='stylesheet' type='text/css' media='screen' href='../css/auth.css' />" +
                       //"<link rel='stylesheet' type='text/css' media='screen' href='../css/base.css' />" +
                        "<link rel='stylesheet' type='text/css' media='screen' href='../css/valuepad.css' />" +
                            " <style> " +
                            " h3 {font-size: 24px;margin-top: 20px;margin-bottom: 10px;font-weight: 500;line-height: 1.1;}" +
                            ".btn-link, .btn-link:active, .btn-link:focus, .btn-link:hover {border-color: transparent;border-top-color: transparent;border-right-color-value: transparent;border-bottom-color: transparent;border-left-color-value: transparent;border-left-color-ltr-source: physical;border-left-color-rtl-source: physical;border-right-color-ltr-source: physical;border-right-color-rtl-source: physical;}" +
                            ".btn-link, .btn-link:active, .btn-link[disabled], fieldset[disabled] .btn-link {background-color: transparent;box-shadow: none;} .btn-link {color: #333;;font-weight: 400; cursor: pointer;border-radius: 0px;}" +
                            "th{text-align: left;} b, strong {font-weight: 700;}  .well{background: none repeat scroll 0 0 #d6dde7;bordor-bottom:1px solid black;min-height: 50px;box-sizing: border-box;margin-bottom: 10px !important;}</style>\n</head>" +
                            "<body style='color: #333; font-family:Open Sans,Arial,Helvetica,sans-serif;font-size:12px;line-height: 1.42857;'>" +
                            "<div> " +
                            //"<i id='iprint' class='fa fa-print' style='cursor:pointer; font-size: 20px !important; padding-top: 7px; margin-bottom:20px' onclick='window.print();' rel='tooltip' title='' data-placement='bottom' data-original-title='Print' style='display: block;'></i>" +
                            '<button type="button" onclick="window.print();" rel="tooltip" title="" data-placement="bottom" data-original-title="print" class="btn-action padding-15 btn-print" ></button>' +
                            //"<input id='btnprintOfNewPage' style='float:right;margin-bottom:20px;' type='button' value='Print' onclick='window.print();' />" +
                            "</div><div style=\"testStyle\">\n"
                        + BasicDetailContainer.innerHTML + DocumentContainer.innerHTML + Dc.innerHTML + "\n</div>\n</body>\n</html>";
        WindowObject.document.writeln(strHtml);
        WindowObject.document.close();
        WindowObject.focus();
    }
    else {
        var DocumentContainer = document.getElementById(printid);
        var WindowObject = window.open('', 'PrintWindow', 'width=750,height=650,top=50,left=50,toolbars=no,scrollbars=yes,status=no,resizable=yes');
        var strHtml = "<html>\n<head>\n <link rel='stylesheet' type='text/css' media='screen' href='../css/font-awesome.min.css' /> " +
                        "<link rel='stylesheet' type='text/css' media='screen' href='../css/valuepad.css' />" +
                         "<link rel='stylesheet' type='text/css' media='screen' href='../css/auth.css' />" +
                       "<link rel='stylesheet' type='text/css' media='screen' href='../css/base.css' />" +
                        "<script src='../../js/app.min.js'></script>" +
                            " <style> " +
                            ".btn-link, .btn-link:active, .btn-link:focus, .btn-link:hover {border-color: transparent;border-top-color: transparent;border-right-color-value: transparent;border-bottom-color: transparent;border-left-color-value: transparent;border-left-color-ltr-source: physical;border-left-color-rtl-source: physical;border-right-color-ltr-source: physical;border-right-color-rtl-source: physical;}" +
                            ".btn-link, .btn-link:active, .btn-link[disabled], fieldset[disabled] .btn-link {background-color: transparent;box-shadow: none;} .btn-link {color: #333;;font-weight: 400; cursor: pointer;border-radius: 0px;}" +
                            "th{text-align: left;} b, strong {font-weight: 700;} .well{background: none repeat scroll 0 0 #d6dde7;bordor-bottom:1px solid black;min-height: 50px;box-sizing: border-box;margin-bottom: 10px !important;}</style>\n</head>" +
                            "<body style='color: #333; font-family:Open Sans,Arial,Helvetica,sans-serif;font-size:12px;line-height: 1.42857;'>" +
                            "<div>" +
                            //" <i id='iprint' class='fa fa-print' style='cursor:pointer; font-size: 20px !important; padding-top: 7px; margin-bottom:20px' onclick='window.print();' rel='tooltip' title='' data-placement='bottom' data-original-title='Print' style='display: block;'></i>" +
                            '<button type="button" onclick="window.print();" rel="tooltip" title="" data-placement="bottom" data-original-title="print" class="btn-action padding-15 btn-print" ></button>' +
                            //"<input id='btnprintOfNewPage' style='float:right;margin-bottom:20px;' type='button' value='Print' onclick='window.print();' />" +
                            "</div><div style=\"testStyle\">\n"
                        + DocumentContainer.innerHTML + "\n</div>\n</body>\n</html>";
        WindowObject.document.writeln(strHtml);
        WindowObject.document.close();
        WindowObject.focus();
        //WindowObject.print();
        //WindowObject.close();
        //$("[rel=tooltip]").tooltip();
    }

}

function getParameterByName(name) {
    //get value from query string.
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

function GetMonthName(month) {
    switch (month) {
        case 1:
            return 'January';

        case 2:
            return 'February';

        case 3:
            return 'March';

        case 4:
            return 'April';

        case 5:
            return 'May';

        case 6:
            return 'June';

        case 7:
            return 'July';

        case 8:
            return 'August';

        case 9:
            return 'September';

        case 10:
            return 'October';

        case 11:
            return 'November';

        case 12:
            return 'December';
    }
}

function ShowLocationOnMap(address) {
    var geocoder = new google.maps.Geocoder();
    geocoder.geocode({ address: address/*'United State, 380061' zip you got from user input */ },
        function (results_array, status) {

            var lat = results_array[0].geometry.location.lat();
            var lng = results_array[0].geometry.location.lng();
            var myLatlng = new google.maps.LatLng(lat, lng);

            var mapOptions = {
                center: new google.maps.LatLng(lat, lng),
                zoom: 14,
                disableDefaultUI: true,
                zoomControl: false,
                scaleControl: false,
                scrollwheel: false

            }

            var map = new google.maps.Map(document.getElementById('testMap'), mapOptions);
            google.maps.event.addListenerOnce(map, 'idle', function () {
                var Marker = new google.maps.Marker({
                    position: myLatlng,
                    map: map
                });
                google.maps.event.trigger(map, 'resize');
                map.setCenter(myLatlng);
                map.setZoom(10);
            });
        });
    //$('#googleMap').modal();
    //$('#googleMap').modal('show');
}

function ShowLocationOnMapByLangLat(langitude, latitude) {

    var mapOptions = {
        center: new google.maps.LatLng(latitude, langitude),
        zoom: 10,
        scrollwheel: false
    }
    var myLatlng = new google.maps.LatLng(latitude, langitude);
    var map = new google.maps.Map(document.getElementById('testMap'), mapOptions);

    google.maps.event.addListenerOnce(map, 'idle', function () {
        var Marker = new google.maps.Marker({
            position: myLatlng,
            map: map
        });
        google.maps.event.trigger(map, 'resize');
        map.setCenter(myLatlng);
    });
    google.maps.event.addListener(map, 'mouseout', function () {
        map.set('scrollwheel', false);
    });
    google.maps.event.addListener(map, 'click', function () {
        map.set('scrollwheel', true);
    });
}
function ShowStreetMapInPlaceOfPropertyImage(long, lat) {

    $('#divPropertyImage').html('');
    var myLatlng = new google.maps.LatLng(lat, long);

    var map = new google.maps.Map(document.getElementById('dvStreetviewForProperty'));
    google.maps.event.addListenerOnce(map, 'idle', function () {
        google.maps.event.trigger(map, 'resize');
    });
    var panoramaOptions = {
        position: myLatlng,
        pov: {
            heading: 34,
            pitch: 10
        },
        scrollwheel: false,
        addressControl: false,
        panControl: false
    };

    var panorama = new google.maps.StreetViewPanorama(document.getElementById("dvStreetviewForProperty"), panoramaOptions);
    map.setStreetView(panorama);
}

function getPageName() {
    var url = window.location.href
    if (url.lastIndexOf("?") > -1) { url = url.split("?")[0] }
    var index = url.lastIndexOf("/") + 1,
        filenameWithExtension = url.substr(index),
        filename = filenameWithExtension.split(".")[0];

    return filename;
}

function ShowActiveLinkInHeader() {

    $('#divArrowSeeAllNotification').hide();
    var pageName = getPageName();
    var obj;
    if (pageName == "dashboard") {
        var obj = $("#liDashboard");
    }
    else if (pageName == "appraisaldetails" || pageName == "appraisal") // || pageName == "seeallnotification"
    {
        var obj = $("#liAppraisal");
    }
    else if (pageName == "scheduler") {
        var obj = $("#liScheduler");
    }
    else if (pageName == "profile") {
        var obj = $("#liProfile");
    }
    else if (pageName == "jobtypes") {
        var obj = $("#liJobType");
    }
    else if (pageName == "coverage" || pageName == "companydetail") {
        var obj = $("#liCoverage");
    }
    else if (pageName == "myinvitations" || pageName == "invitations") {
        var obj = $("#liInvitation");
    }
    else if (pageName == "settings" || pageName == "setting" || pageName == "apiuserprofile") {
        var obj = $("#liSettings");
    }
    else if (pageName == "support") {
        var obj = $("#liHelp");
    }
    else if (pageName == "myteam") {
        var obj = $("#liTeam");
    }
    else if (pageName == "apiusermsmqlog" || pageName == "ipusermsmqlog") {
        var obj = $("#liMSMQLog");
    }
    else if (pageName == "additionalstatus") {
        var obj = $("#liAdditionalStatusHeader");
    }
    else if (pageName == "seeallnotification") {
        $('#divArrowSeeAllNotification').show();
    }
    else if (pageName == "accounting" || pageName == "addcompany") {
        var obj = $("#liAccounting");
    }

    if (obj != null) {
        $(obj).addClass("active");
        $(obj).siblings().removeClass("active");
    }
}

function ShowUserData() {
    try {
        $.ajax({
            url: ProfileImageURL + UserID + "/" + UserProfileImage, //or your url
            success: function (data) {
                $('#dvUserProfile').css({ 'background-image': 'url(' + ProfileImageURL + UserID + "/" + UserProfileImage + '?' + parseInt(Math.random() * 10000) + ')' });
            },
            error: function (data) {
                $('#dvUserProfile').css({ 'background-image': 'url(' + ProfileImageURL + "no-photo.png" + ')' });
            },
        })


        $("#lblHeaderFirstName").html(FirstName);
        if (UserID != null) {
            $("#ctlheader_hlnkHelpCenter").attr("href", BaseURL + "common/support.aspx?id=" + UserID);
        }
    }
    catch (ex) { }
}

function ShowSupportPage() {
    var params = new Object();
    params.UserID = UserID;

    $.ajax({
        type: "POST",
        url: BaseURL + 'services/appraiser.asmx/GenerateSupportToken',
        data: JSON.stringify(params),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d.length > 0) {
                var token = response.d;
                window.location.href = BaseURL + "common/support.aspx?token=" + token;
            } else {
                SmallNotification('Unable to proceed, please try later.', -1);
            }
        },
        failure: function (xhr, status, error) {
            AjaxErrorHandling(status);
            //SmallNotification('Unable to proceed, please try later.', -1);
        },
        error: function (xhr, status, error) {
            AjaxErrorHandling(status);
            //SmallNotification('Unable to proceed, please try later.', -1);
        }
    });
}

/* Back To the Previous Page btn Start */
function CheckPreviousPage(pagename) {
    var fr = document.referrer;
    if (fr.indexOf(pagename) > -1)
        $('.btnback').show(300);
    else
        $('.btnback').hide();
}
function BackToThePage() {
    window.history.back();
}
/* Back To the Previous Page btn End */

function ShowUserWiseLinks() {
    if (UserType == 'IntegrationPartner' || UserType == 'IntegrationClient') {
        //$('#appNav').hide();
        //$('#compNav').show();

        $("#liAccounting").hide();
        $("#liJobType").show();
        $("#ctlheader_hlnkProfile").attr("href", BaseURL + "company/profile.aspx");

        //$("#ctlheader_hlnkJobType").html('<span class="companydetail"></span>Company Details');
        //$("#ctlheader_hlnkJobType").attr("href", BaseURL + "company/companydetail.aspx");

        //$("#ctlheader_hlnkCoverage").html('<span class="companydetail"></span>Company Details');
        //$("#ctlheader_hlnkCoverage").attr("href", BaseURL + "company/companydetail.aspx");

        $("#ctlheader_hlnkJobType").attr("href", BaseURL + "company/jobtypes.aspx");

        $("#ctlheader_hlnkMyInvitation").html('<span class="invitation"></span>Invitations');
        $("#ctlheader_hlnkMyInvitation").attr("href", BaseURL + "company/invitations.aspx");

        $("#ctlheader_hlnkSettings").attr("href", BaseURL + "company/setting.aspx");

        $('#ctlheader_hlnkAddOrderForAppraiser').remove();
        //$('#ctlheader_hlnkAddOrderForAppraiser').hide();

    } else {
        $("#liInvitation").show();
        $("#liScheduler").show();
        $("#liAppraisal").show();
        $("#liCoverage").show();
        $("#liJobType").show();
        $("#liAccounting").show();
        $("#ctlheader_hlnkProfile").attr("href", BaseURL + "appraiser/profile.aspx");

        $("#ctlheader_hlnkCoverage").html('<span class="coverage"></span>Coverage');
        $("#ctlheader_hlnkCoverage").attr("href", BaseURL + "appraiser/coverage.aspx");

        $("#ctlheader_hlnkJobType").html('<span class="jobtype"></span>Job Type');
        $("#ctlheader_hlnkJobType").attr("href", BaseURL + "appraiser/jobtypes.aspx");

        $("#ctlheader_hlnkMyInvitation").html('<span class="invitation"></span>Invitations');
        $("#ctlheader_hlnkMyInvitation").attr("href", BaseURL + "appraiser/myinvitations.aspx");

        $("#ctlheader_hlnkSettings").attr("href", BaseURL + "appraiser/settings.aspx");
        //$('#compNav').hide();
        //$('#appNav').show();        
    }
    if (UserID != null && UserType != null) {
        if (UserType == "IntegrationPartner") {
            //$("#liCoverage").show();
            $("#liCoverage").hide();
            $("#liSetting").show();
            $("#liTeam").show();
            $("#liInvitation").show();//for invitations
            $("#liScheduler").show();
            $("#liAppraisal").show();
            $("#liMSMQLog").show();
            //$("#liAccounting").show();
            //$("#ctlheader_hlnkAccounting").attr("href", BaseURL + "company/addcompany.aspx");
            //$("#ctlheader_hlnkAccounting").html('<span class="accounting"></span>Company');

            $("#ctlheader_hlMSMQLog").attr("href", BaseURL + "company/ipusermsmqlog.aspx");

            if (AccountTypeID == 3) {
                $("#liTeam").show();
                $("#liInvitation").show();
                //$("#liJobType").hide();
            }
            else {
                $("#liTeam").hide();
                $("#liInvitation").hide();
            }
            $('#liAdditionalStatusHeader').show();
        }
        else {
            //$("#liSetting").hide();
            //$("#liCoverage").hide();
            $("#liTeam").hide();
            //$("#liInvitation").hide();
            $("#liScheduler").show();
            $("#liAppraisal").show();
        }
        if (UserType == "IntegrationClient") {
            $("#liMSMQLog").show();
            $("#ctlheader_hlnkSettings").attr("href", BaseURL + "company/apiuserprofile.aspx");
            //$("#liJobType").hide();//for hide company details
            $("#liTeam").hide();
            $("#liInvitation").hide();
            $("#liScheduler").hide();
            $("#liAppraisal").hide();
            $("#liCoverage").hide();
            //$("#ctlheader_hlnkJobType").html('<span class="companydetail"></span>User\'s Activity');
            //$("#ctlheader_hlnkJobType").attr("href", BaseURL + "company/useractivity.aspx");
        }
    }
}

function HideLoadingOverlay() {
    $('.loginOverLay').hide();
}

function ShowLoadingOverlay() {
    $('.loginOverLay').show();
}

function ShowHideMap() {

    if ($('#dvappraisalMapDetail').is(":visible")) {
        $('#dvappraisalMapDetail').slideUp('slow');
        setCookie(UserID, 0, 15);// 0 for hide
    }
    else {
        //$('#dvappraisalMapDetail').show();
        ShowMap(ID, OrderLongitude, OrderLattitude);

        $('#dvappraisalMapDetail').slideDown('slow');
        setCookie(UserID, 1, 15);// 1 for show
    }
    setTimeout(function () { $(".js-masonry").masonry(); }, 2000);
    //setTimeout(function () {
    ////Map Settings - start desktop-record-columns
    $('#cssMap').remove();
    var width = $('#divStreetView').outerWidth();
    $("<style type='text/css' id='cssMap'> .widthForMap{ width:" + width + "px !important;} </style>").appendTo("head");
    $('#dvStreetviewForProperty').addClass("widthForMap");
    $('#testMap').addClass("widthForMap");
    //Map Settinggs - End
    //}, 100);

}


function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + "; " + expires;
}

function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1);
        if (c.indexOf(name) == 0) return c.substring(name.length, c.length);
    }
    return "";
}
function checkUserSession() {
    $.ajax({
        type: "POST",
        url: BaseURL + 'Services/register.asmx/CheckUserSession',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d == 0) {
                window.location = BaseURL + "default.aspx";
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
//function ShowLocationOnMapByLangLat(langitude, latitude) {

//    //var lat = latitude;
//    //var lng = langitude;
//    var mapOptions = {
//        center: new google.maps.LatLng(latitude, langitude),
//        zoom: 10,
//        //disableDefaultUI: true,
//        zoomControl: true,
//        scaleControl: true,
//        scrollwheel: false

//    }
//    var mapOptionsChnage = {
//        center: new google.maps.LatLng(latitude, langitude),
//        zoom: 10,
//        //disableDefaultUI: false
//    }

//    var myLatlng = new google.maps.LatLng(latitude, langitude);
//    var map = new google.maps.Map(document.getElementById('testMap'), mapOptions);

//    google.maps.event.addListenerOnce(map, 'idle', function () {
//        var Marker = new google.maps.Marker({
//            position: myLatlng,
//            map: map
//        });
//        google.maps.event.trigger(map, 'resize');
//        map.setCenter(myLatlng);
//        map.setZoom(10);
//    });
//    google.maps.event.addListener(map, 'mouseout', function () {
//        //    ShowLocationOnMapByLangLat(langitude, latitude);

//        var myOptions = {
//            center: new google.maps.LatLng(latitude, langitude),
//            zoom: 10,
//            scrollwheel: false
//        }
//        map.set(myOptions);
//        console.log('out');
//    });
//    google.maps.event.addListener(map, 'click', function () {
//        //var map = new google.maps.Map(document.getElementById('testMap'), mapOptionsChnage);

//        //google.maps.event.trigger(map, 'resize');

//        //google.maps.event.addListenerOnce(map, 'idle', function () {
//        //    var Marker = new google.maps.Marker({
//        //        position: myLatlng,
//        //        map: map
//        //    });
//        //    google.maps.event.trigger(map, 'resize');
//        //    map.setCenter(myLatlng);
//        //    map.setZoom(10);
//        //});

//        //google.maps.event.addListener(map, 'mouseout', function () {
//        //    ShowLocationOnMapByLangLat(langitude, latitude);


//        //});

//        var myOptions = {
//            center: new google.maps.LatLng(latitude, langitude),
//            zoom: 10,
//        }
//        map.set(myOptions);
//        console.log('click');
//    });


//}
//MOney Formation
function Comma(Num) { //function to add commas to textboxes
    Num += '';
    Num = Num.replace(',', ''); Num = Num.replace(',', ''); Num = Num.replace(',', '');
    Num = Num.replace(',', ''); Num = Num.replace(',', ''); Num = Num.replace(',', '');
    x = Num.split('.');
    x1 = x[0];
    x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1))
        x1 = x1.replace(rgx, '$1' + ',' + '$2');
    return x1 + x2;
}