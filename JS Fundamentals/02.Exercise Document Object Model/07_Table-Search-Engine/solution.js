function solve() {
   document.getElementById('searchBtn').addEventListener('click',function (e) {
        let input = document.getElementById('searchField');
        let valueFromInput = input.value.toLowerCase();
        input.value = '';

       Array.from(document.querySelectorAll('tbody tr')).forEach(function (currentRow) {
         currentRow.removeAttribute('class');
       });

        if(!valueFromInput) {
            return;
        }

        Array.from(document.querySelectorAll('tbody tr')).forEach(function (currentRow) {
            let children = Array.from(currentRow.childNodes).forEach(function (child) {
                if(child.textContent.toLowerCase().includes(valueFromInput)) {
                    currentRow.setAttribute('class','select');
                }
            })
        })
   })
}