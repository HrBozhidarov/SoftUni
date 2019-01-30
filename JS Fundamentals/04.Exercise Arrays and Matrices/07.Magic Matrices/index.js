function solve(matrix) {
    console.log(matrixIsMagic());

    function matrixIsMagic() {
        let compareSum = 0;

        matrix[0].forEach(function (element) {
            compareSum += element;
        });

        for (let i = 0; i < matrix.length; i++) {
            let sumColmn = 0;
            let sumRow = 0;

            for (let j = 0; j < matrix[i].length; j++) {
                sumRow += matrix[i][j];
            }
            for (let j = 0; j < matrix.length; j++) {
                sumColmn += matrix[j][i];
            }

            if(compareSum !== sumRow || compareSum !== sumColmn) {
                return false;
            }
        }

        return true;
    }
}

solve([[1, 0, 0],[0, 0, 1],[0, 1, 0]]);