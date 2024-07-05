


function Delete(id) {
    Swal.fire({
        title: lbTitleMsgDelete,
        text: lbTextMsgDelete,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: lbconfirmButtonText,
        cancelButtonText: lbcancelButtonText
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = `/Notification/Delete?Id=${id}`;
            
            Swal.fire(
                lbTitleDeletedOk,
                lbMsgDeletedOkRole,
                lbSuccess
            )
        }
    })
}
