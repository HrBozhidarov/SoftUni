function solve() {
    let div = document.querySelector('#exercise div');
    div.style.position='absolute';

        setInterval(function () {
            console.log('asdas');
            let marginVertical = generateRandomNumber(1, 45);
            let marginHorizontal = generateRandomNumber(1, 81);
            div.style.top = marginVertical + 'VH';
            div.style.right = marginHorizontal + '%';
        },2000);


    function generateRandomNumber(min , max)
    {
        return Math.random() * (max - min) + min ;
    }
}