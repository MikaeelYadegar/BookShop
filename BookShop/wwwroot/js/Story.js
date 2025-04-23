let timeout;
function showStory(element) {
    clearTimeout(timeout);
    const modal = document.getElementById("storyModal");
    const modalImage = document.getElementById("modalImage");
    const modalVideo = document.getElementById("modalVideo");
    clearTimeout(timeout);
    if (element.tagName === "IMG") {
        modalImage.src = element.src;
        modalImage.style.display = "block";
        modalVideo.style.display = "none";
    }
    else if (element.tagName === "Video") {
        modalVideo.src = element.src;
        modalVideo.style.display = "block";
        modalImage.style.display = "none";
        modalVideo.play();
    }
    modal.style.display = "flex";
    
    timeout = setTimeout(() => {
        hideStory();
    },5000);
}
function hideStory() {
    const modal = document.getElementById("storyModal");
    const modalImage = document.getElementById("modalImage");
    const modalVideo = document.getElementById("modalVideo");
    modal.style.display = "none";
    modalImage.style.display = "none";
    modalVideo.style.display = "none";
    modalImage.src = "";
    modalVideo.pause();
    modalVideo.src = "";
    clearTimeout(timeout);
}