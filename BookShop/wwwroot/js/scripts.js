

var navBtn = document.getElementById("myNavBtn");
var desktopNav = document.getElementById("desktopNav");

navBtn.addEventListener("click" , () => {

    if(desktopNav.style.display === "flex"){
        desktopNav.style.display = "none";
    }
    else{
        desktopNav.style.display = "flex";
        desktopNav.style.flexDirection = "column"
    }
});







let countInput = document.getElementById("countInput");
countInput.addEventListener("change" , () => {

    let bookIntPrice = document.getElementById("bookIntPrice");
    let bookShowPrice = document.getElementById("bookShowPrice");
    let count = countInput.value;
    let totalPrice = count * bookIntPrice.value;
    bookShowPrice.innerHTML = `قیمت نهایی : ${totalPrice.toLocaleString()} تومان`;

});

