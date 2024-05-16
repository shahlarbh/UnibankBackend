// Change language
document.querySelectorAll('.login_lang a').forEach(function(lang) {
    lang.addEventListener('click', function() {
        document.querySelector('.login_lang .selected_lang').classList.remove('selected_lang')
        lang.classList.add('selected_lang')
    })
})

// Change cards
let dots = document.querySelectorAll('.card_control span')

for(let dot of dots) {
    dot.onclick = function() {
        let selected_card = document.querySelector('.selected_card')
        selected_card.classList.remove('selected_card')
        this.classList.add('selected_card')

        let id = this.getAttribute('data-id')
        let boxes = document.querySelectorAll('.left_content .box')

        for(let box of boxes) {
            if(id == box.id) {
                box.classList.remove('d-none')
            }
            else{
                box.classList.add('d-none')
            }
        }
    }
}