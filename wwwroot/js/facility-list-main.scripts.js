jq(function() {
    jq('.tabs').tabs();

    jq("#facilitychecks-list .switch").find("input[type=checkbox]").on("change",function() {
        var names = "#FacilityChecks_" + jq(this).data("idnt") + "__Value";

        if (jq(this).prop('checked')){
            jq(names).val(1);
        }
        else{
            jq(names).val(0);
        }
    });

    jq(".collection").on("click", ".email-unread", function() {
        var action = jq(this).data('facility');
        if (action != '@Model.Selected.Code'){
            window.location.href = action;
        }
    });

    jq('td.now input[type=number]').change(function(){
        var item = jq(this).closest('tr').find('.aft');

        var vals = parseInt(jq(this).val());
        var open = parseInt(jq(this).closest('tr').find('.bfo').text());
        var diff = open - vals;

        if (diff <= 0) {
            diff = 0;
            item.removeClass('red-text');
        }
        else {
            item.addClass('red-text');
        }

        item.text(diff);
    });

    jq('.chart-circle').percentcircle({
        animate : true,
        diameter : 100,
        guage: 10,
        coverBg: '#fff',
        bgColor: '#efefef',
        fillColor: '#D870A9',
        percentSize: '18px',
        percentWeight: 'normal'
    });
});