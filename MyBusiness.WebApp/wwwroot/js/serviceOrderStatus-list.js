﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').dataTable({
        "ajax": {
            "url":     "/ServiceOrderStatus/GetAll",
            "type"     : "GET",
            "datatype" :"json"
        },
        "columns": [
            {
                "data": "color",
                "render": function (data) {
                    return `<div class="text-center">
                            <svg width="1em" height="1em" viewBox="0 0 16 16" class="bi bi-circle-fill" fill="${data}">
                              <circle cx="8" cy="8" r="8" />
                            </svg>
                           </div>`;
                 },"width": "5%"
            },
            { "data": "statusName", "width": "10%" },
            { "data": "createdBy", "width": "15%" },
            { "data": "creationDate", "width": "15%" },
            { "data": "updatedBy", "width": "15%" },
            { "data": "lastUpdateDate", "width": "15%" },
            {
                "data": " serviceOrderStatusId",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/category/Upsert/${data}" class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
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