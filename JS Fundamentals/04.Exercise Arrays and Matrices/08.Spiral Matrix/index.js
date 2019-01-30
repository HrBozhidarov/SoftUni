function solve(firstDimension, secondDimension) {
    let maxRol = firstDimension;
    let maxCol = secondDimension;
    let minRow = 0;
    let minCol = 0;
    let maxNumber = maxRol * maxCol;
    let increaseNumber = 0;
    let count = 1;
    let matrix = [];

    for (let i = 0; i < maxRol; i++) {
        matrix[i] = [];
    }

    while (increaseNumber < maxNumber) {
        if (count === 1) {
            for (let col = minCol; col < maxCol; col++) {
                increaseNumber++;
                matrix[minRow][col] = increaseNumber;
            }

            minRow++;
        }
        else if (count === 2) {
            for (let row = minRow; row < maxRol; row++) {
                increaseNumber++;
                matrix[row][maxCol - 1] = increaseNumber;
            }

            maxCol--;
        }
        else if (count === 3) {
            for (let col = maxCol - 1; col >= minCol; col--) {
                increaseNumber++;
                matrix[maxRol - 1][col] = increaseNumber;
            }

            maxRol--;
        }
        else {
            for (let row = maxRol - 1; row >= minRow; row--) {
                increaseNumber++;
                matrix[row][minCol] = increaseNumber;
            }

            minCol++;
            count = 0;
        }

        count++;
    }

    for (let row = 0; row < matrix.length; row++) {
        console.log(matrix[row].join(' '));
    }
}

solve(5, 5);