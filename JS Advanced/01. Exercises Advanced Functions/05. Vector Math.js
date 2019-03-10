let solution = (function () {
    return {
        add: function (v1, v2) {
            let sumV1 = v1[0] + v2[0];
            let sumV2 = v1[1] + v2[1];

            return [sumV1, sumV2];
        },
        multiply: function (v, scalar) {
            let mulA = v[0] * scalar;
            let mulB = v[1] * scalar;

            return [mulA, mulB];
        },
        length: function (v) {
            return Math.sqrt((v[0]*v[0]) + (v[1] * v[1]));
        },
        dot: function (v1, v2) {
            return (v1[0] * v2[0]) + (v1[1] * v2[1]);
        },
        cross: function (v1, v2) {
            return (v1[0] * v2[1]) - (v1[1] * v2[0]);
        }
    }
})();

console.log(solution.dot([2, 3], [2, -1]));