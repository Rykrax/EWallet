let changePasswordAPI = "http://localhost:5289/change-password";

document.addEventListener("DOMContentLoaded", () => {
    fetch("http://localhost:5289/api/banks")
        .then(response => response.json())
        .then(data => {
            const select = document.querySelector("#bankSelect");
            let option = document.createElement("option");
            option.value = "";
            option.text = "Chọn ngân hàng";
            data.forEach(bank => {
                const option = document.createElement("option");
                option.value = bank.bankID;
                option.text = bank.bankName;
                select.appendChild(option);
            });
        })
        .catch(error => console.error("Error fetching banks:", error));

    const addBankBtn = document.getElementById('addBankBtn');
});

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

let addBank = (data, callback) => {
    let options = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    };
    fetch("http://localhost:5289/add-bank-account", options)
        .then(response => response.json())
        .then(callback)
}

let handleAddBank = () => {
    const bank = document.getElementById('bankSelect').value;
    const accountNumber = document.getElementById('accountnumber').value.trim();

    if (bank === "Chọn ngân hàng") {
        alert("Vui lòng chọn ngân hàng");
        return;
    }
    if (accountNumber === "") {
        alert("Vui lòng nhập số tài khoản.");
        return;
    }
    fetch("http://localhost:5289/get-user-info")
        .then(response => response.json())
        .then(userData => {
            let data = {
                userID: userData.userID,
                bankID: bank,
                accountNumber: accountNumber,
                status: "active"
            };
            console.log(data);
            addBank(data, (result) => {
                console.log(data, "bah" + result.status);
                if (result.status === 200) {
                    // console.log(result.message);
                    alert("Thêm tài khoản ngân hàng thành công!");
                    document.getElementById('bankSelect').value = "Chọn ngân hàng";
                    document.getElementById('accountnumber').value = "";
                } else {
                    alert("Thêm tài khoản ngân hàng thất bại!");
                }
            });
        });
};

addBankBtn.addEventListener('click', (event) => {
    event.preventDefault();
    handleAddBank();
});