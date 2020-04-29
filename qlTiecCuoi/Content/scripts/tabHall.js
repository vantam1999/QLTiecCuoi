window.addEventListener("DOMContentLoaded", () => {
    var tabHall = document.querySelectorAll(".tab__link");
    var carouselHall = document.querySelectorAll(".carousel-hall");
    for (let i = 0; i < tabHall.length; i++) {        
        tabHall[i].addEventListener("click", activeHall)
    }
    function activeHall(e) {
        for (let i = 0; i < tabHall.length; i++) {
            tabHall[i].classList.remove("active__tab");
            carouselHall[i].classList.remove("active__carousel");            
        }
        // active tab carousel
        var getTarget = e.target.getAttribute("target");
        console.log(getTarget);
        var getId = document.getElementById(getTarget);
        getId.classList.add("active__carousel");

        // active tab link
        e.target.classList.add("active__tab");
    }
});