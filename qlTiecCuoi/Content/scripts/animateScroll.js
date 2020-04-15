window.addEventListener("DOMContentLoaded", () => {
    window.addEventListener('scroll', (e) => {
        console.log('scrollTop ' + document.documentElement.scrollTop);
        var topbar = document.querySelector('.topbar');       
        function scrollTopbar() {
            if (document.documentElement.scrollTop >= 100) {
                topbar.classList.add('active');
                
            } else {
                topbar.classList.remove('active');
            }
        }
        scrollTopbar();
    });
});