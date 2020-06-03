window.addEventListener("DOMContentLoaded", function () {
    var direction = document.querySelectorAll(".tabs__direction li button");
    var tabItem = document.querySelectorAll(".tabs__item");
    for (let i = 0; i < direction.length; i++) {
        direction[i].addEventListener("click", activeTabsItem);        
    }
    function activeTabsItem(e) {       
        for (let i = 0; i < tabItem.length; i++) {
            tabItem[i].classList.remove("active__tabs");
            direction[i].classList.remove("active__direction");
        }
        var getId = e.target.getAttribute("data-target");
        var docCurr = document.getElementById(getId);
        e.target.classList.add("active__direction");
        docCurr.classList.add("active__tabs");
    }
});