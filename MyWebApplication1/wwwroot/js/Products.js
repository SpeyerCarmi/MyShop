window.addEventListener("load", GetProduct());
window.addEventListener("load", GetCategory());


function ItemsCountText(){
    let myCartAsJson = sessionStorage.getItem('myCart')
    myCart = JSON.parse(myCartAsJson)
    if (myCart == null)
        myCart = []
    document.getElementById("ItemsCountText").innerHTML = myCart.length
}

async function GetProduct() {
    

    const res = await fetch(`https://localhost:44351/api/Product`)
    const res1 = await res.json();
    ShowProduct(res1);
    ItemsCountText();
    return res1;
}
function ShowProduct(products) {
    document.getElementById("counter").innerHTML = products.length
    products.forEach(product => ShowProducts(product))
}
function ShowProducts(product) {
    var price = String(product.price);
    var tmp = document.getElementById("temp-card");
    var clon = tmp.content.cloneNode(true);
    clon.querySelector("h1").innerText = product.name;
    clon.querySelector(".price").innerText = price +'₪';
    clon.querySelector(".author").innerText = product.author;
    clon.querySelector(".description").innerText = product.description;
    clon.querySelector(".btn").addEventListener('click', () => { addToCart(product) });

    clon.querySelector("img").src = "./img/" + product.imageUrl;

    document.body.appendChild(clon);
   
}
async function GetCategory() {
    const res = await fetch(`https://localhost:44351/api/Category`)
    const res1 = await res.json();
    ShowCategory(res1)
}
function ShowCategory(Category) {
    Category.forEach(category => ShowCategorys(category))
}


function ShowCategorys(category) {
    var tmp = document.getElementById("temp-category");
    var clon = tmp.content.cloneNode(true);
    clon.querySelector(".opt").id = category.id;
    clon.querySelector(".opt").value = category.id;
    clon.querySelector(".OptionName").innerText = category.name;
    clon.querySelector(".opt").addEventListener('click', filterProducts);
    document.getElementById("categoryList").appendChild(clon);
}



function removeProduct() {
    const res = document.getElementsByClassName("card");
    for (let i = res.length - 1; i >= 0; i--) {
        var prod = res[i]
        document.body.removeChild(prod);
    }
}

const filterByCategories =  ()=>  {
    var selectedCategoryId = []
    var categories = document.getElementsByClassName("opt")
    for (var i = 0; i < categories.length; i++) {
        if (categories[i].checked) {
            selectedCategoryId.push(categories[i].value)

        }
    }
    return selectedCategoryId
}
const queryString = (categoriesId = null, name = null, author=null, minPrice = null, maxPrice = null) => {
    let queryString = "";
    name != null ? queryString += `&name=${name}` : queryString += ``;
    author != null ? queryString += `&author=${author}` : queryString += ``;
    minPrice != null ? queryString += `&minPrice=${minPrice}` : queryString += ``;
    maxPrice != null ? queryString += `&maxPrice=${maxPrice}` : queryString += ``;
    if (categoriesId != null) {
        categoriesId.forEach(categoryId => {
            queryString += `&categoryId=${categoryId}`;
        });
    }
    console.log(queryString)   
    filterProduct(queryString)

        }
const filterProduct = async (queryString) => {
    const res = await fetch(`https://localhost:44351/api/Product/?${queryString}`)

    if (!res.ok)
        throw new Error(`the connect failed ${response.status}, try again`);
    if (res.status == 204) {
        console.log("no products");
        await removeProduct()
        return;
    }
    const dataProducts = await res.json();
    await removeProduct()
    ShowProduct(dataProducts)

}

const filterProducts = () => {
    const selectedCategoryId = filterByCategories();
    const name = document.getElementById("nameSearch").value;
    const author = document.getElementById("authorSearch").value;
    const minPrice = document.getElementById("minPrice").value;
    const maxPrice = document.getElementById("maxPrice").value;
    queryString(selectedCategoryId, name, author, minPrice, maxPrice)

}
const addToCart = (product) => {
    let myCartAsJson = sessionStorage.getItem('myCart')
    myCart = JSON.parse(myCartAsJson)
    if (myCart == null)
       myCart = []
  myCart.push(product)
    document.getElementById("ItemsCountText").innerHTML = myCart.length
    sessionStorage.setItem('myCart',JSON.stringify(myCart))
}

const getMyCartFromSession = () => {
    let myCartAsJson = sessionStorage.getItem('myCart')
    myCart = JSON.parse(myCartAsJson)
}
        

 
