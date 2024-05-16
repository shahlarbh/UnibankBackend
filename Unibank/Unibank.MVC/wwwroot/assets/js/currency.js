// Currency update time
function formatDate(date) {
    const day = date.getDate().toString().padStart(2, '0')
    const month = (date.getMonth() + 1).toString().padStart(2, '0')
    const year = date.getFullYear()
    return `${day}.${month}.${year}`
}

const currentDate = new Date()
const formattedDate = formatDate(currentDate)

let updateCurrency = document.querySelectorAll('.update_time')

updateCurrency.forEach(element => {
    element.innerHTML = `Yeniləndi ${formattedDate}`
})

let usdCurr = document.querySelectorAll('.usd_curr')
let eurCurr = document.querySelectorAll('.eur_curr')
let gbpCurr = document.querySelectorAll('.gbp_curr')
let rubCurr = document.querySelectorAll('.rub_curr')

function getCurrency() {
    fetch('http://data.fixer.io/api/latest?access_key=db914b2c3f399dce8af5d6acebd4b355')
        .then(response => response.json())
        .then(data => {
            // Change main currency from EUR to AZN
            const azn = (data.rates['AZN'] / data.rates['AZN']).toFixed(4)
            const eur = (data.rates['EUR'] * data.rates['AZN']).toFixed(4)
            const usd = (data.rates['EUR'] / data.rates['USD'] * data.rates['AZN']).toFixed(4)
            const gbp = (data.rates['EUR'] / data.rates['GBP'] * data.rates['AZN']).toFixed(4)
            const rub = (data.rates['EUR'] / data.rates['RUB'] * data.rates['AZN']).toFixed(4)

            // Fill the dynamic currency table
            usdCurr.forEach(element => element.innerHTML = usd)
            eurCurr.forEach(element => element.innerHTML = eur)
            gbpCurr.forEach(element => element.innerHTML = gbp)
            rubCurr.forEach(element => element.innerHTML = rub)

            // Convert currency
            let firstInput = document.querySelector('.first_input')
            let secondInput = document.querySelector('.second_input')

            function convertCurrency(inputValue, fromCurrency, toCurrency) {
                if (isNaN(inputValue)) {
                    inputValue = 0
                }

                switch (`${fromCurrency}_${toCurrency}`) {
                    case 'USD_AZN':
                        return (inputValue * usd).toFixed(2)
                    case 'USD_EUR':
                        return (inputValue * usd / eur).toFixed(2)
                    case 'USD_GBP':
                        return (inputValue * usd / gbp).toFixed(2)
                    case 'USD_RUB':
                        return (inputValue * usd / rub).toFixed(2)
                    case 'USD_USD':
                        return inputValue
                    case 'EUR_USD':
                        return (inputValue * eur / usd).toFixed(2)
                    case 'EUR_GBP':
                        return (inputValue * eur / gbp).toFixed(2)
                    case 'EUR_AZN':
                        return (inputValue * eur / azn).toFixed(2)
                    case 'EUR_RUB':
                        return (inputValue * eur / rub).toFixed(2)
                    case 'EUR_EUR':
                        return inputValue
                    case 'AZN_USD':
                        return (inputValue / usd).toFixed(2)
                    case 'AZN_EUR':
                        return (inputValue / eur).toFixed(2)
                    case 'AZN_GBP':
                        return (inputValue / gbp).toFixed(2)
                    case 'AZN_RUB':
                        return (inputValue / rub).toFixed(2)
                    case 'AZN_AZN':
                        return inputValue
                    case 'GBP_AZN':
                        return (inputValue * gbp / azn).toFixed(2)
                    case 'GBP_USD':
                        return (inputValue * gbp / usd).toFixed(2)
                    case 'GBP_EUR':
                        return (inputValue * gbp / eur).toFixed(2)
                    case 'GBP_RUB':
                        return (inputValue * gbp / rub).toFixed(2)
                    case 'GBP_GBP':
                        return inputValue
                    case 'RUB_AZN':
                        return (inputValue * rub / azn).toFixed(2)
                    case 'RUB_USD':
                        return (inputValue * rub / usd).toFixed(2)
                    case 'RUB_EUR':
                        return (inputValue * rub / eur).toFixed(2)
                    case 'RUB_GBP':
                        return (inputValue * rub / gbp).toFixed(2)
                    case 'RUB_RUB':
                        return inputValue
                    default:
                        return inputValue
                }
            }

            function handleConversion() {
                let firstValue = parseFloat(firstInput.value)
                let mainCurrency = firstCurr.innerHTML
                let secondCurrency = secondCurr.innerHTML

                if (mainCurrency !== secondCurrency) {
                    let result = convertCurrency(firstValue, mainCurrency, secondCurrency)
                    secondInput.value = result
                } else {
                    secondInput.value = firstValue.toFixed(2)
                }
            }

            document.querySelectorAll('.exchange_div a').forEach(exchange => {
                exchange.addEventListener('click', () => {
                    firstInput.oninput()
                    secondInput.oninput()
                })
            })

            firstInput.oninput = handleConversion
            secondInput.oninput = () => {
                let secondValue = parseFloat(secondInput.value)
                let mainCurrency = secondCurr.innerHTML
                let secondCurrency = firstCurr.innerHTML

                if (mainCurrency !== secondCurrency) {
                    let result = convertCurrency(secondValue, mainCurrency, secondCurrency)
                    firstInput.value = result
                } else {
                    firstInput.value = secondValue.toFixed(2)
                }
            }
        })
        .catch(error => console.log(error))
}

getCurrency()

// Show exchange_div
function toggleBox(box, exchange, chevron) {
    box.onclick = () => {
        exchange.classList.toggle('d-none')
        chevron.classList.toggle('rotate')
    }
}

const firstBox = document.querySelector('.first_box')
const secondBox = document.querySelector('.second_box')
const firstExchange = document.querySelector('.first_exchange')
const secondExchange = document.querySelector('.second_exchange')
const firstChevron = document.querySelector('.first_chevron')
const secondChevron = document.querySelector('.second_chevron')

toggleBox(firstBox, firstExchange, firstChevron)
toggleBox(secondBox, secondExchange, secondChevron)

// Change currency
function toggleExchange(exchanges, currencyElement, boxElement, flagElement) {
    exchanges.forEach(exchange => {
        exchange.onclick = e => {
            e.preventDefault();

            exchanges.forEach(item => {
                if (exchange !== item) {
                    item.classList.remove('d-none')
                } else {
                    item.classList.add('d-none')
                }
            })

            boxElement.onclick()

            let exchangeSpan = exchange.querySelectorAll('span')
            currencyElement.innerHTML = exchangeSpan[1].innerHTML

            if (exchangeSpan[1].innerHTML in flags) {
                flagElement.style.backgroundImage = `url(${flags[exchangeSpan[1].innerHTML]})`
            }
        }
    })
}

const exchangeFirst = document.querySelectorAll('.first_exchange a')
const exchangeSecond = document.querySelectorAll('.second_exchange a')
const firstCurr = document.querySelector('.first_currency')
const secondCurr = document.querySelector('.second_currency')
const firstFlag = document.querySelector('#first_flag')
const secondFlag = document.querySelector('#second_flag')
const flags = {
    'AZN': 'https://unibank.az/assets/images/azn.png',
    'USD': 'https://unibank.az/assets/images/usd.png',
    'RUB': 'https://unibank.az/assets/images/rub.png',
    'GBP': 'https://unibank.az/assets/images/gbp.png',
    'EUR': 'https://unibank.az/assets/images/euro.png'
}

toggleExchange(exchangeFirst, firstCurr, firstBox, firstFlag, 'AZN')
toggleExchange(exchangeSecond, secondCurr, secondBox, secondFlag, 'USD')

// Responsive currency tabmenu
let currencyTabMenu = document.querySelectorAll('.currency_tabmenu a')
let divs = document.querySelectorAll('.currency_box .box')

currencyTabMenu[0].classList.add('selected_tab')

for (let i = 1; i < divs.length; i++) {
    divs[i].classList.add('display_none')
}

for (let tabMenu of currencyTabMenu) {
    tabMenu.onclick = function (e) {
        e.preventDefault()
        let selectedTab = document.querySelector('.selected_tab')
        selectedTab.classList.remove('selected_tab')
        this.classList.add('selected_tab')

        let id = this.getAttribute('data-id')

        for (let div of divs) {
            if (id == div.id) {
                div.classList.remove('display_none')
            }

            else {
                div.classList.add('display_none')
            }
        }
    }
}