function solve(arrFromStrings) {
    let matrix = [];
    let inputLength = arrFromStrings.length;
    let newMatrix = [];

    for (let i = 0; i < inputLength; i++) {
        matrix[i] = [];
    }

    arrFromStrings.map((x, index) => matrix[index] = x.split(' ').map(x => +x));

    let firstDiagonalSum = 0;
    let secondDiagonalSum = 0;

    for (let row = 0; row < matrix.length; row++) {
        firstDiagonalSum += matrix[row][row];
        secondDiagonalSum += matrix[row][matrix.length - 1 - row];
        newMatrix[row] = [];
        newMatrix[row][row] = matrix[row][row];
        newMatrix[row][matrix.length - 1 - row] = matrix[row][matrix.length - 1 - row];
    }

    if (firstDiagonalSum !== secondDiagonalSum) {
        printResult(matrix);
    }
    else {
        for (let row = 0; row < newMatrix.length; row++) {
            for (let col = 0; col < newMatrix.length; col++) {
                if (row === col || row === newMatrix.length - 1 - col) {
                    continue;
                }

                newMatrix[row][col] = firstDiagonalSum;
            }
        }

        printResult(newMatrix);
    }

    function printResult(matrix) {
        for (let row = 0; row < matrix.length; row++) {
            console.log(matrix[row].join(' '));
        }
    }
}

//solve(['5 3 12 3 1', '11 4 23 2 5', '101 12 3 21 10', '1 4 5 2 2', '5 22 33 11 1']);
solve(['1 1 1', '1 1 1', '1 1 0']);