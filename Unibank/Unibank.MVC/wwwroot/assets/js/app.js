// Change menu
document.querySelectorAll('.menu a').forEach(menu => {
    menu.addEventListener('click', () => {
        document.querySelector('.menu .active').classList.remove('active')
        menu.classList.add('active')
    })
})

// Change language
document.querySelectorAll('.lang a').forEach(lang => {
    lang.addEventListener('click', () => {
        document.querySelector('.lang .d-none').classList.remove('d-none')
        lang.classList.add('d-none')
    })
})

// Darkmode with session storage & autotime
function toggleTheme(isDaytime) {
    const darkMode = document.querySelector('.theme .moon')
    const lightMode = document.querySelector('.theme .sun')
    const responsiveDarkMode = document.querySelector('.theme_hamburger .moon')
    const responsiveLightMode = document.querySelector('.theme_hamburger .sun')

    if (isDaytime) {
        document.body.classList.remove('darkmode')
        darkMode.classList.remove('d-none')
        lightMode.classList.add('d-none')
        responsiveDarkMode.classList.remove('d-none')
        responsiveLightMode.classList.add('d-none')
    }
    else {
        document.body.classList.add('darkmode')
        darkMode.classList.add('d-none')
        lightMode.classList.remove('d-none')
        responsiveDarkMode.classList.add('d-none')
        responsiveLightMode.classList.remove('d-none')
    }
}

function setChatIconVisibility(isDaytime) {
    const chatIcon = document.querySelector('.chat_icon')
    const hour = new Date().getHours()

    if (hour >= 6 && hour < 18) {
        chatIcon.classList.remove('d-none')
    }
    else {
        chatIcon.classList.add('d-none')
    }
}

function setThemeBasedOnTime() {
    const hour = new Date().getHours()
    const isDaytime = hour >= 6 && hour < 18
    toggleTheme(isDaytime)
    sessionStorage.setItem('isDaytime', isDaytime.toString())
    setChatIconVisibility(isDaytime)
}

function initializeLocalStorage() {
    const storedValue = sessionStorage.getItem('isDaytime')

    if (storedValue === null) {
        setThemeBasedOnTime()
    }
    else {
        updateTheme()
    }
}

function updateTheme() {
    const storedValue = sessionStorage.getItem('isDaytime')
    const isDaytime = storedValue === 'true'
    toggleTheme(isDaytime)
    setChatIconVisibility(isDaytime)
}

document.addEventListener('DOMContentLoaded', () => {
    initializeLocalStorage()

    const sunIcons = document.querySelectorAll('.theme .sun, .theme_hamburger .sun')
    const moonIcons = document.querySelectorAll('.theme .moon, .theme_hamburger .moon')

    sunIcons.forEach(icon => {
        icon.addEventListener('click', () => {
            const isDaytime = true
            toggleTheme(isDaytime)
            sessionStorage.setItem('isDaytime', 'true')
            setChatIconVisibility(isDaytime, true)
        })
    })

    moonIcons.forEach(icon => {
        icon.addEventListener('click', () => {
            const isDaytime = false
            toggleTheme(isDaytime)
            sessionStorage.setItem('isDaytime', 'false')
            setChatIconVisibility(isDaytime, true)
        })
    })

    window.addEventListener('storage', event => {
        if (event.key === 'isDaytime') {
            updateTheme()
        }
    })

    setInterval(setThemeBasedOnTime, 3600000)
})

// Search panel
let searchLoop = document.querySelector('.search_loop')
let searchPanel = document.querySelector('.search_panel')
let hiddenPanel = document.querySelector('.hidden_panel')
let closePanel = document.querySelector('.close')
let loop = document.querySelector('.loop')

searchLoop.onclick = () => {
    searchPanel.classList.toggle('d-none')
    document.querySelector('body').classList.toggle('noscroll')
    hiddenPanel.classList.remove('active_search')
}

closePanel.onclick = () => {
    searchPanel.classList.add('d-none')
    document.querySelector('body').classList.toggle('noscroll')
}

loop.onclick = () => hiddenPanel.classList.toggle('active_search')

// Hamburger menu
let hamburgerMenu = document.querySelector('.hamburger_icon')
let hamburgerPanel = document.querySelector('.hamburger_panel')

hamburgerMenu.onclick = () => {
    hamburgerPanel.classList.toggle('active_hamburger')
    document.querySelector('body').classList.toggle('noscroll')
}

// Change responsive menu
document.querySelectorAll('.menu_hamburger a').forEach(menu => {
    menu.addEventListener('click', () => {
        document.querySelector('.menu_hamburger .active').classList.remove('active')
        menu.classList.add('active')
    })
})

// Change responsive language
document.querySelectorAll('.responsive_language a').forEach(lang => {
    lang.addEventListener('click', () => {
        document.querySelector('.responsive_language .d-none').classList.remove('d-none')
        lang.classList.add('d-none')
    })
})

// Select location for pages
const allLinks = document.querySelectorAll('.hr_links a, .transfer_link a')

allLinks.forEach(link => {
    link.addEventListener('click', event => {
        event.preventDefault()

        allLinks.forEach(otherLink => {
            otherLink.classList.remove('select_location')
        })

        link.classList.add('select_location')
        window.location.href = link.getAttribute('href')
    })
})

const currentURL = window.location.href

allLinks.forEach(link => {
    if (link.href === currentURL) {
        link.classList.add('select_location')
    }
})

// Click the digital box
let digitalBox = document.querySelectorAll('.digital_box')

for (let box of digitalBox) {
    box.onclick = () => {
        const url = box.getAttribute('data-url')
        window.location.href = url
    }
}

// Play video
function playVideo() {
    let iframe = document.querySelector('.unibank_video iframe')
    iframe.setAttribute("src", iframe.getAttribute("src") + "&autoplay=1")

    iframe.style.opacity = '1'
    iframe.style.height = '400px'

    document.querySelector('.unibank_video').style.height = '400px'
    document.querySelector('.unibank_video i').style.opacity = '0'
}

// Click the contact box
let contactBox = document.querySelectorAll('.contact_box')

for (let box of contactBox) {
    box.onclick = () => {
        const location = box.getAttribute('data-location')
        window.location.href = location

        if (location === '#chat') {
            chatIcon.onclick()
        }
    }
}

// Click the top news details
let newsBox = document.querySelectorAll('.news .box')

for (let box of newsBox) {
    box.onclick = () => {
        const location = box.getAttribute('data-news')
        window.location.href = location
    }
}

// Click the bank boxes
let bankBoxes = document.querySelectorAll('.bank_boxes .bank_box')

for (let box of bankBoxes) {
    box.onclick = () => {
        const location = box.getAttribute('data-about')
        window.location.href = location
    }
}

// Click the HR boxes
let hrBoxes = document.querySelectorAll('.hr_information .box')

for (let box of hrBoxes) {
    box.onclick = () => {
        const location = box.getAttribute('data-hr')
        window.location.href = location
    }
}

// Backend search
$(document).on('keyup', '#commonSearch', function () {
    var searchedNavigation = $(this).val();
    var searchResultContainer = $("#searchResult");

    searchResultContainer.empty();

    $.ajax({
        url: "/home/search?SearchedNavigation=" + searchedNavigation,
        type: "GET",
        success: function (response) {
            searchResultContainer.append(response);
        },
        error: function (xhr) {

        }
    });
});

let searchArea = document.querySelector('.search_panel input')
searchArea.oninput = () => hiddenPanel.classList.add('active_search')