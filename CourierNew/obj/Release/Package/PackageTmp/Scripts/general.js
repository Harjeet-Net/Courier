var App = function () {

    var config = {//Basic Config
        tooltip: true,
        popover: true,
        nanoScroller: true,
        nestableLists: true,
        hiddenElements: true,
        bootstrapSwitch: true,
        dateTime: true,
        select2: true,
        tags: true,
        slider: true
    };

    var voice_methods = [];





    /*Form Masks*/
    var masks = function () {
        $("[data-mask='date']").mask("99/99/9999");
        $("[data-mask='phone']").mask("(999) 999-9999");
        $("[data-mask='phone-ext']").mask("(999) 999-9999? x99999");
        $("[data-mask='phone-int']").mask("9999 999 999");
        $("[data-mask='taxid']").mask("99-9999999");
        $("[data-mask='ssn']").mask("999-99-9999");
        $("[data-mask='product-key']").mask("****-****-****-****");
        $("[data-mask='percent']").mask("99%");
        $("[data-mask='currency']").mask("$999,999,999.99");
        $("[data-mask='time-int']").mask("99:99 aa");
        $("[data-mask='box-range']").mask("999-999");
    };//End of masks


    return {

        init: function (options) {
            //Extends basic config with options
            $.extend(config, options);

        },

        /*Pages Javascript Methods*/

        masks: function () {
            masks();
        },



    };

}();

$(function () {
    //$("body").animate({opacity:1,'margin-left':0},500);
    $("body").css({ opacity: 1, 'margin-left': 0 });
});

