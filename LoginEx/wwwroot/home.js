const signIn = async () => {
    const email = document.getElementById("username").value;
    const pwd = document.getElementById("userpwd").value;
    const response = await fetch("https://localhost:44333/api/user/SignIn", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ "userEmail": email, "userPassword": pwd })
    });
    if (response.status == 204) { alert('one or more parameters are wrong'); }
    if (!response.ok) { }

    else {
        const user = await response.json();
        sessionStorage.setItem('user', JSON.stringify(user));
        document.location = "https://localhost:44333/update.html";
    }
}

const signUp = async () => {
    const email = document.getElementById("username2").value;
    const pwd = document.getElementById("userpwd2").value;
    const fname = document.getElementById("fname2").value;
    const lname = document.getElementById("lname2").value;
    const user = { userFname: fname, userLname: lname, userPassword: pwd, userEmail: email }
    const response = await fetch("https://localhost:44333/api/user", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    })
    if (response.ok) {
        console.log(response.status)
        const newUser = await response.json();
        sessionStorage.setItem('user', JSON.stringify(newUser));

        document.location = "https://localhost:44333/update.html";
    }
    else { alert('request failed'); }
}

const fill = () => {
    const user = JSON.parse(sessionStorage.getItem('user'));
    document.getElementById("email").setAttribute('value', user.userEmail);
    //document.getElementById("email").setAttribute('value', user.email);
    document.getElementById("pwd").setAttribute('value', user.userPassword);
    document.getElementById("fname").setAttribute('value', user.userFname);
    document.getElementById("lname").setAttribute('value', user.userLname);
}

const updateUser = async () => {
    const email = document.getElementById("email").value;
    const pwd = document.getElementById("pwd").value;
    const fname = document.getElementById("fname").value;
    const lname = document.getElementById("lname").value;
    const id = JSON.parse(sessionStorage.getItem('user')).userId;
    const user = { userFname: fname, userLname: lname, userPassword: pwd, userEmail: email, UserId: id };
    const response = await fetch(`https://localhost:44333/api/user/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    })
    if (!response.ok) { alert('request failed'); }
    else {
    const updatedUser = await response.json();
    sessionStorage.setItem('user', JSON.stringify(updatedUser));
    alert("user details was updated");
    }
}

const checkPasswordStrength = async () => {
    const pwd = document.getElementById("userpwd2").value;
    const res = await fetch(`https://localhost:44333/api/password`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(pwd)
    })
    const strength = await res.json();
    document.getElementById("file").setAttribute("value", strength);
}