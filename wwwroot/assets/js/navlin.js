/*const openpage = window.location.pathname;
const navopen = document.querySelectorAll('ul li').forEach(item => {
    if (item.nodeName.includes(`${openpage}`)) {
        item.classList.add('open');
        item.style.background = "#dbe4f3";
    }
})


const openpage = window.location.pathname;
const navlinks = document.querySelectorAll('aside ul li').forEach(item => {
    if (item.location.includes(`${openpage}`)) {
        item.classList.add('open');
        item.style.background = "#dbe4f3";
    }

})

*/


//active 
const activepage = window.location.pathname;
const navlinks = document.querySelectorAll('aside ul a').forEach(link => {
    if (link.href.includes(`${activepage}`)) {
        link.classList.add('active');
        link.style.background = "#dbe4f3";
    }

})
