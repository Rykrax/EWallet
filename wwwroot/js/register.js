const api = "http://localhost:5289/register";

let createUser = (data, callback) => {
    let options = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    };
    // console.log(api);
    fetch(api, options)
        .then(response => response.json())
        .then(callback)
        // .catch(error => console.error("Error sending request:", error.message));
};

let handleRegister = () => {
    console.log("vào handleRegister");                                                                               
    let email = document.querySelector('#email').value;
    let phoneNumber = document.querySelector('#phoneNumber').value;
    let cccd = document.querySelector('#cccd').value;
    let password = document.querySelector('#password').value;
    let confirm = document.querySelector('#confirm').value;

    let data = {
        email: email,
        phoneNumber: phoneNumber,
        cccd: cccd,
        password: password,
        confirmPassword: confirm
    }
    console.log(data);
    createUser(data, (result) => {
        let successAlert = document.getElementById("successAlert");
        let errorAlert = document.getElementById("errorAlert");
        // console.log(result.message);
        if (result.status === 400) {
            errorAlert.innerHTML = result.message;
            errorAlert.classList.remove("d-none");
            successAlert.classList.add("d-none");
        }
        if (result.status === 200) {
            successAlert.innerHTML = result.message;
            successAlert.classList.remove("d-none");
            errorAlert.classList.add("d-none");
        } else console.log("Error: " + result.message);
    });
};

