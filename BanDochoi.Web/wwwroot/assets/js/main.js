let topHeader = document.querySelector(".top-header");
let logo = document.querySelector(".logo p");
let searchForm = document.querySelector(".search-form");
let cartForm = document.querySelector(".cart-form")
window.onscroll = () => {
    let height = window.pageYOffset;
    searchForm.classList.remove("is-active");
    cartForm.classList.remove("is-active");
    if (height > 10) {
        topHeader.style.height = "8rem";
        logo.style.fontSize = "3rem";
    } else {
        topHeader.style.height = "10rem";
        logo.style.fontSize = "3.6rem";
    }
}

let searchBtn = document.querySelector(".search-btn");
searchBtn.onclick = () => {
    searchForm.classList.toggle("is-active");
    cartForm.classList.remove("is-active");
}

let cartBtn = document.querySelector(".cart-btn");
cartBtn.onclick = () => {
    cartForm.classList.toggle("is-active");
    searchForm.classList.remove("is-active");
}

let menuBtn = document.querySelector(".menu-btn");
let menuSection = document.querySelector(".menu-btn div");
let nav = document.querySelector(".nav-links")

menuBtn.onclick = () => {
    menuSection.classList.toggle("change");
    nav.classList.toggle("is-active")
}


let listSlide = document.querySelectorAll(".list-slide");
let progessFill = document.querySelectorAll(".progess-fill");
let slideLen = listSlide.length;
let i = 0;
let submenu = document.querySelector(".submenu");

$(document).ready(function () {
    $('.nav-links>li:nth-last-child(3)').hover(function () {
        submenu.classList.add("active")
    }, function () {
        submenu.classList.remove("active")
    });
});



function slider() {
    if (i > slideLen - 1) {
        i = 0;
    }
    if (i == 0) {
        listSlide[slideLen - 1].classList.remove("active");
        progessFill[slideLen - 1].classList.remove("active");

    } else {
        listSlide[i - 1].classList.remove("active");
        progessFill[i - 1].classList.remove("active");
    }
    listSlide[i].classList.add("active");
    progessFill[i].classList.add("active");
    i++;
    setTimeout(slider, 7000);
}



// swiper

var swiper = new Swiper(".mySwiper", {
    loop: true,
    spaceBetween: 20,
    autoplay: {
        delay: 5000,
        disableOnInteraction: false,
    },
    centeredSlides: true,
    breakpoints: {
        640: {
            slidesPerView: 2,
        },
        768: {
            slidesPerView: 3,
        },
        1024: {
            slidesPerView: 4,
        },
    },
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },
});
