let changePasswordAPI = "http://localhost:5289/change-password";

let resetInputs = () => {
    document.getElementById("oldpassword").value = "";  
    document.getElementById("newpassword").value = "";
    document.getElementById("renewpassword").value = "";
}

let changePassword = (data, callback) => {
    let options = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    }

    // fetch(changePasswordAPI, options)
    //     .then(response => response.json())
    //     .then(callback)
    //     .catch(error => console.error("Error sending request:", error));
    fetch(changePasswordAPI, options)
        .then(async response => {
            let contentType = response.headers.get("content-type");
            if (contentType && contentType.includes("application/json")) {
                let data = await response.json();
                callback(data);
            } else {
                let text = await response.text();
                console.error("Unexpected response:", text);
                alert("Có lỗi xảy ra trên server!");
            }
        })
        .catch(error => console.error("Lỗi khi gửi request:", error));

};

let handleChangePassword = (data) => {
    fetch("http://localhost:5289/get-user-info")
        .then(response => response.json())
        .then(userData => {
            let dataDTO = {
                oldPassword: data.oldpassword,
                newPassword: data.newpassword,
                phoneNumber: userData.phoneNumber,
            };
            changePassword(dataDTO, (response) => {
                console.log(response.message);
                if (response.status === 200) {
                    resetInputs();
                    alert("Thay đổi mật khẩu thành công!");
                    // window.location.href = "/home";
                } else {
                    alert(response.message);
                }
            });
        })
}