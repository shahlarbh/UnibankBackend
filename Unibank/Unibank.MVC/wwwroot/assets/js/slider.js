// Slider carusel
let slider = document.querySelector('.slider')
let sliderCount = document.querySelectorAll('.slider .slider_page').length
slider.style.width = `${100 * sliderCount}%`

const caruselControl = document.querySelector('.carusel_control ul')

for (let i = 0; i < sliderCount; i++) {
    const sliderControl = document.createElement('li')
    caruselControl.appendChild(sliderControl)
}

caruselControl.querySelector('li').classList.add('selected')

const indicators = document.querySelectorAll('.carusel_control ul li')
let currentIndex = 0

indicators.forEach((indicator, index) => {
    indicator.addEventListener('click', () => {
        document.querySelector('.carusel_control .selected').classList.remove('selected')
        indicator.classList.add('selected')
        currentIndex = index

        updateSliderPosition()
    })
})

function updateSliderPosition() {
    const translateX = currentIndex * (-100 / sliderCount)
    slider.style.transform = `translate(${translateX}%)`
}

function updateSelectedIndicator() {
    document.querySelector('.carusel_control .selected').classList.remove('selected')
    indicators[currentIndex].classList.add('selected')
}

function nextSlider() {
    currentIndex = (currentIndex + 1) % indicators.length
    updateSliderPosition()
    updateSelectedIndicator()
}

setInterval(nextSlider, 3000)