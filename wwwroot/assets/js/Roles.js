
function Delete(id) {
    Swal.fire({
        title: 'warning',
        text: 'warning',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'warning',
        cancelButtonText: 'warning'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = `/Roles/Delete?Id=${id}`;
            Swal.fire(
                'warning',
                'warning',
                'warning'
            )
        }
    })
}
