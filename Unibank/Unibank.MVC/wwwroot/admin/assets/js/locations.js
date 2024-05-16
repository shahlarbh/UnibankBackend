// Show branchs
let branch_tabmenu = document.querySelectorAll('.atm a')
branch_tabmenu[0].classList.add('select_location')

for(let tabmenu of branch_tabmenu) {
    tabmenu.onclick = function(e) {
        e.preventDefault()
        let select_location = document.querySelector('.select_location')
        select_location.classList.remove('select_location')
        this.classList.add('select_location')

        let branchs = document.querySelectorAll('.branch')

        for(let branch of branchs) {
            let id = branch.getAttribute('data-id')

            if(id.includes(this.id)) {
                branch.classList.remove('d-none')
            }
            else{
                branch.classList.add('d-none')
            }
        }
    }
}

window.addEventListener('load', function () {
    branch_tabmenu[0].click()
})

// Birbirine aynı data-id değerine sahip elementleri kontrol et
function hideDuplicateBranches() {
    // Tüm branch elementlerini seç
    var branchElements = document.querySelectorAll('.branch');

    // Her bir branch elementi için işlem yap
    branchElements.forEach(function (branchElement) {
        // Şu anki branch elementinin data-id değerini al
        var dataId = branchElement.getAttribute('data-id');

        // Aynı data-id'ye sahip diğer branch elementleri
        var duplicateBranches = document.querySelectorAll('.branch[data-id="' + dataId + '"]');

        // Eğer birden fazla aynı data-id'ye sahip branch elementi varsa
        if (duplicateBranches.length > 1) {
            // İlk branch elementi dışında kalan tüm aynı data-id'ye sahip elementleri kontrol et
            for (var i = 1; i < duplicateBranches.length; i++) {
                var currentH1 = branchElement.querySelector('.branch_address h1');
                var duplicateH1 = duplicateBranches[i].querySelector('.branch_address h1');

                // Eğer h1 içeriği aynıysa, bu elementi gizle
                if (currentH1.textContent === duplicateH1.textContent) {
                    duplicateBranches[i].style.display = 'none';
                }
            }
        }
    });
}

// Sayfa yüklendiğinde işlemi başlat
window.addEventListener('DOMContentLoaded', hideDuplicateBranches);
