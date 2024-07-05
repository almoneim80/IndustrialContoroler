$(document).ready(function () {
    $('#tableRole').DataTable({
        "autoWidth": false,
        "responsive":true
    });
});

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
            window.location.href = `/Account/Delete?userId=${id}`;
            Swal.fire(
                lbTitleDeletedOk,
                lbMsgDeletedOkRegister,
                lbSuccess
            )
        }
    })
}

Edit = (id, fullName, username, userphone, email, image, role, active) => {
    document.getElementById("title").innerHTML = lbTitleEdit;
    document.getElementById("btnSave").value = lbEdit;
    document.getElementById("userId").value = id;
    document.getElementById("fullName").value = fullName;
    document.getElementById("userName").value = username;
    document.getElementById("userPhone").value = userphone;
    document.getElementById("userEmail").value = email;
    /*document.getElementById("userImage").value = image;*/
    document.getElementById("ddluserRole").value = role;
    var Active = document.getElementById("userActive");
    if (active == "True")
        Active.checked = true;
    else
        Active.checked = false;
    $('#grPassword').hide();
    $('#grcomPassword').hide();
    document.getElementById("userPassword").value = "$$$$$$";
    document.getElementById("userCompare").value = "$$$$$$";
    document.getElementById("image").hidden = false;
    document.getElementById("image").src = PathImageuser + image;
    document.getElementById("imgeHide").value = image;

}

Rest = () => {
    document.getElementById("title").innerHTML = lbAddNewUsers;
    document.getElementById("btnSave").value = lbbtnSave;
    document.getElementById("userId").value = "";
    document.getElementById("fullName").value = "";
    document.getElementById("userName").value = "";
    document.getElementById("userPhone").value = "";
    document.getElementById("userEmail").value = "";
    document.getElementById("userImage").value = "";
    document.getElementById("ddluserRole").value = "";
    document.getElementById("userActive").checked = false;
    $('#grPassword').show();
    $('#grcomPassword').show();
    document.getElementById("userPassword").value = "";
    document.getElementById("userCompare").value = "";
    document.getElementById("image").hidden = true;
    document.getElementById("imgeHide").value = "";


}



function ChangePassword(id) {

    document.getElementById('userPassId').value = id;
}

let lbTitleEdit = '@Html.Raw(ResourceWeb.lbTitleEditUser)';
let lbAddNewUsers = '@Html.Raw(ResourceWeb.lbAddNewUsers)';
let lbEdit = '@Html.Raw(ResourceWeb.lbEdit)';
let lbAddNewRole = '@Html.Raw(ResourceWeb.lbAddNewRole)';
let lbbtnSave = '@Html.Raw(ResourceWeb.lbbtnSave)';

let lbTitleMsgDelete = '@Html.Raw(ResourceWeb.lbbtnDelete)';
let lbTextMsgDelete = '@Html.Raw(ResourceWeb.lbTextMsgDelete)';
let lbconfirmButtonText = '@Html.Raw(ResourceWeb.lbconfirmButtonText)';
let lbcancelButtonText = '@Html.Raw(ResourceWeb.lbcancelButtonText)';

let lbTitleDeletedOk = '@Html.Raw(ResourceWeb.lbTitleDeletedOk)';
let lbMsgDeletedOkRegister = '@Html.Raw(ResourceWeb.lbMsgDeletedOkRegister)';
let lbSuccess = '@Html.Raw(Helper.Success)';
let PathImageuser = '@Html.Raw(Helper.PathImageuser)';