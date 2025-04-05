let resetError = () => {
    let successAlert = document.getElementById("successAlert");
    let errorAlert = document.getElementById("errorAlert");
    successAlert.innerText = '';
    errorAlert.innerText = '';
    successAlert.classList.remove("d-none");
    errorAlert.classList.remove("d-none");
};

let Validator = (formSelector, options = {}) => {
    let getParent = (element, selector) => {
        while (element.parentElement) {
            if (element.parentElement.matches(selector)) {
                return element.parentElement;
            }
            element = element.parentElement;
        }
    };

    let formRules = {};
    let validatorRules = {
        required: (value) => {
            return value && value.trim() != "" ? undefined : 'Vui lòng nhập trường này';
        },
        email: (value) => {
            let regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            return regex.test(value) ? undefined : "Email không hợp lệ";
        },
        sdt: (value) => {
            let regex = /^(0|\+84)[1-9]\d{8}$/;
            return regex.test(value) ? undefined : "Số điện thoại không hợp lệ";
        },
        min: (min) => {
            return (value) => {
                return value.length >= min ? undefined : `Vui lòng nhập ít nhất ${min} ký tự`;
            }
        },
        confirm: (selector) => {
            return (value) => {
                let confirmValue = document.querySelector(selector).value;
                // console.log(confirmValue);
                // console.log(value);
                return value === confirmValue ? undefined : 'Mật khẩu xác nhận không chính xác';
            };
        },
        newPassword: (selector) => {
            return (value) => {
                let oldValue = document.querySelector(selector).value;
                // console.log(confirmValue);
                // console.log(value);
                return value !== oldValue ? undefined : 'Mật khẩu mới không được giống mật khẩu cũ';
            };
        }
    };

    let handleValidate = (event) => {
        let rules = formRules[event.target.name];
        let errorMessage;
        for (let rule of rules) {
            errorMessage = rule(event.target.value);
            if (errorMessage) break;
        }
        if (errorMessage) {
            let formGroup = getParent(event.target, '.form-group');

            if (!formGroup) return; 

            if (formGroup) {
                // formGroup.classList.add('invalid');
                let formMessage = formGroup.querySelector('.form-message');
                if (formMessage) {
                    formMessage.innerText = errorMessage;
                }
            }
        }
        return !errorMessage;
    };

    let handleClearError = (event) => {
        let formGroup = getParent(event.target, '.form-group');
        if (formGroup) {
            // formGroup.classList.remove('invalid');
            let formMessage = formGroup.querySelector('.form-message');
            if (formMessage) {
                formMessage.innerText = '';
            }
        }
    }

    let formElement = document.querySelector(formSelector);

    if (formElement) {
        let inputs = formElement.querySelectorAll('[name][rules]');

        for (let input of inputs) {
            let rules = input.getAttribute('rules').split('|');
            for (let rule of rules) {
                let ruleInfo;
                let isRuleHasValue = rule.includes(':'); 

                if (rule.includes(':')) {
                    ruleInfo = rule.split(':');
                    rule = ruleInfo[0];
                    // console.log(validatorRules[rule](ruleInfo[1]));
                }

                let ruleFunc = validatorRules[rule];

                if (isRuleHasValue) {
                    ruleFunc = ruleFunc(ruleInfo[1]);
                }
                // console.log(ruleFunc);
                if (Array.isArray(formRules[input.name])) {
                    formRules[input.name].push(ruleFunc);
                } else {
                    formRules[input.name] = [ruleFunc];
                }
            }

            input.onblur = handleValidate;
            input.oninput = handleClearError;                                                                                                
        }


        formElement.onsubmit = (event) => {
            event.preventDefault();
            // resetError();
            let inputs = formElement.querySelectorAll('[name][rules]');
            let isValid = true;
            for (let input of inputs) {
                if (!handleValidate({ target: input })) {
                    isValid = false;
                } 
            }
            
            if (isValid) {
                if (typeof options.onSubmit === 'function') {
                    let enableInputs = formElement.querySelectorAll("[name]");
                    let formValues = Array.from(enableInputs).reduce((values, input) => {
                        values[input.name] = input.value
                        return values;
                    }, {});
                    return options.onSubmit(formValues);
                }
                
                formElement.submit();
            }
        };
    }
};