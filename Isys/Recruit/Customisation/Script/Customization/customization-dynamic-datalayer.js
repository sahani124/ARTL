/// <reference path="../../WebServices/CustomizationDynamic.asmx" />
//var path = window.location.origin + "/Application/Isys/Saim/WebServices/customization.asmx"
//var path = window.location.protocol + "//" + window.location.hostname + "/Application/Isys/Saim/WebServices/customization.asmx"

//CLoud(Publlished)
//<!--Commented and Added on 24082021-->

//var path = window.location.protocol + "//" + window.location.hostname + (window.location.port ? ':' + window.location.port : '') + "/SAIM_TALIC_PUBLISHED/Application/Isys/Saim/WebServices/customizationdynamic.asmx"
//var path = window.location.protocol + "//" + window.location.hostname + (window.location.port ? ':' + window.location.port : '') + "../../WebServices/CustomizationDynamic.asmx"
var path = window.location.protocol + "//" + window.location.hostname + (window.location.port ? ':' + window.location.port : '') + "/SAIM_TALIC_PUBLISHED/Application/Isys/Recruit/customisation/WebServices/customizationdynamic.asmx"
//var path = window.location.protocol + "//" + window.location.hostname + (window.location.port ? ':' + window.location.port : '') + "/Application/Isys/Recruit/customisation/WebServices/customizationdynamic.asmx"
//<!--Commented and Added on 24082021-->

//CLoud (not Published)
//var path = window.location.protocol + "//" + window.location.hostname + (window.location.port ? ':' + window.location.port : '') + "/SAIM_TALIC/Application/Isys/Saim/WebServices/customizationdynamic.asmx"

//Developement
//var path = window.location.protocol + "//" + window.location.hostname + (window.location.port ? ':' + window.location.port : '') + "/Application/Isys/Saim/WebServices/customizationdynamic.asmx"
function GetValueFactors(Dropdown, MAP_CODE, VAL_CODE, ACT_CODE) {
    data = {
        "MAP_CODE": MAP_CODE,
        "VAL_CODE": VAL_CODE,
        "ACT_CODE": ACT_CODE
    }
    $.ajax({
        url: "/GetValueFactors",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        success: function (resp) {
            console.log(resp.d)
            console.log(resp)
        },
        error: function () {
            console.log(resp.d)
            console.log(resp)
        }
    })
}

function BindLookup(Dropdown, LookupCode, ShowSelect) {
    data = {
        "LookupCode": LookupCode
    }
    $.ajax({
        url: path + "/GetLookupData",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        async: false,
        success: function (resp) {
            var j = JSON.parse(resp.d);
            if (j["status"] == "0") {
                BindDropdown(j["Data"], Dropdown, "ParamValue", "ParamDesc01", ShowSelect);
            }
            else {
                BindDropdown(j["status"], Dropdown, "ParamValue", "ParamDesc01", true);
            }
        },
        error: function (resp) {
            console.log(resp)
        }
    })
}

function GetFixFactorsData(KPI_CODE, ACTION_TYPE, FLAG, ACT_SCHM_KEY, TYPE, callback) {
    data = {
        "KPI_CODE": KPI_CODE,
        "ACTION_TYPE": ACTION_TYPE,
        "ACT_SCHM_KEY": ACT_SCHM_KEY,
        "FLAG": FLAG,
        "TYPE": TYPE
    }
    $.ajax({
        url: path + "/GetFixFactorsData",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        async: false,
        success: function (resp) {
            var j = JSON.parse(resp.d);
            callback(j);
        },
        error: function (resp) {
            console.log(resp)
        }
    })
}

function GetBasedFFDDL(RANGE, Dropdown, LookupCode, Type, ACT_SCH_KEY, ShowSelect) {
    data = {
        "LookupCode": LookupCode,
        "Type": Type,
        "ACT_SCH_KEY": ACT_SCH_KEY,
        "RANGE": RANGE
    }
    $.ajax({
        url: path + "/GetBasedFFDDL",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        //async: false,
        success: function (resp) {
            var j = JSON.parse(resp.d);
            if (j["status"] == "0") {
                BindDropdown(j["Data"], Dropdown, "ParamValue", "ParamDesc01", ShowSelect);
                $("#ddl" + LookupCode).multiselect('destroy').multiselect({
                    includeSelectAllOption: true,
                    onInitialized: function (obj, e) {
                        $(obj).attr("MultiSelect", $(obj).attr("multiple") ? "Y" : "N")
                        $(e.find('button')).attr("target", $(obj).attr("id"))
                    }
                })
            }
            else {
                BindDropdown(j["status"], Dropdown, "ParamValue", "ParamDesc01", true);
            }
        },
        error: function (resp) {
            console.log(resp)
        }
    })
}

function GetBasedRFDDL(Dropdown, LookupCode, Type, ACT_SCH_KEY, ShowSelect) {
    data = {
        "LookupCode": LookupCode,
        "Type": Type,
        "ACT_SCH_KEY": ACT_SCH_KEY
    }
    $.ajax({
        url: path + "/GetBasedRFDDL",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        async: false,
        success: function (resp) {
            var j = JSON.parse(resp.d);
            if (j["status"] == "0") {
                BindDropdown(j["Data"], Dropdown, "ParamValue", "ParamDesc01", ShowSelect);
                $("#ddl" + LookupCode).multiselect('destroy').multiselect({
                    includeSelectAllOption: true,
                    onInitialized: function (obj, e) {
                        $(obj).attr("MultiSelect", $(obj).attr("multiple") ? "Y" : "N")
                        $(e.find('button')).attr("target", $(obj).attr("id"))
                    }
                })
            }
            else {
                BindDropdown(j["status"], Dropdown, "ParamValue", "ParamDesc01", true);
            }
        },
        error: function (resp) {
            console.log(resp)
        }
    })
}

function GetFactorsBySchemeKey(ACT_SCH_KEY, KPI_CODE, ACTION_TYPE, callback) {
    data = {
        "ACT_SCH_KEY": ACT_SCH_KEY,
        "KPI_CODE": KPI_CODE,
        "ACTION_TYPE": ACTION_TYPE
    }
    $.ajax({
        url: path + "/GetFactorsBySchemeKey",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        async: false,
        success: function (resp) {
            var j = JSON.parse(resp.d);
            if (j["status"] == "0") {
                callback(j["Data"]);
            }
            else {
                console.log(j["Data"])
            }
        },
        error: function (resp) {
            console.log(resp)
        }
    })
}

// Main Table

function SaveRangeFactors(ACT_SCH_KEY, FIX_FACTOR, VAL_CODE, FROM_DATA, TO_DATA, CREATED_BY, KPI_CODE, ACT_TYP_ID, SelValue, optionSelIndex) {
    var factordata = Create_FF_Data(FIX_FACTOR);
    var data = {
        "ACT_SCH_KEY": ACT_SCH_KEY,
        "FIX_FACTOR": JSON.stringify(factordata),
        "VAL_CODE": VAL_CODE,
        "FROM_DATA": FROM_DATA,
        "TO_DATA": TO_DATA,
        "CREATED_BY": CREATED_BY,
        "KPI_CODE": KPI_CODE,
        "ACTION_TYPE": ACT_TYP_ID,
        "SelValue": SelValue,
        "selPosition": optionSelIndex
    }
    $.ajax({
        url: path + "/SaveRangeFactor", 
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        async: false,
        success: function (resp) {
            var j = JSON.parse(resp.d);
            if (j["status"] == "0") {
                alert('Data saved successfully');
                //GetRangeFactors(ACT_SCH_KEY, FIX_FACTOR, VAL_CODE, 'div' + VAL_CODE + 'Table', true, true, false)
            }
            else {
                alert(j["Data"]);
            }
        },
        error: function (resp) {
            console.log(resp)
        }
    })
}

function UpdateRangeFactors(RNG_FACT_ID, ACT_SCH_KEY, FIX_FACTOR, VAL_CODE, FROM_DATA, TO_DATA, UPDATED_BY, KPI_CODE, ACT_TYP_ID, SRT_ORDR, POS) {
    var factordata = Create_FF_Data(FIX_FACTOR);
    data = {
        "RNG_FACT_ID": RNG_FACT_ID,
        "KPI_CODE": KPI_CODE,
        "ACTION_TYPE": ACT_TYP_ID,
        "ACT_SCH_KEY": ACT_SCH_KEY,
        "FIX_FACTOR": JSON.stringify(factordata),
        "VAL_CODE": VAL_CODE,
        "FROM_DATA": FROM_DATA,
        "TO_DATA": TO_DATA,
        "UPDATED_BY": UPDATED_BY,
        "SRT_ORDR": SRT_ORDR,
        "POS": POS
    }
    $.ajax({
        url: path + "/UpdateRangeFactor",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        async: false,
        success: function (resp) {
            var j = JSON.parse(resp.d);
            if (j["status"] == "0") {
                alert('Data updated successfully');
                //GetRangeFactors(ACT_SCH_KEY, FIX_FACTOR, VAL_CODE, 'div' + VAL_CODE + 'Table', true, true, false)
            }
            else {
                alert(j["Data"]);
            }
        },
        error: function (resp) {
            console.log(resp)
        }
    })
}

function GetRangeFactors(ACT_SCH_KEY, FIX_FACTOR, VAL_CODE, Table_ID, ShowEdit, ShowDelete, ShowSpilt) {
    debugger;
    var factordata = Create_FF_Data(FIX_FACTOR)
    data = {
        "ACT_SCH_KEY": ACT_SCH_KEY,
        "VAL_CODE": VAL_CODE,
        "FIX_FACTOR": JSON.stringify(factordata)
    }
    $.ajax({
        url: path + "/GetRangeFactor",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        async: false,
        success: function (resp) {
            var j = JSON.parse(resp.d);
            if (j["status"] == "0") {
                BindRangeTable(j["Data"], FIX_FACTOR, Table_ID, VAL_CODE, ACT_SCH_KEY, ShowEdit, ShowDelete, ShowSpilt);
            }
            else {
                alert(j["Data"]);
            }
        },
        error: function (resp) {
            console.log(resp)
        }
    })
}

function DeleteRangeFactor(RNG_FACT_ID, VAL_CODE, FROM_DATA, TO_DATA, SRT_ORD, FIX_FACTOR, KPI_CODE, ACT_TYP_ID, ACT_SCH_KEY) {
    var factordata = Create_FF_Data(FIX_FACTOR);

    data = {
        "RNG_FACT_ID": RNG_FACT_ID,
        "ACT_SCH_KEY": ACT_SCH_KEY,
        "FIX_FACTOR": JSON.stringify(factordata),
        "VAL_CODE": VAL_CODE,
        "FROM_DATA": FROM_DATA,
        "TO_DATA": TO_DATA,
        "UPDATED_BY": "system",
        "SRT_ORDR": SRT_ORD,
        "KPI_CODE": KPI_CODE,
        "ACTION_TYPE": ACT_TYP_ID
    }
    $.ajax({
        url: path + "/DeleteRangeFactor",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        success: function (resp) {
            var j = JSON.parse(resp.d);
            if (j["status"] == "0") {
                GetRangeFactors(ACT_SCH_KEY, FIX_FACTOR, VAL_CODE, 'div' + VAL_CODE + 'Table', true, true, false)
                alert('Data Deleted Successfully.')
            }
            else {
                alert(j["Data"]);
            }
        },
        error: function (resp) {
            console.log(resp)
        }
    })
}

//Updated  BY Pratik
function GetRangeFactorsBasedOnFF(ACT_SCH_KEY, FIX_FACTOR, VAL_CODE, Table_ID, ShowEdit, ShowDelete, ShowSpilt, data) {
    var j = data;
    if (j["status"] == "0") {
        BindRangeTable(j["Data"], FIX_FACTOR, Table_ID, VAL_CODE, ACT_SCH_KEY, ShowEdit, ShowDelete, ShowSpilt);
    }
    else {
        alert(j["Data"]);
    }
}

// Main Table

// Staging Table

// Staging Table
function GetFixFactorsFromRangeFactors(ACT_SCH_KEY, VAL_CODE, DropDownID, showSelect) {
    data = {
        "ACT_SCH_KEY": ACT_SCH_KEY,
        "VAL_CODE": VAL_CODE
    }
    $.ajax({
        url: path + "/GetFixFactorFromRangeFactor",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        async: false,
        success: function (resp) {
            var j = JSON.parse(resp.d);
            if (j["status"] == "0") {
                BindDropdown(j["Data"], DropDownID, "paramval", "paramdesc", showSelect)
                $("#" + DropDownID).multiselect('destroy').multiselect({
                    includeSelectAllOption: false,
                    onInitialized: function (obj, e) {
                        $(obj).attr("MultiSelect", $(obj).attr("multiple") ? "Y" : "N")
                        $(e.find('button')).attr("target", $(obj).attr("id"))
                    }
                })
            }
            else {
                BindDropdown([], DropDownID, "paramval", "paramdesc", showSelect)
            }
        },
        error: function (resp) {
            console.log(resp)
        }
    })
}


//updated by pratik
function GetRangeFactorsDDLBasedOnFF(ACT_SCH_KEY, FIX_FACTOR, VAL_CODE, DropDownID, showSelect, data) {
    var j = data
    if (j["status"] == "0") {
        BindDropdown(j["Data"], DropDownID, "paramval", "paramdesc", showSelect)
        $("#" + DropDownID + " option").map(function (x, e) {
            $(e).data("range", j["Data"][x]["params"])
        })
        $("#" + DropDownID).multiselect('destroy').multiselect({
            includeSelectAllOption: true,
            onInitialized: function (obj, e) {
                $(obj).attr("MultiSelect", $(obj).attr("multiple") ? "Y" : "N")
                $(e.find('button')).attr("target", $(obj).attr("id"))
            }
        })
    }
    else {
        BindDropdown([], DropDownID, "paramval", "paramdesc", showSelect)
    }
    var x = document.getElementById('ddl' + VAL_CODE + 'Position')
    if (x.options[2].value == "M") return
    if (j["DataCount"] > 1) {
        var x = document.getElementById('ddl' + VAL_CODE + 'Position')
        var option = document.createElement("option");
        option.text = "Middle";
        option.value = "M";
        x.add(option, x[2]);
    }
    else {
        document.getElementById("selectNow")
        $('#ddl' + VAL_CODE + 'Position option[value="M"]').remove();
    }
}


function GetConvetedRangeFactor(ACTION_TYPE, ACT_SCH_KEY, FIX_FACTOR, KPI_CODE, TYPE, CallBack) {
    var factordata = Create_FF_Data(FIX_FACTOR)
    data = {
        "ACT_SCH_KEY": ACT_SCH_KEY,
        "KPI_CODE": KPI_CODE,
        "FIX_FACTOR": JSON.stringify(factordata),
        "ACTION_TYPE": ACTION_TYPE,
        "TYPE": TYPE
    }
    $.ajax({
        url: path + "/GetConvetedRangeFactor",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        success: function (resp) {
            var j = JSON.parse(resp.d);
            CallBack(j)
        },
        error: function (resp) {
            console.log(resp)
        }
    })
}

function GetConvetedRangeFactorByValCode(ACTION_TYPE, ACT_SCH_KEY, FIX_FACTOR, KPI_CODE, TYPE, VAL_CODE, Selected_Range, CallBack) {
    debugger;
    var factordata = Create_FF_Data(FIX_FACTOR)
    data = {
        "ACT_SCH_KEY": ACT_SCH_KEY,
        "KPI_CODE": KPI_CODE,
        "FIX_FACTOR": JSON.stringify(factordata),
        "SELECTED_RANGE": JSON.stringify(Selected_Range),
        "VAL_CODE": VAL_CODE,
        "ACTION_TYPE": ACTION_TYPE,
        "TYPE": TYPE
    }
    $.ajax({
        url: path + "/GetConvetedRangeFactorByValCode",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        success: function (resp) {
            var j = JSON.parse(resp.d);
            CallBack(j)
        },
        error: function (resp) {
            console.log(resp)
        }
    })
}

function GetConvRangeFactorsDDLBasedOnFF(MODE, ACT_SCH_KEY, FIX_FACTOR, VAL_CODE, DropDownID, showSelect) {
    var factordata = {}
    var araay = []
    var colums = Object.keys(FIX_FACTOR)
    for (var i = 0; i < colums.length; i++) {
        colname = colums[i].toString();
        factordata[colname] = FIX_FACTOR[colname].split(',').map(function (x) { return { "value": x } })
    }
    data = {
        "ACT_SCH_KEY": ACT_SCH_KEY,
        "VAL_CODE": VAL_CODE,
        "FIX_FACTOR": JSON.stringify(factordata),
        "MODE": MODE
    }
    $.ajax({
        url: path + "/GetConvRangeFactorBasedOnFF",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        success: function (resp) {
            var j = JSON.parse(resp.d);
            if (j["status"] == "0") {
                BindDropdown(j["Data"], DropDownID, "paramval", "paramdesc", showSelect)
                $("#" + DropDownID).multiselect('destroy').multiselect({
                    includeSelectAllOption: true,
                    onInitialized: function (obj, e) {
                        $(obj).attr("MultiSelect", $(obj).attr("multiple") ? "Y" : "N")
                        $(e.find('button')).attr("target", $(obj).attr("id"))
                    }
                })
            }
            else {
                BindDropdown([], DropDownID, "paramval", "paramdesc", showSelect)
            }
        },
        error: function (resp) {
            console.log(resp)
        }
    })
}

function SaveMPL(ACT_SCH_KEY, FIX_FACTOR, RANGE_FACTOR, RATE, MPL_FLAG, CREATED_BY) {
    data = {
        "ACT_SCH_KEY": ACT_SCH_KEY,
        "FIX_FACTOR": FIX_FACTOR,
        "RANGE_FACTOR": RANGE_FACTOR,
        "RATE": RATE,
        "MPL_FLAG": MPL_FLAG,
        "CREATED_BY": CREATED_BY
    }

    $.ajax({
        url: path + "/SaveMPL",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        success: function (resp) {
            var j = JSON.parse(resp.d);
            if (j["status"] == "0") {
                alert('Data saved successfully');
            }
            else {
                alert(j["Data"]);
            }
        },
        error: function (resp) {
            console.log(resp)
        }
    })
}

function GetPendingData(tblID, FIX_FACTOR, ACT_SCH_KEY, RANGE) {
    var factordata = Create_FF_Data(FIX_FACTOR)
    data = {
        "FIX_FACTOR": JSON.stringify(factordata),
        "ACT_SCH_KEY": ACT_SCH_KEY,
        "RANGE": RANGE
    }
    $.ajax({
        url: path + "/GetPendingData",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        async: false,
        success: function (resp) {
            var j = JSON.parse(resp.d);
            if (j["status"] == "0") {
                BindPendingTable(j["Data"], tblID)
            }
            else {
                alert(j["Data"]);
            }
        },
        error: function (resp) {
            console.log(resp)
        }
    })
}

function GetUpdatedData(tblID, ACT_SCHM_KEY, RANGE) {
    data = {
        "ACT_SCHM_KEY": ACT_SCHM_KEY,
        "RANGE": RANGE
    }

    $.ajax({
        url: path + "/GetUpdatedData",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        async: false,
        success: function (resp) {
            var j = JSON.parse(resp.d);
            if (j["status"] == "0") {
                BindUpdatedTable(j["Data"], tblID)
            }
            else {
                alert(j["Data"]);
            }
        },
        error: function (resp) {
            console.log(resp)
        }
    })
}

function SaveConvRangeFactors(selectRangeFactor, ACT_SCH_KEY, KPI_CODE, ACT_TYP_ID, CREATED_BY, IsConsider, TYPE, callback) {
    data = {
        "ACT_SCH_KEY": ACT_SCH_KEY,
        "COVT_RANGE_FACTOR": JSON.stringify(selectRangeFactor),
        "CREATED_BY": CREATED_BY,
        "KPI_CODE": KPI_CODE,
        "ACTION_TYPE": ACT_TYP_ID,
        "IS_CONSIDER": IsConsider,
        "TYPE": TYPE
    }

    $.ajax({
        url: path + "/SaveConvRangeFactor",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        async: false,
        success: function (resp) {
            var j = JSON.parse(resp.d);
            if (j["status"] == "0") {
                alert('Data saved successfully');
            }
            else {
                alert(j["Data"]);
            }
            callback();
        },
        error: function (resp) {
            console.log(resp)
        }
    })
}


function SaveWORangeFactors(FIX_FACTOR, ACT_SCH_KEY, KPI_CODE, ACT_TYP_ID, CREATED_BY, IsConsider, TYPE,callback) {
    var factordata = Create_FF_Data(FIX_FACTOR)
    data = {
        "ACT_SCH_KEY": ACT_SCH_KEY,
        "FIX_FACTOR": JSON.stringify(factordata),
        "CREATED_BY": CREATED_BY,
        "IS_CONSIDER": IsConsider,
        "KPI_CODE": KPI_CODE,
        "ACTION_TYPE": ACT_TYP_ID,
        "TYPE": TYPE
    }

    $.ajax({
        url: path + "/SaveWORangeFactor",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        async: false,
        success: function (resp) {
            var j = JSON.parse(resp.d);
            if (j["status"] == "0") {
                alert('Data saved successfully');
            }
            else {
                alert(j["Data"]);
            }
            callback()
        },
        error: function (resp) {
            console.log(resp)
        }
    })
}

function GetHtmlTemplates(KPI_CODE, ACT_NO, ACT_TYP_ID, ACT_SCHM_KEY, callback) {
    data = {
        "ACT_SCHM_KEY": ACT_SCHM_KEY,
        "KPI_CODE": KPI_CODE,
        "ACT_NO": ACT_NO,
        "ACT_TYP_ID": ACT_TYP_ID
    }

    $.ajax({
        url: path + "/GetHtmlTemplates",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        async: false,
        success: function (resp) {
            var j = JSON.parse(resp.d);
            if (j["status"] == "0") {
                callback(j["Data"]);
            }
            else {
                alert(j["Data"]);
            }
        },
        error: function (resp) {
            console.log(resp)
        }
    })
}



//Added BY Pratik

function Create_FF_Data(FIX_FACTOR) {
    var colums = Object.keys(FIX_FACTOR)
    var factordata = {}
    factordata["Data"] = []
    for (var i = 0; i < colums.length; i++) {
        colname = colums[i].toString();
        var d = FIX_FACTOR[colname].split(',').map(function (x) { return { "ID": (i + 1), "VAL_CODE": colname, "val": x } });

        for (j = 0; j < d.length; j++) {
            factordata["Data"].push(d[j])
        }
    }

    return factordata;
}

//--------------------------- MPL_SU_DYNAMIC_PAGE ------------------------------------------- //

function GetRangeFactorsBasedOnFixedFactors(ACT_SCH_KEY, FIX_FACTOR, VAL_CODE, callback) {
    var factordata = Create_FF_Data(FIX_FACTOR)
    data = {
        "ACT_SCH_KEY": ACT_SCH_KEY,
        "VAL_CODE": VAL_CODE,
        "FIX_FACTOR": JSON.stringify(factordata)
    }
    $.ajax({
        url: path + "/GetRangeFactorBasedOnFF",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        async: false,
        success: function (resp) {
            var j = JSON.parse(resp.d);
            callback(j);
        },
        error: function (resp) {
            console.log(resp)
        }
    })
}

function GetPendingAndUpdatedDataWithRange(KPI_CODE, ACT_TYP_ID, ACT_SCH_KEY, callback) {
    data = {
        "ACT_SCH_KEY": ACT_SCH_KEY,
        "ACTION_TYPE": ACT_TYP_ID,
        "KPI_CODE": KPI_CODE
    }
    $.ajax({
        url: path + "/GetPendingAndUpdatedDataWithRange",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        async: false,
        success: function (resp) {
            callback(JSON.parse(resp.d));
        },
        error: function (resp) {
            console.log(resp)
        }
    })
}

function GetPendingAndUpdatedDataWithoutRange(KPI_CODE, ACT_TYP_ID, ACT_SCH_KEY, callback) {
    data = {
        "ACT_SCH_KEY": ACT_SCH_KEY,
        "ACTION_TYPE": ACT_TYP_ID,
        "KPI_CODE": KPI_CODE
    }
    $.ajax({
        url: path + "/GetPendingAndUpdatedDataWithoutRange",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        async: false,
        success: function (resp) {
            callback(JSON.parse(resp.d));
        },
        error: function (resp) {
            console.log(resp)
        }
    })
}

//--------------------------- MPL_SU_VIEW_DYNAMIC_PAGE ------------------------------------------- //