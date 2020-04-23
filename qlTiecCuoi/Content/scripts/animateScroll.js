window.addEventListener("DOMContentLoaded", () => {
    var widthWindow = window.innerWidth;
    console.log('width window = ' + widthWindow);
    window.addEventListener('scroll', (e) => {        
        var topbar = document.querySelector('.topbar');
        var backTop = document.querySelector('.backTop');

        // ==== console log ==== //
        //console.log('scrollTop ' + document.documentElement.scrollTop);        

        // ==== scroll topbar ==== //
        function scrollTopbar() {
            if (document.documentElement.scrollTop >= 100) {
                topbar.classList.add('active');
                
            } else {
                topbar.classList.remove('active');
            }
        }

        // ==== scroll back to top ==== //
        function scrollBackTop() {
            if (document.documentElement.scrollTop >= (widthWindow / 2)) {
                backTop.classList.add('active');
            } else {
                backTop.classList.remove('active');
            }                
                
        }

        // ============= //
        scrollTopbar();
        scrollBackTop();
    });
});