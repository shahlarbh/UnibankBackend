// Change language
document.querySelectorAll('.password_lang a').forEach(function(lang) {
    lang.addEventListener('click', function() {
        document.querySelector('.password_lang .selected_lang').classList.remove('selected_lang')
        lang.classList.add('selected_lang')
    })
})

// Show password
document.querySelectorAll('.reset_input i').forEach(function(icon) {
    icon.addEventListener('click', function() {
        let id = this.getAttribute('data-id')
        let inputs = document.querySelectorAll('.reset_input input')

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