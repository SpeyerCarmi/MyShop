window.addEventListener("load", goDoShoppingBag());


function goDoShoppingBag(){
    const user = sessionStorage.getItem('user')
    if (user != null)
        window.location.href ="ShoppingBag.html"
}

const connectServer = async () => {
    const Name = document.getElementById("loginName").value;
    const password = document.getElementById("loginPassword").value;
    const ans = await fetch(`https://localhost:44351/Api/Users?Name=${Name}&password=${password}`);
    if (ans.ok) {
        const ans2 = await ans.json();
        alert("ברוך הבא " + ans2.firstName);
        sessionStorage.setItem('user', JSON.stringify(ans2));

        window.location.href = "ShoppingBag.html";
    }
    else
        alert("משתמש לא קיים במערכת,אנא הרשם");
}

const addUser = async () => {
    const name = document.getElementById("registerEmail").value;
    const password = document.getElementById("registerPassword").value;
    const firstName = document.getElementById("registerFirstName").value;
    const lastName = document.getElementById("registerLastname").value;

    newUser = { "Name": name, "password": password, "firstName": firstName, "lastName": lastName };

   
    const res = await fetch(`https://localhost:44351/Api/Users`,
        {
            headers: { "content-type": "application/json" },
            method: 'POST',
            body: JSON.stringify(newUser)
        })
    if (res.ok) {
        debugger;
        const theNewUser = await res.json()
        alert("נוסף בהצלחה למערכת  " + theNewUser.firstName);
        sessionStorage.setItem("user", JSON.stringify(theNewUser))
        window.location.href="ShoppingBag.html"
    }
    else
        throw new Error("failed, please try later");
}

const checkPassword = async() => {
    const password = document.getElementById("registerPassword").value;
    const res = await fetch(`https://localhost:44351/Api/Password`,
        {
            headers: { "content-type": "application/json" },
            method: 'POST',
            body: JSON.stringify(password)
        })
    if (res.ok) {
        debugger;
        const ans = await res.json()
        document.getElementById("checkPassword").innerHTML = ans.score;

    }
    else
        throw new Error("failed, please try later");
}

