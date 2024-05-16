// Category filter
document.querySelector('#select_category').addEventListener('change', function () {
    let value = this.value
    let boxes = document.querySelectorAll('.partner_box')

    for (let box of boxes) {
        let category = box.getAttribute('data-category')

        if (value === '' || value === category) {
            box.style.display = 'block'
        } else {
            box.style.display = 'none'
        }
    }
})

// Partner filter
document.addEventListener('DOMContentLoaded', () => {
    let selectCategory = document.querySelector('#select_category')
    let selectPartner = document.querySelector('#select_partner')
    let partnerBoxes = document.querySelectorAll('.partner_box')

    selectCategory.addEventListener('change', () => {
        let selectedCategory = selectCategory.value
        loadMoreButton.textContent = 'Tam siyahı'

        for (let i = 0; i < selectPartner.options.length; i++) {
            selectPartner.options[i].style.display = 'none'
        }

        for (let i = 0; i < partnerBoxes.length; i++) {
            let partnerBox = partnerBoxes[i]
            let partnerCategory = partnerBox.getAttribute('data-category')
            let partnerOptionValue = partnerBox.getAttribute('data-partner')

            if (selectedCategory === '' || partnerCategory === selectedCategory) {
                partnerBox.style.display = 'block'
                selectPartner.querySelector('option[value="' + partnerOptionValue + '"]').style.display = 'block'
            }
            else {
                partnerBox.style.display = 'none'
            }
        }

        selectPartner.selectedIndex = 0
    })

    selectPartner.addEventListener('change', () => {
        let selectedPartner = selectPartner.value
        loadMoreButton.textContent = 'Tam siyahı'

        for (let i = 0; i < partnerBoxes.length; i++) {
            let partnerBox = partnerBoxes[i]
            let partnerOptionValue = partnerBox.getAttribute('data-partner')
            let partnerCategory = partnerBox.getAttribute('data-category')

            if ((selectedPartner === '' || partnerOptionValue === selectedPartner) && (selectCategory.value === '' || partnerCategory === selectCategory.value)) {
                partnerBox.style.display = 'block'
            }
            else {
                partnerBox.style.display = 'none'
            }
        }
    })
})

// Search filter
let searchInput = document.querySelector('#searchInput')
let partnerContainer = document.querySelector('#partnerContainer')
let partnerBoxes = partnerContainer.querySelectorAll('.partner_box')
let loadMoreButton = document.querySelector('#loadMore')

searchInput.addEventListener('input', function () {
    let searchValue = this.value.trim().toLowerCase()
    loadMoreButton.textContent = 'Tam siyahı'

    for (let box of partnerBoxes) {
        let partnerInfo = box.querySelector('.partner_info')
        let partnerText = partnerInfo.textContent || partnerInfo.innerText
        let isMatched = partnerText.toLowerCase().indexOf(searchValue) !== -1
        box.style.display = isMatched ? 'block' : 'none'
    }

    if (searchValue === '') {
        resetToInitialState()
    }
})

function resetToInitialState() {
    for (let i = 0; i < partnerBoxes.length; i++) {
        if (i < 10) {
            partnerBoxes[i].style.display = 'block'
        } else {
            partnerBoxes[i].style.display = 'none'
        }
    }
    loadMoreButton.textContent = 'Tam siyahı'
}

// Load more
document.addEventListener('DOMContentLoaded', () => {
    const partnerBoxes = partnerContainer.querySelectorAll('.partner_box')

    loadMoreButton.addEventListener('click', event => {
        event.preventDefault()

        if (loadMoreButton.textContent === 'Daha az göstər') {
            resetToInitialState()
        } else {
            for (let i = 0; i < partnerBoxes.length; i++) {
                partnerBoxes[i].style.display = 'block'
            }
            loadMoreButton.textContent = 'Daha az göstər'
        }
    })

    resetToInitialState()
})

// Sort filter
document.addEventListener('DOMContentLoaded', () => {

    const partners = document.querySelectorAll('.partner_box')
    const partnerContainer = document.querySelector('#partnerContainer')

    function sortedFilter(sorted) {
        switch (sorted) {
            case '1':
                Array.from(partners).sort((a, b) => a.querySelector('h4').innerText.localeCompare(b.querySelector('h4').innerText)).forEach(partner => partnerContainer.appendChild(partner))
                break
            case '2':
                Array.from(partners).sort((a, b) => b.querySelector('h4').innerText.localeCompare(a.querySelector('h4').innerText)).forEach(partner => partnerContainer.appendChild(partner))
                break
            case '3':
                Array.from(partners).sort((a, b) => parseFloat(a.querySelector('h2').innerText) - parseFloat(b.querySelector('h2').innerText)).forEach(partner => partnerContainer.appendChild(partner))
                break
            case '4':
                Array.from(partners).sort((a, b) => parseFloat(b.querySelector('h2').innerText) - parseFloat(a.querySelector('h2').innerText)).forEach(partner => partnerContainer.appendChild(partner))
                break
            default:
                break
        }
    }

    const sortFilter = document.querySelector('#sortFilter')
    sortFilter.addEventListener('change', () => {
        const sorted = sortFilter.value
        sortedFilter(sorted)
    })

    sortedFilter('1')
})

// Cashback infobox
let cashbackTabMenu = document.querySelectorAll('.cashback_tabs a')
let cashbackContext = document.querySelectorAll('.cashback_information .cashback_context')

cashbackTabMenu[0].classList.add('selected_tab')

for (let i = 1; i < cashbackContext.length; i++) {
    cashbackContext[i].classList.add('d-none')
}

for (let tabMenu of cashbackTabMenu) {
    tabMenu.onclick = function (e) {
        e.preventDefault()
        let selectedTab = document.querySelector('.selected_tab')
        selectedTab.classList.remove('selected_tab')
        this.classList.add('selected_tab')

        let id = this.getAttribute('data-id')

        for (let context of cashbackContext) {
            if (id == context.id) {
                context.classList.remove('d-none')
            }

            else {
                context.classList.add('d-none')
            }
        }
    }
}

// Responsive cashback tabmenu
let responsiveTabMenu = document.querySelector('#responsive_tabmenu')
let cashbackHeader = document.querySelector('.cashback_header')

responsiveTabMenu.onclick = () => cashbackHeader.classList.toggle('steels')

// Responsive cashback infobox
let responsiveTabs = document.querySelectorAll('.responsive_cashback_tabs a')
let responsiveContexts = document.querySelectorAll('.responsive_cashback .cashback_context')

responsiveTabs[0].classList.add('selected_tab')
document.querySelectorAll('.responsive_cashback_tabs a i')[0].classList.add('active_arrow')

for (let i = 1; i < responsiveContexts.length; i++) {
    responsiveContexts[i].classList.add('d-none')
}

for (let tab of responsiveTabs) {
    tab.addEventListener('click', function (e) {
        e.preventDefault()
        this.classList.toggle('selected_tab')

        let id = this.getAttribute('data-id')

        for (let context of responsiveContexts) {
            if (id == context.id) {
                context.classList.toggle('d-none')
                tab.querySelector('i').classList.toggle('active_arrow')
            }
        }
    })
}

// Open the cashback details
let cashbackBoxes = document.querySelectorAll('.cashback_partners .partner_box')

for (let box of cashbackBoxes) {
    box.onclick = () => {
        const location = box.getAttribute('data-cashback')
        window.location.href = location
    }
}

// Calculate cashback
document.querySelector('#category').addEventListener('change', function () {
    let selectedCategoryId = this.value
    let partnerSelect = document.querySelector('#partner')
    let partnerOptions = partnerSelect.getElementsByTagName('option')
    let initialPartnerSelected = false

    for (let i = 0; i < partnerOptions.length; i++) {
        let partnerDataValue = partnerOptions[i].getAttribute('data-value')
        if (!selectedCategoryId || partnerDataValue === selectedCategoryId) {
            partnerOptions[i].style.display = 'block'
            if (!initialPartnerSelected) {
                partnerOptions[i].selected = true
                initialPartnerSelected = true
                updateCashback(partnerOptions[i].value)
            }
        } else {
            partnerOptions[i].style.display = 'none'
            partnerOptions[i].selected = false
        }
    }
})

document.querySelector('#partner').addEventListener('change', function () {
    updateCashback(this.value)
})

document.querySelector('#calculate_cashback').addEventListener('input', function () {
    let cash = this.value
    let percentage = Number(document.querySelector('#hideCashback').innerHTML)
    document.querySelector('#cashback').innerHTML = cash * percentage / 100
})

function updateCashback(partnerValue) {
    let boxes = document.querySelectorAll('.partner_box')
    for (let box of boxes) {
        let partner = box.getAttribute('data-partner')
        if (partnerValue === partner) {
            let cashback = Number((box.querySelector('h2').innerHTML)
                .slice(0, box.querySelector('h2').innerHTML.length - 1))

            document.querySelector('#hideCashback').innerHTML = cashback
            document.querySelector('#calculate_cashback').dispatchEvent(new Event('input'))
            return
        }
    }
}