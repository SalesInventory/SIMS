/************************************************************************
*************************************************************************
@Name :       	JqGrid Custom Pager Plug-in
@Version :    	1.0.0
@Date : 		15 Sep 2014
@Author:     	Tirthak Shah

**************************************************************************
*************************************************************************/
(function ($) {
    $.pager = {
        defaults: {
            Grid: null, // JqGrid for which we need to display pager
            PagerContainer: null, // Container in which pager will be displyed
            PageSize: 10, // Page-size 
            MaxPagerNumbers: 2, //max numbers-count of pages to be displayed + 1s
            TotalRecords: 0, //Total Records
            CurrentPage: 1, //Current Page
            TotalPages: 1, // Total Pages
            /** METHODS - OPTIONS **/
            OnCompleted: null,
            ReloadGrid: null
        },

        /*****************/
        /** Init Method **/
        /*****************/
        init: function (msg, options) {
            opts = $.extend({}, $.pager.defaults, options);
            if (this.validate()) {
                //Create Page Size List
                //this.pagesizecontroller();

                //Create Pager Navigator
                this.pagenavigator();
                if (opts.OnCompleted) opts.OnCompleted();
            }
        },
        validate: function () {
            //if (opts.Grid == null) {
            //    console.log('Grid not supplied.');
            //    return false;
            //}
            if (opts.PagerContainer == null) {
                //console.log('PagerContainer not supplied.');
                return false;
            }
            return true;
        },
        pagesizecontroller: function () {
            opts.PagerContainer.html("");

            var ulPagination = $('<ul>', { class: "pagination display pull-left" }), i = 0,
                myPageSizeRefresh = function (e) {
                    var newPagesize = $(e.target).text();
                    if (newPagesize == "All")
                        newPagesize = -1;
                    opts.Grid[0].p.rowNum = newPagesize;
                    grid.trigger("reloadGrid");
                    e.preventDefault();
                };

            $('<li>', { html: "<span>Display</span>" }).appendTo(ulPagination);

            for (i = 0; i < opts.PageSizeList.length; i++) {
                var intPageSizeList = opts.PageSizeList[i] == "All" ? -1 : opts.PageSizeList[i];
                if (intPageSizeList == opts.Grid[0].p.rowNum)
                    var li = $('<li>', { class: "active" });
                else
                    var li = $('<li>');
                $('<a>', { href: "javascript:void(0);", click: myPageSizeRefresh, html: opts.PageSizeList[i] }).appendTo(li);
                ulPagination.append(li);
            }

            opts.PagerContainer.append(ulPagination);
        },
        pagenavigator: function () {
            var ulNavigation = $('<ul>', { class: "pagination" }), i = 0,
                myPageNavRefresh = function (e) {
                    var newPage = $(e.target).text();
                    opts.ReloadGrid(newPage);
                    e.preventDefault();
                },
                myFirstPageNavRefresh = function (e) {
                    //ReloadGrid(1);
                    opts.ReloadGrid(1);
                    e.preventDefault();
                },
                myPrevPageNavRefresh = function (e) {
                    var newPage = opts.CurrentPage;
                    if (newPage > 1)
                        newPage--;
                    //ReloadGrid(newPage);
                    opts.ReloadGrid(newPage);
                    e.preventDefault();
                },
                myNextPageNavRefresh = function (e) {
                    var newPage = opts.CurrentPage;
                    if (newPage < opts.TotalPages)
                        newPage++;
                    //ReloadGrid(newPage);
                    opts.ReloadGrid(newPage);
                    e.preventDefault();
                },
                myLastPageNavRefresh = function (e) {
                    //ReloadGrid(opts.TotalPages);
                    opts.ReloadGrid(opts.TotalPages);
                    e.preventDefault();
                };

            //$('<li>', { html: $('<a>', { href: "javascript:void(0);", click: myFirstPageNavRefresh, html: "First" }) }).appendTo(ulNavigation);
            //$('<li>', { html: $('<a>', { href: "javascript:void(0);", click: myPrevPageNavRefresh, html: "Prev" }) }).appendTo(ulNavigation);

            $('<li><a href="javascript:void(0);" onclick="' + opts.ReloadGrid + '(1)">First</a><li>').appendTo(ulNavigation);
            if (opts.CurrentPage > 1) {
                prev = opts.CurrentPage - 1;
                $('<li><a href="javascript:void(0);" onclick="' + opts.ReloadGrid + '(' + prev + ') ">Prev</a><li>').appendTo(ulNavigation);
            } else {
                $('<li><a href="javascript:void(0);" onclick="' + opts.ReloadGrid + '(' + opts.CurrentPage + ') ">Prev</a><li>').appendTo(ulNavigation);
            }

            var totalPages = opts.TotalPages, cntNumbers = 0;
            var startIndex = opts.TotalPages - opts.CurrentPage < opts.MaxPagerNumbers ? opts.TotalPages - opts.MaxPagerNumbers : opts.CurrentPage - 1;

            for (var i = startIndex; i <= totalPages && cntNumbers <= opts.MaxPagerNumbers; i++) {
                //alert("i:" + i + " totalPages:" + totalPages + " cntNumbers:" + cntNumbers);
                if (i <= 0) { continue; }

                var li = $('<li>');

                //if (i == opts.CurrentPage) {
                //    $('<a>', { class: "active", href: "javascript:void(0);", click: myPageNavRefresh, html: i }).appendTo(li);
                //} else {
                //    $('<a>', { href: "javascript:void(0);", click: myPageNavRefresh, html: i }).appendTo(li);
                //}
                if (i == opts.CurrentPage) {
                    $('<a class="active" href="javascript:void(0);" onclick="' + opts.ReloadGrid + '(' + i + ')" >' + i + '</a>').appendTo(li);
                } else {
                    $('<a href="javascript:void(0);" onclick="' + opts.ReloadGrid + '(' + i + ')" >' + i + '</a>').appendTo(li);
                }
                ulNavigation.append(li);
                cntNumbers++;
            }

            //$('<li>', { html: $('<a>', { href: "javascript:void(0);", click: myNextPageNavRefresh, html: "Next" }) }).appendTo(ulNavigation);
            //$('<li>', { html: $('<a>', { href: "javascript:void(0);", click: myLastPageNavRefresh, html: "Last" }) }).appendTo(ulNavigation);

            if (opts.CurrentPage < opts.TotalPages) {
                next = opts.CurrentPage + 1;
                $('<li><a href="javascript:void(0);" onclick="' + opts.ReloadGrid + '(' + next + ') ">Next</a><li>').appendTo(ulNavigation);
            } else {
                $('<li><a href="javascript:void(0);" onclick="' + opts.ReloadGrid + '(' + opts.CurrentPage + ') ">Next</a><li>').appendTo(ulNavigation);
            }
            $('<li><a href="javascript:void(0);" onclick="' + opts.ReloadGrid + '(' + opts.TotalPages + ') ">Last</a><li>').appendTo(ulNavigation);

            if (opts.TotalPages > 1) {
                opts.PagerContainer.html('');
                opts.PagerContainer.append(ulNavigation);
            }
            //opts.PagerContainer.append('<div class="pull-right padding-10">TotalPages : ' + opts.TotalPages + '</div>')
        }
    };

    /** Init method **/
    pager = function (msg, options) {
        //jQuery.extend(true, {}, $.pager).init(msg, options);
        $.pager.init(msg, options);
    };

})(jQuery);


(function ($) {
    $["fn"]["Pagination"] = function (num, options) {
        opts = $.extend({}, $.pager.defaults, options);
        if (opts.PagerContainer == null) {
            //console.log('PagerContainer not supplied.');
            return false;
        } else {
            var ulNavigation = $('<ul>', { class: "pagination" }), i = 0;

            var totalPages = opts.TotalPages, cntNumbers = 0;
            var startIndex = opts.TotalPages - opts.CurrentPage < opts.MaxPagerNumbers ? opts.TotalPages - opts.MaxPagerNumbers : opts.CurrentPage - 1;

            $('<li><a href="javascript:void(0);" onclick="' + opts.ReloadGrid + '(1)">First</a><li>').appendTo(ulNavigation);
            if (opts.CurrentPage > 1) {
                prev = opts.CurrentPage - 1;
                $('<li><a href="javascript:void(0);" onclick="' + opts.ReloadGrid + '(' + prev + ') ">Prev</a><li>').appendTo(ulNavigation);
            } else {
                $('<li><a href="javascript:void(0);" onclick="' + opts.ReloadGrid + '(' + opts.CurrentPage + ') ">Prev</a><li>').appendTo(ulNavigation);
            }

            var totalPages = opts.TotalPages, cntNumbers = 0;
            var startIndex = opts.TotalPages - opts.CurrentPage < opts.MaxPagerNumbers ? opts.TotalPages - opts.MaxPagerNumbers : opts.CurrentPage - 1;

            for (var i = startIndex; i <= totalPages && cntNumbers <= opts.MaxPagerNumbers; i++) {
                //alert("i:" + i + " totalPages:" + totalPages + " cntNumbers:" + cntNumbers);
                if (i <= 0) { continue; }

                var li = $('<li>');

                if (i == opts.CurrentPage) {
                    $('<a class="active" href="javascript:void(0);" onclick="' + opts.ReloadGrid + '(' + i + ')" >' + i + '</a>').appendTo(li);
                } else {
                    $('<a href="javascript:void(0);" onclick="' + opts.ReloadGrid + '(' + i + ')" >' + i + '</a>').appendTo(li);
                }
                ulNavigation.append(li);
                cntNumbers++;
            }

            if (opts.CurrentPage < opts.TotalPages) {
                next = opts.CurrentPage + 1;
                $('<li><a href="javascript:void(0);" onclick="' + opts.ReloadGrid + '(' + next + ') ">Next</a><li>').appendTo(ulNavigation);
            } else {
                $('<li><a href="javascript:void(0);" onclick="' + opts.ReloadGrid + '(' + opts.CurrentPage + ') ">Next</a><li>').appendTo(ulNavigation);
            }
            $('<li><a href="javascript:void(0);" onclick="' + opts.ReloadGrid + '(' + opts.TotalPages + ') ">Last</a><li>').appendTo(ulNavigation);

            opts.PagerContainer.html('');
            opts.PagerContainer.append(ulNavigation);
            //opts.PagerContainer.append('<div class="pull-right padding-10">TotalPages : ' + opts.TotalPages + '</div>')
        }
    }
}(jQuery));