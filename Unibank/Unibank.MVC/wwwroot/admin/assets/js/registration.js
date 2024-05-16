// Change language
document.querySelectorAll('.registration_lang a').forEach(function(lang) {
    lang.addEventListener('click', function() {
        document.querySelector('.registration_lang .selected_lang').classList.remove('selected_lang')
        lang.classList.add('selected_lang')
    })
})

// Show password
document.querySelectorAll('.registration_input i').forEach(function(icon) {
    icon.addEventListener('click', function() {
        let id = this.getAttribute('data-id')
        let inputs = document.querySelectorAll('.registration_input input')

        for(let input of inputs) {
            if(id === input.id) {
                if(input.type === 'password') {
                    input.type = 'text'
                    icon.classList.replace('fa-eye', 'fa-eye-slash')
                }
                else{
                    input.type = 'password'
                    icon.classList.replace('fa-eye-slash', 'fa-eye')
                }
            }
        }
    })
})