window.addEventListener('DOMContentLoaded', () => {
    var linkTC = document.getElementById('link__tiecCuoi')
    var dropMenuTopbar = document.getElementById('dropdown__menu--topbar')
    linkTC.addEventListener('click', dropdownHeader);
    function dropdownHeader() {
        if (!dropMenuTopbar.classList.contains('active')) {
            dropMenuTopbar.classList.add('active');
        } else {
            dropMenuTopbar.classList.remove('active');
        }
    }
});