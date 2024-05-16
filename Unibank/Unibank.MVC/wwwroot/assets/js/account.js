// Log out
let log = document.querySelector('.log')

log.onclick = () => document.querySelector('.logout').classList.toggle('d-none')

// Request count
let requestContent = document.querySelectorAll('.request_result .request_content')
let requestCount = 0

for (let content of requestContent) {
    if (content.innerHTML !== '') {
        requestCount++
    }
}

document.querySelector('.request_box span').innerHTML = requestCount

if (requestCount == 0) {
    document.querySelector('.alert').classList.remove('d-none')
}
else {
    document.querySelector('.alert').classList.add('d-none')
}

let requestResult = document.querySelectorAll('.request_result')

for (let result of requestResult) {
    if (result.querySelector('.request_content').innerHTML == '') {
        result.classList.add('d-none')
    }
    else {
        result.classList.remove('d-none')
    }
}

// Request row
let requestRow = document.querySelectorAll('.request_result .request_row')

if (requestCount > 0) {
    for (i = 1; i <= requestCount; i++) {
        requestRow[i - 1].innerHTML = i
    }
}