window.onload = autoFooter;
window.onresize = autoHeader;

function autoHeader() {
    var divHeader = window.document.getElementById('divHeader');
    var divEmptyHeader = window.document.getElementById('divEmptyHeader');

    var headerHeight = divHeader.offsetHeight;

    divEmptyHeader.style.height = headerHeight + 'px';
}

function autoFooter()
{
    var footer = window.document.getElementById('footer');
    var bodyHeight = window.document.getElementById('body').scrollHeight;
    var windowHeight = document.documentElement.clientHeight;

    if (windowHeight > bodyHeight) {
        footer.style.position = "absolute";
        footer.style.bottom = "0";
    }
    else {
        footer.style.position = "static";
        footer.style.bottom = "";
    }
}