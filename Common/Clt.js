function lookupBank(id, obj, lang)
{
    if (id == "")
    {
        document.getElementById(obj).value = "";
    }
    else
    {
        Common.Client.Clt.LookupBank(id, lang, 
        SuccessfulCallBack, FailedCallback, obj);
    }
}

function lookupBranch(id, obj, obj2, lang)
{
    if (id == "")
    {
        document.getElementById(obj).value = "";
        document.getElementById(obj2).value = "";
    }
    else
    {
        Common.Client.Clt.LookupBranch(id, lang, 
        SuccessfulCallBack, FailedCallback, obj);
//        Common.Client.Clt.LookupBranch2(id, lang, 
//        SuccessfulCallBack, FailedCallback, obj2);
    }
}

function lookupLocation(id, obj, lang)
{
    if (id == "")
    {
        document.getElementById(obj).value = "";
    }
    else
    {
        Common.Client.Clt.LookupLocation(id, lang, 
        SuccessfulCallBack, FailedCallback, obj);
    }
}

function lookupProduct(id, obj)
{
    if (id == "")
    {
        document.getElementById(obj).value = "";
    }
    else
    {
        Common.Client.Clt.LookupProduct(id,
        SuccessfulCallBack, FailedCallback, obj);
    }
}

function lookupAgent(id, obj)
{
    if (id == "")
    {
        document.getElementById(obj).value = "";
    }
    else
    {
        Common.Client.Clt.LookupAgent(id,
        SuccessfulCallBack, FailedCallback, obj);
    }
}

function lookupClient(id, obj)
{
    if (id == "")
    {
        document.getElementById(obj).value = "";
    }
    else
    {
        Common.Client.Clt.LookupClient(id,
        SuccessfulCallBack, FailedCallback, obj);
    }
}

function SuccessfulCallBack(result, obj)
{
    document.getElementById(obj).value = result;
}

function FailedCallback(error)
{
    alert(error.get_message());
}

if (typeof(Sys) !== "undefined") Sys.Application.notifyScriptLoaded();