// Show branchs
let branchTabMenu = document.querySelectorAll('.atm a')
branchTabMenu[0].classList.add('select_location')

for (let tabMenu of branchTabMenu) {
    tabMenu.onclick = function (e) {
        e.preventDefault()
        let selectLocation = document.querySelector('.select_location')
        selectLocation.classList.remove('select_location')
        this.classList.add('select_location')

        let branchs = document.querySelectorAll('.branch')

        for (let branch of branchs) {
            let id = branch.getAttribute('data-id')

            if (id.includes(this.id)) {
                branch.classList.remove('d-none')
            }
            else {
                branch.classList.add('d-none')
            }
        }
    }
}

window.addEventListener('load', function () {
    branchTabMenu[0].click()
})

// For backend
const branchElements = document.querySelectorAll('.branch')
const locationLinks = document.querySelectorAll('.locations a')

locationLinks.forEach(locationLink => {
    locationLink.addEventListener('click', () => {
        const clickedId = locationLink.getAttribute('id')

        branchElements.forEach(branch => {
            branch.style.display = 'none'
        })

        const firstBranchElements = {}

        branchElements.forEach(branch => {
            const branchDataId = branch.getAttribute('data-id')
            const branchH1 = branch.querySelector('h1').textContent

            if (branchDataId === clickedId || branchDataId.includes(clickedId)) {
                if (!firstBranchElements[branchH1]) {
                    firstBranchElements[branchH1] = branch
                }
            }
        })

        Object.values(firstBranchElements).forEach(branch => {
            branch.style.display = 'flex'
        })
    })
})