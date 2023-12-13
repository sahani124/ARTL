var TableAdvanced = function () {

    var initTable1 = function() {

        /* Formatting function for row details */
        
function fnFormatDetails ( oTable, nTr )
        {
            var aData = oTable.fnGetData( nTr );
            var sOut = '<table cellpadding="0" width="100%" cellspacing="5" style="border: 1px solid #c1c1c1">';
            sOut += '<tr><td style="background-color:#c1c1c1"><b>Contestant Code</b></td><td  style="background-color:#c1c1c1"><b>Comp Description</b></td><td  style="background-color:#c1c1c1"><b>Sales Channel</b></td><td  style="background-color:#c1c1c1"><b>Sub Class</b></td><td  style="background-color:#c1c1c1"><b>Member Type</b></td><td  style="background-color:#c1c1c1"><b>Period</b></td><td style="background-color:#c1c1c1"><b>Effective From</b></td><td style="background-color:#c1c1c1"><b>Effective To</b></td><td style="background-color:#c1c1c1"><b>Version No.</b></td></tr>';
            sOut += '<tr><td><a href="form_layouts1.html">10000001</a></td><td>Advisor Bonus Commission </td><td>Tied Agency</td><td align="center">Tied Agency</td><td align="center">Sales Advisor</td><td align="center">2014 - 15</td><td align="center">4/1/2014</td><td align="center">3/31/2015</td><td align="center">1.00</td></tr>';
            sOut += '<tr><td>10000002</td><td>Advisor Bonus Commission </td><td>TiedD Agency</td><td align="center">Tied Agency</td><td align="center">Rural Advisor</td><td align="center">2014 - 15</td><td align="center">4/1/2014</td><td align="center">3/31/2015</td><td align="center">1.00</td></tr>';
            sOut += '</table>';
             
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