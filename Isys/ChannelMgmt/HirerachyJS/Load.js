function OpenElement(Id, CODE_ID, FRAME_ID, flag) {
    debugger;
    var Selectchannel;

    Selectchannel = document.getElementById(CODE_ID).value
    var url = "HirerachyJS/HTMLPage_new_html.html?time=33&Flag=" + flag + "&CODE=" + Selectchannel;
    var iframe = document.getElementById(FRAME_ID).src = url;

    id = '#' + Id;
    $(id).modal();
}