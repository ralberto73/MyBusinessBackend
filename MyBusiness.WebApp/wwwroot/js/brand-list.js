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
            { "data": "brandName", "width": "15%" },
            { "data": "createdBy", "width": "15%" },
            { "data": "creationDate", "width": "15%" },
            { "data": "updatedBy", "width": "15%" },
            { "data": "lastUpdateDate", "width": "15%" },
            {
                "data": "brandId",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/brand/Upsert/${data}" class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
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
            "emptyTable":"NO records found"
        },
        "width":"100%"
    });
}