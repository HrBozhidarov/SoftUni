function solve() {
    let firstMatrix = JSON.parse(document.getElementById('mat1').value);
    let secondMatrix = JSON.parse(document.getElementById('mat2').value);

    secondMatrix = secondMatrix[0].map((col, i) => secondMatrix.map(row => row[i]));

    let matrix = multiply(firstMatrix, secondMatrix);

    for (let matrixElement of matrix) {
        let p = document.createElement('p');
        p.textContent = matrixElement.join(', ');

        document.getElementById('result').appendChild(p);
    }

    function multiply(a, b) {
        let aNumRows = a.length;
        let aNumCols = a[0].length;
        let bNumCols = b[0].length;

        let m = [aNumRows];
        for (let r = 0; r < aNumRows; ++r) {
            m[r] = [bNumCols];
            for (let c = 0; c < bNumCols; ++c) {
                m[r][c] = 0;
                for (let i = 0; i < aNumCols; ++i) {
                    m[r][c] += a[r][i] * b[i][c];
                }
            }
        }
        return m;
    }
}