// Pagination
const newsBoxes = document.querySelectorAll('.news_page .news_box')

document.addEventListener('DOMContentLoaded', () => {
    const itemsPerPage = 3
    let currentPage = 1

    function showPage(pageNumber) {
        newsBoxes.forEach((box, index) => {
            if (index >= (pageNumber - 1) * itemsPerPage && index < pageNumber * itemsPerPage) {
                box.style.display = 'block'
            } else {
                box.style.display = 'none'
            }
        })
    }

    function createPaginationButtons() {
        const paginationDiv = document.querySelector('.pagination')
        paginationDiv.innerHTML = ''

        const totalPages = Math.ceil(newsBoxes.length / itemsPerPage)
        let buttonCount = Math.min(totalPages, 4)

        if (totalPages > 0) {
            if (totalPages < 4) {
                buttonCount = totalPages
            }

            const startPage = Math.min(Math.max(currentPage - 2, 1), totalPages - buttonCount + 1)

            for (let i = startPage; i < startPage + buttonCount; i++) {
                const button = document.createElement('button')
                button.textContent = i
                button.addEventListener('click', () => {
                    currentPage = i
                    showPage(currentPage)
                    createPaginationButtons()
                })

                if (currentPage === i) {
                    button.classList.add('active_page')
                }
                paginationDiv.appendChild(button)
            }

            if (currentPage > 1) {
                const prevButton = document.createElement('button')
                prevButton.textContent = '←'
                prevButton.classList.add('active_direction')
                prevButton.addEventListener('click', () => {
                    currentPage -= 1
                    showPage(currentPage)
                    createPaginationButtons()
                })

                paginationDiv.insertBefore(prevButton, paginationDiv.firstChild)
            }

            if (currentPage < totalPages) {
                const nextButton = document.createElement('button')
                nextButton.textContent = '→'
                nextButton.classList.add('active_direction')
                nextButton.addEventListener('click', () => {
                    currentPage += 1
                    showPage(currentPage)
                    createPaginationButtons()
                })

                paginationDiv.appendChild(nextButton)
            }
        }
    }

    createPaginationButtons()
    showPage(currentPage)

    // Open the all news details
    for (let box of newsBoxes) {
        box.onclick = () => {
            const location = box.getAttribute('data-newsdetails')
            window.location.href = location
        }
    }
})