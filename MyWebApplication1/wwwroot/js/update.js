function updateUser() {
    const currentUser = sessionStorage.getItem('user');
    const user = JSON.parse(currentUser);
    console.log(user)
    //let detailsUser = document.getElementById("detailsUser");
    //detailsUser.style.setProperty("visibility", "visible");
    let name = document.getElementById("registerEmail");
    console.log(name)
    name.setAttribute("value", user.name)
    let lastName = document.getElementById("registerLastname");
    lastName.setAttribute("value", user.lastName)
    let firstName = document.getElementById("registerFirstName");
    firstName.setAttribute("value", user.firstName)
    let password = document.getElementById("registerPassword");
    password.setAttribute("value", user.password)

}


const update = async () => {
    const currentUser = sessionStorage.getItem('user');
    const user = JSON.parse(currentUser);
    const id = user.id;
    const name = document.getElementById("registerEmail").value;
    const password = document.getElementById("registerPassword").value;
    const firstName = document.getElementById("registerFirstName").value;
    const lastName = document.getElementById("registerLastname").value;

    const newUser = { "name": name, "password": password, "firstName": firstName, "lastName": lastName };
    sessionStorage.setItem('user', JSON.stringify( newUser));

    const res = await fetch(`https://localhost:44351/Api/Users/${id}`,
        {
            headers: { "Content-Type" :"application/json" },
            method: 'PUT',
            body: JSON.stringify(newUser)
        })
    if (res.ok) {
        alert("the updated worked")
        window.location.href="ShoppingBag.html"
    }
    else
        throw new Error("failed, please try later");
}