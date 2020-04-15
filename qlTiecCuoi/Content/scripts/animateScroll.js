window.addEventListener("DOMContentLoaded", () => {
    window.addEventListener('scroll', (e) => {
        console.log('scrollTop ' + document.documentElement.scrollTop);
        var topbar = document.querySelector('.topbar');
        function scrollTopbar() {
            if (document.documentElement.scrollTop >= 100) {
                topbar.style.backgroundColor = "#fff";
            } else {
                topbar.style.backgroundColor = "transparent";
            }
        }
        scrollTopbar();
    });
});