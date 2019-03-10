function solve(arr, sortCriteria) {
    function ascending(a, b) {
        return a - b;
    }

    function descending(a, b) {
        return b - a;
    }

    let criteriaObj = {
        'asc': ascending,
        'desc': descending
    };

    return arr.sort(criteriaObj[sortCriteria]);
}

solve([14, 7, 17, 6, 8], 'asc');