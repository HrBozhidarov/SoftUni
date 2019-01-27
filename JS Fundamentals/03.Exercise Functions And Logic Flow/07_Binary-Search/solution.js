function binarySearch() {
    let arr = document.getElementById('arr').value.split(', ').map(x => +x);
    let searchNumber = +document.getElementById('num').value;
    let result = document.getElementById('result');

    let index = binarySearch(arr,arr.length,searchNumber);

    if(arr[index] !== searchNumber) {
        result.textContent =`${searchNumber} is not in the array`;

        return;
    }

    result.textContent =`Found ${arr[index]} at index ${index}`;

    function binarySearch(arr,length,searchNumber) {
        let left = 0;
        let right = length;

        while(left < right) {
            let middle = Math.floor((left + right)/2);

            if(arr[middle] <= searchNumber) {
                left = middle + 1;
            }
            else {
                right = middle
            }
        }

        return left - 1;
    }
}