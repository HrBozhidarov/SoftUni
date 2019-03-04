function validate() {
    let company = $('#company').on('click', viewCompany);
    let companyNumber = $('#companyNumber');
    let password = $('#password');
    let confirmPassword = $('#confirm-password');
    let email = $('#email');
    let username = $('#username');
    let companyInfo = $('#companyInfo');
    let visible = $('#valid');

    $('#submit').on('click', validate);

    function validate(e) {
        if(fieldsAreValid()) {
            visible.css('display', 'block');
        }
        else {
            visible.css('display', 'none');
        }

        e.preventDefault();
    }

    function fieldsAreValid() {
        let isValid = true;

        if (company.is(':checked')) {
            let number = Number(companyNumber.val());

            if (number >= 1000 && number <= 9999) {
                addCssBorder(companyNumber, 'border', '1px solid darkblue');
            }
            else {
                addCssBorder(companyNumber, 'border-color', 'red');
                isValid = false;
            }
        }

        let usernameRegex = /^[A-Za-z0-9]{3,20}$/g;

        if (usernameRegex.test(username.val())) {
            addCssBorder(username, 'border', '1px solid darkblue');
        }
        else {
            addCssBorder(username, 'border-color', 'red');
            isValid = false;
        }

        let passwordRegex = /^\w{5,15}$/;

        if (passwordRegex.test(password.val())) {
            if (password.val() !== confirmPassword.val()) {
                addCssBorder(password, 'border-color', 'red');
                addCssBorder(confirmPassword, 'border-color', 'red');
                isValid = false;
            }
            else {
                addCssBorder(password, 'border', '1px solid darkblue');
                addCssBorder(confirmPassword, 'border', '1px solid darkblue');
            }
        }
        else {
            addCssBorder(password, 'border-color', 'red');
            addCssBorder(confirmPassword, 'border-color', 'red');
            isValid = false;
        }

        let emailRegex = /.*?@.*?\..*/g;

        if (emailRegex.test(email.val())) {
            addCssBorder(email, 'border', '1px solid darkblue');
        }
        else {
            addCssBorder(email, 'border-color', 'red');
            isValid = false;
        }

        return isValid;
    }

    function addCssBorder(input, property, value) {
        input.css(property, value);
    }

    function viewCompany(e) {
        if (company.css('display') !== 'block') {
            companyInfo.css('display', 'block');
        }
        else {
            companyInfo.css('display', 'none');
        }
    }
}
