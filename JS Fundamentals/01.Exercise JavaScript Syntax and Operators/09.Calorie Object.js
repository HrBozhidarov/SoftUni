function calorieObject(arr) {
    let obj={};
    for(let i = 0;i < arr.length; i += 2) {
        obj[arr[i]]=+arr[i+1];
    }

    console.log(obj);
}

calorieObject(['Yoghurt', 48, 'Rise', 138, 'Apple', 52])