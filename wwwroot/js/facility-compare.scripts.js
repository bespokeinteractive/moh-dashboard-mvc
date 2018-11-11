    /*================================================================================
    Item Name: Materialize - Material Design Admin Template
    Version: 1.0
    Author: DENNIS HENRY
    Author URL: https://themeforest.net/user/daugmaud/portfolio
    ================================================================================*/

jq(function() {
    String.prototype.toAccounting = function() {
        var str =  parseFloat(this).toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');

        if (str.charAt(0) == '-'){
            return '(' + str.substring(1,40) + ')';
        }
        else {
            return str;
        }
    };

    jq('#facility1.autocomplete').autocomplete({
        data: facility_data,
        limit: 10,
        onAutocomplete: function(val) {
            GetCompareFacilities(val);
        },
        minLength: 1
    });

    jq('#facility2.autocomplete').autocomplete({
        data: "{}",
        limit: 10,
        minLength: 1
    });

    function GetCompareFacilities(code){
        jq.ajax({
            dataType: "json",
            url: '/Home/GetCompareFacilities',
            data: {
                "ifac": true,
                "code": code
            },
            beforeSend: function() {
                jq('body').removeClass('loaded');
            },
            success: function(result) {
                jq('#facility2.autocomplete').autocomplete({
                    data: result.facilities,
                    limit: 10,
                    onAutocomplete: function(val) {
                        GetSecondFacility(val);
                    },
                    minLength: 1
                });

                jq('#facility2.autocomplete').val('');
                jq('#detail-box-2').hide();

                PopulateElements(result, $('#detail-box-1'));
            },
            error: function(xhr, ajaxOptions, thrownError) {
                console.log(xhr.status);
                console.log(thrownError);
            },
            complete: function() {
                $('body').addClass('loaded');
            }
        });
    }

    function GetSecondFacility(code) {
        jq.ajax({
            dataType: "json",
            url: '/Home/GetCompareFacilities',
            data: {
                "ifac": false,
                "code": code
            },
            beforeSend: function() {
                jq('body').removeClass('loaded');
            },
            success: function(result) {
                PopulateElements(result, $('#detail-box-2'));
            },
            error: function(xhr, ajaxOptions, thrownError) {
                console.log(xhr.status);
                console.log(thrownError);
            },
            complete: function() {
                $('body').addClass('loaded');
            }
        });
    }

    function PopulateElements(data, el){
        el.empty();

        var html = "<table><thead><tr><th>" + data.facility.name + " <span class='new badge red accent-2 right' data-badge-caption='LEVEL " + data.facility.category.level.id + "'> </span></th></tr></thead><tbody>";
        html += "<tr><td>" + data.facility.county.name + " COUNTY, " + data.facility.subCounty.name + " CONSTITUENCY</td><tr>";
        html += "<tr><td>&mdash; Facility CheckList <span class='task-cat cyan right'> " + data.scoreChecklist.toString().toAccounting() + " % </span></td><tr>";
        html += "<tr><td>&mdash; Human Resources <span class='task-cat cyan right'> " + data.scoreHumanResources.toString().toAccounting() + " % </span></td><tr>";
        html += "<tr><td>&mdash; Human Resources <span class='task-cat cyan right'> " + data.scoreInfrastructure.toString().toAccounting() + " % </span></td><tr>";
        html += "<tr><td class='bold-text' style='padding-top:2px;'>Facility Overall Score <span class='task-cat deep-orange accent-2 right'> " + data.scoreOverall.toString().toAccounting() + " % </span></td><tr>";
        html += "<tr><td>&nbsp; County Rank <span class='bold-text right'> " + data.rank1 + " &nbsp; </span></td><tr>";
        html += "<tr><td>&nbsp; National Rank <span class='bold-text right'> " + data.rank1 + " &nbsp; </span></td><tr>";
        html += "</tbody></table>";

        el.html(html);
        el.show();
    }
});