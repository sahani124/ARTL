//Page Load 

$(document).ready(function () {
    $('.decimal').on('keypress', function (e) {
        return CheckDecimalValue(e, this);
    })

    $(".datetime").datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd/mm/yy'
    });
})

function GetQueryStringValue(url, param) {
    param = param.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regVal = new RegExp("[\\?&]" + param + "=([^&#]*)"),
    results = regVal.exec(url);
    return results === null ? null : decodeURIComponent((results[1]).replace(/\+/g, " "));
}

function BindDropdown(Data, ControlID, ParamVal, ParamDesc, ShowSelect, SelectText, SelectedValue) {
    var ddl = document.getElementById(ControlID);
    var selText = SelectText || "-- SELECT --";
    var selVal = SelectedValue || "-1";
    ddl.setAttribute("ShowSelect", ShowSelect ? "Y" : "N");
    ddl.setAttribute("SelectVal", selVal);
    var option;
    $(ddl).empty();
    if (ShowSelect) {
        option = document.createElement("OPTION");
        option.innerHTML = selText;
        option.value = selVal;
        ddl.options.add(option);
    }
    for (var i = 0; i < Data.length; i++) {
        option = document.createElement("OPTION");
        option.innerHTML = Data[i][ParamDesc];
        option.value = Data[i][ParamVal];
        ddl.options.add(option);
    }
}

function isDecimal(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function CheckDecimalValue(e, object) {
    var val = $(object).val();
    var charCode = (e.which) ? e.which : e.keyCode;
    if (isDecimal(e)) {
        if (val == "") {
            return !(charCode == 48 || charCode == 46)
        }
        if (val.indexOf('.') != -1) {
            if (charCode == 46)
                return false;
            return !(val.substr(val.indexOf('.') + 1).length >= 2);
        }
        return true;
    }
    else {
        return false
    }
}

function ClearDropdown(ControlID) {
    var ddl = document.getElementById(ControlID);
    $(ddl).empty();
}

function BindRangeTable(Data, FIX_FACTOR, ControlID, VAL_CODE, ACT_SCH_KEY, ShowEdit, ShowDelete, ShowSpilt) {
    var html = ''
    html += '<table class="footable">'
    html += '<thead class="footable">'
    html += '<tr class="gridview th">'
    html += '<th>KEY</th>'
    html += '<th>Sort Order</th>'
    html += '<th>ACT_SCHM_CODE</th>'
    html += '<th>From Data</th>'
    html += '<th>To Data</th>'
    if (ShowEdit)
        html += '<th></th>'

    if (ShowDelete)
        html += '<th></th>'

    if (ShowSpilt)
        html += '<th></th>'

    html += '</tr>'
    html += '</thead>'
    html += '<tbody>'
    document.getElementById('hdnMIN' + VAL_CODE).value = "";
    document.getElementById('hdnMAX' + VAL_CODE).value = "";
    if (Data.length != 0) {

        for (var i = 0; i < Data.length; i++) {
            html += '<tr>'
            //html += '<td>' + (i + 1) + '</td>';
            html += '<td>' + Data[i]["RNG_FACT_ID"] + '</td>';
            html += '<td>' + Data[i]["SRT_ORD"] + '</td>';
            html += '<td>' + Data[i]["ACT_SCHM_CODE"] + '</td>';
            html += '<td>' + Data[i]["FROM_DATA"] + '</td>';
            html += '<td>' + Data[i]["TO_DATA"] + '</td>';
            ShowEdit = true;
            ShowDelete = true;

            ////EDIT START
            if (ShowEdit) {
                if (i == 0) {
                    document.getElementById('hdnFirst' + VAL_CODE).value = Data[i]["TO_DATA"];
                    if (ShowEdit) {
                        if (Data.length > 1) {
                            var EditFunction = "EditRow('" + Data[i]["RNG_FACT_ID"] + "','" + VAL_CODE + "', '" + Data[i]["FROM_DATA"] + "','" + Data[i]["TO_DATA"] + "','" + Data[i]["SRT_ORD"] + "', ' ','" + Data[i + 1]["TO_DATA"] + "','FIRST')";
                            html += '<td><a href="javascript:void(0)" onclick="' + EditFunction + '">Edit</a></td>';
                        }
                        else {
                            var EditFunction = "EditRow('" + Data[i]["RNG_FACT_ID"] + "','" + VAL_CODE + "', '" + Data[i]["FROM_DATA"] + "','" + Data[i]["TO_DATA"] + "','" + Data[i]["SRT_ORD"] + "', '','','FIRST')";
                            html += '<td><a href="javascript:void(0)" onclick="' + EditFunction + '">Edit</a></td>';
                        }
                    }
                }
                if (i != 0 && i != Data.length - 1) {
                    if (ShowEdit) {
                        var EditFunction = "EditRow('" + Data[i]["RNG_FACT_ID"] + "','" + VAL_CODE + "', '" + Data[i]["FROM_DATA"] + "','" + Data[i]["TO_DATA"] + "','" + Data[i]["SRT_ORD"] + "', '" + Data[i - 1]["FROM_DATA"] + "','" + Data[i + 1]["TO_DATA"] + "','MIDDLE')";
                        html += '<td><a href="javascript:void(0)" onclick="' + EditFunction + '">Edit</a></td>';
                    }
                }
                if (Data.length > 1) {
                    if (i == Data.length - 1) {
                        if (ShowEdit) {

                            var EditFunction = "EditRow('" + Data[i]["RNG_FACT_ID"] + "','" + VAL_CODE + "', '" + Data[i]["FROM_DATA"] + "','" + Data[i]["TO_DATA"] + "','" + Data[i]["SRT_ORD"] + "', '" + Data[i - 1]["FROM_DATA"] + "',' ','LAST')";
                            html += '<td><a href="javascript:void(0)" onclick="' + EditFunction + '">Edit</a></td>';

                        }
                        else {
                            var EditFunction = "EditRow('" + Data[i]["RNG_FACT_ID"] + "','" + VAL_CODE + "', '" + Data[i]["FROM_DATA"] + "','" + Data[i]["TO_DATA"] + "','" + Data[i]["SRT_ORD"] + "', '" + Data[i - 1]["FROM_DATA"] + "',' ','LAST')";
                            html += '<td><a href="javascript:void(0)" onclick="' + EditFunction + '">Edit</a></td>';
                        }
                    }
                }
            }
            else {
                html += '<td></td>';
            }
            ////EDIT END

            ////DELETE START

            var ACT_TYP_ID = GetQueryStringValue(window.location, 'ACT_TYPE');
            var KPI_CODE = GetQueryStringValue(window.location, 'kpicode');
            if (ShowDelete) {
                var DeleteFunction = "DeleteRow('" + Data[i]["RNG_FACT_ID"] + "','" + VAL_CODE + "', '" + Data[i]["FROM_DATA"] + "','" + Data[i]["TO_DATA"] + "','"
                    + Data[i]["SRT_ORD"] + "','" + btoa(JSON.stringify(FIX_FACTOR)) + "','" + KPI_CODE + "','" + ACT_TYP_ID + "','" + ACT_SCH_KEY + "')";
                html += '<td><a href="javascript:void(0)" onclick="' + DeleteFunction + '">Delete</a></td>';
            }
            else {
                html += '<td></td>';
            }

            ////DELETE END

            if (ShowSpilt) {
                var SplitFunction = "";
                html += '<td><a href="javascript:void(0)" onclick="' + SplitFunction + '">Spilt Values</a></td>';
            }

            html += '</tr>'
        }
    }
    else {
        html += '<tr><td colspan="' + (5 + (ShowEdit + ShowDelete + ShowSpilt)) + '">No Record Found!!</td></tr>'
        //html += '<tr><td>No Record Found!!</td></tr>'
    }
    html += '</tbody>'
    html += '</table>'

    //added for pagination
    if (Data.length > 5) {
        html += '<div class="pagination-container" style="text-align:center;">'
        html += '<nav>'
        html += '<ul class="pagination" id="' + ControlID + '">'
        html += '<li data-page="prev" >'
        html += '<span> < <span class="sr-only">(current)</span></span>'
        html += '</li>'
        html += '<li data-page="next" id="prev">'
        html += '<span> > <span class="sr-only">(current)</span></span>'
        html += '</li>'
        html += '</ul>'
        html += '</nav>'
        html += '</div>'
    }
    //added for pagination

    document.getElementById(ControlID).innerHTML = html;
    getPagination("#" + ControlID, "#" + ControlID);
}

function BindPendingTable(Data, ControlID) {
    var validColumns = [];
    var html = ''
    html += ''
    html += '<table class="footable" id="tblPenData">'
    html += '<thead class="footable">'
    if (Data.length != 0) {
        var columns = Object.keys(Data[0])
        var Col_Count = columns.length;
        html += '<tr class="gridview th">'
        for (var i = 0; i < columns.length; i++) {
            validColumns.push(columns[i]);
            html += '<th>' + columns[i] + '</th>'
        }

        html += '</tr>'
        html += '</thead>'
        html += '<tbody>'

        document.getElementById('divDataPen').style.display = "block";
        for (var i = 0; i < Data.length; i++) {
            html += '<tr>'
            for (var j = 0; j < validColumns.length; j++) {
                var val = Data[i][validColumns[j]];
                html += '<td>' + val + '</td>';
            }
            html += '</tr>'
        }
        html += '</tbody>'
        html += '</table>'

        html += '<div class="pagination-container" style="text-align:center;">'
        html += '<nav>'
        html += '<ul class="pagination" id="tblPenData-pager">'
        html += '<li data-page="prev" >'
        html += '<span> < <span class="sr-only">(current)</span></span>'
        html += '</li>'
        html += '<li data-page="next" id="prev">'
        html += '<span> > <span class="sr-only">(current)</span></span>'
        html += '</li>'
        html += '</ul>'
        html += '</nav>'
        html += '</div>'

        document.getElementById('btnPenDwnld').style.display = "block";
    }
    else {
        html += '</thead>'
        html += '<tbody>'
        html += '<tr><td>No Record Found!!</td></tr>'
        html += '</tbody>'
        html += '</table>'
    }

    document.getElementById(ControlID).innerHTML = html;
    getPagination("#tblPenData", "#tblPenData-pager");
}

function BindUpdatedTable(Data, ControlID) {
    var validColumns = [];
    var html = ''
    html += ''
    html += '<table class="footable" id="tblUPDData">'
    html += '<thead class="footable">'
    if (Data.length != 0) {
        var columns = Object.keys(Data[0])
        var Col_Count = columns.length;

        html += '<tr class="gridview th">'
        for (var i = 0; i < columns.length; i++) {
            validColumns.push(columns[i]);
            html += '<th>' + columns[i] + '</th>'
        }

        html += '</tr>'
        html += '</thead>'
        html += '<tbody>'
        document.getElementById('divDataUPD').style.display = "block";
        for (var i = 0; i < Data.length; i++) {
            html += '<tr>'
            for (var j = 0; j < validColumns.length; j++) {
                var val = Data[i][validColumns[j]] === null ? 0 : Data[i][validColumns[j]];
                html += '<td>' + val + '</td>';
            }
            html += '</tr>'
        }
        html += '</tbody>'
        html += '</table>'

        html += '<div class="pagination-container" style="text-align:center;">'
        html += '<nav>'
        html += '<ul class="pagination" id="tblUPDData-pager">'
        html += '<li data-page="prev" >'
        html += '<span> < <span class="sr-only">(current)</span></span>'
        html += '</li>'
        html += '<li data-page="next" id="prev">'
        html += '<span> > <span class="sr-only">(current)</span></span>'
        html += '</li>'
        html += '</ul>'
        html += '</nav>'
        html += '</div>'

        document.getElementById('btnUpdatedDwnld').style.display = "block";
    }
    else {
        html += '</thead>'
        html += '<tbody>'
        html += '<tr><td>No Record Found!!</td></tr>'
        html += '</tbody>'
        html += '</table>'
    }

    document.getElementById(ControlID).innerHTML = html;
    getPagination("#tblUPDData", "#tblUPDData-pager");

}

function EditRow(RNG_FACT_ID, VAL_CODE, FROM_DATA, TO_DATA, SRT_ORD, MIN, MAX, Position) {
    document.getElementById('hdn' + VAL_CODE).value = RNG_FACT_ID;
    document.getElementById('hdnSRT_ORD' + VAL_CODE).value = SRT_ORD;

    document.getElementById('txt' + VAL_CODE + 'From').value = FROM_DATA;
    document.getElementById('txt' + VAL_CODE + 'To').value = TO_DATA;
    document.getElementById('div' + VAL_CODE + 'Update').style.display = "block";
    document.getElementById('div' + VAL_CODE + 'Add').style.display = "none";

    document.getElementById('ddl' + VAL_CODE + 'Position').disabled = true;
    $('#ddl' + VAL_CODE + 'Parent').multiselect("disable");
    document.getElementById('hdnMIN' + VAL_CODE).value = MIN;
    document.getElementById('hdnMAX' + VAL_CODE).value = MAX;
    if (Position == "FIRST" || Position == "LAST")
        document.getElementById('hdnPosition' + VAL_CODE).value = Position;
    else
        document.getElementById('hdnPosition' + VAL_CODE).value = "MIDDLE";
}

function DeleteRow(RNG_FACT_ID, VAL_CODE, FROM_DATA, TO_DATA, SRT_ORD, FIX_FACTOR, KPI_CODE, ACT_TYP_ID, ACT_SCH_KEY) {
    if (confirm('Are you sure to delete this entry?')) {
        CancelEdit(VAL_CODE)
        DeleteRangeFactor(RNG_FACT_ID, VAL_CODE, FROM_DATA, TO_DATA, SRT_ORD, JSON.parse(atob(FIX_FACTOR)), KPI_CODE, ACT_TYP_ID, ACT_SCH_KEY)
        document.getElementById("btnFixConfirmSelection").click();
    }
}

function CancelEdit(VAL_CODE) {
    document.getElementById('hdn' + VAL_CODE).value = "";
    document.getElementById('txt' + VAL_CODE + 'From').value = "";
    document.getElementById('txt' + VAL_CODE + 'To').value = "";
    document.getElementById('div' + VAL_CODE + 'Update').style.display = "none";
    document.getElementById('div' + VAL_CODE + 'Add').style.display = "block";

    document.getElementById('ddl' + VAL_CODE + 'Position').disabled = false;
    $('#ddl' + VAL_CODE + 'Parent').multiselect("enable");
    $('#ddl' + VAL_CODE + 'Parent').multiselect('refresh');
}

function ClearData(VAL_CODE) {
    document.getElementById('txt' + VAL_CODE + 'From').value = "";
    document.getElementById('txt' + VAL_CODE + 'To').value = "";
    document.getElementById('ddl' + VAL_CODE + 'Position').value = "-1";
    document.getElementById('ddl' + VAL_CODE + 'Parent').value = "-1";
    $('#ddl' + VAL_CODE + 'Parent').multiselect('refresh');
}

function ValidateRangeFactor(VAL_CODE) {
    var from = document.getElementById('txt' + VAL_CODE + 'From');
    var to = document.getElementById('txt' + VAL_CODE + 'To');
    if (from.value.trim() == "") {
        alert('Please Enter From Data')
        from.focus()
        return false;
    }

    if (to.value.trim() == "") {
        alert('Please Enter To Data')
        to.focus()
        return false;
    }

    if (parseFloat(from.value.trim()) > parseFloat(to.value.trim())) {
        alert('from value cannot be greater than to value')
        to.focus()
        return false;
    }

    return true;
}

function ValidateFixFactor(FIX_FACTORS) {
    var factors = fix_factors.split('|');
    var isValid = true;
    for (var i = 0; i < factors.length; i++) {
        var ddl = $('#ddl' + factors[i])
        if ($(ddl).val() == ddl.attr("SelectVal")) {
            alert('Please select all fix factors');
            ddl.focus();
            isValid = false;
            break;
        }
    }
    return isValid;
}

function EnableFixFactors(enabled) {
    var factors = fix_factors.split('|');
    if (enabled) {
        for (var i = 0; i < factors.length; i++) {
            $("button[target='ddlFIX" + factors[i] + "']").attr("disabled", "disabled")
        }
    }
    else {
        for (var i = 0; i < factors.length; i++) {
            $("button[target='ddlFIX" + factors[i] + "']").removeAttr("disabled");
        }
    }
}

function GetValuesFixFactors(FIX_FACTOR) {
    var factors = FIX_FACTOR.split('|');
    var data = {};
    for (var i = 0; i < factors.length; i++) {
        var val = $("#ddlFIX" + factors[i]).val();

        if (typeof (val) === 'string') {
            data[factors[i]] = val;
        }
        else {
            data[factors[i]] = val.join(',');
        }
    }
    return data;
}

function GetCONVRangeFactors(RANGE_FACTOR) {
    var factors = RANGE_FACTOR.split('|');
    var data = {};
    for (var i = 0; i < factors.length; i++) {
        var val = $("#ddlFix" + factors[i]).val();

        if (typeof (val) === 'string') {
            data[factors[i]] = val;
        }
        else {
            data[factors[i]] = val.join(',');
        }
    }
    return data;
}

function GetValuesRangeFactors(RANGE_FACTOR) {
    var factors = RANGE_FACTOR.split('|');
    var data = {};
    for (var i = 0; i < factors.length; i++) {
        var val = $("#ddlFix" + factors[i]).val();

        if (typeof (val) === 'string') {
            data[factors[i]] = val;
        }
        else {
            data[factors[i]] = val.join(',');
        }
        //data[factors[i]] = $("#ddlFix" + factors[i]).val();
    }
    return data;
}

function ResetFixFactorDropDownValues(FIX_FACTOR, Values) {
    var data = JSON.parse(Values);
    var factors = FIX_FACTOR.split('|');
    for (var i = 0; i < factors.length; i++) {
        $("#ddl" + factors[i]).val(data[factors[i]]);
        $("#ddl" + factors[i]).multiselect("refresh");
    }
}



function getSelectedLen(id) {
    var selArr = [];
    var sel = document.getElementById(id);
    var listLength = sel.options.length;
    var valLength = 0;
    for (var i = 0; i < listLength; i++) {
        if (sel.options[i].selected) {
            valLength = valLength + 1;
            selArr.push(i);
        }
    }
    return selArr;
}

function getSelectedValue(id) {
    var selVal = " ";
    var sel = document.getElementById(id);
    var listLength = sel.options.length;
    for (var i = 0; i < listLength; i++) {
        if (sel.options[i].selected) {
            if (selVal == " ") {
                selVal = sel.options[i].value;
            }
            else {
                selVal += ',' + sel.options[i].value;
            }
        }
    }
    return selVal;
}

function getSelectedText(id) {
    var selVal = " ";
    var sel = document.getElementById(id);
    var listLength = sel.options.length;
    for (var i = 0; i < listLength; i++) {
        if (sel.options[i].selected) {
            if (selVal == " ") {
                selVal = sel.options[i].text;
            }
            else {
                selVal += ',' + sel.options[i].text;
            }
        }
    }
    return selVal;
}

function getSelectedRange(id) {
    var selVal = [];
    var range = ""
    var sel = document.getElementById(id);
    var listLength = sel.options.length;
    for (var i = 0; i < listLength; i++) {
        if (sel.options[i].selected) {
            $(sel.options[i]).data("range").split('-').map(function (x) {
                selVal.push(x)
            });
        }
    }
    selVal = selVal.sort();
    return selVal[0] + '-' + selVal[selVal.length - 1] ;
}

function getConvSelectedValue(RANGE_FACTOR) {
    var factors = RANGE_FACTOR.split('|');
    var data = {};
    for (var i = 0; i < factors.length; i++) {
        var val = $("#ddlFix" + factors[i]).val();
        if (typeof (val) === 'string') {
            selVal = val;
        }
        else {
            selVal = val.join('|');
        }
    }
    return selVal;
}

function GetAllFixFactors(FIX_FACTOR) {
    var factors = FIX_FACTOR.split('|');
    var data = {};
    for (var i = 0; i < factors.length; i++) {
        var optVal = " ";
        var val = $("#ddl" + factors[i] + " option").length;
        for (var j = 0; j < val; j++) {
            if (optVal == " ") {
                optVal = $("#ddl" + factors[i] + " option")[j].value
            }
            else {
                optVal += ',' + $("#ddl" + factors[i] + " option")[j].value;
            }
        }
        data[factors[i]] = optVal;
    }
    return data;
}


function getPagination(table, pager) {
    var lastPage = 1; 
    lastPage = 1;
    $(pager).find("li").slice(1, -1).remove();
    var trnum = 0; 
    var maxRows = 5;

    var totalRows = $(table + " tbody tr").length; // numbers of rows
    $(table + " tr:gt(0)").each(function () {
        // each TR in  table and not the header
        trnum++; // Start Counter
        if (trnum > maxRows) {
            // if tr number gt maxRows

            $(this).hide(); // fade it out
        }
        if (trnum <= maxRows) {
            $(this).show();
        } // else fade in Important in case if it ..
    }); //  was fade out to fade it in
    if (totalRows >= maxRows) {
        // if tr total rows gt max rows option
        var pagenum = Math.ceil(totalRows / maxRows); // ceil total(rows/maxrows) to get ..
        //	numbers of pages
        for (var i = 1; i <= pagenum;) {
            // for each page append pagination li
            $(pager + " #prev")
              .before(
                '<li data-page="' +
                  i +
                  '">\
								  <span>' +
                  i++ +
                  '<span class="sr-only">(current)</span></span>\
								</li>'
              )
              .show();
        } // end for i
    } // end if row count > max rows
    $(pager + ' [data-page="1"]').addClass("active"); // add active class to the first li
    $(pager + " li").on("click", function (evt) {
        // on click each page
        evt.stopImmediatePropagation();
        evt.preventDefault();
        var pageNum = $(this).attr("data-page"); // get it's number

        var maxRows = 5; // get Max Rows from select option

        if (pageNum == "prev") {
            if (lastPage == 1) {
                return;
            }
            pageNum = --lastPage;
        }
        if (pageNum == "next") {
            if (lastPage == $(pager + " li").length - 2) {
                return;
            }
            pageNum = ++lastPage;
        }

        lastPage = pageNum;
        var trIndex = 0; // reset tr counter
        $(pager + " li").removeClass("active"); // remove active class from all li
        $(pager + ' [data-page="' + lastPage + '"]').addClass("active"); // add active class to the clicked
        // $(this).addClass('active');					// add active class to the clicked
        limitPagging(pager);
        $(table + " tr:gt(0)").each(function () {
            // each tr in table not the header
            trIndex++; // tr index counter
            // if tr index gt maxRows*pageNum or lt maxRows*pageNum-maxRows fade if out
            if (
              trIndex > maxRows * pageNum ||
              trIndex <= maxRows * pageNum - maxRows
            ) {
                $(this).hide();
            } else {
                $(this).show();
            } //else fade in
        }); // end of for each tr in table
    }); // end of on click pagination list
    limitPagging(pager);

    // Added BY Pratik For hidding data pagination if data is less than max rows allowed
    if (totalRows <= maxRows) {
        if (pager.indexOf("-pager") != -1) {
            $(pager).hide();
        }
        else {
            $(pager).find(".pagination-container").hide();    
        }
        
    }
}

function limitPagging(pager) {
    if ($(pager + " li").length > 7) {
        if ($(pager + " li.active").attr("data-page") <= 3) {
            $(pager + " li:gt(5)").hide();
            $(pager + " li:lt(5)").show();
            $(pager + ' [data-page="next"]').show();
        }
        if ($(pager + " li.active").attr("data-page") > 3) {
            $(pager + " li:gt(0)").hide();
            $(pager + ' [data-page="next"]').show();
            for (
              i = parseInt($(pager + " li.active").attr("data-page")) - 2;
              i <= parseInt($(pager + " li.active").attr("data-page")) + 2;
              i++
            ) {
                $(pager + ' [data-page="' + i + '"]').show();
            }
        }
    }
}

$(function () {
    $("table tr:eq(0)").prepend("<th> ID </th>");

    var id = 0;

    $("table tr:gt(0)").each(function () {
        id++;
        $(this).prepend("<td>" + id + "</td>");
    });
});

//----------------------------------------------- Factor Validation --------------------------------------------------//

//Added BY Pratik

function ValidateFixFactors(FIX_FACTOR, VAL_CODE_DTLS, ACTION_TYPE) {
    var isValid = true;
    for (i = 0; i < FIX_FACTOR.length; i++) {
        var data = getSelectedLen("ddlFIX" + FIX_FACTOR[i])
        if (data.length == 0) {
            var val = VAL_CODE_DTLS.filter(x => x.VAL_CODE == FIX_FACTOR[i] && x.IS_SCOPE == ACTION_TYPE)
            alert("Please select " + val[0]['VAL_DESC']);
            isValid = false;
            break;
        }
    }
    return isValid;
}

function ValidateRangeFactors_ddl(RANGE_FACTOR, VAL_CODE_DTLS, ACTION_TYPE) {
    var isValid = true;
    for (i = 0; i < RANGE_FACTOR.length; i++) {
        var data = getSelectedLen("ddlConvFIX" + RANGE_FACTOR[i])
        if (data.length == 0) {
            var val = VAL_CODE_DTLS.filter(x => x.VAL_CODE == RANGE_FACTOR[i] && x.IS_SCOPE == ACTION_TYPE)
            alert("Please select " + val[0]['VAL_DESC']);
            isValid = false;
            break;
        }
    }
    return isValid;
}

function ValidateRangeFactors(RANGE_FACTOR, VAL_CODE_DTLS, ACTION_TYPE, DROPDONW_DATA) {
    debugger;
    var isValid = true;
    for (i = 0; i < RANGE_FACTOR.length; i++) {
        var data = DROPDONW_DATA[RANGE_FACTOR[i]]
        if(data){
            if (data.length == 0) {
                var val = VAL_CODE_DTLS.filter(x => x.VAL_CODE == RANGE_FACTOR[i] && x.IS_SCOPE == ACTION_TYPE)
                alert("Please select " + val[0]['VAL_DESC']);
                isValid = false;
                break;
            }
        }
        else{
            alert("Please select all converted range factors");
            isValid = false;
            break;
        }
    }
    return isValid;
}


function validateMiddleRange(Id, DATATYPE, fromTxt, toTxt, VAL_DESC) {
    var selArr = getSelectedLen(Id)
    if (selArr.length == 2) {
        var sum = selArr.reduce(function (a, b) {
            return b - a;
        }, 0);
        if (sum == -1 || sum == 1) {
            if (fromTxt != "" && toTxt != "") {
                return true;
                //var data = getSelectedRange(Id).split('-');
                //var min = data[0];
                //var max = data[1];
                //if (DATATYPE.toLowerCase() == "date" || DATATYPE.toLowerCase() == "datetime") {
                    
                //    if (Date.parse(fromTxt.trim()) >= Date.parse(toTxt.trim())) {
                //        alert('From value cannot be greater than To value')
                //        return false;
                //    }
                //    if (Date.parse(fromTxt) <= Date.parse(min.trim())) {
                //        alert('From value cannot be less than equal to ' + min);
                //        return false;
                //    }
                //    if (Date.parse(toTxt) >= Date.parse(max.trim())) {
                //        alert('To value cannot be greater than equal to ' + max);
                //        return false;
                //    }
                //    return true;
                //}
                //else {
                //    if (parseFloat(fromTxt.trim()) >= parseFloat(toTxt.trim())) {
                //        alert('From value cannot be greater than To value')
                //        return false;
                //    }
                //    if (parseFloat(fromTxt) <= parseFloat(min.trim())) {
                //        alert('From value cannot be less than equal to ' + min);
                //        return false;
                //    }
                //    if (parseFloat(toTxt) >= parseFloat(max.trim())) {
                //        alert('To value cannot be greater than equal to ' + max);
                //        return false;
                //    }
                //    return true;
                //}
            }
            else {
                alert("Please enter From and To data of " + VAL_DESC + "!")
                return false;
            }
        }
        else {
            alert("Only continuous ranges in " + VAL_DESC + " are allowed!")
            return false;
        }
    }
    else {
        alert("Only 2 ranges of " + VAL_DESC + " select position are acceptable!")
        return false;
    }
}

function validateFirstRange(Id, DATATYPE, fromTxt, toTxt, MAX, VAL_DESC) {
    if (fromTxt != "" && toTxt != "") {
        if (DATATYPE.toLowerCase() == "date" || DATATYPE.toLowerCase() == "datetime") {
            if (Date.parse(fromTxt.trim()) >= Date.parse(toTxt.trim())) {
                alert('From value cannot be greater than equal To value')
                return false;
            }
            if (Date.parse(fromTxt) >= Date.parse(MAX.trim())) {
                alert('From value cannot be greater than ' + MAX);
                return false;
            }
            if (Date.parse(toTxt) >= Date.parse(MAX.trim())) {
                alert('To value cannot be greater than equal to' + MAX);
                return false;
            }
            if (Date.parse(fromTxt.trim()) == Date.parse(toTxt.trim())) {
                alert('From and To value cannot be same.')
                return false;
            }
            return true;
        }
        else {
            if (parseFloat(fromTxt.trim()) >= parseFloat(toTxt.trim())) {
                alert('From value cannot be greater than equal To value')
                return false;
            }
            if (parseFloat(fromTxt) >= parseFloat(MAX.trim())) {
                alert('From value cannot be greater than ' + MAX);
                return false;
            }
            if (parseFloat(toTxt) >= parseFloat(MAX.trim())) {
                alert('To value cannot be greater than equal to' + MAX);
                return false;
            }
            if (parseFloat(fromTxt.trim()) == parseFloat(toTxt.trim())) {
                alert('From and To value cannot be same.')
                return false;
            }
            return true;
        }
    }
    else {
        alert("Please enter From and To data of " + VAL_DESC + "!")
        return false;
    }
}

function validateEdit(fromTxt, toTxt, MIN, MAX, POS, DATATYPE) {
    var from_value = "";
    var to_value = "";
    var min_value = "";
    var max_value = "";
    if (DATATYPE.toLowerCase() == "date" || DATATYPE.toLowerCase() == "datetime") {
        from_value = moment(fromTxt, "DD/MM/YYYY").toDate();
        to_value = moment(toTxt, "DD/MM/YYYY").toDate();
        min_value = moment(MIN, "DD/MM/YYYY").toDate();
        max_value = moment(MAX, "DD/MM/YYYY").toDate();
    } else {
        from_value = parseInt(fromTxt);
        to_value = parseInt(toTxt);
        min_value = parseInt(MIN);
        max_value = parseInt(MAX);
    }

    if (from_value >= to_value) {
        alert('From value should be less than To Value');
        return false;
    }

    //if (from_value <= to_value) {
    //    alert('To value should be less than From Value');
    //    return false;
    //}
    return true;

    //if (POS == "FIRST") {
    //    if (parseFloat(fromTxt.trim()) >= parseFloat(MAX.trim())) {
    //        alert('From value cannot be greater than equal to ' + MAX)
    //        return false;
    //    }
    //    if (parseFloat(fromTxt.trim()) > parseFloat(toTxt.trim())) {
    //        alert('From value cannot be greater than To Value')
    //        return false;
    //    }

    //    if (parseFloat(toTxt.trim()) == parseFloat(fromTxt.trim())) {
    //        alert('From and To value cannot be equal')
    //        return false;
    //    }
    //    if (parseFloat(toTxt.trim()) >= parseFloat(MAX.trim())) {
    //        alert('To value cannot be greater than equal to ' + MAX)
    //        return false;
    //    }
    //    return true;
    //}
    //if (POS == "LAST") {
    //    if (parseFloat(fromTxt.trim()) <= parseFloat(MIN.trim())) {
    //        alert('From value cannot be lesser than equal to ' + MIN)
    //        return false;
    //    }
    //    if (parseFloat(fromTxt.trim()) > parseFloat(toTxt.trim())) {
    //        alert('From value cannot be greater than To Value')
    //        return false;
    //    }

    //    if (parseFloat(toTxt.trim()) == parseFloat(fromTxt.trim())) {
    //        alert('From and To value cannot be equal')
    //        return false;
    //    }
    //    if (parseFloat(toTxt.trim()) <= parseFloat(MIN.trim())) {
    //        alert('To value cannot be lesser than equal to ' + MIN)
    //        return false;
    //    }
    //    return true;
    //}
    //else {
    //    if (parseFloat(fromTxt.trim()) <= parseFloat(MIN.trim())) {
    //        alert('From value cannot be lesser than equal to ' + MIN)
    //        return false;
    //    }
    //    if (parseFloat(fromTxt.trim()) >= parseFloat(MAX.trim())) {
    //        alert('From value cannot be greater than equal to ' + MAX)
    //        return false;
    //    }

    //    if (parseFloat(toTxt.trim()) > parseFloat(MAX.trim())) {
    //        alert('To value cannot be greater than ' + MAX)
    //        return false;
    //    }
    //    if (parseFloat(toTxt.trim()) <= parseFloat(MIN.trim())) {
    //        alert('To value cannot be lesser than' + MIN)
    //        return false;
    //    }

    //    if (parseFloat(fromTxt.trim()) > parseFloat(toTxt.trim())) {
    //        alert('From value cannot be greater than To Value')
    //        return false;
    //    }

    //    if (parseFloat(toTxt.trim()) == parseFloat(fromTxt.trim())) {
    //        alert('From and To value cannot be equal')
    //        return false;
    //    }
    //    return true;
    //}
}

function ShowReqDtl1(divName, btnName) {
    try {
        var objnewdiv = document.getElementById(divName)
        var objnewbtn = document.getElementById(btnName);
        if (objnewdiv.style.display == "block") {
            objnewdiv.style.display = "none";
        }
        else {
            objnewdiv.style.display = "block";
        }
    }
    catch (err) {
    }
}


