window.addEventListener("DOMContentLoaded", () => {
    var openMenu = document.getElementById("openMenu");
    var closeMenu = document.getElementById("closeMenu");
    var albumLeft = document.querySelector(".album__left");
    var albumRight = document.querySelector(".album__right");   
    var albumLeftInside = document.querySelector(".album__left--inside");
    var pageLink = document.querySelectorAll(".page-link");
    var pageInside = document.querySelectorAll(".page .inside");
    // page
    var page = document.querySelectorAll(".page");   
    //var page1 = document.querySelector(".page1");
    //var page2 = document.querySelector(".page2");
    //var page3 = document.querySelector(".page3");
    //var page4 = document.querySelector(".page4");

    // click
    openMenu.addEventListener("click", openPageBook);
    closeMenu.addEventListener("click", closePageBook);
    for (let i = 0; i < pageLink.length; i++) {
        pageLink[i].addEventListener("click", flipPage)
    }

    // function
    function openPageBook() {
        albumLeft.classList.add("activeRotateY");
        albumLeftInside.classList.add("activeShow");
        albumLeft.style.boxShadow = "3px 0 5px #000000";
        albumRight.style.boxShadow = "3px 0 5px #000000";       
    }    

    function flipPage(e) {
        var index = Number(e.target.innerText);      
        for (let i = 0; i < index - 1; i++) {
            pageInside[i].classList.add("activeShow");
            page[i].classList.add("activeRotateY");
        }
        albumLeft.style.zIndex = "1";
        albumRight.style.zIndex = "3"               
        page[index - 2].classList.add("activezIndex");
        page[index - 3].classList.remove("activezIndex");
    }

    function closePageBook() {
        albumLeft.classList.remove("activeRotateY");
        albumLeft.style.zIndex = "3";
        albumRight.style.zIndex = "1";
        albumLeftInside.classList.remove("activeShow");
        albumLeft.style.boxShadow = "0 1px 5px #000000";
        albumRight.style.boxShadow = "0 1px 5px #000000";
        for (let i = 0; i < page.length; i++) {
            page[i].classList.remove("activeRotateY");
            pageInside[i].classList.remove("activeShow");
        }
    }
}); 