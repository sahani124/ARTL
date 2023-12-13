var TableAdvanced = function () {

    var initTable1 = function() {

        /* Formatting function for row details */
        
function fnFormatDetails ( oTable, nTr )
        {
        debugger;
        
            var aData = oTable.fnGetData( nTr );

            var id=aData[1];

            // here is the ID- DO what ever u wanna do..

            //alert(  $(id).toString() + " adarsh." );
            var sOut = '';
         if (id == 10000001)
         {
            sOut = '<table cellpadding="0" width="100%" cellspacing="5" style="border: 1px solid #c1c1c1">';
            sOut += '<tr><td style="background-color:#c1c1c1"><b>Contestant Code</b></td><td  style="background-color:#c1c1c1"><b>Comp Description</b></td><td  style="background-color:#c1c1c1"><b>Sales Channel</b></td><td  style="background-color:#c1c1c1"><b>Sub Class</b></td><td  style="background-color:#c1c1c1"><b>Member Type</b></td><td  style="background-color:#c1c1c1"><b>Period</b></td><td style="background-color:#c1c1c1"><b>Effective From</b></td><td style="background-color:#c1c1c1"><b>Effective To</b></td><td style="background-color:#c1c1c1"><b>Version No.</b></td></tr>';
            sOut += '<tr><td><a href="BonCommPg1.html">10000001</a></td><td>Advisor Bonus Commission </td><td>Tied Agency</td><td align="center">Tied Agency</td><td align="center">Sales Advisor </td><td align="center">2014 - 15</td><td align="center">01/04/2014</td><td align="center">31/03/2015</td><td align="center">1.00</td></tr>';
            sOut += '<tr><td><a href="BonCommPg2.html">10000002</a></td><td>Advisor Bonus Commission </td><td>Tied Agency</td><td align="center">Tied Agency</td><td align="center">Rural Advisor</td><td align="center">2014 - 15</td><td align="center">01/04/2014</td><td align="center">31/03/2015</td><td align="center">1.00</td></tr>';
            sOut += '</table>';
             
            }
            else if (id == 10000002)
            {
             sOut = '<table cellpadding="0" width="100%" cellspacing="5" style="border: 1px solid #c1c1c1">';
            sOut += '<tr><td style="background-color:#c1c1c1"><b>Contestant Code</b></td><td  style="background-color:#c1c1c1"><b>Comp Description</b></td><td  style="background-color:#c1c1c1"><b>Sales Channel</b></td><td  style="background-color:#c1c1c1"><b>Sub Class</b></td><td  style="background-color:#c1c1c1"><b>Member Type</b></td><td  style="background-color:#c1c1c1"><b>Period</b></td><td style="background-color:#c1c1c1"><b>Effective From</b></td><td style="background-color:#c1c1c1"><b>Effective To</b></td><td style="background-color:#c1c1c1"><b>Version No.</b></td></tr>';
            sOut += '<tr><td><a href="OVCommPg1.html">10000001</a></td><td>CDA Override Commission </td><td>CDA Franchisee</td><td align="center">CDA Franchisee</td><td align="center">Elite CDA</td><td align="center">2014 - 15</td><td align="center">01/04/2014</td><td align="center">31/03/2015</td><td align="center">1.00</td></tr>';
            sOut += '<tr><td><a href="OVCommPg2.html">10000002</a></td><td>CDA Override Commission </td><td>CDA Franchisee</td><td align="center">CDA Franchisee</td><td align="center">Lite CDA</td><td align="center">2014 - 15</td><td align="center">01/04/2014</td><td align="center">31/03/2015</td><td align="center">1.00</td></tr>';
            sOut += '<tr><td><a href="OVCommPg3.html">10000003</a></td><td>CDA Override Commission </td><td>CDA Franchisee</td><td align="center">CDA Franchisee</td><td align="center">Silver CDA</td><td align="center">2014 - 15</td><td align="center">01/04/2014</td><td align="center">31/03/2015</td><td align="center">1.00</td></tr>';
            sOut += '<tr><td><a href="OVCommPg4.html">10000004</a></td><td>CDA Override Commission </td><td>CDA Franchisee</td><td align="center">CDA Franchisee</td><td align="center">Rookie CDA</td><td align="center">2014 - 15</td><td align="center">01/04/2014</td><td align="center">31/03/2015</td><td align="center">1.00</td></tr>';
            sOut += '</table>';
             }
            else if (id == 50000150)
            {
            sOut = '<table cellpadding="0" width="100%" cellspacing="5" style="border: 1px solid #c1c1c1">';
            sOut += '<tr><th>Reward Code</th><th>Category Classification</th><th class="hidden-xs">Rule Set Key</th><th class="hidden-xs">Reward Type</th><th class="hidden-xs">Type</th><th class="hidden-xs">Based On KPI</th><th class="hidden-xs">Value	</th><th class="hidden-xs">Reward Desc</th><th class="hidden-xs">Reward Amount</th></tr>';
            sOut += '<tr><td align="center">10000001</td><td align="left">Elite agent Team direct fees</td><td align="center">10000001</td><td align="center">FIXED</td><td align="center">PERCENT</td><td align="center">WRP Premium</td><td align="center">60.00</td><td align="center">Direct fees</td><td align="right">12,350.00</td></tr>';
            sOut += '<tr><td align="center">10000002</td><td align="left">Elite to Elite indirect fees</td><td align="center">10000002</td><td align="center">FIXED</td><td align="center">PERCENT</td><td align="center">WRP Premium</td><td align="center">0.00</td><td align="center">Indirect fees</td><td align="right">0.00</td></tr>';
            sOut += '<tr><td align="center">10000003</td><td align="left">Lite to Elite indirect fees</td><td align="center">10000003</td><td align="center">FIXED</td><td align="center">PERCENT</td><td align="center">WRP Premium</td><td align="center">10.00</td><td align="center">Indirect fees</td><td align="right">0.00</td></tr>';
            sOut += '<tr><td align="center">10000004</td><td align="left">Silver to Elite indirect fees</td><td align="center">10000004</td><td align="center">FIXED</td><td align="center">PERCENT</td><td align="center">WRP Premium</td><td align="center">25.00</td><td align="center">Indirect fees</td><td align="right">0.00</td></tr>';
            sOut += '<tr><td align="center">10000005</td><td align="left">Rookie to Elite indirect fees</td><td align="center">10000005</td><td align="center">FIXED</td><td align="center">PERCENT</td><td align="center">WRP Premium</td><td align="center">35.00</td><td align="center">Indirect fees</td><td align="right">1540.00</td></tr>';
            sOut += '</table>';
             }
             else if (id == 50000180)
            {
            sOut = '<table cellpadding="0" width="100%" cellspacing="5" style="border: 1px solid #c1c1c1">';
            sOut += '<tr><th>Reward Code</th><th>Category Classification</th><th class="hidden-xs">Rule Set Key</th><th class="hidden-xs">Reward Type</th><th class="hidden-xs">Type</th><th class="hidden-xs">Based On KPI</th><th class="hidden-xs">Value	</th><th class="hidden-xs">Reward Desc</th><th class="hidden-xs">Reward Amount</th></tr>';
            sOut += '<tr><td align="center">10000001</td><td align="left">Rookie agent Team direct fees</td><td align="center">10000001</td><td align="center">FIXED</td><td align="center">PERCENT</td><td align="center">WRP Premium</td><td align="center">25.00</td><td align="center">Direct fees</td><td align="right">1,112.00</td></tr>';
            sOut += '<tr><td align="center">10000002</td><td align="left">Rookie to Rookie indirect fees</td><td align="center">10000002</td><td align="center">FIXED</td><td align="center">PERCENT</td><td align="center">WRP Premium</td><td align="center">0.00</td><td align="center">Indirect fees</td><td align="right">0.00</td></tr>';
            sOut += '</table>';
             }


            return sOut;
        }

        /*
         * Insert a 'details' column to the table
         */
        var nCloneTh = document.createElement( 'th' );
        var nCloneTd = document.createElement( 'td' );
        nCloneTd.innerHTML = '<span class="row-details row-details-close"></span>';
         
        $('#sample_1 thead tr').each( function () {
            this.insertBefore( nCloneTh, this.childNodes[0] );
        } );
         
        $('#sample_1 tbody tr').each( function () {
            this.insertBefore(  nCloneTd.cloneNode( true ), this.childNodes[0] );
        } );
         
        /*
         * Initialize DataTables, with no sorting on the 'details' column
         */
        var oTable = $('#sample_1').dataTable( {
            "aoColumnDefs": [
                {"bSortable": false, "aTargets": [ 0 ] }
            ],
            "aaSorting": [[1, 'asc']],
             "aLengthMenu": [
                [5, 15, 20, -1],
                [5, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": 10,
        });

        jQuery('#sample_1_wrapper .dataTables_filter input').addClass("form-control input-small"); // modify table search input
        jQuery('#sample_1_wrapper .dataTables_length select').addClass("form-control input-small"); // modify table per page dropdown
        jQuery('#sample_1_wrapper .dataTables_length select').select2(); // initialize select2 dropdown
         
        /* Add event listener for opening and closing details
         * Note that the indicator for showing which row is open is not controlled by DataTables,
         * rather it is done here
         */
        $('#sample_1').on('click', ' tbody td .row-details', function () {
            var nTr = $(this).parents('tr')[0];
            if ( oTable.fnIsOpen(nTr) )
            {
                /* This row is already open - close it */
                $(this).addClass("row-details-close").removeClass("row-details-open");
                oTable.fnClose( nTr );
            }
            else
            {
                /* Open this row */                
                $(this).addClass("row-details-open").removeClass("row-details-close");
                oTable.fnOpen( nTr, fnFormatDetails(oTable, nTr), 'details' );
            }
        });
    }

    var initTable2 = function() {
        var oTable = $('#sample_2').dataTable( {           
            "aoColumnDefs": [
                { "aTargets": [ 0 ] }
            ],
            "aaSorting": [[1, 'asc']],
             "aLengthMenu": [
                [5, 15, 20, -1],
                [5, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": 10,
        });

        jQuery('#sample_2_wrapper .dataTables_filter input').addClass("form-control input-small"); // modify table search input
        jQuery('#sample_2_wrapper .dataTables_length select').addClass("form-control input-small"); // modify table per page dropdown
        jQuery('#sample_2_wrapper .dataTables_length select').select2(); // initialize select2 dropdown

        $('#sample_2_column_toggler input[type="checkbox"]').change(function(){
            /* Get the DataTables object again - this is not a recreation, just a get of the object */
            var iCol = parseInt($(this).attr("data-column"));
            var bVis = oTable.fnSettings().aoColumns[iCol].bVisible;
            oTable.fnSetColumnVis(iCol, (bVis ? false : true));
        });
    }

    return {

        //main function to initiate the module
        init: function () {
            
            if (!jQuery().dataTable) {
                return;
            }

            initTable1();
            initTable2();
        }

    };

}();