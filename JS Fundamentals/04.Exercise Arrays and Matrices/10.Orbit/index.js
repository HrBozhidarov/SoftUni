function solve(arr) {
    let firstDimension = arr[0];
    let secondDimension = arr[1];
    let coordinateX = arr[2];
    let coordinateY = arr[3];
    let matrix = [];

    for (let i = 0; i < firstDimension; i++) {
        matrix[i] = [];
        for (let j = 0; j < secondDimension; j++) {
            let x = Math.abs(coordinateX - i);
            let y = Math.abs(coordinateY - j);

            matrix[i][j] = Math.max(x,y) + 1;
        }
    }

    matrix[coordinateX][coordinateY] = 1;

    matrix.forEach(function (element) {
        console.log(element.join(' '));
    })
}

solve([5, 5, 2, 2]);