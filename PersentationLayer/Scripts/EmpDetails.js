/// <reference path="jqGrid/jquery.jqGrid.js" />

var EmployeeDetails = {

    GetEmpData: function () {
        $("#list").jqGrid({
            url: '/Employee/EmpInfoData',
            datatype: 'json',
            mtype: 'Get',
            colModel: [
                {
                    key: true, hidden: true, name: 'EmployeeNo', index: 'EmployeeNo', editable: true
                },

                          { key: false, name: 'FirstName', index: 'FirstName', width: 245, editable: true, editrules: { required: true }, },

                            { name: 'LastName', index: 'LastName', width: 245, editable: true, editrules: { required: true }, },
                               { name: 'Address', index: 'Address', width: 245, editable: true, editrules: { required: true }, },

                          {
                              name: 'MobileNo', index: 'MobileNo', width: 245, editable: true, editrules: { required: true }, editoptions: {
                                  maxlength: "10", dataInit: function (element) {
                                      $(element).keypress(function (e) {
                                          if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                                              alert("Accept only numeric value and only ten digits");
                                              return false;
                                          }
                                      });
                                  }
                              }
                          },

                          {
                              name: 'PostelCode', index: 'PostelCode', width: 145, editable: true, editrules: { required: true }, editoptions: {
                                  maxlength: "6", dataInit: function (element) {
                                      $(element).keypress(function (e) {

                                          if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {

                                              alert("Accept only numeric value and only six digits");
                                              return false;
                                          }
                                      });
                                  }
                              }
                          },
                            { name: 'EmailId', index: 'EmailId', width: 245, editable: true, editrules: { required: true }, }
            ],
            pager: jQuery('#pager'),
            rowNum: 10,
            loadonce: true,
            rowList: [10, 20, 30, 40],
            height: '100%',
            viewrecords: true,
            caption: 'Employee Details',
            emptyrecords: 'No records to display',
            jsonReader: {
                repeatitems: false,
                root: function (obj) { return obj; },
                page: "page",
                total: "total",
                records: "records",
                repeatitems: false,
                EmployeeNo: "0"
            },
            autowidth: true,
            multiselect: false
        }).navGrid('#pager', { add: false, edit: true, del: true, search: false, refresh: true },
       {
           // edit options
           zIndex: 1000,
           url: '/Employee/UpdateEmployeeInfo',
           closeOnEscape: true,
           closeAfterEdit: true,
           recreateForm: true,
           loadonce: true,
           align: 'center',
           afterComplete: function (response) {
               GetEmpData()
               if (response.responseText) {
                  
                   alert(response.responseText);
                   jQuery('#list').jqGrid('clearGridData');
                   jQuery('#list').jqGrid('setGridParam', {data: dataToLoad});
                   jQuery('#list').trigger('reloadGrid');
               }
           }
       }, {},
       {
           // delete options
           zIndex: 1000,
           url: '/Employee/DeleteEmployeeInfo',
           closeOnEscape: true,
           closeAfterdel: true,
           recreateForm: true,
           msg: "Esta seguro de borrar el registro?",
           afterComplete: function (response) {
               if (response.responseText) {
                   $("#alert-Grid").html("<b>" + response.responseText + "</b>");
                   $("#alert-Grid").show();
                   $("#alert-Grid").delay(3000).fadeOut("slow");
       
               }
           }
       });
    },
    insertEmployeeDetails: function () {
     
        $("#btnSubmit").click(function () {
         
            $.ajax(
            {
                type: "POST", //HTTP POST Method  
                url: "/Employee/InsertEmployeeInfo", // Controller/View   
                data: { //Passing data  

                    FirstName: $("#txtFName").val(), //Reading text box values using Jquery   
                    LastName: $("#txtLName").val(),
                    Address: $("#txtAddress").val(),
                    MobileNo: $("#txtMobileNo").val(),
                    PostelCode: $("#txtPinCode").val(),
                    EmailId: $("#txtEmail").val()
                },
                success: function (data) {
                    alert(data);
                    $("##alert-danger").html("<b>" + data + "</b>");
                    $("##alert-danger").show();
                    $("##alert-danger").delay(10000).fadeOut("slow");

                    jQuery('#list').jqGrid('clearGridData');
                    jQuery('#list').jqGrid('setGridParam', {data: dataToLoad});
                    jQuery('#list').trigger('reloadGrid');
                },
                error: function (data) {
                    GetEmpData();
                    //var r = data.responseText;
                    //var errorMessage = r.Message;
                    $("##alert-danger").html("<b>" + data + "</b>");
                    $("##alert-danger").show();
                    $("##alert-danger").delay(10000).fadeOut("slow");
                }
            });
        });
    }
}





