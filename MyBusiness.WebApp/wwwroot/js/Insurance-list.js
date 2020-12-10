var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').dataTable({
        "ajax": {
            "url": "/insurance/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "insuranceName", "width": "15%" },
            { "data": "createdBy", "width": "15%" },
            { "data": "creationDate", "width": "15%" },
            { "data": "updatedBy", "width": "15%" },
            { "data": "lastUpdateDate", "width": "15%" },
            {
                "data": "insuranceId",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Insurance/Upsert/${data}" class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                                    <i class='far fa-edit'></i> Edit
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Admin/category/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
                                    <i class='far fa-trash-alt'></i> Delete
                                </a>
                            </div>
                            `;
                }, "width": "25%"
            }

        ],
        "language": {
            "emptyTable": "NO records found"
        },
        "width": "100%"
    });

}
 