const brandsSlider = document.getElementById('brandsSlider');
const imageSources = [
    "/asstes/img/Nokia_Icon-removebg-preview.png",
    "/asstes/img/hp_icon-removebg-preview.png",
    "/asstes/img/Samsung_Image-removebg-preview.png",
    "/asstes/img/motorola_icon-removebg-preview.png",
    "/asstes/img/AppleImage-removebg-preview.png",
    "/asstes/img/Huway_icon-removebg-preview.png"
];
let currentIndex = 5;
setInterval(() => {
    brandsSlider.removeChild(brandsSlider.firstElementChild);
    const newImg = document.createElement("img");
    newImg.src = imageSources[currentIndex];
    newImg.alt = "Brand";
    brandsSlider.appendChild(newImg);
    currentIndex = (currentIndex + 1) % imageSources.length;
}, 2000);