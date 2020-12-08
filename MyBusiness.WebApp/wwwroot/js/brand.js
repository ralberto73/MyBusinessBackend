var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').dataTable({
        "ajax": {
            "url"      : "/brand/GetAll",
            "type"     : "GET",
            "datatype" :"json"
        },
        "columns": [
            { "data": "brandId", "width": "10%" },
            { "data": "brandName", "width": "15%" },
            { "data": "createdBy", "width": "15%" },
            { "data": "creationDate", "width": "15%" },
            { "data": "updatedBy", "width": "15%" },
            { "data": "lastUpdateDate", "width": "15%" },

        ],
        "language": {
            "emptyTable":"NO records found"
        },
        "width":"100%"
    });
}