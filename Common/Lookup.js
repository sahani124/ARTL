function lookupState(id, obj, lang)
{
    if (id == "")
    {
        document.getElementById(obj).value = "";
    }
    else
    {
        Common.Client.Lookup.LookupState(id, lang, 
        SuccessfulCallBack, FailedCallback, obj);
    }
}

function lookupCountry(id, obj, lang)
{
    if (id == "")
    {
        document.getElementById(obj).value = "";
    }
    else
    {
        Common.Client.Lookup.LookupCountry(id, lang,
        SuccessfulCallBack, FailedCallback, obj);
    }
}

function lookupNational(id, obj, lang)
{
    if (id == "")
    {
        document.getElementById(obj).value = "";
    }
    else
    {        
        if (id.toUpperCase() == "OTH")
        {
            document.getElementById(obj).value = "";
            document.getElementById(obj).disabled = false;  
        }
        else
        {
            Common.Client.Lookup.LookupNational(id, lang, 
            SuccessfulCallBack, FailedCallback, obj);           
            document.getElementById(obj).disabled = true;  
        }
    }
}

function lookupResCntry(id, obj, lang)
{
    if (id == "")
    {
        document.getElementById(obj).value = "";
    }
    else
    {
        Common.Client.Lookup.LookupResCntry(id, lang, 
        SuccessfulCallBack, FailedCallback, obj);
    }
}

function lookupQual(id, obj, lang)
{
    if (id == "")
    {
        document.getElementById(obj).value = "";
    }
    else
    {
        Common.Client.Lookup.LookupQual(id, lang, 
        SuccessfulCallBack, FailedCallback, obj);
    }
}

function lookupOccupation(id, obj, lang)
{
    if (id == "")
    {
        document.getElementById(obj).value = "";
    }
    else
    {
        Common.Client.Lookup.LookupOccupation(id, lang, 
        SuccessfulCallBack, FailedCallback, obj);
    }
}

//function CltRefresh(id, obj, lang)
//{
//    if (id == "")
//    {
//        document.getElementById(obj).value = "";
//    }
//    else
//    {
//        Common.Client.Lookup.CltRefresh(id, lang, 
//        SuccessfulCallBack, FailedCallback, obj);
//    }
//}

function SuccessfulCallBack(result, obj)
{
    document.getElementById(obj).value = result;
}

function FailedCallback(error)
{
    alert(error.get_message());
}


if (typeof(Sys) !== "undefined") Sys.Application.notifyScriptLoaded();