let chatIcon = document.querySelector('.chat_icon')
let unibankChat = document.querySelector('.unibank_chat')
let closeChat = document.querySelector('.close_chat')

// Open chat
chatIcon.onclick = () => {
    unibankChat.classList.remove('d-none')
    chatIcon.classList.add('d-none')
    document.body.classList.add('chat_scroll')
}

// Close chat
closeChat.onclick = () => {
    unibankChat.classList.add('d-none')
    chatIcon.classList.remove('d-none')
    document.body.classList.remove('chat_scroll')
    chatOptions.classList.add('d-none')
}

// Open/close the options menu in chat
let options = document.querySelector('.options')
let chatOptions = document.querySelector('.chat_options')

options.onclick = () => chatOptions.classList.toggle('d-none')

// Sound on/off
let volumeOptions = document.querySelector('.volume_options')
let changeVolume = document.querySelector('.change_volume')
let maxVolume = document.querySelector('.max_volume')
let minVolume = document.querySelector('.min_volume')

volumeOptions.onclick = () => {
    volumeOptions.classList.toggle('color_transfer')
    changeVolume.classList.toggle('margin_transfer')
    maxVolume.classList.toggle('d-none')
    minVolume.classList.toggle('d-none')
}