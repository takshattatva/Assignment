//*************************** Datatable ***************************/
$(document).ready(function () {
    $('.TaskTable').DataTable({
        destroy: true,
        "pageLength": 5,
        language: {
            oPaginate: {
                sNext: '<i class="bi bi-caret-right-fill text-info"></i>',
                sPrevious: '<i class="bi bi-caret-left-fill text-info"></i>'

            }
        }
    });
    $('.dataTables_length').hide();
    $('.dataTables_filter').hide();
});

//*************************** Fetch Add Task Modal ***************************/
function AddTask() {
    event.preventDefault();

    $.ajax({
        method: "GET",
        url: "/Task/CreateTask",

        success: function (result) {
            if (result.code == 401) {
                location.reload();
            }
            $('#showCaseModal').html(result);
            $('#addTaskId').modal('show');
        },

        error: function () {
            Swal.fire("Oops", "Something Went Wrong", "error");
        }
    });
}

//*************************** Fetch Edit Task Modal ***************************/
function EditTask(Id) {
    event.preventDefault();

    $.ajax({
        method: "GET",
        url: "/Task/EditTask",
        data: { Id: Id },

        success: function (result) {
            if (result.code == 401) {
                location.reload();
            }
            $('#showCaseModal').html(result);
            $('#editTaskId').modal('show');
        },

        error: function () {
            Swal.fire("Oops", "Something Went Wrong", "error");
        }
    });
}

function DeleteTask(Id) {
    event.preventDefault();

    $.ajax({
        method: "Post",
        url: "/Task/DeleteTask",
        data: { Id: Id },

        success: function (result) {
            if (result.code == 401) {
                location.reload();
            }
            $('#showCaseModal').html(result);
            $('#editTaskId').modal('show');
        },

        error: function () {
            Swal.fire("Oops", "Something Went Wrong", "error");
        }
    });
}
