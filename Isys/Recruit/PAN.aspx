<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="PAN.aspx.cs" Inherits="Application_Isys_Recruit_PAN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="../../../assets/scripts/jquery.min.js"></script>
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="IE=11"/>
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
     <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />

     <script type="text/javascript"  lang="js"> 
         //added by sanoj 31082023
          function Conpopup(id) {
            debugger;
              if (id == "btnYes") {
                //document.getElementById('ctl00_ContentPlaceHolder1_iLoading').style.display = 'block';
                document.getElementById('ctl00_ContentPlaceHolder1_lnkPrcdWthCon').click();
                Hidepopup();  
            }
            else if(id=="btnProceed")
            {
                document.getElementById('ctl00_ContentPlaceHolder1_lmkbtnProceed').click();
				Hidepopup();
            }
            else
            {
                var AppNo=document.getElementById('ctl00_ContentPlaceHolder1_hdnCndCode').value;
                document.getElementById('ctl00_ContentPlaceHolder1_lblPANMsg').innerHTML = "Duplicate match found for <br/>ApplicationNo :- "+AppNo ;
				Hidepopup();
            }
        }
          function popup() {
             debugger;
            $("#myModal").show();
        }
        function Hidepopup() {
			debugger;
			$("#myModal").hide();
         }
           //Endded by sanoj 31082023
         $(document).ready(function () {
             debugger;
            
             var yourByteArrayAsBase64 = "89504E470D0A1A0A0000000D49484452000000870000002A08060000009965483A0000000467414D410000B18F0BFC61050000187049444154785EADDC79B47FD5FCC7F16FA9546892424A1A0CA994A1490369D442CB90D5246914511A89065142930C2129194B14A5A2412834105132451A69448686B57F1EDB7A7DEC76E7DC7BBFFDFAE3BDF639FB4CFBECF773BFDEEFBDCFE7DE59AF7DED6BCB820B2E581EFBD8C796051658A0CC3BEFBCE5094F7842996FBEF9EA766BEAD8FCF3CFFFB07A75B19CD79EFFB8C73DEE61C752CFDAFAD43DFEF18FAF96FBB6967386EA5D93E3BD8D1DF3CEACAD736EEAF54D5FAF8ED956D75A8EB7C752A7BF99FDD666722CF74CDD74E69A85165A68B08E2DBCF0C2B54EC9165D74D15AFFD4A73EB5CCDA76DB6DCB9BDEF4A672D04107950F7CE003E53DEF794F39E49043CAC1071F5CDEFFFEF797C30E3BACDAE1871F5E8F1F71C411E5831FFC60F9D0873E54EDC31FFE7039F2C823CB51471D558E3EFAE86AC71C734C39F6D863CB473EF2916AC71D775CF9E8473F5A3EF6B18F954F7CE213D58E3FFEF8F2C94F7EB27CEA539FAAF6E94F7FBA9C70C209E5339FF94C39F1C413CB673FFBD96A279D745239E59453CAE73FFFF96A5FF8C217CA17BFF8C5F2A52F7DA97CF9CB5F2E5FF9CA57AA9D7AEAA9E5B4D34E2B5FFDEA57AB7DED6B5F2B679C714639F3CC33AB7DE31BDF28DFFCE637CB59679D55CB6C9F7DF6D9E55BDFFA5639E79C73AA9D77DE79D5BEFDED6F97EF7CE73BE5FCF3CF2F175C7041B58B2EBAA8DA77BFFBDD72F1C51797EF7DEF7BE5FBDFFF7EB54B2EB9A4DAA5975E5A7EF8C31F961FFDE847E5C73FFE71B5CB2EBBAC5C7EF9E5E58A2BAE28575E7965B59FFCE427E5E73FFF79B5ABAFBEBAFCE217BF28BFFCE52FAB5D73CD35D5AEBDF6DAF2AB5FFDAA5C77DD75E5D7BFFE75B5DFFCE637E577BFFB5DF9FDEF7F5FAEBFFEFA6A7FFCE31FABDD70C30DD5FEF4A73F55BBF1C61BCB4D37DD546EBEF9E672CB2DB7945B6FBDB5DC76DB6DD5FEFCE73F97BFFCE52FE5F6DB6FAFF6B7BFFDADDC7DF7DDE5CE3BEF2C0F3CF040F9D9CF7E5666BDEE75AF2BBBEFBE7B7534280E3CF0C0F2BEF7BDAF8230060703C55460048E1E0C40B0C0102002023BF9E493CBE73EF7B90914CA1E1070B0168CC071FAE9A75738BEFEF5AF574002490B08285A30CE3DF7DC6A8068A1B8F0C20BA784E2073FF8C1048A1E0C503050040C50B09FFEF4A713BBEAAAABAA3358606941E92101C86F7FFBDB0A490BCA1FFEF08709242D1C2C6080A205E38E3BEEA85080C7B66340714D85638F3DF6A84AF1AE77BDAB820112D6C2018C168E56390249001982837DFCE31F9F5231623D2860984A315AD568C118832360B0168C2846AF1A00612D1C01041CB15E397A487AF5080C4340F450B4604C07058B6244357AC5606060D402207FFDEB5F2B1877DD75D77FE178CD6B5E5395E3BDEF7D6F39F4D043ABE36D538A471A5686C0E895A305830925092781220AD22BC9182CBD82F490B4803C92B01215E9210145AF1840080C518B5E217AB5105A125E02066B430AC5E8A1E8C1E8C349E00814510C500041DD3FFFF9CF7A9EBA7BEFBDF77FCAF1F6B7BFBD0220A4BCFBDDEFAEF907000011EB55A3852260082953859556397A40DA5CA30F2F812120B43024C718538C40D1020186369CB4408081452D02036BC168C34BAB1CAD7AB0A19C23B0F4CAD1E61D438A018C589F770065AAB0321652C0E0D83DF7DC5301F9F7BFFF5DEBB4A12AC75BDEF296EAFC563D84975E315AD568C3490B07287AB54802DA83C1DA90D227A281A3CD35A8056B2169C3CB18287D5869D5A20D29C93986F28E3EA4048640106BF38C58A0489ED1AA47AB1A4C48896A0490168EA1B0C2C6D483C939C6E010521CA722EAEEBFFFFE7A4D8563CF3DF7AC6030500827D3C1018AA17012A5000A38EC279CD857820408EA29876D7000020C518EA8460B4654041801A20D290927AD7280A24F46FB44347080C13E38124EA805208614031C4A50082BF60388FD2130125E80A05E091410B896C35B387AE500C558BED1432154B4C968C0E8438B6DEAC1E41DEE53E178C73BDE31518DA9E000C6181C43E184F395F6A322C048780914144419950046140408F6E51B99A1B4790620A803280012B58862048E36ACF470B461A50D2F142321052463700823B6D5732E18A849C0008452680101655047BA03066000D0E71BD3C1D1E71C43F9C6101C6068E1504A48A78503140009182D1CC0081C7DBE310407A5A024B641601F14000184FD24A4F659A00004608417D0048C24A2E00085522801044028072080D14F61C7720E404439C04039EC0B27B6A70B2B8CF381D226A214848141F850E618F5082440082C600818812360F4B946C0188303180929C0E8434AC2CA9470B4AAD1C3D1AB865CA3078381C23E1838DD7560113A1C63000142C20930A21220E0F8A80738124658F20D60500C4024AC8024204431ECF7704CA51A20701D081CA31C14C1B542440B46AB1A39A6B49F90925042156C832230C4E954C33E35B14F3540D48211D548AE11301E6948E955031C4A5000E4EF7FFF7BBD4F8563AFBDF67A181C6C7655238A2184A8B7CDE181850A289D0F0EA0804029CC0044B9D5565B9545165964B224DE2E2333C72CEF3EF399CF2C5B6EB965BD061CA0E15CD0802770B4AA010E600CA90638381CB02BAEB8E264C97B892596A8EB3E6370D83EE080036A7B5C6379FA452F7A517D5FC7C1C1841CCA0010EDDD61871DCAFAEBAF5F165F7CF1F2C4273EB10E46B000620C8E56359284060E0E1D520D708CA90628A8C5201CBEAD80031881432303C7906A8083F35BD500071876DA69A7326BD6AC6ABEBBCC39E79C65AEB9E62AABAFBE7A9D2ABBA7677080670410E1843A70F076DB6D57AF730FD7E67EAD393ECF3CF3D4E3BE0D801C88420A18A803C5981DD59067D8D7B6673CE31993B67B8E81008A80C1385E38A114FA1014DAE6FCE5965BAEAA1C154808010868010D22E7F9A695F7316000E15C50040C16305866278F46AE413586E0709F87284754031C7D48896AB4D35765AB1A6CD75D772D8F79CC6326CEF5214DA9937584728E39E6A81DE33CD0B8C642DC5BDFFAD6F2B6B7BDADBCEC652F9B9CE75AA5FB2953977AF750BAF76AABAD564315B5907F2841613BCA21647957A0CAB3B41D28720D61C43658975C72C9873CCB792D1C510D7008217BEFBD77FD60E55C6DA522C2A250C2D900F1DCE73CE73993F67AC79CCFE4652D1843AA3153385AD518CB370011E50049E0B0083681A3CD39660A07B3ADD3009259C9FEFBEF5F9D4B2E37DC70C36AABACB24A858423D3194A9D34F7DC733FC4F1B6759AFAD439D7B5EAC9F5269B6C5236D86083B2D4524BD5F372AEF37C02C84C858A040A8AA0CE4746A1C2F9AE5B679D75AA6A00C339D443787BDAD39E56EF1748BDE75439C73BDFF9CEAA6069C7B39FFDEC0A8710C28456E1292030A1E4C52F7E7179F5AB5F5D438C76520E79C7A30DC754EA010E060C904C564887940314437080A13530000328661FEA5EF18A579435D75CB39A17A70CCF7BDEF36A8889439891B5ECB2CB56A7DBD759710655716E60B2EDB8FA95575EB93A74ADB5D62A4F79CA5326C722CFCF7FFEF3278A219CD8164E00230C2EBDF4D213B5717EE0105AA807E520EFC28A73D21EFD31A418CC36E5009DB6789F160ED36EEFEA5E9E2DA4183480F35CB39B4C61337399291CC0188303186370F43907A31C81E32161A5CD3740D182D1E71B09274C78F19224D1E77EBF0788C374BE8432DB7134F3BB08BF1F586FBDF5CA3EFBEC33F9D867F99E32E8E05CD34292BA40063A60D8A64EB657586185EA8C659659A6AA0038E4331B6FBC71BD9764D3A8D52E70500D606445546872BDE738C733F4C7D01A07038877F73E69EF4A2BAD54E19067BCF4A52FADED72DC3BC8F33C5308314B0100289494C076C0081C01A39DA5040E60300EEDE1E8C1180B2B54031CB62770B40969420A288654236000826AD8CEEC0428E0A2084648EBDCC060C428D3813ADE6813D6249359AF78E31BDF3801C17DCC4ECC4836DF7CF33A8A5D97D2B3F21C4ECC35B61D739FA88A6B1C6B215B7BEDB52B3CD483E3A900153483D0C68C76EF4C315AD5C84A2840001EE7BBEFB39EF5ACC994DBCCCA3DD4AFBAEAAA55C580C1A80475114E80E09E012660F4B3948001A48031A41A2D1863F906A500461251E53FFEF18FFFC14112DB6414142D182D1C3AA99DA5989A02C439661CA9333A7586244D673BC731DB8E9B91080B3A7FF9E597AFC7248220D9669B6D1EE2409DAE3D59CF904B88E18C7C3B2790C8439EF4A42755A35AEA0261EEC700E39A288E3AF018ED0606C8D56B07C77AFFA17C83090B720ECF704FF70687A9AC4F13B98FF6001CE8F20CB31BF706CFCB5FFEF2DA2F548363401103C7D0F435700083CD24116DE1C84C65080EF7AA5F655B38A218BD6AF47008254A0EA2229C9F15504A22094D879069F2EEB869A219836BB6DF7EFBEA14CA000E9DC939C089F338D6F1ADB7DEBA7E2DA632FBEEBB6FD971C71D2B188EEB60CF0206C0B200E63E721E4E038124532E44C13CD7B52933B259F223661F9C9E6FE024ECA67F62FAD173728DB679CF4D37DDB4DECFF3030D550A98CA3C5BA83363A3282D188123B946C09849AE31144E7A388413F6303866A21C7D480105E7DAE654DB14013060B10D0E2F0D0E230534510D0E94F4EDBCF3CEB5337590E7E84CB98145307571562C1D9F4EE554759EB1C61A6BD4F6B749284838D2B93ADE28B6CEA1A4129C264105E91BDEF08689733951DB9D93670E996331FB69976D70C8C3C098764641EC3B97D90E8C9E29ECEA533947C000045000020650A8CB3E20D471680FC87421A5CD37E41ACAFCB6639290068C563DA682C30B3040808345EA2987598397374AF38D0510428FEB77D96597BA50A433CDFD5D4735C06194B670643B9D9A91960E05C75AFF99BD68B3EC5F4C0701A5726FA1CD081692CC469C63DAE97E6654F20DDF53BC37A34E429EE32CB0A43DBD39274E4F496D0C10AAE71CF50172DD75D7ADEB2CFAF5CD6F7E736D8B77749DF2B9CF7D6ECD65020450940C2C729140C1E1CEB33F0447AB1E8F080ECA11387AD96CE100C6181CC20A072BD5BDE0052F98384F4E41D29FFEF4A757334D5C6CB1C56A6788BB4244FB814D386801701E28B2CF382C2391E978EAA1AD54837A5045D79171C06635D4AA29E7B9DE6C25ABA53EAE99026785D47D394B1910A6326D08C8AEF1ECECC7BC0B58E534E0B1D8A60FA816C8BD17F5A0B6510730D8163AC021A4A807853AFB9CDDE61D01630C0E60F47008278370048A168EA9540300AD6A808203A210D623D2A93AC44B1B356D275115892BA87C400B2064DEF19CCB91D661385CA8B06EE079C212E83821E79371CED77E1D6F545A81CD62180024949EAD4DCEA71C924AE058D1D406F7D57E66F4EB17B39458D638326BB1DA6A1AAF0DFD7B02DDB3DC2BA12AD024FF89A5DE7912F3AC7724B4701A2783248E37E3115640F1485543BE010EE5BFFEF5AF7A9F87C1D1AA06305AD500C6101C510D7030D41B153A44C748C2248BCC88249B3ADCC8D579EA74AE6F11125770C4313ACAB99E6B9A9BE9A1910E28B98291E639CEA7127E2C6DFDC4BED025AC69939C47DB416894BAC692BB63CE018FB50E705B23492EA00DDE2FEB1AFD22987DA1C8E88F9329833ED50FF63D0BC4FAC080D027F212EFEE3818B4C9F36CEB17FDA78F0290F6A8D73F203758C0020425156955031863AA018C19C1618EEE4540D1C331A61A518C1E8E2888B0E285BC18353163C90736C775E6669B6D5647B64E3095936F705C3EBCC53146A43699CAEA101099CE82C40CA6FE01CE7FCE33EA74F0AB5EF5AA9A6B70887AE65EF6337275B4F3E304757E852FF7A01C9CE8BADCC37BB6AA91350E46757C36101EF23C00E82BB325CF50F7E4273FB92EF459C7B01A6A6DC3D4D8BB5B74D3066DD1AE4CC5B5336DD076C7D376F5428935107000624835D874AAC184137987DF91BA479DAD8023502881D1C2D1E71A7D38091C46A611C824A45ED6A83612258700718EC41304EE6511CA4BEA0C4E69BFCABA5EA798697836384021AC80847248EC747AE4188CAF7CE52B27CBE4714CA060EAB4CB76F202A58F7F9CA51DAE77DC75AED70FEDDA0648001248A8AF67E719D4D160F00D28F7A00242A12FB5420148949EE9B3434005C5165B6C516755260B7E00EEFEFBEDB75F5DE5757FF7532611ED55632CA40CE51AC000C56CC3D187150E658050671B189C1F48989CC30B7851CA41BA75BAF398D10F168B41CE633A13004245468B5202E7D994220B61924E90F88940720EA57385152BBE54C5B236CB97D8FCBA3E21433B1D939083D6F239759338BB67DAE13D03469B6B00439EE2835FBBCE216C009D731316F4851C4702EC771BD443A91F843FED07ADF384D7CC529414425E01500933739D95D2C0911033BB2105102D1CF7DD77DF7FC3CA181C92D1E9662A8C12443D3857A3850D1FDB748897E550EA010E0E3023E100F77FC94B5E523B4368F0B28E5B3E37CA38C6A8368A9D1BE55002CE74583EA2F3A304A6A0E091B80228BFE7B09D6F277ECFE17CCE30ADF49D4338F1ED84F3BD879C238E669EDFAA460B87D2A86E730E614D98F45C3333EF923C8B2A4882CD420C1AA1475BBC2B20E5413EF14B42393F53D5CC4C40C2D40D2D803DAA7058710C1CAC85031843CA9184940A80C1399C6B04DA4E58D119EEE9DA00061439870F6C9CA44336DA68A30A0F4501473A99B90FB9CDBE8E8EB5F520B16E2071CDF4141C1C210C316A631D84C35C63244B449D67B6E23AEF030E0E8BD384D08011389273500ECBE754CBBBB8AF9C03C494413EE21EDA4BB1F20ECA00655F5F0941FA8BD303060B14EA02468001C6101C0123700C8514261165E05082A38615CBBEE00814CA803155CE2174D856CA3194C0208F9C994EE23C2F6D3B1D9DE39CA9CEB4119CC206E5F0DB06D7254F50266E3B3F1D9BD23D258354005C16C0280787FB1EE2BE2070AFB60D4C1B92E0F9A111D9960FF9ED45DAE919DEAF0523AA211965D497A3DDDFF9BE0C0B2B3EAA590E974769637B4FCF547A5726B7A2869C9CF50DC92618C0112509188F866A6496322338A21A01634C35841123CC88D2711444ECE6684E4B27E9883882E9104631C4759FB3E504C29191C6B208E6DA1606FBE950F7720FE1E8852F7C614DF4280615A018E43CDBEAFDF8284E5172867B642483CF770DA1071CDAE65981527F8CC1A1EC7FEC030E2A4539FC598252AEE3C74A1268CFCFFD3D0BD806883C8452E4133D3040000E25105A38FEBFAA91590A284C616DFBA326F7A9708897518C1E8E21D588510C39876D390050CCC1DDF3F5AF7F7DFDADA45298F0BDC4BEA5718B3B4688699D6B38C32853CA4728D08E3BEE587FB50514F7740D45B1AF5E9D6C1E9099E5500C2144D800851011487C3BB218B6DB6EBB55F37C7FE9C72886990AC0E51F7212CE36B5F50CA18A0A8122068EA806A358FAD10F8D41E079F218B983296B14C4BDF59BA4D9F91267CF05A5C41304CE8F4A28A98832610414B180C1C65423700CA946720D360A47A05002A38503182D1C510BDBE0C81456490180E28599E4CE312593974818E51D4088014348718CA38D3AA590A02E6B1BA6AF3A18004C9D10D2FE889823038A521D5838409DA4D43E10D459505267E55452CAA9F20B21C6341308B65B3002877C4309020A41458CFEA8855F9B83C2A7F8AC6FA40483A96C60487E61F5936A0005200C14C93902C6584801C6584801C67470F8FF1C158E2C828D8595A1901238125A5A4080113800001625284CCF1810801220C021B30740A0500A3160008812242C6030604834010190CC4C1888180561124E70008281838123B315398A122831A1A4872321051C0C1CB1FC290238AC6928C1D1021238F2239F1E0C16C5004412D28499E9E068434A0F471B52C0919CA3558E9A73B4708C85953EA4040E163880615AC6A21AA030656581230A12307A385A305A38A220F2076A1138320B091C510F8A1138A804305A3828450B460BC7D88F7A6602072828050B1CD4A30783628083050E60040E60CC048E84942138125286E000C66CC31130D85848091CC0188303188103182D1C7284563558C0E8552370443586E00046E0886A048E4C6903C6181CC0081CC018832321051C0143080186BC227000630C0E60040E60B470F4AA113802463B4B091C1C39060730D8584869E1B032FA1038B2CED1C3315548493869C168434AC010527AD500460F47AF1A7D48E9C1489E91E9EA986A249CB470F460B4700C81C1324B69C1886A008301A387A307A38523E16428A4F4604435324B09188F564801040307F598E41C81A34F44D9986A0CC14131DA5C23700CA9066B55031CB3AB1A6DAE311D1CBD6A0CE51A53A9C674704435322399896AF4704CA51A2D1CAD6A806326AA018EA954237058DF00C8048E76B63204C7906A0829A088F570802216305814A3578DC031A41A0C14B11E0E50C4C0010C16C5E85523700CA9060345AC85434801450C1C518D36096D55838DA9068B620CA9062862E0886A800314B180C1C65423704CA51A1423703CF8E08315B4091CC2092086420A30C6E048486913D18031145286E0982A118D62048CC09144B4052370B4B9C6542105187D4869C1081C49445B3002479B884E155280D1C221DF68C11883031881238968C0783412D18031088785298B4A4090985AC4B100642167CCF2D573C82C60654ADC1BE8A244BD65F6336481AE37A12B61ABB7CC8886AC55A9DE5A95EA2D21AC37A12C21AC37500272C812C2862C49706F200D9CBD096B0969BD45BDC6AC0D7740BDF4D24BCBFF01C6F842246E05E3F80000000049454E44AE426082";
             document.getElementById("testImage2").src = "data:image/png;base64," + yourByteArrayAsBase64;
         });

     </script> 
     <script type="text/javascript">

        
        function movetoNext (currenttxtbxid, nextFieldID,Charflag,Defval) {
            //debugger;
            if (document.getElementById("ctl00_ContentPlaceHolder1_lblPANMsg") != null) {
                document.getElementById("ctl00_ContentPlaceHolder1_lblPANMsg").style.display = "none";
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_btnprecdnext") != null) {
                document.getElementById("ctl00_ContentPlaceHolder1_btnPrcd").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_btnPrcd").setAttribute("style","margin-left:177px")
                document.getElementById("ctl00_ContentPlaceHolder1_btnprecdnext").style.display = "none";
            }
            var a = allLetter(currenttxtbxid, Charflag);
            if (currenttxtbxid.value.length= 1) {
                if (a == true) {
                    if (Charflag == "A") {
                        if (Defval.toUpperCase() != '' && currenttxtbxid.value.toUpperCase() != Defval.toUpperCase()) {
                            alert('Textbox value should be P');
                            currenttxtbxid.value = "";
                            return;
                        }
                        else {
                            currenttxtbxid.value = currenttxtbxid.value.toUpperCase();
                        }
                    }
                    
                    document.getElementById("ctl00_ContentPlaceHolder1_" + nextFieldID).focus();
                }
                else {
                    currenttxtbxid.value = "";
                }
            }
        }
        function buttonClick(currenttxtbxid, Charflag) {
            debugger;
            var a = allLetter(currenttxtbxid, Charflag);
            if (currenttxtbxid.value.length = 1) {
                if (a == true) {
                    if (Charflag == "A") {
                        currenttxtbxid.value = currenttxtbxid.value.toUpperCase();
                        document.getElementById("ctl00_ContentPlaceHolder1_btnVerify").click();
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_" + currenttxtbxid).value == "";
                        document.getElementById("ctl00_ContentPlaceHolder1_" + currenttxtbxid).focus();
                        
                    }
                    //document.getElementById("ctl00_ContentPlaceHolder1_" + nextFieldID).focus();
                }

                //document.getElementById("ctl00_ContentPlaceHolder1_btnVerify").click();
            }
        }
        function allLetter(inputtxt,Charflag){
            debugger;
            if (Charflag == "A") {
                var letters = /^[A-Za-z]+$/;
            }
            else if (Charflag == "N") {
                var letters = /^[0-9]+$/;
            }
            if (inputtxt.value.match(letters)) {
                return true;
            }
            else {
                return false;
            }
        }

        function filltextbox(alphabet) {
            debugger;
            const Arraypan = alphabet;            
            for (let i = 0; i < (Arraypan.length ); i++) {
                let j=i+1;
                var Id = "ctl00_ContentPlaceHolder1_TextBox" + j;
                document.getElementById(Id).value = Arraypan[i];
            }
            
        }
    </script>
    <style>

        .glyphicon{
            color:white;
        }

    </style>
    <asp:ScriptManager ID="SM1" runat="server">
        </asp:ScriptManager>
        <div class="panel panel-success PanelInsideTab" style="margin-top: 0px;">
            <%--//Note added 19 july 2023 start--%>
            <div class="row">
                <div class="col-sm-12" style="text-align:center;">

                <asp:Label runat="server" ID="lblmsgrec" style="color:red;font-weight:bold;font-size:18px;"></asp:Label>      
                </div>

            </div> 
            <%--//Note added 19 july 2023 end--%>
            <div class="row rowspacing" style="text-align:center;margin-left:15px">
                <div class="col-sm-6">
                    <img src="../../../image/pan-card-2.jpg" class="auto-style2" style="margin-left:78px"/>
                </div>
                <div class="col-sm-6" style="float:right">
                    <div class="row" style="text-align:left">
                        <div class="row">
                            <div class="col-sm-12"  style="display: flex">
                    <img src="../../../image/download_prev_ui.png" class="auto-style1" />
                                <p style="margin-left:5px"> Please note that till now the PAN number has been the<br />
                                    primary identity Number for an agent or intermediary <br />
                                    candidate as per IRDAI guidelines. Hence we would use<br />
                                    the candidate's PAN Number to perform his identity   <br /> 
                                    verification (KYA).                                  <br /> 
                        </p>
                   
                        
                         
                                 </div>
                        </div>
                    </div>
                    
                </div>
            </div>
            <br />
            <div class="row" style="padding-left:30px;">
               
                <asp:Label ID="lbltitle" runat="server" Text="Enter PAN below:" CssClass="control-label HeaderColor" style="margin-left:119px"></asp:Label>
                
               
            </div>
           <br/>
           
            <div class="row" style="margin-left:137px">
                
                    <div class="col-sm-1">
                    <asp:TextBox ID="TextBox1" CssClass="form-control" style="width:40px;" onkeyup="movetoNext(this,'TextBox2','A','')" MaxLength="1" BorderColor="Red" runat="server" ></asp:TextBox>
                    </div>
                    <div class="col-sm-1">
                    <asp:TextBox ID="TextBox2" CssClass="form-control" style="width:40px;" onkeyup="movetoNext(this,'TextBox3','A','')" MaxLength="1" BorderColor="Red" runat="server" ></asp:TextBox>
                    </div>
                    <div class="col-sm-1">
                    <asp:TextBox ID="TextBox3" CssClass="form-control" style="width:40px;" onkeyup="movetoNext(this,'TextBox4','A','')" MaxLength="1" BorderColor="Red" runat="server" ></asp:TextBox>
                    </div>
                    <div class="col-sm-1">
                    <asp:TextBox ID="TextBox4" CssClass="form-control" style="width:40px;" onkeyup="movetoNext(this,'TextBox5','A','P')" MaxLength="1" BorderColor="Red" runat="server" ></asp:TextBox>
                    </div>
                    <div class="col-sm-1">
                    <asp:TextBox ID="TextBox5" CssClass="form-control" style="width:40px;" onkeyup="movetoNext(this,'TextBox6','A','')" MaxLength="1" BorderColor="Red" runat="server" ></asp:TextBox>
                    </div>
                    <div class="col-sm-1">
                    <asp:TextBox ID="TextBox6" CssClass="form-control" style="width:40px;" onkeyup="movetoNext(this,'TextBox7','N','')" MaxLength="1" BorderColor="Red" runat="server" ></asp:TextBox>
                    </div>
                    <div class="col-sm-1">
                    <asp:TextBox ID="TextBox7" CssClass="form-control" style="width:40px;" onkeyup="movetoNext(this,'TextBox8','N','')" MaxLength="1" BorderColor="Red" runat="server" ></asp:TextBox>
                    </div>
                    <div class="col-sm-1">
                    <asp:TextBox ID="TextBox8" CssClass="form-control" style="width:40px;" onkeyup="movetoNext(this,'TextBox9','N','')" MaxLength="1" BorderColor="Red" runat="server" ></asp:TextBox>
                    </div>
                    <div class="col-sm-1">
                    <asp:TextBox ID="TextBox9" CssClass="form-control" style="width:40px;" onkeyup="movetoNext(this,'TextBox10','N','')" MaxLength="1" BorderColor="Red" runat="server" ></asp:TextBox>
                    </div>
                    <div class="col-sm-1">
                    <asp:TextBox ID="TextBox10" CssClass="form-control" style="width:40px;" onChange="javascript:this.value=this.value.toUpperCase();"  onkeyup="movetoNext(this,'TextBox10','A','')"
                       BorderColor="Red" MaxLength="1" runat="server"></asp:TextBox>
                      <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_GivenName" runat="server"
                                FilterType="LowercaseLetters, UppercaseLetters,Custom" TargetControlID="TextBox10" 
                                ValidChars=" " FilterMode="ValidChars">
                            </ajaxToolkit:FilteredTextBoxExtender>
                    </div>
                    <div class="col-sm-1">
                    </div>
                      
            </div>
                          
            <br />
            <div class="row">
                <asp:Label ID="lblPANMsg" runat="server" Font-Bold="False" CssClass="control-label" style="text-align:center" 
                  Font-Size="15px"></asp:Label>
            </div>
             <br />
            <div class="row" style="text-align:center;">
                
                <div class="col-sm-3" style="margin-left:8px">
                     <asp:LinkButton ID="btnClear" runat="server" OnClick="btnClear_Click" CssClass="btn btn-clear" Text="CLEAR" style="margin-left:78px">CLEAR</asp:LinkButton>
                    </div>
                <div class="col-sm-4">
                     <asp:LinkButton ID="lnkPrcdWthCon" runat="server" OnClick="lnkPrcdWthCon_Click" CssClass="btn btn-clear" style="display:none;">
                                </asp:LinkButton> 
                    </div>
                
                <div class="col-sm-3" style="text-align:right;">
                    
                    <asp:LinkButton ID="btnVerify" runat="server" style="display:none" OnClick="btnVerify_Click"  CssClass="btn btn-success">
                        Verify
                    </asp:LinkButton>
                    <%-- <div class="btn btn-xs btn-primary" style="width: 90px;">
                                    <i class="glyphicon glyphicon-arrow-left BtnGlyphicon" style="color:#ccc">--%>
                        <asp:Button ID="btnPrcd" runat="server"  OnClick="btnPrcd_Click" CssClass="btn btn-success" style="display:block;margin-left:177px;"  Text="PROCEED" />
                                   <%-- </i>--%>
             
                      <%--</div> --%> 
                    <asp:Button ID="btnprecdnext" runat="server"  OnClick="btnprecdnext_Click" CssClass="btn btn-success" style="display:none;margin-left:177px;" Text="PROCEED" />
                      
                </div>
                <div class="col-sm-1">

                    </div>
                <div class="col-sm-1">

                    </div>
            </div>
            <br />
            <div class="row" style="text-align: center;margin-left: 132px;">
                <div class="col-sm-12"  style="display: flex">
              <img src="../../../image/download_prev_ui.png" class="auto-style1" />
                <p style="margin-left: 5px;text-align:left;">Please ensure the PAN Number is correct in order to process the candidate's appointment seamlessly in the minimum<br />
                                            possible time.<br />
                </p>
            </div>
              </div>
       </div>
    <%--added by sanoj 31082023--%>
    <div class="modal fade" id="myModal" role="dialog" style="opacity:1.0">
        <div class="modal-dialog modal-sm">

            <!-- Modal content-->
            <div class="modal-content" style='width: 394px;height: 200px;margin-left: -41px;margin-top:16pc'>
                <div id="divmdlbdy" class="modal-body" style="text-align: center">
                    <div class="row" style="margin-top: 11px;">
                        <div class="col-sm-12">
                              <asp:Label ID="Label7" Text="" runat="server"  Style="margin-left: 7px; color: black; font-size: 16px; margin-top: 20px;"></asp:Label>
                        </div>
                    </div>
                        <div class="row" >
                            <div class="col-sm-12" style="text-align:center;padding:38px">
                                      <button type="button" id="btnNo" value="No" class="btn btn-success" onclick="Conpopup('btnNo');">
                                            <span  style="color: white" ></span>No
                             </button>
                                <button type="button" id="btnYes" runat="server" class="btn btn-success" value="Yes" onclick="Conpopup('btnYes');">
                        <span  style="color: white" ></span>Yes
                    </button>

                                   <button type="button" id="btnProceed" runat="server" class="btn btn-success" value="Yes" onclick="Conpopup('btnProceed');">
                        <span  style="color: white" ></span>Proceed
                    </button>
                                 <asp:LinkButton ID="lmkbtnProceed" runat="server" style="display:none" OnClick="lmkbtnProceed_Click" CssClass="btn btn-clear" > Proceed
                                </asp:LinkButton> 
              
                        </div>
                        </div>
                   
                </div>
            </div>

        </div>
    </div>

     <div id="iLoading" runat="server" class="Content" style="position:absolute;top:50%;left:50%;margin:-50px 0px 0px -50px;z-index:9999;display:none">
            <img id="img1" src="../../../assets/img/loading-spinner-blue.gif" alt="LOADING" /> 
            <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Loading...
        </div>
     <%--Endded by sanoj 31082023--%>
      <asp:HiddenField ID="hdnNewAppNo" runat="server" />
       <asp:HiddenField ID="hdnCndCode" runat="server" />
       <asp:HiddenField ID="hdnPan" runat="server" />
       <asp:HiddenField ID="hdnPanValue" runat="server" />
       <asp:HiddenField ID="hdnUrn" runat="server" />
       <asp:HiddenField ID="hdnAgentBrokerCode" runat="server" />
       <asp:HiddenField ID="hdnEmpCode" runat="server" />
     <asp:HiddenField ID="hpan" runat="server" />
       <%--<asp:HiddenField ID="hdnPanINT" runat="server" />--%>
    
    <script>
        function CheckPANFormat(strPANNo) {
            debugger;
            var result = true;
            var pan = strPANNo.split(",");
            var Char;
            var pan2 = pan[0]
            if (pan2 != "") {
                if (pan2.length == 10) {
                    for (j = 0; j < pan2.length && result == true; j++) {
                        Char = pan2.substring(j, j + 1);

                        if (j == 0 || j == 1 || j == 2 || j == 3 || j == 4 || j == 9) {
                            if (!isAlphabet(Char)) {
                                return false;
                            }
                            if (j == 3) {
                                if (pan2.substring(j, j + 1) != 'P') {
                                    return false;
                                }
                            }
                        }
                        if (j == 5 || j == 6 || j == 7 || j == 8) {
                            if (!IsNumeric(Char)) {
                                return false;
                            }
                        }
                    }
                }
            }
            else {
                return false;
              }
              return true;
        }
        

    </script>
</asp:Content>